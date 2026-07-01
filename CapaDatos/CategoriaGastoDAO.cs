using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class CategoriaGastoDAO
    {
        private readonly MiDbContext context;

        public CategoriaGastoDAO(MiDbContext _context) 
        { 
            this.context = _context;     
        }

        public void CrearCategoria (Categoria_gasto nuevaCategoria) 
        { 
            context.Categorias_gasto.Add(nuevaCategoria); 
        }

        public List<Categoria_gasto> get_AllCategorias()
        {
            return context.Categorias_gasto.ToList();
        }

        public List<Categoria_gasto> get_AllCategoriasActive() 
        {
            return context.Categorias_gasto
                .Where(cg => cg.estado_categoria == true)
                .ToList(); 
        }

        public Categoria_gasto buscarDescripcionCategoria(string _categoria)
        {
            return context.Categorias_gasto.FirstOrDefault(c => c.descripcion_categoria == _categoria);
        }

        public Categoria_gasto buscarIdCategoria(int id_categoria)
        {
            return context.Categorias_gasto.FirstOrDefault(c => c.id_categoria == id_categoria);
        }
         
        // -- UPDATE --
        public Categoria_gasto update_categoria(Categoria_gasto datos_modificados)
        {
            Categoria_gasto categoria_modificar = context.Categorias_gasto.FirstOrDefault(cg => cg.id_categoria == datos_modificados.id_categoria);

            if (categoria_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(categoria_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return categoria_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }

    }
}
