using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_PersonaJuridica
    {
        private Dictionary<string, string> validacion;

        public CN_PersonaJuridica()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public void CrearPersonaJurica(PersonaJuridica _personajuridica)
        {
            using (var context = new MiDbContext())
            {
                // Ejecutamos si se supera al validacion del detalle. 
                PersonaJuridicaDAO personaDAO = new PersonaJuridicaDAO(context);
                personaDAO.Crear_personajuridica(_personajuridica); // Retornar el ID del detalle.  
            }
        }

        public Dictionary<string, string> ValidarPersonaJuridica(PersonaJuridica _personajuridica)
        {
            this.validacion.Clear();

            this.validarRazonSocial(_personajuridica);
            this.validarCUIT(_personajuridica);
            this.validarNombreComercial(_personajuridica); 
              
            return this.validacion;
        }

        public void validarRazonSocial(PersonaJuridica _personajuridica)
        {
            // Validaciones para campo Razon Social.  
            if (this.existeRazon(_personajuridica))
            {
                validacion.Add("TBRazonSocial", "La Razon Social ingresada ya existe."); 
            } 
        }

        public void validarCUIT(PersonaJuridica _personajuridica)
        {
            // Validaciones para campo Dni.  
            /*
            if (!long.TryParse(Convert.ToString(_cuit), out _))
            {
                errores.Add("TBCuit", "El campo CUIT debe contener un valor numerico.");
                return false;
            }
            */
            if (_personajuridica.cuit > 99999999999)
            {
                validacion.Add("TBCuit", "El campo CUIT no puede tener mas de 11 cifras."); 
            }
            else if (this.existeCuit(_personajuridica)) 
            {
                validacion.Add("TBCuit", "El CUIT ingresado ya existe."); 
            } 
        }

        public void validarNombreComercial(PersonaJuridica _personajuridica)
        {
            // Validaciones para campo Nombre Comercial. 
            if (string.IsNullOrEmpty(_personajuridica.nombre_comercial))
            {
                validacion.Add("TBNombreComercial", "El campo Nombre Comercial no puede estar vacio."); 

            }
            else if (this.existeNombreComercial(_personajuridica))
            {
                validacion.Add("TBNombreComercial", "El  Nombre Comercial ingresado ya existe."); 
            } 
        }

        public bool existeRazon(PersonaJuridica _personajuridica)
        {
            using (var context = new MiDbContext()) 
            { 
                PersonaJuridicaDAO personajuridicaDAO = new PersonaJuridicaDAO(context);  
                bool resultado = personajuridicaDAO.RazonSocialExist(_personajuridica);

                return resultado;
            } 
        }
  
        public bool existeNombreComercial(PersonaJuridica _personajuridica)
        {
            using (var context = new MiDbContext())
            {
                PersonaJuridicaDAO personajuridicaDAO = new PersonaJuridicaDAO(context);
                bool resultado = personajuridicaDAO.NombreComercialExist(_personajuridica);

                return resultado;
            }
        }

        public bool existeCuit(PersonaJuridica _personajuridica)
        {
            using (var context = new MiDbContext())
            {
                PersonaJuridicaDAO personajuridicaDAO = new PersonaJuridicaDAO(context);
                bool resultado = personajuridicaDAO.CuitExist(_personajuridica);

                return resultado;
            }
        }

        public PersonaJuridica GetPersonaJuridica(string razon, long cuit) 
        {
            using (var context = new MiDbContext())
            {
                PersonaJuridicaDAO personajuridicaDAO = new PersonaJuridicaDAO(context);
                PersonaJuridica resultado = personajuridicaDAO.GetPersonaJuridica(razon, cuit);

                return resultado;
            }
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }
    }
}
