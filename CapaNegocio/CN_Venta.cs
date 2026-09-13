using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using iTextSharp.text;
using WindowsFormsApp1.DTO;
using iTextSharp.tool.xml.html.head;
using System.Threading;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Venta
    {
        public Dictionary<string, string> validacion;

        public CN_Venta()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public void GuardarVenta(Venta _venta, MiDbContext _context)
        {
            // El cliente se supone ya en existencia entonces necesitaremos enlazarlo
            ClienteDAO cliente = new ClienteDAO(_context);
            cliente.Attach_cliente(_venta.cliente);

            CajaDAO caja = new CajaDAO(_context);
            caja.Attach_caja(_venta.caja);

            VentaDAO venta = new VentaDAO(_context);
            venta.CrearVenta(_venta);
        }

        // Los parametros debemos modificarlo por el comportamiento del detalle.
        public async Task<int> RegistrarVentaAsync(Venta nuevaVenta)
        {
            // Valido los detalles de la venta?
            CN_Pago pago = new CN_Pago();
            CN_MovimientoCaja movimiento_caja = new CN_MovimientoCaja();
            CN_DetalleVenta detalle_venta = new CN_DetalleVenta();

            if (this.ValidadarVenta(nuevaVenta).Count > 0)
            {
                return 0;
            }

            // Cargo la venta en lo detalles y valido
            this.LoadVentaOnDetalles(nuevaVenta);

            if (detalle_venta.ValidarDetalles(nuevaVenta.detalles) != 1)
            {
                this.unirDiccionarios(detalle_venta.GetErrors());
                return 0;
            }

            // Cargo la venta en lo pagos y valido. Falta Attach del metodo
            if (nuevaVenta.monto_venta > decimal.Round(nuevaVenta.pagos.Sum(p => p.importe_pago), 2))
            {
                return 0;
            }
             
            if (pago.ValidarPagos(nuevaVenta.pagos) != 1)
            {
                this.unirDiccionarios(pago.GetErrors());
                return 0;
            }

            // Faltaria registrar el movimiento en caso de que haya vuelto.
            Movimiento_caja nuevoMovimiento = this.GenerarVueltoPago(nuevaVenta);
            
            if (nuevoMovimiento != null && movimiento_caja.ValidarMovimiento(nuevoMovimiento).Count > 0) 
            {
                this.unirDiccionarios(movimiento_caja.GetErrors());
                return 0;
            }

            // Bloque using tradicional (Sincrónico)
            using (var _context = new MiDbContext())
            {
                // Iniciar transacción de forma SINCRÓNICA (compatible con versiones viejas)
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {  
                        this.GuardarVenta(nuevaVenta, _context);

                        // Con el UPDATE condicionado conseguimos que el stock sea consultado al momento de la modificacion.

                        // 2.Ejecutamos el UPDATE atómico directamente en SQL
                        // Nota: Usamos parámetros para evitar SQL Injection y garantizar la seguridad
                        string sqlUpdate = @"
                            UPDATE Producto 
                            SET stock_producto = stock_producto - @cantidad 
                            WHERE id_producto = @productoId AND stock_producto >= @cantidad";

                        int filasAfectadas = 0;

                        // A continuacion, esto lo debemos iterar para cada producto en los diferentes detalles. 
                        foreach (Detalle_venta detalle in nuevaVenta.detalles)
                        {
                            filasAfectadas = await _context.Database.ExecuteSqlCommandAsync(
                            sqlUpdate,
                            new SqlParameter("@cantidad", detalle.cantidad_producto),
                            new SqlParameter("@productoId", detalle.id_producto)
                            );

                            if (filasAfectadas == 0)
                            {
                                return 0;
                            }

                            // Seria util nullear el producto asi evito posibles creates del SaveChanges? --> Al modificar una relación, la propiedad de clave externa correspondiente se establece en un valor nulo. --> Generaria Error (nullea id_producto).
                            // detalle.producto = null;

                            // Attach a pleno de producto.
                            ProductoDAO producto = new ProductoDAO(_context);
                            producto.AttachProducto(detalle.producto);
                        }

                        // Confirmo y hago attach de los metodos de pago?
                        pago.SetConfirmationPay(nuevaVenta.pagos);

                        pago.RegistrarPago(nuevaVenta.pagos, _context);

                        await _context.SaveChangesAsync();

                        nuevoMovimiento.descripcion_movimiento = nuevoMovimiento.descripcion_movimiento.Replace("#0", "#" + nuevaVenta.id_venta);
                        movimiento_caja.RegistrarMovimiento(nuevoMovimiento, _context);
                         
                        await _context.SaveChangesAsync();

                        // Confirmamos la transacción de forma SINCRÓNICA
                        transaction.Commit();
                        return 1;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Sincrónico
                        throw;
                    } 
                }
            }
        } 

        public Movimiento_caja GenerarVueltoPago(Venta nuevaVenta) 
        {
            CN_TipoMovimiento tipo = new CN_TipoMovimiento();
            Tipo_movimiento tipo_egreso = tipo.ObtenerTipo("Egreso");

            if(nuevaVenta.pagos.Sum(p => p.importe_pago) > nuevaVenta.monto_venta)
            {
                // Generamos el movimiento
                Movimiento_caja nuevoMovimiento = new Movimiento_caja();
                nuevoMovimiento.caja = nuevaVenta.caja;
                nuevoMovimiento.tipo_movimiento = tipo_egreso;
                nuevoMovimiento.monto_movimiento = nuevaVenta.pagos.Sum(p => p.importe_pago) - nuevaVenta.monto_venta;
                nuevoMovimiento.descripcion_movimiento = "Vuelto correspondiente a la Venta #" + nuevaVenta.id_venta + ".";
                nuevoMovimiento.fecha_movimiento = DateTime.Now;
                nuevoMovimiento.estado_movimiento = true; 

                return nuevoMovimiento;
            }

            // Y si no retornamos null 
            return null;
        }

        public void LoadVentaOnDetalles(Venta _venta)
        {
            foreach (Detalle_venta dv in _venta.detalles)
            {
                dv.venta = _venta;
            }
        }

        // Monto total de Ventas Acumuladas por Periodos.
        public List<ReporteVentaDTO> VentasPorDia(DateTime desde, DateTime hasta) 
        {
            List<Venta> ventas;

            if(desde < hasta) 
            {
                ventas = this.AllFilterVentas(desde, hasta);
            }
            else 
            {
                ventas = this.AllVentas();
            }

            List<ReporteVentaDTO> datos = ventas.GroupBy(v => v.fecha_venta.Date)
                              .Select(g => new ReporteVentaDTO
                              {
                                  fecha_acumulada = g.Key,
                                  monto_acumulado = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.fecha_acumulada)
                              .ToList();

            return datos;
        }

        public List<ReporteVentaDTO> VentasPorSemana(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentas(desde, hasta);
            }
            else
            {
                ventas = this.AllVentas();
            }

            List<ReporteVentaDTO> datos = ventas.GroupBy(v => {

                                    DateTime fecha = v.fecha_venta.Date;

                                    int diasDesdeLunes = (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;

                                    if (diasDesdeLunes < 0) diasDesdeLunes += 7;

                                    return fecha.AddDays(-diasDesdeLunes);
                              })
                              .Select(g => new ReporteVentaDTO
                              {
                                  fecha_acumulada = g.Key,                        // CultureInfo --> CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday = Indica que la primera semana de la año --> es la primera semana con cuatro o mas dias antes del primer dia de la semana asignado
                                  monto_acumulado = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.fecha_acumulada)
                              .ToList();

            return datos;
        }

        public List<ReporteVentaDTO> VentasPorMes(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentas(desde, hasta);
            }
            else
            {
                ventas = this.AllVentas();
            }

            List<ReporteVentaDTO> datos = ventas.GroupBy(v => new 
                             {
                                  Año = v.fecha_venta.Year,
                                  Mes = v.fecha_venta.Month
                              })
                              .Select(g => new ReporteVentaDTO
                              {
                                  fecha_acumulada = new DateTime(g.Key.Año, g.Key.Mes, 1),
                                  monto_acumulado = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.fecha_acumulada)
                              .ToList();

            return datos;
        }

        public List<ReporteVentaDTO> VentasPorTrimestre(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentas(desde, hasta);
            }
            else
            {
                ventas = this.AllVentas();
            }

            List<ReporteVentaDTO> datos = ventas.GroupBy(v => {

                                    DateTime fecha = v.fecha_venta.Date;

                                    int trimestre = ((fecha.Month - 1) / 3) * 3 + 1;

                                    return new DateTime(fecha.Year, trimestre, 1);
                              })
                              .Select(g => new ReporteVentaDTO
                              {
                                  fecha_acumulada = g.Key,                        // CultureInfo --> CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday = Indica que la primera semana de la año --> es la primera semana con cuatro o mas dias antes del primer dia de la semana asignado
                                  monto_acumulado = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.fecha_acumulada)
                              .ToList();
            
            return datos;
        }

        public List<ReporteVentaDTO> VentasPorSemestre(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentas(desde, hasta);
            }
            else
            {
                ventas = this.AllVentas();
            }

            List<ReporteVentaDTO> datos = ventas.GroupBy(v => {

                                    DateTime fecha = v.fecha_venta.Date;

                                    int semestre = ((fecha.Month - 1) / 6) * 6 + 1;

                                    return new DateTime(fecha.Year, semestre, 1);
                              })
                              .Select(g => new ReporteVentaDTO
                              {
                                  fecha_acumulada = g.Key,                        // CultureInfo --> CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday = Indica que la primera semana de la año --> es la primera semana con cuatro o mas dias antes del primer dia de la semana asignado
                                  monto_acumulado = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.fecha_acumulada)
                              .ToList();

            return datos;
        }

        public List<ReporteVentaDTO> VentasPorAño(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentas(desde, hasta);
            }
            else
            {
                ventas = this.AllVentas();
            }

            List<ReporteVentaDTO> datos = ventas.GroupBy(v => new {
                                    Año = v.fecha_venta.Year,
                              })
                              .Select(g => new ReporteVentaDTO
                              {
                                  fecha_acumulada = new DateTime(g.Key.Año, 1, 1),
                                  monto_acumulado = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.fecha_acumulada)
                              .ToList();

            return datos;
        }

        // Monto de ventas acumulados por Empleado y Periodo
        public List<ReporteVentaEmpleadoDTO> VentasDiarioEmpleado(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentasEmpleado(desde, hasta);
            }
            else
            {
                ventas = this.AllVentasEmpleado();
            }

            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => new {
                                    Fecha = v.fecha_venta.Date, 
                                    Empleado = v.caja.id_usuario 
                              })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = g.Key.Fecha,
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.periodo)
                              .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaEmpleadoDTO>> VentasPeriodoDiarioEmpleadoAsync(DateTime desde, DateTime hasta, CancellationToken token) 
        { 
            List<Venta> ventas = await this.AllFilterPeriodoEmpleado(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;
             
            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => new {
                                    Fecha = v.fecha_venta.Date,
                                    Empleado = v.caja.id_usuario
                              })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = g.Key.Fecha,
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.monto_total)
                              .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaEmpleadoDTO>> VentasPeriodoSemanalEmpleadoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoEmpleado(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => {
                                    DateTime fecha = v.fecha_venta.Date;

                                    int diasDesdeLunes =
                                        (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;

                                    if (diasDesdeLunes < 0)
                                        diasDesdeLunes += 7;

                                    return new
                                    {
                                        Periodo = fecha.AddDays(-diasDesdeLunes),
                                        Empleado = v.caja.id_usuario
                                    };
                              })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = g.Key.Periodo,
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.monto_total)
                              .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaEmpleadoDTO>> VentasPeriodoMensualEmpleadoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoEmpleado(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => new
                              {
                                    Año = v.fecha_venta.Year,
                                    Mes = v.fecha_venta.Month,
                                    Empleado = v.caja.id_usuario
                              })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = new DateTime(g.Key.Año, g.Key.Mes, 1),
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.monto_total)
                              .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaEmpleadoDTO>> VentasPeriodoTrimestralEmpleadoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoEmpleado(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => {

                                    DateTime fecha = v.fecha_venta.Date;

                                    int trimestre = ((fecha.Month - 1) / 3) * 3 + 1;

                                    return new
                                    {
                                        Periodo = new DateTime(fecha.Year, trimestre, 1),
                                        Empleado = v.caja.id_usuario
                                    };
                               })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = g.Key.Periodo,
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.monto_total)
                              .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaEmpleadoDTO>> VentasPeriodoSemestralEmpleadoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoEmpleado(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => {

                                    DateTime fecha = v.fecha_venta.Date;

                                    int semestre = ((fecha.Month - 1) / 6) * 6 + 1;

                                    return new
                                    {
                                        Periodo = new DateTime(fecha.Year, semestre, 1),
                                        Empleado = v.caja.id_usuario
                                    };
                              })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = g.Key.Periodo,
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.monto_total)
                              .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaEmpleadoDTO>> VentasPeriodoAnualEmpleadoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoEmpleado(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            List<ReporteVentaEmpleadoDTO> datos = ventas.GroupBy(v => new {
                                    Año = v.fecha_venta.Year,
                                    Empleado = v.caja.id_usuario
                              })
                              .Select(g => new ReporteVentaEmpleadoDTO
                              {
                                  nombreCompleto_empleado = g.First().caja.usuario.empleado.nombreCompleto_empleado,
                                  periodo = new DateTime(g.Key.Año, 1, 1),
                                  cantidad_ventas = g.Count(),
                                  monto_promedio = g.Average(v => v.monto_venta),
                                  monto_total = g.Sum(v => v.monto_venta)
                              })
                              .OrderBy(v => v.monto_total)
                              .ToList();

            return datos;
        }

        // Monto de ventas acumulados por Empleado y Periodo
        public List<ReporteVentaProductoDTO> VentasDiarioProducto(DateTime desde, DateTime hasta)
        {
            List<Venta> ventas;

            if (desde < hasta)
            {
                ventas = this.AllFilterVentasProducto(desde, hasta);
            }
            else
            {
                ventas = this.AllVentasProducto();
            }
  
            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(x => x.Periodo)
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            // Parte dos obtengo todas los producto vendidos en periodo (diario)
            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            IdVenta = v.id_venta,
                                                            Fecha = v.fecha_venta.Date,
                                                            Producto = d.producto,
                                                            Cantidad = d.cantidad_producto,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(x => new
                                                {
                                                    Periodo = x.Fecha,
                                                    Producto = x.Producto.id_producto
                                                })
                                                .Select(g => new ReporteVentaProductoDTO
                                                {
                                                    id_venta = g.First().IdVenta,
                                                    producto_completo = g.First().Producto.producto_completo,
                                                    periodo = g.Key.Periodo,
                                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                                    importe_vendido = g.Sum(x => x.Subtotal),
                                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100 / totalesPeriodo[g.Key.Periodo]), 2)
                                                })
                                                .OrderBy(v => v.periodo)
                                                .ToList();

            return datos;
        }

        // ----------

        public async Task<List<ReporteVentaProductoDTO>> VentasPeriodoDiarioProductoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoProducto(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            // Parte uno agrupo por periodo para obtener las ventas totales del mismo y poder determinar el porcentaje luego.
            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(x => x.Periodo)
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            // Parte dos obtengo todas los producto vendidos en periodo (diario)
            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Fecha = v.fecha_venta.Date,
                                                            Producto = d.producto,
                                                            Cantidad = d.cantidad_producto,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(x => new
                                                {
                                                    Periodo = x.Fecha,
                                                    Producto = x.Producto.id_producto
                                                })
                                                .Select(g => new ReporteVentaProductoDTO
                                                {
                                                    producto_completo = g.First().Producto.producto_completo,
                                                    periodo = g.Key.Periodo,
                                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                                    importe_vendido = g.Sum(x => x.Subtotal),
                                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100 / totalesPeriodo[g.Key.Periodo]), 2)
                                                })
                                                .OrderBy(v => v.periodo)
                                                .ToList();
            
            return datos;
        }

        public async Task<List<ReporteVentaProductoDTO>> VentasPeriodoSemanalProductoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoProducto(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(v => {
                                                    DateTime fecha = v.Periodo;

                                                    int diasDesdeLunes =
                                                        (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;

                                                    if (diasDesdeLunes < 0)
                                                        diasDesdeLunes += 7;

                                                    return new
                                                    {
                                                        Periodo = fecha.AddDays(-diasDesdeLunes),
                                                    };
                                                })
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Fecha = v.fecha_venta.Date,
                                                            Producto = d.producto,
                                                            Cantidad = d.cantidad_producto,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(v => {
                                                    DateTime fecha = v.Fecha;

                                                    int diasDesdeLunes =
                                                        (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;

                                                    if (diasDesdeLunes < 0)
                                                        diasDesdeLunes += 7;

                                                    return new
                                                    {
                                                        Periodo = fecha.AddDays(-diasDesdeLunes),
                                                        Producto = v.Producto.id_producto
                                                    };
                                                })
                                                .Select(g => new ReporteVentaProductoDTO
                                                {
                                                    producto_completo = g.First().Producto.producto_completo,
                                                    periodo = g.Key.Periodo,
                                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                                    importe_vendido = g.Sum(x => x.Subtotal),
                                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100 / totalesPeriodo[new {g.Key.Periodo} ]), 2)
                                                })         
                                                .OrderBy(v => v.periodo)
                                                .ToList();                                 

            return datos;
        }

        public async Task<List<ReporteVentaProductoDTO>> VentasPeriodoMensualProductoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoProducto(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;
            
            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(v => new
                                                    {
                                                        Año = v.Periodo.Year,
                                                        Mes = v.Periodo.Month,
                                                    }
                                                )
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new
                                                {
                                                    Fecha = v.fecha_venta.Date,
                                                    Producto = d.producto,
                                                    Cantidad = d.cantidad_producto,
                                                    Subtotal = d.subtotal
                                                }
                                        )
                                )
                                .GroupBy(v => new
                                {
                                    Año = v.Fecha.Year,
                                    Mes = v.Fecha.Month,
                                    Producto = v.Producto.id_producto          // Producto vacio                      
                                })
                                .Select(g => new ReporteVentaProductoDTO
                                {
                                    producto_completo = g.First().Producto.producto_completo,
                                    periodo = new DateTime(g.Key.Año, g.Key.Mes, 1),
                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                    importe_vendido = g.Sum(x => x.Subtotal),
                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100) / totalesPeriodo[new { g.Key.Año, g.Key.Mes}], 2),
                                })
                                .OrderBy(v => v.periodo)
                                .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaProductoDTO>> VentasPeriodoTrimestralProductoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoProducto(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(v => {

                                                    DateTime fecha = v.Periodo;

                                                    int trimestre = ((fecha.Month - 1) / 3) * 3 + 1;

                                                    return new
                                                    {
                                                        Periodo = new DateTime(fecha.Year, trimestre, 1),
                                                    };
                                                })
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new
                                            {
                                                Fecha = v.fecha_venta.Date,
                                                Producto = d.producto,
                                                Cantidad = d.cantidad_producto,
                                                Subtotal = d.subtotal
                                            }
                                        )
                                )
                                .GroupBy(v => 
                                {

                                    DateTime fecha = v.Fecha;

                                    int trimestre = ((fecha.Month - 1) / 3) * 3 + 1;

                                    return new
                                    {
                                        Periodo = new DateTime(fecha.Year, trimestre, 1),
                                        Producto = v.Producto.id_producto
                                    };
                                })
                                .Select(g => new ReporteVentaProductoDTO
                                {
                                    producto_completo = g.First().Producto.producto_completo,
                                    periodo = g.Key.Periodo,
                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                    importe_vendido = g.Sum(x => x.Subtotal),
                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100) / totalesPeriodo[new {g.Key.Periodo}], 2),
                                })
                                .OrderBy(v => v.periodo)
                                .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaProductoDTO>> VentasPeriodoSemestralProductoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoProducto(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(v => {
                                                    DateTime fecha = v.Periodo;

                                                    int semestre = ((fecha.Month - 1) / 6) * 6 + 1;

                                                    return new
                                                    {
                                                        Periodo = new DateTime(fecha.Year, semestre, 1),
                                                    };
                                                })
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new
                                            {
                                                Fecha = v.fecha_venta.Date,
                                                Producto = d.producto,
                                                Cantidad = d.cantidad_producto,
                                                Subtotal = d.subtotal
                                            }
                                        )
                                )
                                .GroupBy(v => 
                                {

                                    DateTime fecha = v.Fecha;

                                    int semestre = ((fecha.Month - 1) / 6) * 6 + 1;

                                    return new
                                    {
                                        Periodo = new DateTime(fecha.Year, semestre, 1),
                                        Producto = v.Producto.id_producto
                                    };
                                })
                                .Select(g => new ReporteVentaProductoDTO
                                {
                                    producto_completo = g.First().Producto.producto_completo,
                                    periodo = g.Key.Periodo,
                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                    importe_vendido = g.Sum(x => x.Subtotal),
                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100) / totalesPeriodo[new { g.Key.Periodo}], 2),
                                })
                                .OrderBy(v => v.periodo)
                                .ToList();

            return datos;
        }

        public async Task<List<ReporteVentaProductoDTO>> VentasPeriodoAnualProductoAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            List<Venta> ventas = await this.AllFilterPeriodoProducto(desde, hasta, token);

            if (ventas == null || ventas.Count == 0) return null;

            var totalesPeriodo = ventas.SelectMany(v => v.detalles.Select(d => new
                                                        {
                                                            Periodo = v.fecha_venta.Date,
                                                            Subtotal = d.subtotal
                                                        }
                                                    )
                                                )
                                                .GroupBy(v => new {
                                                    Año = v.Periodo.Year
                                                })
                                                .ToDictionary(
                                                                g => g.Key,
                                                                g => g.Sum(x => x.Subtotal)
                                                );

            List<ReporteVentaProductoDTO> datos = ventas.SelectMany(v => v.detalles.Select(d => new 
                                    { 
                                        Fecha = v.fecha_venta.Date, 
                                        Producto = d.producto,
                                        Cantidad = d.cantidad_producto, 
                                        Subtotal = d.subtotal 
                                    }
                                ))
                                .GroupBy(v => new 
                                    {
                                        Año = v.Fecha.Year,
                                        Producto = v.Producto.id_producto
                                    }
                                )
                                .Select(g => new ReporteVentaProductoDTO
                                {
                                    producto_completo = g.First().Producto.producto_completo,
                                    periodo = new DateTime(g.Key.Año, 1,  1),
                                    cantidad_vendida = g.Sum(x => x.Cantidad),
                                    importe_vendido = g.Sum(x => x.Subtotal),
                                    // porcentaje_venta_importe = (g.Sum(x => x.Detalle.subtotal) * 100) / ventas.Sum(v => v.monto_venta)

                                    porcentaje_venta_importe = decimal.Round((g.Sum(x => x.Subtotal) * 100) / totalesPeriodo[new { g.Key.Año}], 2),
                                })
                              .OrderBy(v => v.periodo)
                              .ToList();

            return datos;
        }


        // Validaciones y manejo del diccionario.
        public Dictionary<string, string> ValidadarVenta(Venta _venta)
        {
            this.validacion.Clear();

            // Validamos los campos y las entidades necesarias
            this.ValidarCliente(_venta.cliente);
            this.ValidarCaja(_venta.caja);
            this.ValidarFechaVenta(_venta.fecha_venta);
            this.ValidarMontoVenta(_venta.monto_venta);

            return this.validacion;
        }

        public void ValidarCliente(Cliente _cliente)
        {
            if (_cliente == null)
            {
                this.validacion.Add("Cliente", "Es necesario asociar un cliente a la venta."); //this.validacion.Add("", "")
            }
        }

        public void ValidarCaja(Caja _caja)
        {
            // Podriamos tambien hacer algunas comprobaciones extras , como por ejemplo: si existe en la BD dicha caja y si dicha caja se encuentra abierta ..

            if (_caja == null)
            {
                this.validacion.Add("Caja", "Es necesario asociar una caja a la venta."); //this.validacion.Add("", "")
            }
        }

        public void ValidarFechaVenta(DateTime _fecha)
        {
            if (_fecha == null)
            {
                this.validacion.Add("Fecha_venta", "Es necesario ingresar un fecha de venta."); //this.validacion.Add("", "")
            }
        }

        public void ValidarMontoVenta(decimal _importe)
        {
            if (_importe <= 0)
            {
                this.validacion.Add("Monto_venta", "El importe final de la venta debe ser mayor a cero.");
            }
            else if (decimal.Round(_importe, 2) != _importe)
            {
                this.validacion.Add("Monto_venta", "El importe final de la venta debe tener a lo sumo dos decimales.");
            }
        }

        public void ValidarDetalles(ICollection<Detalle_venta> _detalles)
        {
            if (_detalles == null || _detalles.Count == 0)
            {
                this.validacion.Add("Detalles_venta", "La venta no genero los detalles correspondientes");
            }
        }

        public List<Venta> AllVentas() 
        {
            using (var context = new MiDbContext()) 
            {
                VentaDAO venta = new VentaDAO(context);
                return venta.GetAllVentas();
            }
        }

        public List<Venta> AllFilterVentas(DateTime desde, DateTime hasta)
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return venta.GetAllFilterVentas(desde, hasta);
            }
        }

        // Para empleado y ventas
        public List<Venta> AllVentasEmpleado()
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return venta.GetAllVentasEmpleado();
            }
        }

        public List<Venta> AllFilterVentasEmpleado(DateTime desde, DateTime hasta)
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return venta.GetAllFilterVentasEmpleado(desde, hasta);
            }
        }

        public async Task<List<Venta>> AllFilterPeriodoEmpleado(DateTime desde, DateTime hasta, CancellationToken token)
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return await venta.GetAllFilterPeriodoEmpleado(desde, hasta, token);
            }
        }

        // ----- Para productos y ventas
        public List<Venta> AllVentasProducto()
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return venta.GetAllVentasProducto();
            }
        }

        public List<Venta> AllFilterVentasProducto(DateTime desde, DateTime hasta)
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return venta.GetAllFilterVentasProducto(desde, hasta);
            }
        }

        public async Task<List<Venta>> AllFilterPeriodoProducto(DateTime desde, DateTime hasta, CancellationToken token)
        {
            using (var context = new MiDbContext())
            {
                VentaDAO venta = new VentaDAO(context);
                return await venta.GetAllFilterPeriodoProducto(desde, hasta, token);
            }
        }

        // -------

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }

        public Dictionary<string, string> unirDiccionarios(Dictionary<string, string> _diccionario)
        {
            if (_diccionario != null)
            {
                foreach (var error in _diccionario)
                {
                    validacion[error.Key] = error.Value; // Agrega o actualiza
                }
            }

            return validacion;
        }


    }

}
