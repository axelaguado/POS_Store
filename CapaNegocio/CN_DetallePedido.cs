using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_DetallePedido
    {
        private Dictionary<string, string> validacion;

        public CN_DetallePedido()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public void CrearDetalle(Detalle_pedido _detalle)
        {
            using (var context = new MiDbContext()) 
            {
                // Ejecutamos si se supera al validacion del detalle. 
                Detalle_pedidoDAO detalleDAO = new Detalle_pedidoDAO(context);
                detalleDAO.Crear_detalle(_detalle); // Retornar el ID del detalle.  
            }     
        }

        public List<Detalle_pedido> crearDetallesPedido(List<Detalle_pedido> _detallesPedido, List<Articulo> _articulos, Pedido _pedido)
        {
            int i = 0; 

            foreach (Detalle_pedido item in _detallesPedido)
            {
                item.pedido = _pedido;
                item.articulo = _articulos[i];
                i++;
                // falta crear el pedido jijooo.
            }

            return _detallesPedido;
        }

        public bool validarDetalle(Detalle_pedido _detalle)
        {
            if (!this.validarCantidad(_detalle.cantidad))
            {
                return false;
            }

            return true;
        }

        public bool validarCantidad(int _cantidad)
        {
            if (_cantidad < 0)
            {
                validacion.Add("TBCamtidad", "El campo cantidad no puede ser un valor numerico negativo");
                return false;
            }

            return true;
        }

        public bool ValidarDetalles(List<Detalle_pedido> _detallesPedido)
        { 
            foreach (Detalle_pedido item in _detallesPedido)
            {
                if (!this.validarDetalle(item))
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }
          
    }
}
