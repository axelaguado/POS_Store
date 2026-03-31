using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_empleado { get; set; }

        public int id_persona { get; set; }

        // Propiedades de navegacion 
        [ForeignKey("id_persona")]
        public Persona persona { get; set; }      

        public ICollection<Usuario> usuarios { get; set; }
    } 
}
