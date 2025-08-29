using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Tipo_usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_tipo { get; set;}
        public string descripcion_tipo { get; set;}

        // Propiedad de navegacion.
        public ICollection<Usuario> usuario { get; set;}
    }
}
