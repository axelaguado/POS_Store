using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.CapaPresentacion;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_DetalleVenta
    {
        public Dictionary<string, string> validacion;

        public CN_DetalleVenta()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public Dictionary<string, string> ValidarDetalle(Detalle_venta detalle) 
        { 
            this.validacion.Clear();

            this.ValidarProducto(detalle.producto);
            this.ValidarCantidad(detalle.cantidad_producto);
            this.ValidarSubtotal(detalle.precio_unitario);
            this.ValidarSubtotal(detalle.subtotal);
            this.ValidarVenta(detalle.venta);

            return this.validacion; 
        }

        public void ValidarVenta(Venta _venta)
        {
            if (_venta == null)
            {
                this.validacion.Add("Venta", "El detalle de venta no tiene una venta asociada.");
            }
        }

        public void ValidarProducto(Producto _producto)
        {
            if (_producto == null) 
            {
                this.validacion.Add("Producto", "El detalle de venta no tiene un producto asociado.");
            }
        }

        public void ValidarCantidad(int cantidad)
        {
            if (cantidad <= 0) 
            {
                this.validacion.Add("Cantidad", "La cantidad de productos solicitados debe ser superior a cero.");
            } 
        }

        public void ValidarPrecioUnitario(decimal _precio)
        {
            if (_precio <= 0)
            {
                this.validacion.Add("Precio Unitario", "El precio debe ser mayor a cero.");
            }
            else if (decimal.Round(_precio, 2) != _precio)
            {
                this.validacion.Add("Precio Unitario", "El precio debe tener a lo sumo dos decimales.");
            }
        }

        public void ValidarSubtotal(decimal _subtotal)
        {
            if (_subtotal <= 0)
            {
                this.validacion.Add("Subtotal", "El importe de pago debe ser mayor a cero.");
            }
            else if (decimal.Round(_subtotal, 2) != _subtotal)
            {
                this.validacion.Add("Subtotal", "El importe de pago debe tener a lo sumo dos decimales.");
            }
        }

        public int ValidarDetalles(ICollection<Detalle_venta> _detalles)
        {
            foreach (Detalle_venta item in _detalles)
            {
                this.ValidarDetalle(item);
                if (this.validacion.Count > 0)
                {
                    return -1;
                }
            }

            return 1;
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }

        // Metodos de consulta para trabajar con el reporte de ganancias.
        public IQueryable<Detalle_venta> AllDetallesConfirmados(MiDbContext _context) 
        { 
             
            DetalleVentaDAO detalle = new DetalleVentaDAO(_context);
            return detalle.GetAllDetalleConfirmados();  
        }

        public IQueryable<Detalle_venta> AllFilterDetallesConfirmados(DateTime desde, DateTime hasta, MiDbContext _context)
        {
            DetalleVentaDAO detalle = new DetalleVentaDAO(_context);
            return detalle.GetDetallesFilterConfirmados(desde, hasta);
        }

        // Implementaciones de filtrado de detalles_venta sobre la fecha de venta
        public List<ReporteGananciasBrutasDTO> DetallesActivosPorMes(DateTime desde, DateTime hasta)
        {
            IQueryable<Detalle_venta> detalles;

            List<ReporteGananciasBrutasDTO> datos = new List<ReporteGananciasBrutasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    detalles = this.AllFilterDetallesConfirmados(desde, hasta, context);
                }
                else
                {
                    detalles = this.AllDetallesConfirmados(context);
                }

                datos = this.ReportesAgrupadosMensual(detalles);
            }

            return datos;
        }
         
        public List<ReporteGananciasBrutasDTO> DetallesActivosPorTrimestre(DateTime desde, DateTime hasta)
        {
            IQueryable<Detalle_venta> detalles;

            List<ReporteGananciasBrutasDTO> datos = new List<ReporteGananciasBrutasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    detalles = this.AllFilterDetallesConfirmados(desde, hasta, context);
                }
                else
                {
                    detalles = this.AllDetallesConfirmados(context);
                }

                datos = this.ReportesAgrupadosTrimestral(detalles);
            }

            return datos;
        }

        public List<ReporteGananciasBrutasDTO> DetallesActivosPorSemestre(DateTime desde, DateTime hasta)
        {
            IQueryable<Detalle_venta> detalles;

            List<ReporteGananciasBrutasDTO> datos = new List<ReporteGananciasBrutasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    detalles = this.AllFilterDetallesConfirmados(desde, hasta, context);
                }
                else
                {
                    detalles = this.AllDetallesConfirmados(context);
                }

                datos = this.ReportesAgrupadosSemestral(detalles);
            }

            return datos;
        }

        public List<ReporteGananciasBrutasDTO> DetallesActivosPorAño(DateTime desde, DateTime hasta)
        {
            IQueryable<Detalle_venta> detalles;

            List<ReporteGananciasBrutasDTO> datos = new List<ReporteGananciasBrutasDTO>();

            using (var context = new MiDbContext())
            {
                if (desde < hasta)
                {
                    detalles = this.AllFilterDetallesConfirmados(desde, hasta, context);
                }
                else
                {
                    detalles = this.AllDetallesConfirmados(context);
                }

                datos = this.ReportesAgrupadosAnual(detalles);
            }

            return datos;
        }
       
        public List<ReporteGananciasBrutasDTO> ReportesAgrupadosMensual(IQueryable<Detalle_venta> _detalles)
        {
            List<ReporteGananciasBrutasDTO> resultado = new List<ReporteGananciasBrutasDTO>();

            if (_detalles != null)
            {
                // PASO 1: Agrupamos y proyectamos a un objeto temporal. 
                // Todo esto se traduce a un SQL perfecto y ultra rápido.
                var datosDesdeBD = _detalles
                .GroupBy(d => new
                    {
                        Año = d.venta.fecha_venta.Year,
                        Mes = d.venta.fecha_venta.Month
                    }
                )
                .Select(g => new
                    {
                        Año = g.Key.Año,
                        Mes = g.Key.Mes,
                        CostoTotal = g.Sum(d => d.cantidad_producto * d.precio_costo),
                        VentaTotal = g.Sum(d => d.subtotal),
                    }
                )
                .OrderBy(v => v.Año).ThenBy(v => v.Mes)  //Sera que va?
                .ToList();

                // PASO 2: Ahora que los datos están en la memoria RAM, 
                // C# sí puede usar el constructor de DateTime perfectamente.
                resultado = datosDesdeBD
                .Select(x => new ReporteGananciasBrutasDTO
                    {
                        periodo_reportado = new DateTime(x.Año, x.Mes, 1),
                        costo_total = x.CostoTotal,
                        venta_total = x.VentaTotal,
                        margen_ganancia = x.VentaTotal > 0? decimal.Round(((x.VentaTotal - x.CostoTotal) / x.VentaTotal) * 100, 2) : 0
                    }
                )
                .ToList();

            }

            return resultado;
        }

        public List<ReporteGananciasBrutasDTO> ReportesAgrupadosTrimestral(IQueryable<Detalle_venta> _detalles)
        {
            List<ReporteGananciasBrutasDTO> resultado = new List<ReporteGananciasBrutasDTO>();

            if (_detalles != null)
            {
                // PASO 1: Agrupamos y proyectamos a un objeto temporal. 
                // Todo esto se traduce a un SQL perfecto y ultra rápido.
                var datosDesdeBD = _detalles
                .GroupBy(d => new
                {
                    Año = d.venta.fecha_venta.Year,
                    Mes = ((d.venta.fecha_venta.Month - 1) / 3) * 3 + 1
                }
                )
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    CostoTotal = g.Sum(d => d.cantidad_producto * d.precio_costo),
                    VentaTotal = g.Sum(d => d.subtotal),
                }
                )
                .OrderBy(v => v.Año).ThenBy(v => v.Mes)
                .ToList();

                // PASO 2: Ahora que los datos están en la memoria RAM, 
                // C# sí puede usar el constructor de DateTime perfectamente.
                resultado = datosDesdeBD
                .Select(x => new ReporteGananciasBrutasDTO
                    {
                        periodo_reportado = new DateTime(x.Año, x.Mes, 1),
                        costo_total = x.CostoTotal,
                        venta_total = x.VentaTotal,
                        margen_ganancia = x.VentaTotal > 0 ? decimal.Round(((x.VentaTotal - x.CostoTotal) / x.VentaTotal) * 100, 2) : 0
                    }
                )
                .ToList();

            }

            return resultado;

        }

        public List<ReporteGananciasBrutasDTO> ReportesAgrupadosSemestral(IQueryable<Detalle_venta> _detalles)
        {
            List<ReporteGananciasBrutasDTO> resultado = new List<ReporteGananciasBrutasDTO>();

            if (_detalles != null)
            {
                // PASO 1: Agrupamos y proyectamos a un objeto temporal. 
                // Todo esto se traduce a un SQL perfecto y ultra rápido.
                var datosDesdeBD = _detalles
                .GroupBy(d => new
                {
                    Año = d.venta.fecha_venta.Year,
                    Mes = ((d.venta.fecha_venta.Month - 1) / 6) * 6 + 1,
                }
                )
                .Select(g => new
                {
                    Año = g.Key.Año,
                    Mes = g.Key.Mes,
                    CostoTotal = g.Sum(d => d.cantidad_producto * d.precio_costo),
                    VentaTotal = g.Sum(d => d.subtotal),
                }
                )
                .OrderBy(v => v.Año).ThenBy(v => v.Mes)  //Sera que va?
                .ToList();

                // PASO 2: Ahora que los datos están en la memoria RAM, 
                // C# sí puede usar el constructor de DateTime perfectamente.
                resultado = datosDesdeBD
                .Select(x => new ReporteGananciasBrutasDTO
                {
                    periodo_reportado = new DateTime(x.Año, x.Mes, 1),
                    costo_total = x.CostoTotal,
                    venta_total = x.VentaTotal,
                    margen_ganancia = x.VentaTotal > 0 ? decimal.Round(((x.VentaTotal - x.CostoTotal) / x.VentaTotal) * 100, 2) : 0
                }
                )
                .ToList();

            }

            return resultado;
        }

        public List<ReporteGananciasBrutasDTO> ReportesAgrupadosAnual(IQueryable<Detalle_venta> _detalles)
        {
            List<ReporteGananciasBrutasDTO> resultado = new List<ReporteGananciasBrutasDTO>();

            if (_detalles != null)
            {
                // PASO 1: Agrupamos y proyectamos a un objeto temporal. 
                // Todo esto se traduce a un SQL perfecto y ultra rápido.
                var datosDesdeBD = _detalles
                .GroupBy(d => new
                    {
                        Año = d.venta.fecha_venta.Year,
                    }
                )
                .Select(g => new
                    {
                        Año = g.Key.Año,
                        CostoTotal = g.Sum(d => d.cantidad_producto * d.precio_costo),
                        VentaTotal = g.Sum(d => d.subtotal),
                    }
                )
                .OrderBy(v => v.Año)  //Sera que va?
                .ToList();

                // PASO 2: Ahora que los datos están en la memoria RAM, 
                // C# sí puede usar el constructor de DateTime perfectamente.
                resultado = datosDesdeBD
                .Select(x => new ReporteGananciasBrutasDTO
                    {
                        periodo_reportado = new DateTime(x.Año, 1, 1),
                        costo_total = x.CostoTotal,
                        venta_total = x.VentaTotal,
                        margen_ganancia = x.VentaTotal > 0 ? decimal.Round(((x.VentaTotal - x.CostoTotal) / x.VentaTotal) * 100, 2) : 0
                    }
                )
                .ToList();

            }

            return resultado;
        }
    }
}
