using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{ 

    public class CN_EstadoCompra
    {
        private Dictionary<string, string> _validacion;

        public CN_EstadoCompra() 
        { 
            this._validacion = new Dictionary<string, string>();
        }

        public void AttachEstado (Estado_compra _estado, MiDbContext context) 
        {
            EstadoCompraDAO estado = new EstadoCompraDAO(context);
            estado.Attach_estado(_estado);
        }

        public Estado_compra BuscarEstado(int id_estado)
        {
            using (var context = new MiDbContext())
            {
                EstadoCompraDAO estado = new EstadoCompraDAO(context);
                return estado.buscarEstado(id_estado);
            }
        }

        public Estado_compra ObternerEstadoPendiente() 
        {
            using (var context = new MiDbContext()) 
            {
                EstadoCompraDAO estado= new EstadoCompraDAO(context);
                return estado.GetEstadoPendiente(); 
            }
        }

        public Estado_compra ObternerEstadoConfirmado()
        {
            using (var context = new MiDbContext())
            {
                EstadoCompraDAO estado = new EstadoCompraDAO(context);
                return estado.GetEstadoConfirmado();
            }
        }
    }
}
