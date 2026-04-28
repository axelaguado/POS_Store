using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ClienteDTO
    {
        public long identificacion { get; set; }

        public string cliente { get; set; }
        
        public long telefono { get; set; }

        public string email { get; set; }

        public int codPostal { get; set; }

        public string calle { get; set; }

        public int altura { get; set; }

        public string piso { get; set; }

        public int depto { get; set; }

        public bool estado { get; set; }
    }
}
