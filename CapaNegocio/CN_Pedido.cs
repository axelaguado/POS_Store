using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Pedido
    {

        Dictionary<string, string> errores;

        public CN_Pedido()
        {
            this.errores = new Dictionary<string, string>();
        }

        public int CrearPedido(Pedido _pedido)
        {
            // Ejecutamos si el pedido supera la validacion.

            PedidoDAO pedidoDAO = new PedidoDAO();
            return pedidoDAO.Crear_pedido(_pedido); // Retornar el ID del pedido.
        } 

        public bool ValidarPedido(Pedido _pedido) 
        {
            if (!this.validarFecha(_pedido.fecha_emision)) 
            {
                return false;
            }

            if (!this.validarMonto(_pedido.monto_total))
            {
                return false;
            }

            if (!this.validarEstado(_pedido.estado))
            {
                return false;
            }

            return true;    
        }

        public bool validarFecha(DateTime _fecha)
        {
            if (_fecha > DateTime.Now)
            {
                errores.Add("Fecha_emision", "La fecha de emision del pedido no puede ser posterior a la fecha presente");
                return false;
            }

            return true; 
        }

        public bool validarMonto(decimal _monto)
        {

            if(_monto < 0) 
            {
                errores.Add("Monto_total", "El campo Monto no puede ser menor a cero");
            } 

            return true;
        }

        public bool validarEstado(int _estado)
        {
            if (_estado < 0 && _estado > 2)
            {
                errores.Add("Pedido", "Estado del pedido no permitido");
                return false;
            }

            return true;
        }

        public Dictionary<string, string> mostrarErrores()
        {
            return this.errores;
        }

        public List<Pedido> PedidosPendientes() 
        {
            PedidoDAO pendientes = new PedidoDAO();

            return pendientes.ReadPedidosPendientes();
        }

        public List<Pedido> PedidosConfirmados()
        {
            PedidoDAO pendientes = new PedidoDAO();

            return pendientes.ReadPedidosConfirmados();
        }

        public void CancelarPedido(int id_pedido) 
        {
            PedidoDAO pedido = new PedidoDAO();

            pedido.update_StateInactive(id_pedido); 
        }

        public void ConfirmarPedido(int id_pedido)
        {
            PedidoDAO pedido = new PedidoDAO();

            pedido.update_StateConfirmado(id_pedido);
        }

        public Pedido BuscarPedido(long id_pedido)
        {
            PedidoDAO pedido = new PedidoDAO();

            return pedido.buscarPedido(id_pedido);
        }
    }
}
