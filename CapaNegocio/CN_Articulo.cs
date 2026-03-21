using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Articulo
    {
        private Dictionary<string, string> validacion;

        public CN_Articulo() 
        {
            this.validacion = new Dictionary<string, string>();
        }

        public void CrearArticulo(Articulo _articulo)
        {
            using (var context = new MiDbContext())
            { 
                // Si pasa la validacion se ejecuta. 
                ArticuloDAO articuloDAO = new ArticuloDAO(context);
                articuloDAO.Crear_articulo(_articulo); // Retornar el ID del articulop.
            } 
        }

        public bool validarArticulo(Articulo _ariculo)
        {
            if (!validarMarca(_ariculo.marca_articulo))
            {
                return false;
            }

            if (!validarNombre(_ariculo.nombre_articulo))
            {
                return false;
            }

            if (!validarContenido(_ariculo.contenido_articulo))
            {
                return false;
            }

            if (!validarPrecio(_ariculo.precio_unitario))
            {
                return false;
            }
               
            return true;
        } 

        public bool validarMarca(string _marca)
        {
            if (string.IsNullOrEmpty(_marca))
            {
                 validacion.Add("TBMarca", "El campo Marca no puede estar vacio.");
                 return false;
            }
             
            return true;
        }

        public bool validarNombre(string _nombre)
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                validacion.Add("TBNombreArticulo", "El campo Marca no puede estar vacio.");
                return false;
            }

            return true;
        }

        public bool validarContenido(string _contenido)
        {
            if (string.IsNullOrEmpty(_contenido))
            {
                validacion.Add("TBContenido", "El campo Marca no puede estar vacio.");
                return false;
            }

            return true;
        }

        public bool validarPrecio(decimal _precio)
        {
            if (_precio < 0)
            {
                validacion.Add("TBPrecio", "El campo Precio no puede ser negativo.");
                return false;
            } 

            return true;
        }

        public bool ValidarCarrito(List<Articulo> _articulos)
        {  
            foreach (Articulo item in _articulos)
            {
                if (!this.validarArticulo(item))
                {
                    return false;
                }
            }

            return true;
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }

    }
}
