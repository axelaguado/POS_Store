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
    internal class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pedido { get; set; }

        public int id_proveedor { get; set; }   

        public DateTime fecha_solicitud {  get; set; }  

        public decimal monto_total { get; set; }

        public string estado { get; set; }

        // ------------------------------------------------------

        [ForeignKey("id_proveedor")]

        public Proveedor proveedor { get; set; } 

        public ICollection<Detalle_pedido> detalles { get; set; }   



    }
}
