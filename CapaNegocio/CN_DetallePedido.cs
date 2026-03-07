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
        private Dictionary<string, string> errores;

        public CN_DetallePedido()
        {
            this.errores = new Dictionary<string, string>();
        }

        public int CrearDetalle(Detalle_pedido _detalle)
        {
            // Ejecutamos si se supera al validacion del detalle.

            Detalle_pedidoDAO detalleDAO = new Detalle_pedidoDAO(); 
            return detalleDAO.Crear_detalle(_detalle); // Retornar el ID del detalle.
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
            if(_cantidad < 0) 
            {
                errores.Add("TBCamtidad", "El campo cantidad no puede ser un valor numerico negativo");
                return false; 
            }
            
            return true;
        }

        public Dictionary<string, string> mostrarErrores()
        {
            return this.errores;
        }
    }
}
