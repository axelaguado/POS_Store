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
        // private readonly MiDbContext _context;

        /* Constructor que recibe el DbContext
        public PersonaDAO (MiDbContext context)
        {
            _context = context;
        }
        */



        // Crear un nuevo Usuario
        /* public int Crear_persona(Persona persona)
        {

            // Al usar el bloque using, el contexto MiDbContext es desechado automáticamente cuando termina el bloque de código.
            using (var context = new MiDbContext())
            {
                try
                {
                    context.Personas.Add(persona);
                    context.SaveChanges();
                    return persona.id_persona; // Retornar el ID generado
                }
                catch (Exception excepcion)
                {
                    var innerException = excepcion.InnerException;
                    if (innerException != null)
                    {
                        MessageBox.Show(innerException.Message);
                    }
                    else
                    {
                        MessageBox.Show(excepcion.Message);
                    }
                    
                    return -1; // En caso de error, puedes devolver un valor que indique fallo
                }
            }
        }
        */

        //  -- CREATE --
        public int Crear_persona(Persona persona)
        {

            // Al usar el bloque using, el contexto MiDbContext es desechado automáticamente cuando termina el bloque de código.
            using (var context = new MiDbContext())
            { 
                    context.Personas.Add(persona);
                    context.SaveChanges();
                    return persona.id_persona;  

            }
        }


        // -- READ --
        public List<Persona> listar_personas() 
        {
            using (var context = new MiDbContext())
            { 
                return context.Personas.ToList();
            }
        }

        public Persona buscarPorTelefono(long _telefono)
        {
            using (var context = new MiDbContext())
            {
                return context.Personas.FirstOrDefault(p => p.telefono == _telefono);
            }
        }

        public Persona buscarPorEmail(string _email)
        {
            using (var context = new MiDbContext())
            {
                return context.Personas.FirstOrDefault(p => p.email == _email);
            }
        }

        public Persona buscarPorDni(int _dni) 
        {
            using (var context = new MiDbContext())
            {
                return context.Personas.FirstOrDefault(p => p.dni_persona == _dni);
            }
        }

       
        // -- UPDATE --
        public Persona update_persona(Persona datos_modificados)
        {
            using (var context = new MiDbContext())
            {
                Persona persona_modificar = context.Personas.FirstOrDefault(p => p.id_persona == datos_modificados.id_persona);

                if (persona_modificar != null)
                {
                    // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                    //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                    // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                    // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                    context.Entry(persona_modificar).CurrentValues.SetValues(datos_modificados);

                    // Para finalmente actualizar los datos en la bdd es necesario invocar al SaveChanges osino solo se modifican en el contexto.  
                    context.SaveChanges();
                }

                return persona_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
            }
        }



    }
}
