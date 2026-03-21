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
        private Dictionary<string, string> validacion = new Dictionary<string, string>();

        public CN_Direccion() 
        { 
            this.validacion = new Dictionary<string, string>();
        }

        public void CrearDireccion(Direccion _direccion)
        {   
            using (var context = new MiDbContext()) 
            { 
                DireccionDAO direccionDAO = new DireccionDAO(context);
                direccionDAO.Crear_direccion(_direccion); // Retornar el ID de la dirección 
            }
            
        }  
        public Dictionary<string, string> ValidarDireccion(Direccion _direccion)
        { 
            // Validamos que la direccion no sea nula. 
            if (_direccion == null)
            {
                validacion.Add("Direccion", "Los datos del domicilio no son validos");
            }

            // Validaciones para el atributo calle. 
            if (string.IsNullOrEmpty(_direccion.calle))
            {
                validacion.Add("TBCalle", "El campo calle es obligatorio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_direccion.calle, @"^[a-zA-Z\s]+$"))
            {
                validacion.Add("TBCalle", "El campo calle solo acepeta caracteres alfabeticos.");
            }
            else if (_direccion.calle.Length > 100)
            {
                validacion.Add("TBCalle", "El campo calle supera el numero (100) de caracteres permitido");
            }

            // Validaciones para el atributo altura. 
            if (string.IsNullOrEmpty(Convert.ToString(_direccion.altura)))
            {
                validacion.Add("TBAltura", "El campo altura es obligatorio.");
            }
            else if (!int.TryParse(Convert.ToString(_direccion.altura), out _))
            {
                validacion.Add("TBAltura", "El campo altura solo acepta caracteres numericos.");
            }
            else if (_direccion.altura < 0)
            {
                validacion.Add("TBAltura", "El campo altura no debe ser un valor negativo.");
            }
           
            return validacion; 

        } 

        public Direccion buscar_direccion(int id_direccion)
        {
            using (var context = new MiDbContext()) 
            {
                DireccionDAO direcciom = new DireccionDAO(context);
                Direccion direccion_found = new Direccion();

                return direccion_found = direcciom.buscar_direccion_id(id_direccion);
            } 
        }

        public Direccion updateDireccion(Direccion datos_modificar)
        {
            using (var context = new MiDbContext())
            {
                DireccionDAO direccion = new DireccionDAO(context);
                return direccion.update_direccion(datos_modificar);
            }   
        }

        public List<Direccion> listarDirecciones()
        {
            using (var context = new MiDbContext())
            {
                DireccionDAO nuevo = new DireccionDAO(context);
                List<Direccion> lista = nuevo.listar_direcciones();

                return lista;
            } 
        } 

    }
}
