using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Metodo_pago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_metodo {  get; set; }

        public string descripcion_metodo { get; set; }

        public bool estado_metodo { get; set; }
        
        // Propiedad de navegacion.
        public ICollection<Pago> pagos { get; set; }
    }
}
