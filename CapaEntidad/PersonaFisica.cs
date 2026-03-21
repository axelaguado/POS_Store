using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1.CapaEntidad
{ 
    public class PersonaFisica
    { 
        public int id_persona { get; set; } 

        public int dni_persona { get; set; }

        public string nombre_persona { get; set; }

        public string apellido_persona { get; set; }

        public DateTime fecha_nacimiento { get; set; }

        public string sexo { get; set; }

        // Propiedades de navegacion. 
        [ForeignKey("id_persona")]
        public Persona persona { get; set; } 
    } 
}
