using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pedido { get; set; }

        public int id_proveedor { get; set; }

        public int estado { get; set; }

        public DateTime fecha_emision {  get; set; }  

        public decimal monto_total { get; set; } 

        // Propiedades de navegacion.

        [ForeignKey("id_proveedor")] 
        public Proveedor proveedor { get; set; }

        [ForeignKey("estado")]
        public Estado_Pedido estado_pedido { get; set; }

        public ICollection<Detalle_pedido> detalle_pedido { get; set; } 

    }
}
