using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Persona
    { 
        public CN_Persona() { } 

        public void CrearPersona(Persona persona)  
        { 
            using (var context = new MiDbContext()) 
            {    
                PersonaDAO personaDAO = new PersonaDAO(context); 
                personaDAO.Crear_persona(persona); // Retornar el ID de la dirección   
            } 
        }     
    }
}
