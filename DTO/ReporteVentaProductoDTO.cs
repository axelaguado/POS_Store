using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.DTO
{
    public class ReporteVentaProductoDTO
    {
        public int id_venta {  get; set; }  

        public string producto_completo { get; set; }

        public DateTime periodo { get; set; }
        
        public int cantidad_vendida { get; set; }
        
        public decimal importe_vendido { get; set; }

        public decimal porcentaje_venta_importe { get; set; }
    }
}
