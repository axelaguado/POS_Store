using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class CategoriaProductoDAO
    {
        private readonly MiDbContext context;

        public CategoriaProductoDAO(MiDbContext _context) 
        { 
            this.context = _context;    
        }

        public void Crear_categoria(Categoria_producto _nueva) 
        {
             this.context.Categorias.Add(_nueva);
        }

        public bool Existe_categoria(string _categoria)
        {
            return context.Categorias.Any(c => c.descripcion_categoria == _categoria); 
        }

        public bool Existe_categoria(int id_categoria)
        {
             return context.Categorias.FirstOrDefault(c => c.id_categoria == id_categoria) != null? true : false;
        }


        public List<Categoria_producto> listar_Categorias()
        {
            return context.Categorias.ToList();
        }
    }
}
