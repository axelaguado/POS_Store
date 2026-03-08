using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_usuario {  get; set; }     
        
        public int id_empleado { get; set; }

        public string username { get; set; }

        public string contraseña { get; set; }

        public int tipo_perfil { get; set; }

        public bool estado { get; set; }

        // Propiedad de navegacion.
        [ForeignKey("id_empleado")]
        public Empleado empleado { get; set; }

        [ForeignKey("tipo_perfil")]
        public Tipo_usuario tipo_usuario { get; set; }   
        //public ICollection<Venta> ventas { get; set; }
    }
}
