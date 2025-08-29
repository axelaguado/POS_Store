using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Detalle_venta
    {
        public int id_detalle { get; set; }
        
        public int id_venta { get; set; }
        
        public long id_producto { get; set; }
        
        public int cantidad_producto { get; set; }
        
        public decimal precio_unitario { get; set; }
        
        public decimal subtotal { get; set; }

        // Propiedad de navegacion.
        public Producto producto { get; set; }

        public Venta venta { get; set; }

    }
}
