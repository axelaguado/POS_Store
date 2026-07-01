using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_CategoriaGasto
    {
        public Dictionary<string, string> validacion;

        public CN_CategoriaGasto()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public int CrearCategoria(Categoria_gasto _nueva)
        {
            this.ValidarCategoria(_nueva);

            if (this.validacion.Count == 0) 
            { 
                using (var _context = new MiDbContext())
                {
                    CategoriaGastoDAO categoriaDAO = new CategoriaGastoDAO(_context);
                    _nueva.estado_categoria = true;
                    categoriaDAO.CrearCategoria(_nueva);
                    return _context.SaveChanges();
                } 
            }

            return 0;
        }

        public Categoria_gasto UpdateCategoriaEstado(Categoria_gasto _actualizar)
        {
            using (var _context = new MiDbContext())
            {
                CategoriaGastoDAO categoriaDAO = new CategoriaGastoDAO(_context);
                Categoria_gasto actualizado = categoriaDAO.update_categoria(_actualizar);
                if (_context.SaveChanges() > 0) return actualizado;
            }

            return null;
        }

        public Dictionary<string, string> ValidarCategoria(Categoria_gasto _categoria)
        {
            this.validacion.Clear();

            if (string.IsNullOrEmpty(_categoria.descripcion_categoria))
            {
                this.validacion.Add("TBNuevaCategoria", "El campo Categoria no puede estar vacio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_categoria.descripcion_categoria, @"^[a-zA-Z\s]+$"))
            {
                this.validacion.Add("TBNuevaCategoria", "El campo Categoria solo puede contener letras y espacios.");
            }
            else if (this.GetDescipcionCategoria(_categoria.descripcion_categoria) != null)
            {
                this.validacion.Add("TBNuevaCategoria", "La categoria ya existe.");
            }

            return this.validacion;
        }

        public List<Categoria_gasto> AllCategories()
        {
            using (var _context = new MiDbContext())
            {
                CategoriaGastoDAO categoriaDAO = new CategoriaGastoDAO(_context);
                return categoriaDAO.get_AllCategorias();
            }
        }


        public List<Categoria_gasto> AllCategoriesActive() 
        {
            using (var _context = new MiDbContext())
            {
                CategoriaGastoDAO categoriaDAO = new CategoriaGastoDAO(_context);
                return categoriaDAO.get_AllCategoriasActive();
            }
        } 

        public Categoria_gasto GetDescipcionCategoria(string _categoria)
        {
            using (var _context = new MiDbContext())
            {
                CategoriaGastoDAO categoriaDAO = new CategoriaGastoDAO(_context);
                return categoriaDAO.buscarDescripcionCategoria(_categoria);
            }
        }

        public Categoria_gasto GetIdCategoria(int id_categoria)
        {
            using (var _context = new MiDbContext())
            {
                CategoriaGastoDAO categoriaDAO = new CategoriaGastoDAO(_context);
                return categoriaDAO.buscarIdCategoria(id_categoria);
            }
        } 
          
        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }   
    }
}

