using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Compra
    {

        private Dictionary<string, string> validacion;

        public CN_Compra()
        {
            this.validacion = new Dictionary<string, string>();
        }
         
        public int RegistrarCompra(Compra nuevaCompra)
        { 
            CN_EstadoCompra estado = new CN_EstadoCompra();
            Estado_compra estadoCompra = estado.ObternerEstadoPendiente();

            // Inicializamos la compra con el proveedor. 
            nuevaCompra.fecha_confirmacion = null; 
            nuevaCompra.estado = estadoCompra;

            CN_DetalleCompra detalle = new CN_DetalleCompra();
            detalle.SetCompra(nuevaCompra);

            detalle.ValidarDetalles(nuevaCompra.detalles_compra); 
            this.ValidarCompra(nuevaCompra);
            this.validacion = this.unirDiccionarios(detalle.GetErrors());
            
            if (this.validacion.Count == 0)        
            {  
                return this.GuardarCompra(nuevaCompra); 
            }
            else 
            {
                return 0;
            } 
        }

        public int GuardarCompra(Compra _compra)
        {
            using (var context = new MiDbContext())
            {
                // Esto va a ir en el Dao Directamente.
                CN_Producto producto = new CN_Producto();
                producto.AttachProductosDetalles(_compra.detalles_compra, context); // Esto es para avisarle al EF que los productos ya estan en la BD. 

                CN_Proveedor proveedor = new CN_Proveedor();
                proveedor.AttachProveedor(_compra.proveedor, context);

                CN_EstadoCompra estado = new CN_EstadoCompra();
                estado.AttachEstado(_compra.estado, context);

                // Ejecutamos si el pedido supera la validacion. 
                CompraDAO compraDAO = new CompraDAO(context);
                compraDAO.Crear_compra(_compra); // Retornar el ID del pedido.
                return context.SaveChanges();
            }
        }
         
        public int ImpactarCompra(Compra _compra)
        {
            using (var context = new MiDbContext())
            {
                this.AttachCompra(_compra, context);
                int confirmado = this.ConfirmarCompra(_compra);

                CN_EstadoCompra estado = new CN_EstadoCompra();
                estado.AttachEstado(_compra.estado, context);

                CN_Producto producto = new CN_Producto();
                producto.AttachProductosDetalles(_compra.detalles_compra, context); 
                producto.ImpactarCompraProductos(_compra.detalles_compra, context); 
                 
                if (producto.GetErrors().Count == 0 && confirmado != 0) 
                { 
                    // Ejecutamos si el pedido supera la validacion. 
                    CompraDAO compraDAO = new CompraDAO(context); 
                    compraDAO.update_Compra(_compra); // Retornar el ID del pedido. w
                     
                    return context.SaveChanges(); 
                } 
                 
                return 0;   
            }
        } 

        public int ConfirmarCompra(Compra compraConfirmar)
        {
            CN_EstadoCompra estado = new CN_EstadoCompra();
            Estado_compra estadoCompra = estado.ObternerEstadoPendiente();
            Estado_compra estadoNuevo = estado.ObternerEstadoConfirmado();

            if (compraConfirmar == null)
            {
                return 0;
            }

            if (compraConfirmar.estado_compra != estadoCompra.id_estado)
            {
                return 0;
            }

            compraConfirmar.fecha_confirmacion = DateTime.Now.Date;
            compraConfirmar.estado_compra = estadoNuevo.id_estado;
            compraConfirmar.estado = estadoNuevo;

            this.ValidarCompra(compraConfirmar);

            if (this.GetErrors().Count == 0) return 1;

            return 0;
        }
 
        public void AttachCompra(Compra _compra, MiDbContext context) 
        {
            CompraDAO compra = new CompraDAO(context); 
            compra.Attach_compra(_compra);
        }

        public decimal CalcularMontoTotal(ICollection<Detalle_compra> detalles)
        {
            decimal total = 0;

            if (detalles.Count == 0) return 0;

            foreach (Detalle_compra detalle in detalles) 
            {    
                total = total + detalle.subtotal_producto;
            }

            return total;
        }
          
        // Validaciones
        public void ValidarCompra(Compra _compra)
        {
            this.validacion.Clear();

            this.validarProveedor(_compra.proveedor);
            this.validarFechaEmision(_compra.fecha_emision);
            this.validarFechaConfirmacion(_compra);
            this.validarMonto(_compra.monto_total);
            this.validarEstado(_compra.estado);
        }

        public void validarProveedor(Proveedor proveedor_verificar)
        { 
            if(proveedor_verificar == null) 
            {
                this.validacion.Add("Compra", "La compra no tiene asignado un proveedor."); 
            } 
        }

        public void validarFechaEmision(DateTime _fecha)
        {
            if (_fecha == null)
            {
                this.validacion.Add("Compra", "Se debe indicar uan fecha de emision de la compra.");
            }

        }

        public void validarFechaConfirmacion(Compra compra)
        {
            if (compra.fecha_confirmacion != null)
            {
                if(compra.fecha_confirmacion < compra.fecha_emision) 
                { 
                    this.validacion.Add("Compra", "Se esta intentando ingresar una fecha de confimracion anterior a la fecha de emision.");
                }
            }

        }

        public void validarMonto(decimal _monto)
        {
            if (_monto <= 0)
            {
                this.validacion.Add("Compra", "El campo Monto debe ser mayor a cero");
            }
            else if (decimal.Round(_monto, 2) != _monto)
            {
                this.validacion.Add("Compra", "El campo Monto solo acepta valores con hasta dos decimales");
            }
        }

        public void validarEstado(Estado_compra estado_verificar)
        {
            if (estado_verificar == null)
            {
                this.validacion.Add("Compra", "La compra no tiene asignado un estado."); 
            } 
        }

        // Manejo de errores.
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

        // Consultas
        public List<Compra> ComprasPendientes()
        {
            using (var context = new MiDbContext())
            {
                CompraDAO pendientes = new CompraDAO(context);
                return pendientes.ReadPedidosPendientes();
            }
        }

        public List<Compra> ComprasConfirmadas()
        {
            using (var context = new MiDbContext())
            {
                CompraDAO pendientes = new CompraDAO(context);
                return pendientes.ReadPedidosConfirmados();
            }
        }

        public async Task<List<Compra>> BusquedaAsync_compraPendiente(CancellationToken _ct, string buscado)
        {
            using (var context = new MiDbContext())
            {
                CompraDAO compra = new CompraDAO(context);
                return await compra.GetComprasAsync(_ct, buscado, 2); 
            }
        }

        public async Task<List<Compra>> BusquedaAsync_compraConfirmada(CancellationToken _ct, string buscado)
        {
            using (var context = new MiDbContext())
            {
                CompraDAO compra = new CompraDAO(context);
                return await compra.GetComprasAsync(_ct, buscado, 3);
            }
        }

        public void CancelarPedido(int id_pedido) 
        {
            using (var context = new MiDbContext()) 
            {
                CompraDAO pedido = new CompraDAO(context);
                pedido.update_StateInactive(id_pedido);
                context.SaveChanges();
            } 
        }

        public Compra BuscarCompra(int id_compra)
        {
            using (var context = new MiDbContext()) 
            {
                CompraDAO pedido = new CompraDAO(context);
                return pedido.buscarCompra(id_compra);
            } 
        }

        public IQueryable<Compra> ComprasFilter(DateTime desde, DateTime hasta, MiDbContext _dbContext)
        {
            CompraDAO compra = new CompraDAO(_dbContext);
            return compra.GetComprasFilter(desde, hasta);
        }

        public IQueryable<Compra> GetAllComprasConfirmadas(MiDbContext _dbContext)
        {
            CompraDAO compra = new CompraDAO(_dbContext);
            return compra.AllComprasConfirmadas();
        }

        // Implementamos el comportamiento para reportes.
        public List<ReporteComprasDTO> ComprasConfirmadasPorMes(DateTime desde, DateTime hasta)
        {
            IQueryable<Compra> compras; 

            List<ReporteComprasDTO> datos = new List<ReporteComprasDTO>();

            using (var context = new MiDbContext()) 
            { 
                if (desde < hasta)
                {
                    compras = this.ComprasFilter(desde, hasta, context);
                }
                else
                {
                    compras = this.GetAllComprasConfirmadas(context);
                }

                datos = this.ReportesAgrupadosMensual(compras);
            }

            return datos;
        }

        public List<ReporteComprasDTO> ComprasConfirmadasPorTrimestre(DateTime desde, DateTime hasta)
        {
            IQueryable<Compra> compras;

            List<ReporteComprasDTO> datos = new List<ReporteComprasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    compras = this.ComprasFilter(desde, hasta, context);
                }
                else
                {
                    compras = this.GetAllComprasConfirmadas(context);
                }

                datos = this.ReportesAgrupadosTrimestre(compras);
            }

            return datos;
        }

        public List<ReporteComprasDTO> ComprasConfirmadasPorSemestre(DateTime desde, DateTime hasta)
        {
            IQueryable<Compra> compras;

            List<ReporteComprasDTO> datos = new List<ReporteComprasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    compras = this.ComprasFilter(desde, hasta, context);
                }
                else
                {
                    compras = this.GetAllComprasConfirmadas(context);
                }

                datos = this.ReportesAgrupadosSemestre(compras);
            }

            return datos;
        }

        public List<ReporteComprasDTO> ComprasConfirmadasPorAño(DateTime desde, DateTime hasta)
        {
            IQueryable<Compra> compras;

            List<ReporteComprasDTO> datos = new List<ReporteComprasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    compras = this.ComprasFilter(desde, hasta, context);
                }
                else
                {
                    compras = this.GetAllComprasConfirmadas(context);
                }

                datos = this.ReportesAgrupadosAnual(compras);
            }

            return datos;
        }

        public List<ReporteComprasDTO> ReportesAgrupadosMensual(IQueryable<Compra> _compras)
        {
            List<ReporteComprasDTO> resultado = new List<ReporteComprasDTO>();

            if (_compras != null)
            {
                // PASO 1: Agrupamos y proyectamos a un objeto temporal. 
                // Todo esto se traduce a un SQL perfecto y ultra rápido.
                var datosDesdeBD = _compras
                .GroupBy(c => new
                    {
                        Año = c.fecha_confirmacion.Value.Year,
                        Mes = c.fecha_confirmacion.Value.Month
                    }
                )
                .Select(g => new
                    {
                        Año = g.Key.Año,
                        Mes = g.Key.Mes,
                        Monto = g.Sum(v => v.monto_total)
                    }
                )
                .OrderBy(v => v.Año).ThenBy(v => v.Mes)
                .ToList();

                // PASO 2: Ahora que los datos están en la memoria RAM, 
                // C# sí puede usar el constructor de DateTime perfectamente.
                resultado = datosDesdeBD
                .Select(x => new ReporteComprasDTO
                {
                    periodo_reportado = new DateTime(x.Año, x.Mes, 1),
                    monto_acumulado = x.Monto
                }
                )
                .ToList();
                
            }
            
            return resultado;
        }

        public List<ReporteComprasDTO> ReportesAgrupadosTrimestre(IQueryable<Compra> _compras)
        {
            List<ReporteComprasDTO> resultado = new List<ReporteComprasDTO>();

            if (_compras != null)
            {
                var datosDesdeBD = _compras.GroupBy(c => new
                    {
                        Año = c.fecha_confirmacion.Value.Year,
                        Mes = ((c.fecha_confirmacion.Value.Month - 1) / 3) * 3 + 1,
                    }
                )
                .Select(g => new
                    {
                        Año = g.Key.Año,
                        Mes = g.Key.Mes,
                        Monto = g.Sum(v => v.monto_total)
                    }
                )
                .OrderBy(v => v.Año).ThenBy(v => v.Mes)
                .ToList();

                resultado = datosDesdeBD
                .Select(x => new ReporteComprasDTO
                    {
                        periodo_reportado = new DateTime(x.Año, x.Mes, 1),
                        monto_acumulado = x.Monto
                    }
                )
                .ToList();

            }
        
            return resultado;

        }

        public List<ReporteComprasDTO> ReportesAgrupadosSemestre(IQueryable<Compra> _compras)
        {
            List<ReporteComprasDTO> resultado = new List<ReporteComprasDTO>();

            if (_compras != null)
            {
                var datosDeseBD = _compras.GroupBy(c => new
                    {
                        Año = c.fecha_confirmacion.Value.Year,
                        Mes = ((c.fecha_confirmacion.Value.Month - 1) / 6) * 6 + 1,
                    }
                )
                .Select(g => new
                    {
                        Año = g.Key.Año,
                        Mes = g.Key.Mes,
                        Monto = g.Sum(v => v.monto_total)
                    }
                )
                .OrderBy(v => v.Año).ThenBy(v => v.Mes)
                .ToList();

                resultado = datosDeseBD 
                .Select(g => new ReporteComprasDTO
                    {
                        periodo_reportado = new DateTime(g.Año, g.Mes, 1),
                        monto_acumulado = g.Monto   
                    }
                )
                .OrderBy(v => v.periodo_reportado)
                .ToList();
            }

            return resultado;
        }

        public List<ReporteComprasDTO> ReportesAgrupadosAnual(IQueryable<Compra> _compras)
        {
            List<ReporteComprasDTO> resultado = new List<ReporteComprasDTO>();

            if (_compras != null)
            {
                var datosDesdeBD = _compras.GroupBy(c => new
                    {
                       Año = c.fecha_confirmacion.Value.Year
                    }
                )
                .Select(g => new 
                    {
                        Año = g.Key.Año,
                        Monto = g.Sum(v => v.monto_total)
                    }
                )
                .OrderBy(v => v.Año)
                .ToList();

                resultado = datosDesdeBD
                .Select(g => new ReporteComprasDTO
                    {
                        periodo_reportado = new DateTime(g.Año, 1, 1),
                        monto_acumulado = g.Monto
                    }
                )
                .OrderBy(v => v.periodo_reportado)
                .ToList();
            }

            return resultado;
        }
    }
}
