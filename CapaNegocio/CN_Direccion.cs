using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaPresentacion;

namespace WindowsFormsApp1.CapaEntidad
{
    public class CN_Direccion
    {

        public int CrearDireccion(Direccion _direccion)
        {
            /*
            if ( this.ValidarDireccion(_direccion).Count != 0)
            {
                throw new ArgumentException("No se pudo registrar la dirección. Corrobore los datos suministrados.");
            }
            */

            DireccionDAO direccionDAO = new DireccionDAO();
            return direccionDAO.Crear_direccion(_direccion); // Retornar el ID de la dirección
        }

        public Dictionary<string, string> ValidarDireccion(Direccion _direccion)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();

            // Validamos que la direccion no sea nula.
           
            if (_direccion == null)
            {
                errores.Add("Direccion", "Los datos del domicilio no son validos");
            }

            // Validaciones para el atributo calle.

            if (string.IsNullOrEmpty(_direccion.calle))
            {
                errores.Add("TBCalle", "El campo calle es obligatorio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_direccion.calle, @"^[a-zA-Z\s]+$"))
            {
                errores.Add("TBCalle", "El campo calle solo acepeta caracteres alfabeticos.");
            }
            else if (_direccion.calle.Length > 100)
            {
                errores.Add("TBCalle", "El campo calle supera el numero (100) de caracteres permitido");
            }

            // Validaciones para el atributo altura.

            if (string.IsNullOrEmpty(Convert.ToString(_direccion.altura)))
            {
                errores.Add("TBAltura", "El campo altura es obligatorio.");
            }
            else if (!int.TryParse(Convert.ToString(_direccion.altura), out _))
            {
                errores.Add("TBAltura", "El campo altura solo acepta caracteres numericos.");
            }
            else if (_direccion.altura < 0)
            {
                errores.Add("TBAltura", "El campo altura no debe ser un valor negativo.");
            }
           
            return errores; 

        }

        public Dictionary<string, string> validarCalle(string _calle ) 
        { 
            Dictionary<string, string> errores = new Dictionary<string, string>();


            if (string.IsNullOrEmpty(_calle))
            {
                errores.Add("TBCalle", "El campo calle es obligatorio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_calle, @"^[a-zA-Z\s]+$"))
            {
                errores.Add("TBCalle", "El campo calle solo acepeta caracteres alfabeticos.");
            }
            else if (_calle.Length > 100)
            {
                errores.Add("TBCalle", "El campo calle supera el numero (100) de caracteres permitido");
            }

            return errores;
        }

        public Dictionary<string, string> validarAltura(int _altura)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(Convert.ToString(_altura)))
            {
                errores.Add("TBAltura", "El campo altura es obligatorio.");
            }
            else if (!int.TryParse(Convert.ToString(_altura), out _))
            {
                errores.Add("TBAltura", "El campo altura solo acepta caracteres numericos.");
            }
            else if (_altura <= 0)
            {
                errores.Add("TBAltura", "El campo altura no debe ser un valor negativo.");
            }

            return errores;
        }

        public Direccion buscar_direccion(int id_direccion)
        {
            DireccionDAO direcciom = new DireccionDAO();
            Direccion direccion_found = new Direccion();

            return direccion_found = direcciom.buscar_direccion_id(id_direccion);
        }

        public Direccion updateDireccion(Direccion datos_modificar)
        {
            DireccionDAO direccion = new DireccionDAO(); 

            try
            {
                return direccion.update_direccion(datos_modificar);
            }
            catch
            {
                throw new Exception("No se han podido modificar los datos");
            }
        }

        public List<Direccion> listarDirecciones()
        {
            DireccionDAO nuevo = new DireccionDAO();
            List<Direccion> lista = new List<Direccion>();

            lista = nuevo.listar_direcciones();

            if (lista == null)
            {
                throw new Exception("No se han encontrado elementos.");
            }
            else
            {
                return lista;
            }
        }


    }
}
