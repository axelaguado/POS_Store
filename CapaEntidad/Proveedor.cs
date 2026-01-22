using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    internal class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int id_proveedor {get; set;}

        public string razon_social { get; set; }

        public string nombre_nomercial {  get; set; }

        public int cod_postal {  get; set; }

        public string telefono { get; set; }

        public string email { get; set; }

    }
}
