using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.CapaPresentacion;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1.CapaDatos
{
    public class Detalle_pedidoDAO
    {
        private readonly MiDbContext _context;

        public Detalle_pedidoDAO(MiDbContext context)
        {
            _context = context;
        }

        public void Crear_detalle(Detalle_pedido detalle)
        {
            _context.Detalles_pedido.Add(detalle);  
        }

        public void Crear_detalles(List<Detalle_pedido> _detalles)
        {
            foreach (Detalle_pedido item in _detalles)
            {
                _context.Detalles_pedido.Add(item);
            }
        }
    } 
}   
