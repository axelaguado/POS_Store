using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ReporteGastoCategoriaDTO
    {
        public string nombre_categoria {  get; set; }  

        public DateTime periodo_reportado { get; set; }

        public decimal gasto_acumulado { get; set; }
    }
}
