using iTextSharp.tool.xml.css;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.DTO
{
    public class ProductoDTO
    {
        public int id_producto { get; set; }

        public string producto { get; set; } 

        public string sku_producto { get; set; }

        public bool estado {  get; set; }    
    }
}
