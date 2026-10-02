using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class ReporteVentaCategoriaDTO
    {
        public string nombre_categoria { get; set; }

        public DateTime periodo_reportado { get; set; }

        public int cantidad_vendida { get; set; }

        public decimal importe_vendido { get; set; }

        public decimal porcentaje_venta_importe { get; set; }
    }
}
