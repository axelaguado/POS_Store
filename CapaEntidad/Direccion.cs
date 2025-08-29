using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Direccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_direccion { get; set; }
 
        public int id_persona { get; set; }

        public string calle { get; set; }

        public int altura { get; set; }

        public string piso { get; set; }

        public int depto { get; set; } 

        // Propiedad de navegaciion

        [ForeignKey("id_persona")]
        public Persona persona { get; set; }
    }
}
