using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    internal class Detalle_pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_detalle { get; set; }

        public int id_pedido { get; set; }
         
        public Articulo articulo { get; set; }  

        public int cantidad { get; set; }

        public decimal subtotal { get; set; }

        // ---------------------------------------------- 
        
        [ForeignKey("id_pedido")]
        
        public Pedido pedido { get; set; }  
    }
}
