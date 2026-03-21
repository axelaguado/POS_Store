using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Contacto
    {
        public CN_Contacto() { }

        public void CrearContacto (Contacto _contacto) 
        {
            using (var context = new MiDbContext()) 
            { 
                ContactoDAO nuevocontacto = new ContactoDAO(context);
                nuevocontacto.Crear_contacto(_contacto); 
            } 
        }

        public Contacto BuscarContacto(string _email)
        {
            using (var context = new MiDbContext())
            {
                ContactoDAO nuevocontacto = new ContactoDAO(context);
                return nuevocontacto.Buscar_email(_email);
            }
        }

        public Dictionary <string, string> ValidarContacto(Contacto _contacto) 
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();

            if (_contacto == null)
            {
                errores.Add("Contacto", "Los datos del domicilio no son validos");
            }

            // Validaciones para campo email. 
            if (string.IsNullOrEmpty(_contacto.email))
            {
                errores.Add("TBEmail", "El campo email es obligatorio");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_contacto.email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errores.Add("TBEmail", "El campo email no contiene el formato correspondiente.");
            }
            else if (this.Email_Exist(_contacto))
            {
                errores.Add("TBEmail", "El email ingresado corresponde a una cuenta en uso.");
            }

            // Validacion para campo telefono. 
            if (string.IsNullOrEmpty(Convert.ToString(_contacto.telefono)))
            {
                errores.Add("TBTelefono", "El campo telefono es obligatorio.");
            }
            else if (!long.TryParse(Convert.ToString(_contacto.telefono), out _))
            {
                errores.Add("TBTelefono", "El campo telefono solo puede contener numeros");
            }

            // Validaciones para campo Sitio. 
            if (!string.IsNullOrEmpty(Convert.ToString(_contacto.sitio_web)))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(_contacto.sitio_web, @"www\.[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"))
                {
                    errores.Add("TBSitioWeb", "El Sitio Web ingresado no tiene un formato estandar de dominio.");
                }
            } 
             
            return errores; 
        } 

        public bool Email_Exist (Contacto _contacto) 
        {
            using (var context = new MiDbContext()) 
            { 
                ContactoDAO contacto = new ContactoDAO(context);
                return contacto.EmailExist(_contacto);
            }
        }

        public Contacto UpdateContacto(Contacto _contacto)
        {
            using (var context = new MiDbContext())
            {
                ContactoDAO contacto = new ContactoDAO(context);
                return contacto.update_contacto(_contacto);
            }
        }
    }
}
