using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaDatos
{
    public class PersonaJuridicaDAO
    {
        private readonly MiDbContext _context;

        public PersonaJuridicaDAO (MiDbContext context)
        {
            this._context = context;
        }

        //  -- CREATE --
        public void Crear_personajuridica(PersonaJuridica persona_juridica)
        {
            _context.PersonasJuridicas.Add(persona_juridica); 
        } 

        // -- READ --
        public List<PersonaJuridica> listar_personas()
        {
            return _context.PersonasJuridicas.ToList();
        }


        public bool CuitExist(PersonaJuridica _personaJuridica)
        {
            return _context.PersonasJuridicas
                                   .Any(pj => pj.cuit == _personaJuridica.cuit && pj.id_persona != _personaJuridica.id_persona);
        }

        public bool RazonSocialExist(PersonaJuridica _personaJuridica)
        {
            return _context.PersonasJuridicas
                                    .Any(pj => pj.razon_social == _personaJuridica.razon_social && pj.id_persona != _personaJuridica.id_persona); 
                                                                                            
                                                                                           
        }

        public bool NombreComercialExist(PersonaJuridica _personaJuridica)
        {
             return _context.PersonasJuridicas
                                    .Any(pj => pj.nombre_comercial  == _personaJuridica.nombre_comercial && pj.id_persona != _personaJuridica.id_persona); 
        }

        // -- UPDATE --
        public PersonaJuridica update_personaJuridica(PersonaJuridica datos_modificados)
        { 
            PersonaJuridica personajuridica_modificar = _context.PersonasJuridicas.FirstOrDefault(pj => pj.id_persona == datos_modificados.id_persona);

            if (personajuridica_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(personajuridica_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return personajuridica_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }

    }
}
