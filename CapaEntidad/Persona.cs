using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_persona { get; set; }
 
        public int dni_persona { get; set; }

        public string nombre_persona { get; set; }

        public string apellido_persona{ get; set; }

        public DateTime fecha_nacimiento{ get; set; }

        public string email { get; set; }
        
        public long telefono { get; set; }

        public string sexo { get; set; }  

        // Propiedad de navegacion.
        public Cliente cliente { get; set; }

        public Usuario usuario { get; set; }
 
        public ICollection<Direccion> direccion { get; set; }

    }

}
