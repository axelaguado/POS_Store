using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;


namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_CategoriaProducto
    {
        public Dictionary<string, string> validacion;

        public CN_CategoriaProducto()
        {
            this.validacion = new Dictionary<string, string>(); 
        }

        public void CrearCategoria(Categoria_producto _nueva) 
        {
            using (var _context = new MiDbContext()) 
            { 
                CategoriaProductoDAO categoriaDAO = new CategoriaProductoDAO(_context);
                categoriaDAO.Crear_categoria(_nueva);  
                _context.SaveChanges();
            } 
        }

        public Dictionary<string, string> ValidarCategoria(Categoria_producto _categoria) 
        {
            this.validacion.Clear();

            if (string.IsNullOrEmpty(_categoria.descripcion_categoria))
            {
                this.validacion.Add("TBCategoriaProducto", "El campo Categoria no puede estar vacio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_categoria.descripcion_categoria, @"^[a-zA-Z\s]+$"))
            {
                this.validacion.Add("TBCategoriaProducto", "El campo Categoria solo puede contener letras y espacios.");
            }
            else if (this.ExisteCategoria(_categoria.descripcion_categoria))
            {
                this.validacion.Add("TBCategoriaProducto", "La categoria ya existe.");
            }

            return this.validacion;
        } 

        public bool ExisteCategoria(string _categoria) 
        {
            using (var _context = new MiDbContext())
            {
                CategoriaProductoDAO categoriaDAO = new CategoriaProductoDAO(_context);
                return categoriaDAO.Existe_categoria(_categoria);
            }
        }

        public bool ExisteCategoria(int id_categoria)
        {
            using (var _context = new MiDbContext())
            {
                CategoriaProductoDAO categoriaDAO = new CategoriaProductoDAO(_context);
                return categoriaDAO.Existe_categoria(id_categoria);
            }
        }

        public List<Categoria_producto> listarCategorias() 
        {
            using (var _context = new MiDbContext())
            {
                CategoriaProductoDAO categoriaDAO = new CategoriaProductoDAO(_context);
                return categoriaDAO.listar_Categorias();
            } 
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }



    }
}
