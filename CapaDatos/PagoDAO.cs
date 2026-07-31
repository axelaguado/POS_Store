using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class PagoDAO
    {
        private readonly MiDbContext context;

        public PagoDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearPago(Pago nuevaPago)
        {
            context.Pagos.Add(nuevaPago);
        }

        public Pago GetPagosActiva(int id_pago)
        {
            return context.Pagos.Include(p => p.venta)
                                .Include(p => p.metodo)
                                .FirstOrDefault(p => p.estado_pago == true && p.id_pago == id_pago);

        }

        // -- UPDATE --
        public void update_caja(Pago datos_modificados)
        {
            Pago pago_modificar = context.Pagos.FirstOrDefault(p => p.id_pago == datos_modificados.id_pago);

            if (pago_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(pago_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }
    }
}
