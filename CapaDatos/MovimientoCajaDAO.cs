using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaPresentacion;

namespace WindowsFormsApp1.CapaDatos
{
    public class MovimientoCajaDAO
    {
        private readonly MiDbContext context;

        public MovimientoCajaDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void AddMoviento(Movimiento_caja nuevoMovimiento)
        {
            context.Movimientos_caja.Add(nuevoMovimiento);
        }

        public void AttachMoviento(Movimiento_caja movimientoExistente)
        {
            context.Movimientos_caja.Attach(movimientoExistente);
        }

        public Movimiento_caja GetMovimiento(int id_movimiento)
        {
            return this.context.Movimientos_caja.FirstOrDefault(mc => mc.id_movimiento == id_movimiento);
        }
          
        public List<Movimiento_caja> GetAllActiveMovimientos()
        {
            return this.context.Movimientos_caja.Where(mc => mc.estado_movimiento == true).ToList();
        }

        // -- UPDATE --
        public void UpdateMovimiento(Movimiento_caja datos_modificados)
        {
            Movimiento_caja moovimiento_modificar = this.context.Movimientos_caja.FirstOrDefault(mc => mc.id_movimiento == datos_modificados.id_tipo);

            if (moovimiento_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(moovimiento_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }
    }
}
