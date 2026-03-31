using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using System.Data.Entity;

namespace WindowsFormsApp1.CapaDatos
{
    public class ContactoDAO
    {
        private readonly MiDbContext _context;

        public ContactoDAO(MiDbContext context) 
        { 
            _context = context; 
        }

        public void Crear_contacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto); 
        }


        // -- READ --
        public List<Contacto> listar_contactos()
        {
            return _context.Contactos.ToList();
        }

        public Contacto buscar_contacto(long _telefono)
        {
            return _context.Contactos.Include(c => c.persona)
                                     .Include(c => c.persona.persona_fisica)
                                     .Include(c => c.persona.persona_juridica) 
                                     .FirstOrDefault(c => c.telefono == _telefono);
        }

        public Contacto Buscar_email(string _email)
        {
            return _context.Contactos.Include(c => c.persona)
                                     .Include(c => c.persona.persona_fisica)
                                     .Include(c => c.persona.persona_juridica)
                                     .FirstOrDefault(c => c.email == _email);
        }

        public bool EmailExist(Contacto _contacto)
        {
            return _context.Contactos
                             .Any(c => c.email == _contacto.email && c.id_contacto != c.id_contacto);  // existe el username                         existe el username
                                                                                                       // los id_son distntos --> retorna existe     los id_son iguales --> retorna false
        }

        // -- UPDATE --
        public Contacto update_contacto(Contacto datos_modificados)
        {
            Contacto contacto_modificar = _context.Contactos.FirstOrDefault(c => c.id_persona == datos_modificados.id_persona);

            if (contacto_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(contacto_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return contacto_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }

    }
}
