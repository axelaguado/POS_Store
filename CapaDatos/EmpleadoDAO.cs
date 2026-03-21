using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class EmpleadoDAO
    {
        private readonly MiDbContext _context;

        public EmpleadoDAO(MiDbContext context)
        {
            this._context = context;
        }


        //  -- CREATE --
        public void Crear_empleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado); 
        }


        // -- READ --
        public List<Empleado> listar_empleados()
        {
            return _context.Empleados.ToList();
        }

        // -- UPDATE --
        public Empleado update_empleado(Empleado datos_modificados)
        { 
            Empleado empleado_modificar = _context.Empleados.FirstOrDefault(e => e.id_persona == datos_modificados.id_persona);

            if (empleado_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(empleado_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return empleado_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }

    }
}
