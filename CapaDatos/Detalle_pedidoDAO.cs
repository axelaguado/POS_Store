using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class Detalle_pedidoDAO
    {
        public int Crear_detalle(Detalle_pedido detalle)
        {

            // Al usar el bloque using, el contexto MiDbContext es desechado automáticamente cuando termina el bloque de código.
            using (var context = new MiDbContext())
            {
                context.Detalles_pedido.Add(detalle);
                context.SaveChanges();
                return detalle.id_detalle;

            }
        }


    }
}
