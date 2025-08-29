using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Venta
    {
        public int id_venta{ get; set; }
        
        public int cliente_venta { get; set; }

        public int vendedor_venta { get; set; } 

        public int fecha_venta { get; set; }

        public decimal monto_venta{ get; set; }

        // Propiedad de navegacion --> ermite acceder y gestionar entidades relacionadas de forma fácil y eficiente
        // dentro de Entity Framework, manteniendo la relación entre ellas en el nivel de objetos.

        public Cliente cliente { get; set; }   

        public Usuario vendedor { get; set; }

        public ICollection<Detalle_venta> detalles { get; set; }    

    }
}
