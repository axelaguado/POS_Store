using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class ArticuloDAO
    {
        private readonly MiDbContext _context;

        public ArticuloDAO(MiDbContext context)
        {
            _context = context;
        }

        public void Crear_articulo(Articulo articulo)
        {
            _context.Articulos.Add(articulo);  
        }

        public List<Articulo> Crear_articulos(List<Articulo> _articulos)
        {
            foreach (Articulo item in _articulos)
            {
                _context.Articulos.Add(item); 
            }

            return _articulos;
        }
    } 
}
