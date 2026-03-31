using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id_articulo {  get; set; }

        public string marca_articulo { get; set; }

        public string nombre_articulo { get; set; }

        public string descripcion_articulo { get; set; }

        public string contenido_articulo { get; set; }

        public decimal precio_unitario { get; set; }

        // Propiedad de navegacion.
        public ICollection<Detalle_pedido> detalle_pedido { get; set; } 
    }
}
