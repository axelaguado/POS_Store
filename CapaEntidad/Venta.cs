using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Venta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_venta{ get; set; }
        
        public int id_caja { get; set; } 

        public int id_cliente{ get; set; }

        public DateTime fecha_venta { get; set; }

        public decimal monto_venta{ get; set; }

        public bool estado_venta { get; set; }

        // Propiedad de navegacion --> permite acceder y gestionar entidades relacionadas de forma fácil y eficiente
        // dentro de Entity Framework, manteniendo la relación entre ellas en el nivel de objetos.
        [ForeignKey("id_caja")]
        public Caja caja { get; set; }

        [ForeignKey("id_cliente")]
        public Cliente cliente { get; set; }

        public ICollection<Detalle_venta> detalles { get; set; }    

        public ICollection<Pago> pagos { get; set; }
    }
}
