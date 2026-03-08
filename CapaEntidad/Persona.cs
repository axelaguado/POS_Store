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

        // Propiedad de navegacion.  
        public ICollection<Direccion> direcciones { get; set; }
          
        public ICollection<Contacto> contactos { get; set; }

        // Roles que puede tener una persona.
        public Empleado empleado { get; set; }

        public Cliente cliente { get; set; } 

        public Proveedor proveedor { get; set; }    

        // Tipos de persona 
        public PersonaFisica persona_fisica { get; set; }

        public PersonaJuridica persona_juridica { get; set; }  
    }

}
