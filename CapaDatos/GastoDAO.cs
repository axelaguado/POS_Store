using System;
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

        public List<Gasto> get_AllCategorias()
        {
            return context.Gastos
                .Where(g => g.estado_gasto == true)
                .ToList();
        }


    }
}
