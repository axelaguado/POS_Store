using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int id_proveedor {get; set;}

        public int id_persona {get; set;} 

        public bool estado_proveedor {  get; set;}  

        // Propiedades de navegacion

        [ForeignKey("id_persona")] 
        public Persona persona { get; set; }

        public ICollection<Compra> compras { get; set; }

        // Propiedad para ser utlizada dentro de la aplicacion 
        [NotMapped]
        public string nombreCompleto_proveedor
        {
            get
            {
                return $"{persona.persona_juridica.razon_social}, {persona.persona_juridica.nombre_comercial}";
            }
        }
    }
}
