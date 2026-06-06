using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.util.collections;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_DetalleCompra
    {
        private Dictionary<string, string> validacion;

        public CN_DetalleCompra()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public void CrearDetalle(Detalle_compra _detalle)
        {
            using (var context = new MiDbContext()) 
            {
                // Ejecutamos si se supera al validacion del detalle. 
                Detalle_compraDAO detalleDAO = new Detalle_compraDAO(context);
                detalleDAO.Crear_detalle(_detalle); // Retornar el ID del detalle.  
            }     
        }

        public void SetCompra(Compra _compra) 
        { 
            foreach (Detalle_compra item in _compra.detalles_compra) 
            { 
                item.compra = _compra;
            }
        }
  
        public void validarDetalle(Detalle_compra _detalle)
        {
            this.validacion.Clear();

            this.validarCompra(_detalle.compra);
            this.validarProducto(_detalle.producto); 
            this.validarCantidad(_detalle.cantidad_producto);
            this.validarSubtotal(_detalle.subtotal_producto);
            this.validarInformacion(_detalle.informacion_acerca); 
        }
         
        private void validarCompra(Compra _compra) 
        { 
            if (_compra == null) 
            {
                this.validacion.Add("Detalle_compra", "No es posible crear el detalle, compra no asignado.");            
            }
        }  

        private void validarProducto(Producto _producto) 
        {
            if (_producto == null)
            {
                this.validacion.Add("Detalle_compra", "No es posible crear el detalle, producto asignado.");
            }
        }

        private void validarSubtotal(decimal _subtotal)
        { 
            if (_subtotal <= 0)
            {
                this.validacion.Add("TBProductoPrecio", "El campo subtotal debe ser mayor a cero."); 
            }
            else if (decimal.Round(_subtotal, 2) != _subtotal)
            {
                this.validacion.Add("TBProductoPrecio", "El campo subtotal solo acepta valores con hasta dos decimales"); 
            } 
        }

        private void validarCantidad(int _cantidad)
        { 
            if (_cantidad < 1)
            {
                this.validacion.Add("TBProductoCantidad", "El campo Cantidad debe ser mayor a cero."); 
            } 
        }

        public void validarInformacion(string _informacion)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(_informacion, @"^[a-zA-Z0-9\s,.]+$"))
            {
                this.validacion.Add("TBProductoInformacion", "El campo Informacion solo puede contener caracteres alfabeticos (.,), numericos y espacios."); 
            }
            else if (_informacion.Length > 100)
            {
                this.validacion.Add("TBProductoInformacion", "El campo Informacion supera la cantidad de caracteres(200) posibles."); 
            } 
        }

        public void ValidarDetalles(ICollection<Detalle_compra> _detallesPedido)
        { 
            foreach (Detalle_compra item in _detallesPedido)
            {
                this.validarDetalle(item);
                if (this.validacion.Count > 0) return;  
            } 
        } 

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }
          
    }
}
