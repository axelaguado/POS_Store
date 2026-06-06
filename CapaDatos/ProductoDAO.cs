using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.DTO;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace WindowsFormsApp1.CapaDatos
{
    public class ProductoDAO
    {
        private readonly MiDbContext context;  

        public ProductoDAO(MiDbContext _context) 
        { 
            this.context = _context;
        }

        public void Crear_producto(Producto _producto)
        {
            context.Productos.Add(_producto);
        }

        public void AttachProducto(Producto _producto) 
        {
            context.Productos.Attach(_producto);
        }

        public Producto GetProducto(int _id)
        {
            return context.Productos.Include(pr => pr.categoria).FirstOrDefault(p => p.id_producto == _id);
        } 

        public Producto GetProducto(string _sku) 
        {
            return context.Productos.FirstOrDefault(p => p.sku_producto == _sku); 
        }

        public bool SkuExist(Producto _producto)
        {
            return context.Productos.Any(pr => pr.sku_producto == _producto.sku_producto && pr.id_producto != _producto.id_producto); 
        }

        public List<Producto> GetProductos()
        {
            return context.Productos.Include(pr => pr.categoria).ToList();
        }

        public List<ProductoDTO> GetProductosDTO()
        {
            return context.Productos.Where(pr => pr.estado_producto == true)
                                    .Select(pr => new ProductoDTO 
                                    {
                                        id_producto = pr.id_producto,
                                        producto = pr.nombre_producto + " " + pr.descripcion_producto + ", " + pr.contenido_producto,
                                        sku_producto = pr.sku_producto,
                                        estado = pr.estado_producto
                                    })   
                                    .ToList();
        }


        public ProductoDTO GetProductoDTO(string _sku)
        {
            return context.Productos.Where(pr => pr.sku_producto == _sku && pr.estado_producto == true)
                                    .Select(pr => new ProductoDTO
                                    {
                                        id_producto = pr.id_producto,
                                        producto = pr.nombre_producto + " " + pr.descripcion_producto + ", " + pr.contenido_producto,
                                        sku_producto = pr.sku_producto,
                                        estado = pr.estado_producto
                                    })
                                    .FirstOrDefault();
        }

        public async Task<List<Producto>> GetProductos(CancellationToken _token, string _elemento)
        {
            return await context.Productos.Include(pr => pr.categoria)
                                            .Where(
                                                pr => pr.marca_producto.Contains(_elemento) || 
                                                pr.nombre_producto.Contains(_elemento) ||
                                                pr.sku_producto.StartsWith(_elemento))
                                            .ToListAsync(_token);
        }

        public async Task<List<Producto>> GetProductosDTO(CancellationToken _token, string _elemento)
        {
            return await context.Productos.Where( pr => (pr.estado_producto == true) &&
                                                    ( pr.nombre_producto.Contains(_elemento) || pr.contenido_producto.Contains(_elemento) || pr.descripcion_producto.Contains(_elemento)) 
                                                ) 
                                            .ToListAsync(_token);
        }

        public Producto update_producto(Producto datos_modificados)
        {
            Producto producto_modificar = context.Productos.FirstOrDefault(pr => pr.id_producto == datos_modificados.id_producto);

            if (producto_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(producto_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return producto_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }

    }
}
