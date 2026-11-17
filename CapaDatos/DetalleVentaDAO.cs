using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.DTO;

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

        // Metodos de filtrado en la BD.
        public IQueryable<Detalle_venta> GetAllDetalleConfirmados()
        {
            return this._context.Detalles_venta.Where(d => d.venta.estado_venta == true);
        }

        public IQueryable<Detalle_venta> GetDetallesFilterConfirmados(DateTime desde, DateTime hasta)
        {
            return this._context.Detalles_venta.Where(d => d.venta.estado_venta == true && (d.venta.fecha_venta >= desde && d.venta.fecha_venta <= hasta));
        }
    }
}
