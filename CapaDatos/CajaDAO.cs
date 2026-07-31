using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaDatos
{
    public class CajaDAO
    {
        private readonly MiDbContext context;

        public CajaDAO (MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearCaja(Caja nuevaCaja)
        {
            context.Cajas.Add(nuevaCaja);
        }

        public void Attach_caja(Caja caja)
        {
            context.Cajas.Attach(caja);
        }

        public Caja GetCaja(int id_caja)
        {
            return context.Cajas.Include(c => c.ventas)
                                .Include(c => c.usuario)
                                .Include(c => c.ventas.Select(v => v.cliente))
                                .Include(c => c.ventas.Select(v => v.cliente.persona))
                                .Include(c => c.ventas.Select(v => v.cliente.persona.persona_juridica))
                                .Include(c => c.ventas.Select(v => v.cliente.persona.persona_fisica))
                                .Include(c => c.ventas.Select(v => v.detalles))
                                .Include(c => c.ventas.Select(v => v.detalles.Select(d => d.producto)))
                                .Include(c => c.ventas.Select(v => v.pagos))
                                .Include(c => c.ventas.Select(v => v.pagos.Select(d => d.metodo)))
                                .Include(c => c.movimientos)
                                .Include(c => c.movimientos.Select(m => m.tipo_movimiento))
                                .FirstOrDefault(c => c.estado_caja == true && c.id_caja == id_caja);
        }

        public Caja GetCajaActiva(int id_usuario) 
        {
            return context.Cajas.FirstOrDefault(c => c.estado_caja == true && c.id_usuario == id_usuario);
        }

        // -- UPDATE --
        public void update_caja(Caja datos_modificados)
        {
            Caja caja_modificar = context.Cajas.FirstOrDefault(c => c.id_caja == datos_modificados.id_caja);

            if (caja_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(caja_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }


    }
}
