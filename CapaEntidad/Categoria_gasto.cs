using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Categoria_gasto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_categoria { get; set; }

        public string descripcion_categoria { get; set; }

        public bool estado_categoria { get; set; }

        // ------ Propiedad de Navegacion
        public virtual ICollection<Gasto> gastos { get; set;}    
    }
}
