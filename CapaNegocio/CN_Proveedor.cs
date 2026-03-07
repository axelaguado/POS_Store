using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Proveedor
    {
        Dictionary<string, string> errores;

        public CN_Proveedor()
        {
            this.errores = new Dictionary<string, string>();
        } 

        public int CrearProveedor(Proveedor _proveedor)
        {   
            // Deberia preguntar si se cumple ValidarProveedor y utilizar los bloques Try - catch.

            ProveedorDAO proveedorDAO = new ProveedorDAO();
            return proveedorDAO.Crear_proveedor(_proveedor); // Retornar el ID de la dirección
        }

        public bool ValidarProveedor(Proveedor _proveedor) 
        { 
            if (!validarRazonSocial(_proveedor.razon_social))
            {
                return false;
            }

            if (!validarCUIT(_proveedor.CUIT))
            {
                return false;
            }

            if (!validarNombreComercial(_proveedor.nombre_comercial))
            {
                return false;
            }

            if (!validarCodPostal(_proveedor.cod_postal))
            {
                return false;
            }

            if (!validarTelefono(_proveedor.telefono))
            {
                return false;
            }

            if (!validarEmail(_proveedor.email))
            {
                return false;
            }

            if (!validarSitioWeb(_proveedor.sitio_web))
            {
                return false;
            }

            return true;
        }

        public bool validarRazonSocial(string _razon)
        {  
            // Validaciones para campo Razon Social.  
            if (this.existeRazon(_razon)) 
            {
                errores.Add("CBRazonSocial", "La Razon Social ingresada ya existe.");
                return false;
            }

            return true;
        }

        public bool validarCUIT(long _cuit) 
        { 
            // Validaciones para campo Dni.  
            /*
            if (!long.TryParse(Convert.ToString(_cuit), out _))
            {
                errores.Add("TBCuit", "El campo CUIT debe contener un valor numerico.");
                return false;
            }
            */
            if (_cuit > 99999999999)
            {
                errores.Add("TBCuit", "El campo CUIT no puede tener mas de 11 cifras.");
                return false;
            }
            else if (this.buscarProveedor(_cuit) != null)
            {
                errores.Add("TBCuit", "El CUIT ingresado ya existe."); 
                return false;
            }

            return true;
        }

        public bool validarNombreComercial(string _nombre)
        { 
            // Validaciones para campo Nombre Comercial. 
            if (string.IsNullOrEmpty(_nombre))
            {
                errores.Add("TBNombreComercial", "El campo Nombre Comercial no puede estar vacio.");
                return false;

            }  
            else if (this.existeNombreComercial(_nombre))
            {
                errores.Add("TBNombreComercial", "El  Nombre Comercial ingresado ya existe.");
                return false;
            }

            return true;
        }

        public bool validarCodPostal(int _codigo)
        { 
            // Validaciones para campo Dni. 
            if (string.IsNullOrEmpty(Convert.ToString(_codigo)))
            {
                errores.Add("TBCodPostal", "El campo Codigo Postal no puede estar vacio.");
                return false;

            }
            else if (!int.TryParse(Convert.ToString(_codigo), out _))
            {
                errores.Add("TBCodPostal", "El campo Codigo Postal debe contener un valor numerico.");
                return false;
            }
            else if (_codigo > 9999)
            {
                errores.Add("TBCodPostal", "El campo Codigo Postal no puede tener mas de 4 cifras.");
                return false;
            }

            return true;
        }


        public bool validarTelefono(long _telefono)
        { 
            // Validacion para campo telefono. 
            if (!long.TryParse(Convert.ToString(_telefono), out _))
            {
                errores.Add("TBTelefono", "El campo telefono solo puede contener numeros");
                return false;
            }
            if (this.existeTelefono(_telefono))  
            {
                errores.Add("TBTelefono", "El campo telefono ya se encuentra en uso");
                return false;
            }

            return true;
        } 

        public bool validarEmail(string _email)
        { 
            // Validacion para campo Email.  
            if (!System.Text.RegularExpressions.Regex.IsMatch(_email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errores.Add("TBEmail", "El campo email no contiene el formato correspondiente.");
                return false;
            }
            else if (this.existeEmail(_email))
            {
                errores.Add("TBEmail", "El email ingresado corresponde a una cuenta en uso.");
                return false;
            } 

            return true;
        }

        public bool validarSitioWeb(string _sitio)
        { 
            // Validaciones para campo Sitio. 
            if (!System.Text.RegularExpressions.Regex.IsMatch(_sitio, @"www\.[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"))
            {
                errores.Add("TBSitioWeb", "El Sitio Web ingresado no tiene un formato estandar de dominio.");
                return false;
            }

            return true;
        }
         
        public Dictionary<string, string> mostrarErrores()
        {
            return this.errores;
        }

        public Proveedor buscarProveedor(long _cuit) 
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            Proveedor proveedor = new Proveedor();

            proveedor = proveedorDAO.buscar_Proveedor(_cuit);

            return proveedor; 
        }

        public bool existeRazon(string _razon)
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            Proveedor proveedor = new Proveedor();

            proveedor = proveedorDAO.buscar_Razon(_razon);

            if (proveedor != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existeTelefono(long _telefono)
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            Proveedor proveedor = new Proveedor();

            proveedor = proveedorDAO.buscar_Telefono(_telefono);

            if (proveedor != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existeEmail(string _email)
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            Proveedor proveedor = new Proveedor();

            proveedor = proveedorDAO.buscar_Email(_email);

            if (proveedor != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existeNombreComercial(string _nombreComercial)
        {
            ProveedorDAO proveedorDAO = new ProveedorDAO();
            Proveedor proveedor = new Proveedor();

            proveedor = proveedorDAO.buscar_NombreComercial(_nombreComercial);

            if (proveedor != null) 
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}
