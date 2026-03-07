using System;
using System.Data.Entity; // Para que funcione el include.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class PedidoDAO
    {
        // Create.
        public int Crear_pedido(Pedido pedido)
        {

            // Al usar el bloque using, el contexto MiDbContext es desechado automáticamente cuando termina el bloque de código.
            using (var context = new MiDbContext())
            {
                context.Pedidos.Add(pedido);
                context.SaveChanges();
                return pedido.id_pedido;

            }
        }

        // Read.
        public Pedido buscarPedido(long id_pedido)
        {
            using (var context = new MiDbContext())

                return context.Pedidos
                              .Include(p => p.proveedor)
                              .Include(p => p.proveedor.direccion)
                              .Include(p => p.detalle_pedido)
                              .Include(p => p.detalle_pedido.Select(d => d.articulo))
                              .FirstOrDefault(p => p.id_pedido == id_pedido);
        }


        public List<Pedido> ReadPedidosPendientes()
        {
            using (var context = new MiDbContext())

                return context.Pedidos.Include(p => p.proveedor)
                                       .Include(p => p.detalle_pedido)
                                       .Include(p => p.detalle_pedido.Select(d => d.articulo)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo))
                                       .Where(p => p.estado == 1)
                                       .OrderBy(p => p.id_pedido)
                                       .ToList();
        }

        public List<Pedido> ReadPedidosConfirmados()
        {
            using (var context = new MiDbContext())

                return context.Pedidos.Include(p => p.proveedor)
                                       .Include(p => p.detalle_pedido)
                                       .Include(p => p.detalle_pedido.Select(d => d.articulo)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo))
                                       .Where(p => p.estado == 2)
                                       .OrderBy(p => p.id_pedido)
                                       .ToList();
        }

        // Update. 
        public void update_StateInactive(long id_pedido)
        {
            using (var context = new MiDbContext())
            {
                Pedido pedido_modificar = context.Pedidos
                                                 .Include(p => p.proveedor)
                                                 .Include(p => p.detalle_pedido)
                                                 .Include(p => p.detalle_pedido.Select(d => d.articulo))
                                                 .FirstOrDefault(p => p.id_pedido == id_pedido);


                // Se debe hacer comprobaciones por cada entidad.
                if (pedido_modificar != null)
                {
                    // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                    //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                    // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                    // SetValues: este metodo nos permite asignar/modificar valores al entry.
                        
                    pedido_modificar.estado = 0;
                    context.Entry(pedido_modificar).State = EntityState.Modified;


                    // Para finalmente actualizar los datos en la bdd es necesario invocar al SaveChanges osino solo se modifican en el contexto.  
                    context.SaveChanges();
                }

            }

        }

        public void update_StateConfirmado(long id_pedido)
        {
            using (var context = new MiDbContext())
            {
                Pedido pedido_modificar = context.Pedidos
                                                 .Include(p => p.proveedor)
                                                 .Include(p => p.detalle_pedido)
                                                 .Include(p => p.detalle_pedido.Select(d => d.articulo))
                                                 .FirstOrDefault(p => p.id_pedido == id_pedido);


                // Se debe hacer comprobaciones por cada entidad.
                if (pedido_modificar != null)
                {
                    // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                    //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                    // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                    // SetValues: este metodo nos permite asignar/modificar valores al entry.

                    pedido_modificar.estado = 2;
                    context.Entry(pedido_modificar).State = EntityState.Modified;


                    // Para finalmente actualizar los datos en la bdd es necesario invocar al SaveChanges osino solo se modifican en el contexto.  
                    context.SaveChanges();
                }

            }

        } 
    }
}
