using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Contacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_contacto { get; set; }

        public int id_persona { get; set; }

        public long telefono { get; set; }

        public string email {  get; set; }
        
        public string sitio_web { get; set; }

        // Propiedades de navegacion. 
        public Persona persona { get; set; }
    }
}
