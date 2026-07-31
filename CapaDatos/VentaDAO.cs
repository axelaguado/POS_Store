using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class VentaDAO
    {
        private readonly MiDbContext context;

        public VentaDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearVenta(Venta nuevaVenta)
        {
            context.Ventas.Add(nuevaVenta);
        }

        public Venta GetVentaActiva(int id_venta)
        {
            return context.Ventas.Include(v => v.detalles)
                                .Include(v => v.caja)
                                .Include(v => v.cliente)
                                .FirstOrDefault(v => v.estado_venta == true && v.id_venta == id_venta);
        }

        // -- UPDATE --
        public void update_centa(Venta datos_modificados)
        {
            Venta venta_modificar = context.Ventas.FirstOrDefault(v => v.id_venta == datos_modificados.id_venta);

            if (venta_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(venta_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }
    }
}
