using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    internal class TipoUsuarioDAO
    {
        private readonly MiDbContext _context;
        public TipoUsuarioDAO(MiDbContext context) 
        { 
            this._context = context;
        }

        // -- READ --
        public List<Tipo_usuario> listarTipos() 
        { 
            return _context.Tipo_Usuarios.ToList(); 
        }    

        public Tipo_usuario buscar_tipo(int _tipo)
        { 
            return _context.Tipo_Usuarios.FirstOrDefault(tp => tp.id_tipo == _tipo); 
        }

    }
}
