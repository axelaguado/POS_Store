using System;
using System.Data.Entity; // Para que funcione el include.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class GastoDAO
    {
        private readonly MiDbContext context;

        public GastoDAO(MiDbContext _context)
        {
            this.context = _context;
        }

        public void CrearGasto(Gasto nuevo) 
        {
            this.context.Gastos.Add(nuevo);
        }

        public List<Gasto> get_AllGastosActive()
        {
            return context.Gastos
                .Where(g => g.estado_gasto == true)
                .ToList();
        }

        public List<Gasto> get_AllGastos()
        {
            return context.Gastos.Include(g => g.categoria).
                                    OrderBy(g => g.periodo_gasto).
                                    ToList();
        }

        // Busquedas filtradas ..
        public List<Gasto> get_GastosFilter(DateTime periodo_desde) 
        {
            return context.Gastos.Include(g => g.categoria).
                                    Where(g => g.periodo_gasto == periodo_desde).
                                    OrderBy(g => g.periodo_gasto).
                                    ToList();
        }

        public List<Gasto> get_GastosFilter(int id_categoria)
        {
            return context.Gastos.Include(g => g.categoria).
                                    Where(g => g.categoria.id_categoria == id_categoria).
                                    OrderBy(g => g.periodo_gasto).
                                    ToList();
        }

        public List<Gasto> get_GastosFilter(DateTime periodo_desde, int id_categoria)
        {
            return context.Gastos.Include(g => g.categoria).
                                    Where(g => g.periodo_gasto == periodo_desde && g.categoria.id_categoria == id_categoria).
                                    OrderBy(g => g.periodo_gasto).
                                    ToList();
        }

        public List<Gasto> get_GastosFilter(DateTime periodo_desde, DateTime periodo_hasta)
        {
            return context.Gastos.Include(g => g.categoria).
                                    Where(g => g.periodo_gasto >= periodo_desde && g.periodo_gasto <= periodo_hasta).
                                    OrderBy(g => g.periodo_gasto).
                                    ToList();
        }

        public List<Gasto> get_GastosFilter(DateTime periodo_desde, DateTime periodo_hasta, int id_categoria)
        {
            return context.Gastos.Include(g => g.categoria).
                                    Where(g => g.periodo_gasto >= periodo_desde && g.periodo_gasto <= periodo_hasta && g.categoria.id_categoria == id_categoria).
                                    OrderBy(g => g.periodo_gasto).
                                    ToList();
        }

        // ----------------------

        public Gasto buscarId(int id_gasto)
        {
            return context.Gastos.Include(g => g.categoria).FirstOrDefault(g => g.id_gasto == id_gasto);
        }

        // -- UPDATE --
        public void update_gasto(Gasto datos_modificados)
        {
            Gasto gasto_modificar = context.Gastos.FirstOrDefault(g => g.id_gasto == datos_modificados.id_gasto);

            if (gasto_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                context.Entry(gasto_modificar).CurrentValues.SetValues(datos_modificados);
            }
        }

    }
}
