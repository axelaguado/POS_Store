using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ShortProveedorDTO
    {
        public int id_proveedor { get; set; }

        public string proveedor { get; set; } 

        public long cuit { get; set; }
         
        public bool estado { get; set; }
    }
}
