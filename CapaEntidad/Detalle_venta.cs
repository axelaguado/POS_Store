using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Detalle_venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_detalle { get; set; }
        
        public int id_venta { get; set; }
        
        public int id_producto { get; set; }
        
        public int cantidad_producto { get; set; }
        
        public decimal precio_costo { get; set; }

        public decimal precio_unitario { get; set; }

        public decimal subtotal { get; set; }

        // Propiedad de navegacion.
        [ForeignKey("id_venta")]
        public Venta venta { get; set; }

        [ForeignKey("id_producto")]
        public Producto producto { get; set; }
    }
}
