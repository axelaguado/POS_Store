using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Gasto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int id_gasto { get; set; }

        public DateTime fecha_registro { get; set; }

        public DateTime periodo_gasto { get; set; }

        public string descripcion_gasto { get; set; }

        public decimal monto_gasto { get; set; }

        public int categoria_gasto { get; set; }     

        public bool estado_gasto { get; set; }

        // ----- Propiedad de Navegacion

        [ForeignKey("categoria_gastao")]
        public Categoria_gasto categoria {  get; set; } 
    }
}
