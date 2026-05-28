using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ProveedorDTO
    {
        public int id_proveedor { get; set; }
        
        public string razon_social { get; set; }

        public string nombre_comercial { get; set; }

        public long cuit { get; set; }

        public long telefono { get; set; }

        public string email { get; set; }

        public string sitio_web { get; set; }

        public int cod_postal { get; set; }

        public string calle { get; set; }

        public int altura { get; set; }

        public string piso { get; set; }

        public int depto { get; set; } 

        public bool estado{ get; set; }   
    }
}
