using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Producto
    { 
        private Dictionary<string, string> validacion;

        public CN_Producto()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public int CrearProducto(Producto _producto)
        {
            this.validacion.Clear();

            CN_CategoriaProducto categoriaProducto = new CN_CategoriaProducto(); 

            bool existe_categoria = categoriaProducto.ExisteCategoria(_producto.categoria_producto);
            this.validarProducto(_producto);  

            if (this.validacion.Count() == 0 && existe_categoria) 
            {    
                using (var context = new MiDbContext())
                {
                    // Si pasa la validacion se ejecuta. 
                    ProductoDAO productoDAO = new ProductoDAO(context); 
                    _producto.estado_producto = true;
                    productoDAO.Crear_producto(_producto); // Retornar el ID del articulop.
                    return context.SaveChanges();
                } 
            }
            else 
            { 
                return 0;
            }
        }

        public Dictionary<string, string> validarProducto(Producto _producto)
        {
            this.validacion.Clear();

            this.validarMarca(_producto.marca_producto); 
            this.validarNombre(_producto.nombre_producto); 
            this.validarDescripcion(_producto.descripcion_producto);
            this.validarContenido(_producto.contenido_producto); 
            this.validarStock(_producto.stock_producto);
            this.validarStockMinimo(_producto.stock_minimo); 
            this.validarPrecioCosto(_producto.precio_costo);
            this.validarPrecioVenta(_producto.precio_venta); 
            this.validarSku(_producto);  

            return this.validacion;
        }

        public List<Producto> Get_Productos() 
        {
            using (var context = new MiDbContext())
            {
                // Si pasa la validacion se ejecuta. 
                ProductoDAO productoDAO = new ProductoDAO(context); 
                return productoDAO.GetProductos(); // Retornar el ID del articulop.
            }
        }

        public async Task<List<Producto>> Get_Productos(CancellationToken _token, string _elemento) 
        {
            using (var context = new MiDbContext())
            {
                // Si pasa la validacion se ejecuta. 
                ProductoDAO productoDAO = new ProductoDAO(context);
                return await productoDAO.GetProductos(_token, _elemento); // Retornar el ID del articulop.
            }
        }

        public Producto Get_Producto(int _id)
        {
            using (var context = new MiDbContext())
            {
                // Si pasa la validacion se ejecuta. 
                ProductoDAO productoDAO = new ProductoDAO(context);
                return productoDAO.GetProducto(_id); // Retornar el ID del articulop.
            }
        }

        public int UpdateProducto(Producto datos_modficar)
        {
            this.validarProducto(datos_modficar);

            if (this.validacion.Count() == 0) 
            { 
                using (var context = new MiDbContext())
                { 
                    ProductoDAO producto = new ProductoDAO(context);

                    Producto producto_modificado = producto.update_producto(datos_modficar); 
                    context.SaveChanges();

                    return producto_modificado.id_producto;
                }
            }
            else
            {
                return 0;
            }
        }

        public Producto UpdateProductoEstado(Producto datos_modficar)
        { 
            using (var context = new MiDbContext())
            {
                ProductoDAO producto = new ProductoDAO(context);

                Producto producto_modificado = producto.update_producto(datos_modficar);
                context.SaveChanges();

                return producto_modificado; 
            } 
        }

        public void validarMarca(string _marca)
        {
            if (string.IsNullOrEmpty(_marca))
            {
                this.validacion.Add("TBMarcaProducto", "El campo Marca no puede estar vacio."); 
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_marca, @"^[a-zA-Z0-9\s\-]+$"))
            {
                this.validacion.Add("TBMarcaProducto", "El campo Marca solo puede contener caracteres alfabeticos, numericos, espacios y guiones.");
            }
            else if (_marca.Length > 50) 
            {
                this.validacion.Add("TBMarcaProducto", "El campo Marca supera la cantidad de caracteres(50) posibles.");
            }
        }

        public void validarNombre(string _nombre)
        {
            if (string.IsNullOrEmpty(_nombre))
            {
                this.validacion.Add("TBNombreProducto", "El campo Producto no puede estar vacio."); 
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_nombre, @"^[a-zA-Z\s\-]+$"))
            {
                this.validacion.Add("TBNombreProducto", "El campo Producto solo puede contener caracteres alfabeticos, numericos, espacios y guiones.");
            }
            else if (_nombre.Length > 50) 
            {
                this.validacion.Add("TBNombreProducto", "El campo Producto supera la cantidad de caracteres(50) posibles.");
            }
        }
         
        public void validarDescripcion(string _descripcion)
        {
            if (!string.IsNullOrEmpty(_descripcion))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(_descripcion, @"^[a-zA-Z0-9\s,.]+$"))
                {
                    this.validacion.Add("TBDescripcionProducto", "El campo Descripcion solo puede contener caracteres alfabeticos (.,), numericos y espacios.");
                }
                else if (_descripcion.Length > 200)
                {
                    this.validacion.Add("TBDescripcionProducto", "El campo Descripcion supera la cantidad de caracteres(200) posibles.");
                } 
            }
        } 

        public void validarContenido(string _contenido)
        {
            if (string.IsNullOrEmpty(_contenido))
            {
                this.validacion.Add("TBContenidoProducto", "El campo Contenido no puede estar vacio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_contenido, @"^[a-zA-Z0-9\s,.]+$"))
            {
                this.validacion.Add("TBContenidoProducto", "El campo Contenido solo puede contener caracteres alfabeticos (.,), numeros y espacios.");
            }
            else if (_contenido.Length > 50)
            {
                this.validacion.Add("TBContenidoProducto", "El campo Contenido supera la cantidad de caracteres(50) posibles.");
            }
        }

        public void validarStock(int _stock)
        { 
            if (_stock < 0)
            {
                this.validacion.Add("TBStockProducto", "El campo Stock debe ser mayor o igual a cero."); 
            }  
        }

        public void validarStockMinimo(int _stock)
        {
            if (_stock < 0)
            {
                this.validacion.Add("TBStockMinimo", "El campo Stock Minimo debe ser mayor o igual a cero."); 
            }  
        } 

        public void validarPrecioCosto(decimal _precio)
        { 
            if (_precio < 0)
            {
                this.validacion.Add("TBPrecioCosto", "El campo Precio Costo debe ser mayor o igual a cero."); 
            } 
            else if (decimal.Round(_precio, 2) != _precio)
            {
                this.validacion.Add("TBPrecioCosto", "El campo Precio Costo solo acepta valores con hasta dos decimales");
            }
        }

        public void validarPrecioVenta(decimal _precio)
        {
            if (_precio < 0)
            {
                this.validacion.Add("TBPrecioVenta", "El campo Precio Venta debe ser mayor o igual a cero.");
            }
            else if (decimal.Round(_precio, 2) != _precio)
            {
                this.validacion.Add("TBPrecioVenta", "El campo Precio Venta solo acepta valores con hasta dos decimales");
            } 
        } 

        public void validarSku(Producto _producto)
        {
            if (!string.IsNullOrEmpty(_producto.sku_producto))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(_producto.sku_producto, @"^[a-zA-Z0-9]+$"))
                {
                    this.validacion.Add("TBSkuProducto", "El campo Codigo solo puede contener caracteres alfabeticos y numericos.");
                }
                else if (this.ExisteSku(_producto))
                {
                    this.validacion.Add("TBSkuProducto", "El Codigo ingresado ya se encuentra en uso.");
                } 
            } 
        }

        public bool ExisteSku(Producto _producto) 
        {
            using (var context = new MiDbContext()) 
            { 
                ProductoDAO producto = new ProductoDAO(context);
                return producto.SkuExist(_producto); 
            } 
        }

        public bool ValidarCarrito(List<Producto> _productos)
        {
            foreach (Producto item in _productos)
            {
                if (this.validarProducto(item).Count > 0)
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

        public Dictionary<string, string> unirDiccionarios(Dictionary<string, string> _diccionario)
        {
            if (_diccionario != null)
            {
                foreach (var error in _diccionario)
                {
                    validacion[error.Key] = error.Value; // Agrega o actualiza
                }
            }

            return validacion;
        }

    }
}
