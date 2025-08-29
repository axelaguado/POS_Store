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
        // -- READ --
        public List<Tipo_usuario> listarTipos() 
        {
            using (var context = new MiDbContext())
            {
                return context.Tipo_Usuarios.ToList();
            }
        }    

        public Tipo_usuario buscar_tipo(int _tipo)
        {
            using (var context = new MiDbContext())
            {
                return context.Tipo_Usuarios.FirstOrDefault(tp => tp.id_tipo == _tipo);
            }
        }

    }
}
