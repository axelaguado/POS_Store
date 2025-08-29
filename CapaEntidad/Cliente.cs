using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Cliente
    {
        public int id_cliente{ get; set; }
    
        public int id_persona { get; set; }

        // Propiedad de navegacion.
        public virtual Persona persona { get; set; }

        public virtual ICollection<Venta> compras { get; set; }

    }
}


