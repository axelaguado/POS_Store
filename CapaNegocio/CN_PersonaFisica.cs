using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_PersonaFisica
    {
        public CN_PersonaFisica() { }

        public void CrearPersonaFisica(PersonaFisica _personafisica)
        {
            using (var context = new MiDbContext())
            {
                PersonaFisicaDAO personafisicaDAO = new PersonaFisicaDAO(context);
                personafisicaDAO.Crear_personafisica(_personafisica); // Retornar el ID de la dirección   
            }
        }

        public Dictionary<string, string> ValidarPersonaFisica(PersonaFisica persona_fisica)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>(); 

            if (persona_fisica == null)
            {
                errores.Add("Persona", "Los datos personales insertados no son validos.");
            }

            // Validaciones para campo Dni. 
            if (string.IsNullOrEmpty(Convert.ToString(persona_fisica.dni_persona)))
            {
                errores.Add("TBDni", "El campo dni no puede estar vacio.");

            }
            else if (!int.TryParse(Convert.ToString(persona_fisica.dni_persona), out _))
            {
                errores.Add("TBDni", "El campo dni debe contener un valor numerico.");
            }
            else if (persona_fisica.dni_persona > 99999999)
            {
                errores.Add("TBDni", "El campo dni no puede tener mas de 8 cifras.");
            }
            else if (this.Dni_Exist(persona_fisica))
            {
                errores.Add("TBDni", "El dni ingresado ya existe.");
            }

            // Validaciones para campo nombre. 
            if (string.IsNullOrEmpty(persona_fisica.nombre_persona))
            {
                errores.Add("TBNombre", "El campo nombre es obligatorio.");
            }
            else if (string.IsNullOrWhiteSpace(persona_fisica.nombre_persona))
            {
                errores.Add("TBNombre", "El campo nombre no puede contener solo espacios en blanco.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(persona_fisica.nombre_persona, @"^[a-zA-Z\s]+$"))
            {
                errores.Add("TBNombre", "El campo nombre solo puede contener letras y espacios.");
            }

            // Validaciones para campo apellido. 
            if (string.IsNullOrEmpty(persona_fisica.apellido_persona))
            {
                errores.Add("TBApellido", "El campo apellido es obligatorio");
            }
            else if (string.IsNullOrWhiteSpace(persona_fisica.nombre_persona))
            {
                errores.Add("TBApellido", "El campo nombre no puede contener solo espacios en blanco.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(persona_fisica.apellido_persona, @"^[a-zA-Z\s]+$"))
            {
                errores.Add("TBApellido", "El campo apellido solo puede contener letras y espacios.");
            }

            // Validaciones para campo fecha_nacimiento. 
            // Falta rigurosidad con respecto de los mesese y dias.
            DateTime fechaNacimiento = persona_fisica.fecha_nacimiento;
            DateTime fechaHoy = DateTime.Today;
            int edad = fechaHoy.Year - fechaNacimiento.Year;

            if (fechaHoy.Month < fechaNacimiento.Month || (fechaHoy.Month == fechaNacimiento.Month && fechaHoy.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            if (edad < 18)
            {
                errores.Add("DTPFechaNacimiento", "La fecha de nacimiento corresponde a un menor de 18 años.");
            }

            // Validacion para campo sexo. 
            if (string.IsNullOrEmpty(persona_fisica.sexo))
            {
                errores.Add("Sexo", "Debe seleccionar un sexo.");
            }
            else if (!(persona_fisica.sexo.Equals("Mujer") || persona_fisica.sexo.Equals("Hombre")))
            {
                errores.Add("Sexo", "El sexo seleccionado no esta disponible.");
            }
             
            // Retornamos el diccionario de datos con los errores que se hayan cargado.
            return errores;
        }

        public PersonaFisica updatePersonaFisica(PersonaFisica datos_modficar)
        {
            using (var context = new MiDbContext())
            {
                PersonaFisicaDAO persona_fisica = new PersonaFisicaDAO(context);
                PersonaFisica retorno = persona_fisica.update_personafisica(datos_modficar);

                context.SaveChanges();
                return retorno;
            } 
        }

        public bool Dni_Exist(PersonaFisica _personafisica) 
        {
            using (var context = new MiDbContext())
            {
                PersonaFisicaDAO persona_fisica = new PersonaFisicaDAO(context); 
                return persona_fisica.DniExist(_personafisica);
            }

        }
        
        public PersonaFisica buscar_persona_dni(int _dni)
        { 
            using (var context = new MiDbContext())
            {
                PersonaFisicaDAO persona_fisica = new PersonaFisicaDAO(context);
                PersonaFisica persona_found = persona_fisica.buscarPorDni(_dni);

                context.SaveChanges();

                return persona_found;
            } 
        }
 
        public List<PersonaFisica> listarPersonas()
        { 
            using (var context = new MiDbContext())
            {
                PersonaFisicaDAO persona_fisica = new PersonaFisicaDAO(context);
                List<PersonaFisica> lista = new List<PersonaFisica>();

                lista = persona_fisica.listar_personasfisicas();

                return lista;
            } 
        } 
        
    }
}
