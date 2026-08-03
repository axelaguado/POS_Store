using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class DetalleVentaDAO
    {

        private readonly MiDbContext _context;

        public DetalleVentaDAO(MiDbContext context)
        {
            _context = context;
        }

        public void Crear_detalle(Detalle_venta detalle)
        {
            _context.Detalles_venta.Add(detalle);
        }

        public void Crear_detalles(List<Detalle_venta> _detalles)
        {
            foreach (Detalle_venta item in _detalles)
            {
                _context.Detalles_venta.Add(item);
            }
        }

        public void Attach_detalles(ICollection<Detalle_venta> _detalles)
        {
            foreach (Detalle_venta item in _detalles)
            {
                _context.Detalles_venta.Attach(item);
            }
        }
    }
}
