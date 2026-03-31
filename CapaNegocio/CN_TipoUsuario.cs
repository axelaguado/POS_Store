using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_TipoUsuario
    {
        public CN_TipoUsuario() { }

        public Tipo_usuario buscarTipo(int _tipo)
        {
            using (var context = new MiDbContext()) 
            {
                TipoUsuarioDAO tipo = new TipoUsuarioDAO(context);
                Tipo_usuario tipo_found = tipo.buscar_tipo(_tipo);

                return tipo_found;
            } 
        } 
    }
}
