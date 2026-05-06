using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cliente { get; set; }
    
        public int id_persona { get; set; }

        public bool estado_cliente { get; set; }

        // Propiedad de navegacion.
        [ForeignKey("id_persona")]
        public virtual Persona persona { get; set; }

        public virtual ICollection<Venta> compras { get; set; }

    }
}


