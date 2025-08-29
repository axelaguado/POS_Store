using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    internal class CN_TipoUsuario
    {
        public Tipo_usuario buscarTipo(int _tipo)
        {
            TipoUsuarioDAO tipo = new TipoUsuarioDAO();
            var tipo_found = tipo.buscar_tipo(_tipo);

            if (tipo_found != null)
            {
                return tipo_found;
            }
            else 
            {
                throw new Exception("No se ha encontrado el tipo de usuario.");
            }
        }

    }
}
