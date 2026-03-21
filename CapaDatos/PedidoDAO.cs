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
        private readonly MiDbContext _context;

        public PedidoDAO(MiDbContext context)
        {
            _context = context;
        } 

        // Create.
        public void Crear_pedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);  
        }

        // Read.
        public Pedido buscarPedido(long id_pedido)
        { 
            return _context.Pedidos.Include(p => p.proveedor)
                              .Include(p => p.proveedor.persona.persona_juridica)
                              .Include(p => p.detalle_pedido)
                              .Include(p => p.proveedor.persona.direcciones)
                              .Include(p => p.proveedor.persona.contactos)
                              .Include(p => p.estado_pedido)
                              .Include(p => p.detalle_pedido.Select(d => d.articulo))
                              .FirstOrDefault(p => p.id_pedido == id_pedido);
                              
        }


        public List<Pedido> ReadPedidosPendientes()
        {
             return _context.Pedidos.Include(p => p.proveedor)
                                    .Include(p => p.proveedor.persona.persona_juridica)
                                    .Include(p => p.detalle_pedido)
                                    .Include(p => p.detalle_pedido.Select(d => d.articulo)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo)) 
                                    .Include(p => p.estado_pedido)
                                    .Where(p => p.estado == 2)
                                    .OrderBy(p => p.id_pedido)
                                    .ToList(); 
        }

        public List<Pedido> ReadPedidosConfirmados()
        {
             return _context.Pedidos.Include(p => p.proveedor)
                                       .Include(p => p.proveedor.persona.persona_juridica)
                                       .Include(p => p.detalle_pedido)
                                       .Include(p => p.detalle_pedido.Select(d => d.articulo)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo))
                                       .Include(p => p.estado_pedido)
                                       .Where(p => p.estado == 3)
                                       .OrderBy(p => p.id_pedido)
                                       .ToList();
        }

        // Update. 
        public void update_StateInactive(long id_pedido)
        {
            Pedido pedido_modificar = _context.Pedidos.FirstOrDefault(p => p.id_pedido == id_pedido);

            // Se debe hacer comprobaciones por cada entidad.
            if (pedido_modificar != null)
           {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.
                        
                pedido_modificar.estado = 1; 
            }
     
        } 

        public void update_StateConfirmado(long id_pedido)
        {
            Pedido pedido_modificar = _context.Pedidos.FirstOrDefault(p => p.id_pedido == id_pedido); 

            // Se debe hacer comprobaciones por cada entidad.
            if (pedido_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.

                pedido_modificar.estado = 3; 
            }

        } 
    }
}
