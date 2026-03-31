using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class ItemCarrito
    { 
        public string marca_articulo { get; set; }

        public string nombre_articulo { get; set; }

        public string descripcion_articulo { get; set; }

        public string contenido_articulo { get; set; }

        public decimal precio_unitario { get; set; }

        public int cantidad { get; set; }
         
    }
}
