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
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_compra { get; set; }

        public int id_proveedor { get; set; }

        public DateTime fecha_emision {  get; set; }

        public DateTime? fecha_confirmacion { get; set; }

        public decimal monto_total { get; set; } 

        public int estado_compra { get; set; }

        // Propiedades de navegacion.

        [ForeignKey("id_proveedor")] 
        public Proveedor proveedor { get; set; }

        [ForeignKey("estado_compra")]
        public Estado_compra estado { get; set; }

        public ICollection<Detalle_compra> detalles_compra{ get; set; } 

    }
}
