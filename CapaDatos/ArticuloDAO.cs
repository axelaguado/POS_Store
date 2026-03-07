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
        public int Crear_articulo(Articulo articulo)
        { 

            // Al usar el bloque using, el contexto MiDbContext es desechado automáticamente cuando termina el bloque de código.
            using (var context = new MiDbContext())
            {
                context.Articulos.Add(articulo);
                context.SaveChanges();
                return articulo.id_articulo;

            }
        }

    }
}
