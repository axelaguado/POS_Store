using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_MetodoPago
    {
        public Dictionary<string, string> validaciones;

        public CN_MetodoPago() 
        { 
            this.validaciones = new Dictionary<string, string>();
        }

        public List<Metodo_pago> ObtenerMetodos() 
        {
            using (var context = new MiDbContext())
            {
                MetodoPagoDAO metodo = new MetodoPagoDAO(context);
                return metodo.GetMetodosActivos();
            }
        }
    }
}
