using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class MetodoPagoDAO
    {
        private readonly MiDbContext context;

        public MetodoPagoDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearMetodo(Metodo_pago nuevoMetodo)
        {
            context.Metodos.Add(nuevoMetodo);
        }

        public void Attach_metodo(Metodo_pago metodoExistente)
        {
            context.Metodos.Attach(metodoExistente);
        }

        public List<Metodo_pago> GetMetodosActivos()
        {
            return context.Metodos.Where(m => m.estado_metodo == true).ToList(); 
        }

        // -- UPDATE --
        public void update_caja(Metodo_pago datos_modificados)
        {
            Metodo_pago metodo_modificar = context.Metodos.FirstOrDefault(m => m.id_metodo == datos_modificados.id_metodo);

            if (metodo_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(metodo_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }


    }
}
