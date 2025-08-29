using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public  class Producto
    {
        public long id_producto { get; set; }

        public string marca_producto{ get; set; }

        public string modelo_producto{ get; set; }

        public string descripcion_producto { get; set; }

        public int producto_categoria { get; set; }

        public int stock_producto { get; set; }

        public int stock_minimo { get; set; }

        public decimal precio_venta { get; set; }

        public decimal precio_costo { get; set; }

        public string imagen { get; set; }

        public bool estado { get; set; }

        // Propiedad de navegacion.
        public Categoria_producto categoria { get; set; }   

        public ICollection<Detalle_venta> ventas { get; set; }
    }
}
