using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ReporteGananciasBrutasDTO
    {
        public decimal costo_total { get; set; }    

        public decimal venta_total { get; set; }

        public decimal margen_ganancia { get; set; } 

        public DateTime periodo_reportado { get; set; }
    }
}
