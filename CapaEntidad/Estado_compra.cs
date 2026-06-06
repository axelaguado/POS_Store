using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Estado_compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_estado { get; set; }

        public string descripcion_estado { get; set; }

        // Propiedades de navegacion 
        public ICollection<Compra> compras { get; set; }
    }
}
