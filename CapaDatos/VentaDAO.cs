using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.DTO;
using System.Threading;
using System.Security.Cryptography;

namespace WindowsFormsApp1.CapaDatos
{
    public class VentaDAO
    {
        private readonly MiDbContext context;

        public VentaDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearVenta(Venta nuevaVenta)
        {
            context.Ventas.Add(nuevaVenta);
        }
         
        // ---- Para manejar solamente ventas -----
        public List<Venta> GetAllVentas()
        {
            return context.Ventas.Include(v => v.detalles).ToList();
        }

        public List<Venta> GetAllFilterVentas(DateTime desde, DateTime hasta)
        {
            return context.Ventas.Include(v => v.detalles).Where(v => v.fecha_venta >= desde && v.fecha_venta <= hasta).ToList();
        }

        public async Task<List<Venta>> GetAllFilterVentasAsync(DateTime desde, DateTime hasta, CancellationToken token)
        {
            return await context.Ventas.Include(v => v.detalles).Where(v => v.fecha_venta >= desde && v.fecha_venta <= hasta).ToListAsync(token);
        }

        // ----- Para manejar solamente empleados y ventas    
        public List<Venta> GetAllVentasEmpleado()    
        {
            return context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.caja)
                                 .Include(v => v.caja.usuario)
                                 .Include(v => v.caja.usuario.empleado)
                                 .Include(v => v.caja.usuario.empleado.persona.persona_fisica)
                                 .ToList();
        }

        public List<Venta> GetAllFilterVentasEmpleado(DateTime desde, DateTime hasta)
        {
            return context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.caja)
                                 .Include(v => v.caja.usuario)
                                 .Include(v => v.caja.usuario.empleado) 
                                 .Include(v => v.caja.usuario.empleado.persona.persona_fisica)
                                 .Where(v => v.fecha_venta >= desde && v.fecha_venta <= hasta)
                                 .ToList();
        }

        public async Task<List<Venta>> GetAllFilterPeriodoEmpleado(DateTime desde, DateTime hasta, CancellationToken token)
        {
            return await context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.caja)
                                 .Include(v => v.caja.usuario)
                                 .Include(v => v.caja.usuario.empleado)
                                 .Include(v => v.caja.usuario.empleado.persona.persona_fisica)
                                 .Where(v => v.fecha_venta >= desde && v.fecha_venta < hasta)
                                 .ToListAsync(token);
        }

        // ----- Para manejar solamente productos y ventas

        public List<Venta> GetAllVentasProducto()
        {
            return context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.detalles.Select(d => d.producto))
                                 .ToList();
        }

        public List<Venta> GetAllFilterVentasProducto(DateTime desde, DateTime hasta)
        {
            return context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.detalles.Select(d => d.producto))
                                 .Where(v => v.fecha_venta >= desde && v.fecha_venta <= hasta)
                                 .ToList();
        }

        public async Task<List<Venta>> GetAllFilterPeriodoProducto(DateTime desde, DateTime hasta, CancellationToken token)
        {
            return await context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.detalles.Select(d => d.producto))
                                 .Where(v => v.fecha_venta >= desde && v.fecha_venta < hasta)
                                 .ToListAsync(token);
        }

        // Para manejar solamente Categorias y ventas

        public List<Venta> GetAllVentasCategoria()
        {
            return context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.detalles.Select(d => d.producto))
                                 .Include(v => v.detalles.Select(d => d.producto.categoria))
                                 .ToList();
        }

        public List<Venta> GetAllFilterVentasCategoria(DateTime desde, DateTime hasta)
        {
            return context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.detalles.Select(d => d.producto))
                                 .Include(v => v.detalles.Select(d => d.producto.categoria))
                                 .Where(v => v.fecha_venta >= desde && v.fecha_venta <= hasta)
                                 .ToList();
        }

        public async Task<List<Venta>> GetAllFilterPeriodoCategoria(DateTime desde, DateTime hasta, CancellationToken token)
        {
            return await context.Ventas.Include(v => v.detalles)
                                 .Include(v => v.detalles.Select(d => d.producto))
                                 .Include(v => v.detalles.Select(d => d.producto.categoria))
                                 .Where(v => v.fecha_venta >= desde && v.fecha_venta < hasta)
                                 .ToListAsync(token);
        }

        // -- UPDATE --
        public void update_centa(Venta datos_modificados)
        {
            Venta venta_modificar = context.Ventas.FirstOrDefault(v => v.id_venta == datos_modificados.id_venta);

            if (venta_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(venta_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }
    }
}
