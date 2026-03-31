using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Empleado
    {
        public CN_Empleado() { }

        public void CrearEmpleado(Empleado _empleado) 
        {
            using (var context = new MiDbContext()) 
            {  
                EmpleadoDAO nuevoempleado = new EmpleadoDAO(context);
                nuevoempleado.Crear_empleado(_empleado); 
            }
        }

    }
}
