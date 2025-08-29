using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Categoria_producto
    {
        public int id_categoria{ get; set; }
        
        public string descripcion_categoria { get; set; }

        // Propiedad de navegacion.
        public ICollection<Producto> productos { get; set; }
}
}
