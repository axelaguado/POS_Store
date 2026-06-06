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
    public class Detalle_compraDAO
    {
        private readonly MiDbContext _context;

        public Detalle_compraDAO(MiDbContext context)
        {
            _context = context;
        }

        public void Crear_detalle(Detalle_compra detalle)
        {
            _context.Detalles_compra.Add(detalle);  
        }

        public void Crear_detalles(List<Detalle_compra> _detalles)
        {
            foreach (Detalle_compra item in _detalles)
            {
                _context.Detalles_compra.Add(item);
            }
        }
    } 
}   
