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
        private Dictionary<string, string> errores;

        public CN_Articulo() 
        { 
            this.errores = new Dictionary<string, string>();
        }

        public int CrearArticulo(Articulo _articulo)
        { 
            // Si pasa la validacion se ejecuta.

            ArticuloDAO articuloDAO = new ArticuloDAO();
            return articuloDAO.Crear_articulo(_articulo); // Retornar el ID del articulop.
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
                 errores.Add("TBMarca", "El campo Marca no puede estar vacio.");
                 return false;
            }
             
            return true;
        }

        public bool validarNombre(string _nombre)
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                errores.Add("TBNombreArticulo", "El campo Marca no puede estar vacio.");
                return false;
            }

            return true;
        }

        public bool validarContenido(string _contenido)
        {
            if (string.IsNullOrEmpty(_contenido))
            {
                errores.Add("TBContenido", "El campo Marca no puede estar vacio.");
                return false;
            }

            return true;
        }

        public bool validarPrecio(decimal _precio)
        {
            if (_precio < 0)
            {
                errores.Add("TBPrecio", "El campo Precio no puede ser negativo.");
                return false;
            } 

            return true;
        } 

        public Dictionary<string, string> mostrarErrores()
        {
            return this.errores;
        }

    }
}
