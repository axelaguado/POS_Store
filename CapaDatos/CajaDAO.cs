using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class CajaDAO
    {
        private readonly MiDbContext context;

        public CajaDAO (MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearCaja(Caja nuevaCaja)
        {
            context.Cajas.Add(nuevaCaja);
        }

        public Caja GetCajaActiva(int id_usuario) 
        {
            return context.Cajas.Include(c => c.usuario)
                                .Include(c => c.ventas)
                                .FirstOrDefault(c => c.estado_caja == true && c.id_usuario == id_usuario);
                
        }

        // -- UPDATE --
        public void update_caja(Caja datos_modificados)
        {
            Caja caja_modificar = context.Cajas.FirstOrDefault(c => c.id_caja == datos_modificados.id_caja);

            if (caja_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(caja_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }


    }
}
