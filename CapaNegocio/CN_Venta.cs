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
