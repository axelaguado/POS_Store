using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class pruebaDAO
    {
        // READONLY --> Hace que dicho atriubto no puede ser modificado.
        private readonly MiDbContext _context;

        // Constructor que recibe el DbContext.
        public pruebaDAO(MiDbContext context)
        {
            _context = context;
        }

        //  -- CREATE --
        public void Crear_persona(prueba _persona)
        {
            _context.Pruebas.Add(_persona);
        }
    }
}
