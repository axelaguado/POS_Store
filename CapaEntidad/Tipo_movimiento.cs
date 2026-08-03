using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Tipo_movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo {  get; set; }

        public string descripcion_tipo { get; set; }

        public bool estado_tipo { get; set; }

        // Propiedades de Navegacion.
        public ICollection<Movimiento_caja> movimientos_caja { get; set; }
    }
}
