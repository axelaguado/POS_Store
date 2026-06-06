using System;
using System.Data.Entity; // Para que funcione el include.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1.CapaDatos
{
    public class CompraDAO
    {
        private readonly MiDbContext _context;

        public CompraDAO(MiDbContext context)
        {
            _context = context;
        } 

        // Create.
        public void Crear_compra(Compra _compra)
        {
            // Como compra necesita de un proveedor conocido y los productos del detalle tambien, entonces vamos a recordarle a EF que estos ya existen en la BD.


            _context.Compras.Add(_compra);  
        }

        public void Attach_compra(Compra _compra) 
        { 
            _context.Compras.Attach(_compra);
        }

        // Read.
        public Compra buscarCompra(int id_compra)
        { 
            return _context.Compras.Include(p => p.proveedor)
                              .Include(p => p.proveedor.persona.persona_juridica)
                              .Include(p => p.detalles_compra)
                              .Include(p => p.proveedor.persona.direcciones)
                              .Include(p => p.proveedor.persona.contactos)
                              .Include(p => p.estado)
                              .Include(p => p.detalles_compra.Select(d => d.producto))
                              .FirstOrDefault(p => p.id_compra == id_compra);
                              
        }


        public List<Compra> ReadPedidosPendientes()
        {
             return _context.Compras.Include(p => p.proveedor)
                                    .Include(p => p.proveedor.persona.persona_juridica)
                                    .Include(p => p.detalles_compra)
                                    .Include(p => p.detalles_compra.Select(d => d.producto)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo)) 
                                    .Include(p => p.estado)
                                    .Where(p => p.estado_compra == 2)
                                    .OrderBy(p => p.id_compra)
                                    .ToList(); 
        }

        public List<Compra> ReadPedidosConfirmados()
        {
             return _context.Compras.Include(p => p.proveedor)
                                       .Include(p => p.proveedor.persona.persona_juridica)
                                       .Include(p => p.detalles_compra)
                                       .Include(p => p.detalles_compra.Select(d => d.producto)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo))
                                       .Include(p => p.estado)
                                       .Where(p => p.estado_compra == 3)
                                       .OrderBy(p => p.id_compra)
                                       .ToList();
        }

        // Busquedas asincronas
        public async Task<List<Compra>> GetComprasAsync(CancellationToken _ct, string buscado, int estado)
        { 
            int.TryParse(buscado, out int ordenCompra);

            return await _context.Compras.Include(c => c.proveedor.persona.persona_juridica)
                                         .Where(c => c.estado_compra == estado && (c.id_compra.ToString().StartsWith(ordenCompra.ToString()) 
                                                                                    || c.proveedor.persona.persona_juridica.nombre_comercial.Contains(buscado) 
                                                                                    || c.proveedor.persona.persona_juridica.razon_social.Contains(buscado)))
                                         .ToListAsync(_ct);    
        }
 

        // Update. 
        public void update_StateInactive(long id_pedido)
        {
            Compra pedido_modificar = _context.Compras.FirstOrDefault(p => p.id_compra == id_pedido);

            // Se debe hacer comprobaciones por cada entidad.
            if (pedido_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.
                        
                pedido_modificar.estado_compra = 1; 
            }
     
        } 

        public void update_StateConfirmado(Compra compra_confirmar)
        { 
            // Se debe hacer comprobaciones por cada entidad.
            if (compra_confirmar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.
                compra_confirmar.fecha_confirmacion = DateTime.Now;
                compra_confirmar.estado_compra = 3;
            } 
        }

        public void update_Compra(Compra compra_confirmar)
        {
            Compra compraEncontrada = _context.Compras.Include(c => c.proveedor) 
                                       .Include(c => c.detalles_compra)
                                       .Include(c => c.detalles_compra.Select(d => d.producto)) // Cuando usamos (p => p.detalle_pedido (y el campo detalle pedido es un ICollection).Select(d => d.articulo))
                                       .Include(c => c.estado)
                                       .First(c => c.id_compra == compra_confirmar.id_compra);
             
            // Se debe hacer comprobaciones por cada entidad.
            if (compraEncontrada != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (pedido_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.
                _context.Entry(compraEncontrada).CurrentValues.SetValues(compra_confirmar);
            }
        }
    }
}
