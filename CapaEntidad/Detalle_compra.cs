using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Detalle_compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_detalle { get; set; }

        public int id_compra { get; set; } 

        public int id_producto { get; set; }    

        public int cantidad_producto { get; set; }

        public decimal subtotal_producto { get; set; }

        public string informacion_acerca { get; set; }
         
        // ---------------------------------------------- 
        
        [ForeignKey("id_compra")]
        
        public Compra compra { get; set; }

        [ForeignKey("id_producto")] 

        public Producto producto { get; set; }

    }
}
