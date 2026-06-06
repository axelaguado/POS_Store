using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class EstadoCompraDAO
    {
        private readonly MiDbContext _context;

        public EstadoCompraDAO(MiDbContext context)
        {
            _context = context;
        }
         
        public Estado_compra buscarEstado(int _estado) 
        { 
            return _context.Estados_compra.FirstOrDefault(ep => ep.id_estado == _estado);  
        }

        public Estado_compra GetEstadoPendiente() 
        { 
            return _context.Estados_compra.FirstOrDefault(ep => ep.descripcion_estado == "Pendiente");
        }

        public Estado_compra GetEstadoConfirmado()
        {
            return _context.Estados_compra.FirstOrDefault(ep => ep.descripcion_estado == "Confirmada");
        }

        public void Attach_estado(Estado_compra estado)
        {
            _context.Estados_compra.Attach(estado);
        }
    }
}
