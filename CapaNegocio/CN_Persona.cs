using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Persona
    {

        public int CrearPersona(Persona _persona) 
        {
            /*
            Dictionary <string, string> resultadoValidacion = this.ValidarPersona(_persona);

            // Puedes agregar validaciones o lógica de negocio aquí
            if (resultadoValidacion.Count != 0)
            {  
                return resultadoValidacion;
            }

            // Llamar a la capa de datos para guardar la persona
            PersonaDAO personaDAO = new PersonaDAO();
            int id_PersonaRegistrada = personaDAO.Crear_persona(_persona);
            resultadoValidacion.Add("Exito", Convert.ToString(id_PersonaRegistrada));

            return resultadoValidacion; //Aqui resultadi.Count seria igual a cero, que sera nuestra condicion para realizar las inserciones siguientes. 
            */

            PersonaDAO personaDAO = new PersonaDAO();  
            return personaDAO.Crear_persona(_persona); // Retornar el ID de la dirección
        } 

        // Analizar que tan seguro es tener este value para manejar las validaciones de los campos.  
        public Dictionary<string, string> ValidarPersona(Persona _persona)
        { 
            Dictionary<string, string> errores = new Dictionary<string, string>();
             
            CN_Persona context = new CN_Persona();


                if (_persona == null)
                {
                    errores.Add("Persona", "Los datos personales insertados no son validos.");
                }

                // Validaciones para campo Dni. 
                if (string.IsNullOrEmpty(Convert.ToString(_persona.dni_persona)))
                {
                    errores.Add("TBDni", "El campo dni no puede estar vacio.");

                } 
                else if (!int.TryParse(Convert.ToString(_persona.dni_persona), out _))
                {
                   errores.Add("TBDni", "El campo dni debe contener un valor numerico.");
                }
                else if (_persona.dni_persona > 99999999)
                {
                    errores.Add("TBDni", "El campo dni no puede tener mas de 8 cifras.");
                }
                else if (context.buscar_persona_dni(_persona.dni_persona) != null)
                {
                    errores.Add("TBDni", "El dni ingresado ya existe.");
                } 

            // Validaciones para campo nombre.

                if (string.IsNullOrEmpty(_persona.nombre_persona))
                {
                    errores.Add("TBNombre", "El campo nombre es obligatorio.");
                }
                else if (string.IsNullOrWhiteSpace(_persona.nombre_persona))
                {
                    errores.Add("TBNombre", "El campo nombre no puede contener solo espaciosa en blanco.");
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(_persona.nombre_persona, @"^[a-zA-Z\s]+$"))
                {
                    errores.Add("TBNombre", "El campo nombre solo puede contener letras y espacios.");
                }
                 
                // Validaciones para campo apellido.

                if (string.IsNullOrEmpty(_persona.apellido_persona))
                {
                    errores.Add("TBApellido", "El campo apellido es obligatorio");
                }
                else if (string.IsNullOrWhiteSpace(_persona.nombre_persona))
                {
                    errores.Add("TBApellido", "El campo nombre no puede contener solo espacios en blanco.");
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(_persona.apellido_persona, @"^[a-zA-Z\s]+$"))
                {
                    errores.Add("TBApellido", "El campo apellido solo puede contener letras y espacios.");
                } 
                 
                // Validaciones para campo fecha_nacimiento.

                // Falta rigurosidad con respecto de los mesese y dias.
                DateTime fechaNacimiento = _persona.fecha_nacimiento;
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

                // Validaciones para campo email.

                if (string.IsNullOrEmpty(_persona.email))
                {
                    errores.Add("TBEmail", "El campo email es obligatorio");
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(_persona.email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    errores.Add("TBEmail", "El campo email no contiene el formato correspondiente.");
                }
                else if (context.buscar_persona_email(_persona.email) != null)
                {
                    errores.Add("TBEmail", "El email ingresado corresponde a una cuenta en uso.");
                }

                // Validacion para campo telefono.

                if (string.IsNullOrEmpty(Convert.ToString(_persona.telefono)))
                {
                    errores.Add("TBTelefono", "El campo telefono es obligatorio.");
                }
                else if (!long.TryParse(Convert.ToString(_persona.telefono), out _))
                {
                    errores.Add("TBTelefono", "El campo telefono solo puede contener numeros");
                } 
                if (context.buscar_persona_telefono(_persona.telefono) != null)
                {
                    errores.Add("TBTelefono", "El campo telefono ya se encuentra en uso");
                }
                
                // Validacion para campo sexo. 
                if (string.IsNullOrEmpty(_persona.sexo))
                {
                    errores.Add("Sexo", "Debe seleccionar un sexo.");
                }
                else if (!(_persona.sexo.Equals("Mujer") || _persona.sexo.Equals("Hombre")))
                {
                    errores.Add("Sexo", "El sexo seleccionado no esta disponible.");
                } 

                // Retornamos el diccionario de datos con los errores que se hayan cargado.
                return errores;
        }

        public Dictionary<string, string > validarTelefono (long _telefono) 
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();
            

            // Validacion para campo telefono.

            if (string.IsNullOrEmpty(Convert.ToString(_telefono)))
            {
                errores.Add("TBTelefono", "El campo telefono es obligatorio.");
            }
            else if (!long.TryParse(Convert.ToString(_telefono), out _))
            {
                errores.Add("TBTelefono", "El campo telefono solo puede contener numeros");
            }
            if (this.buscar_persona_telefono(_telefono) != null)
            {
                errores.Add("TBTelefono", "El campo telefono ya se encuentra en uso");
            }

            return errores;
        }

        public Dictionary<string, string> validarDni(int _dni) 
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();
              
            // Validaciones para campo Dni. 
            if (string.IsNullOrEmpty(Convert.ToString(_dni)))
            {
                errores.Add("TBDni", "El campo dni no puede estar vacio.");

            }
            else if (!int.TryParse(Convert.ToString(_dni), out _))
            {
                errores.Add("TBDni", "El campo dni debe contener un valor numerico.");
            }
            else if (_dni > 99999999)
            {
                errores.Add("TBDni", "El campo dni no puede tener mas de 8 cifras.");
            }
            else if (this.buscar_persona_dni(_dni) != null)
            {
                errores.Add("TBDni", "El dni ingresado ya existe.");
            }   

            return errores;
        } 
         
        public Dictionary<string, string> validarEmail(string _email)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();


            // Validacion para campo email.
            if (string.IsNullOrEmpty(_email))
            {
                errores.Add("TBEmail", "El campo email es obligatorio");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errores.Add("TBEmail", "El campo email no contiene el formato correspondiente.");
            }
            else if (this.buscar_persona_email(_email) != null)
            {
                errores.Add("TBEmail", "El email ingresado corresponde a una cuenta en uso.");
            }


            return errores;
        }



        public Persona buscar_persona_dni(int _dni)
        {
            PersonaDAO persona = new PersonaDAO();
            Persona persona_found = new Persona();

            // falta implmentear el bloque try-catch.
            return persona_found = persona.buscarPorDni(_dni);
        }

        public Persona buscar_persona_telefono(long _telefono)
        {
            PersonaDAO persona = new PersonaDAO();
            Persona telefono_found = new Persona();

            // falta implmentear el bloque try-catch.
            return telefono_found = persona.buscarPorTelefono(_telefono); 
        }

        public Persona buscar_persona_email(string _email)
        {
            PersonaDAO persona = new PersonaDAO();
            Persona email_found = new Persona();

            return email_found = persona.buscarPorEmail(_email);    
        }

        public List<Persona> listarPersonas()
        {
            PersonaDAO nuevo = new PersonaDAO();
            List<Persona> lista = new List<Persona>();

            lista = nuevo.listar_personas();

            if (lista == null)
            {
                throw new Exception("No se han encontrado elementos.");
            }
            else
            {
                return lista;
            }
        }

        public Persona updatePersona(Persona datos_modficar)
        {
            PersonaDAO persona = new PersonaDAO();

            try
            {
                return persona.update_persona(datos_modficar);
            }
            catch
            {
                throw new Exception("No se han podido modificar los datos");
            }

        }



    }
}
