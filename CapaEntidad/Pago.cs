using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_pago { get; set; }

        public int id_venta { get; set; }

        public int id_metodo { get; set; }

        public decimal importe_pago { get; set; }

        public DateTime fecha_pago { get; set; }

        public bool estado_pago { get; set; }

        // Propiedad de navegacion.
        [ForeignKey("id_venta")]
        public Venta venta { get; set; }

        [ForeignKey("id_metodo")]
        public Metodo_pago metodo { get; set; }
    }
}
