using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Movimiento_caja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_movimiento { get; set; }

        public int id_caja { get; set; }

        public int id_tipo { get; set; }

        public decimal monto_movimiento { get; set; }

        public string descripcion_movimiento { get; set; }

        public DateTime fecha_movimiento { get; set; }

        public bool estado_movimiento { get; set; }

        // Propiedades de Navegacion.
        [ForeignKey("id_tipo")]
        public Tipo_movimiento tipo_movimiento { get; set; }

        [ForeignKey("id_caja")]
        public Caja caja { get; set; }
    }
}
