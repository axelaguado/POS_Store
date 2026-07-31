using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

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

    }
}
