using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaEntidad
{
    public class ItemCarrito
    { 
        public ProductoDTO producto { get; set; }

        public decimal precio{ get; set; }

        public int cantidad { get; set; }
        
        public string informacion { get; set; }
         
    }
}
