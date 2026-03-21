using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class EstadoPedidoDAO
    {
        private readonly MiDbContext _context;

        public EstadoPedidoDAO(MiDbContext context)
        {
            _context = context;
        }
         
        public Estado_Pedido buscarEstado(int _estado) 
        { 
            return _context.Estados_pedido.FirstOrDefault(ep => ep.id_estado == _estado);  
        }
    }
}
