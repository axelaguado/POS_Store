using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public  class PersonaDAO {
        // READONLY --> Hace que dicho atriubto no puede ser modificado.
        private readonly MiDbContext _context;

        // Constructor que recibe el DbContext.
        public PersonaDAO (MiDbContext context)
        {
            _context = context;
        } 
         
        //  -- CREATE --
        public void Crear_persona(Persona _persona) 
        {     
            _context.Personas.Add(_persona);  
        } 

        // -- READ --
        public List<Persona> listar_personas() 
        { 
            return _context.Personas.ToList(); 
        }
         
        // -- UPDATE --
        public Persona update_persona(Persona datos_modificados)
        { 
            Persona persona_modificar = _context.Personas.FirstOrDefault(p => p.id_persona == datos_modificados.id_persona);

            if (persona_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(persona_modificar).CurrentValues.SetValues(datos_modificados); 
            }

            return persona_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }

    } 
}
