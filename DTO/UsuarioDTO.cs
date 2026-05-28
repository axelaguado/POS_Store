using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class UsuarioDTO
    {
        public int id_usuario {  get; set; }    

        public string apellido { get; set; }
        
        public string nombre { get; set; }
        
        public int dni { get; set; }
        
        public string username { get; set; } 

        public string descripcion_tipo { get; set; }

        public long telefono { get; set; }

        public string email { get; set; }

        public string calle { get; set; }

        public int altura { get; set; }

        public string piso { get; set; }

        public int depto { get; set; }

        public bool estado { get; set; }    
    }
}
