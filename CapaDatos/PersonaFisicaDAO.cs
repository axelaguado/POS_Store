using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaDatos
{
    public class PersonaFisicaDAO
    {
        private readonly MiDbContext _context;

        public PersonaFisicaDAO (MiDbContext context)
        { 
            this._context = context;    
        }

        //  -- CREATE --
        public void Crear_personafisica(PersonaFisica persona_fisica)
        {
            _context.PersonasFisicas.Add(persona_fisica); 
        } 

        // -- READ --
        public List<PersonaFisica> listar_personasfisicas()
        {
            return _context.PersonasFisicas.ToList();
        } 

        public PersonaFisica buscarPorDni(int _dni)
        {
            return _context.PersonasFisicas.FirstOrDefault(p => p.dni_persona == _dni); 
        }

        public bool DniExist(PersonaFisica _personafisca)
        {
            return _context.PersonasFisicas
                             .Any(pf => pf.dni_persona == _personafisca.dni_persona && pf.id_persona != _personafisca.id_persona);  // existe el username                         existe el username
                                                                                                                 // los id_son distntos --> retorna existe     los id_son iguales --> retorna false
        }

        // -- UPDATE --
        public PersonaFisica update_personafisica(PersonaFisica datos_modificados)
        { 
            PersonaFisica personafisica_modificar = _context.PersonasFisicas.FirstOrDefault(pf => pf.id_persona == datos_modificados.id_persona);

            if (personafisica_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(personafisica_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return personafisica_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        } 
    }
}
