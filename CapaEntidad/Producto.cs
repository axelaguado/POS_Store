using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Utilities;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1.CapaEntidad
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int id_producto { get; set; }

        public string marca_producto { get; set; }

        public string nombre_producto { get; set; }

        public string descripcion_producto { get; set; }

        public int categoria_producto { get; set; }

        public string contenido_producto { get; set; }

        public int stock_producto { get; set; }

        public int stock_minimo { get; set; } 

        public decimal precio_costo { get; set; }

        public decimal precio_venta { get; set; }
          
        // SKU --> Stock Keeping Unit (Unidad de mantenimiento de stock)
        public string sku_producto { get; set; }
        
        public bool estado_producto { get; set; }

        // Propiedad de navegacion.
        [ForeignKey("categoria_producto")]
        public Categoria_producto categoria { get; set; }

        public ICollection<Detalle_compra> detalles_compra { get; set; }

        // Propiedad para ser utlizada dentro de la aplicacion 
        [NotMapped]
        public string producto_completo
        {
            get
            {
                return $"{nombre_producto} - {contenido_producto}, {descripcion_producto}";
            }
        }
    }
}
