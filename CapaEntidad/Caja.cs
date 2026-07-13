using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Caja
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_caja { get; set; }

        public int id_usuario { get; set; }

        public DateTime fecha_apertura { get; set; }

        public DateTime fecha_cierre { get; set; }

        public decimal saldo_incial { get; set; }

        public decimal saldo_cierre { get; set; }

        public bool estado_caja { get; set; }

        // Propiedad de navegacion.

        [ForeignKey("id_usuario")]
        public Usuario usuario { get; set; }

        public ICollection<Movimiento_caja> movimientos { get; set; }

        public ICollection<Venta> ventas { get; set; }
    }
}
