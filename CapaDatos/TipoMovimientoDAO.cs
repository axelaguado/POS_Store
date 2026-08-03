using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class TipoMovimientoDAO
    {
        private readonly MiDbContext context;

        public TipoMovimientoDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearTipo(Tipo_movimiento nuevoTipo)
        {
            context.Tipos_movimiento.Add(nuevoTipo);
        }

        public void Attach_tipo(Tipo_movimiento tipoExistente)
        {
            context.Tipos_movimiento.Attach(tipoExistente);
        }

        public Tipo_movimiento GetTipo(string descripicion)
        {
            return this.context.Tipos_movimiento.FirstOrDefault(tm => tm.descripcion_tipo == descripicion);
        }

        public Tipo_movimiento GetTipo(int id_tipo)
        {
            return this.context.Tipos_movimiento.FirstOrDefault(tm => tm.id_tipo == id_tipo);
        }

        public List<Tipo_movimiento> GetAllTipos() 
        {
            return this.context.Tipos_movimiento.ToList();
        } 

        // -- UPDATE --
        public void update_tipo(Tipo_movimiento datos_modificados)
        {
            Tipo_movimiento tipo_modificar = context.Tipos_movimiento.FirstOrDefault(tm => tm.id_tipo == datos_modificados.id_tipo);

            if (tipo_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(tipo_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }

    }
}
