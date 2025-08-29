using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class DireccionDAO
    {
        // READONLY --> Hace que dicho atriubto no puede ser modificado.
        //private readonly MiDbContext _context;

        /* Constructor que recibe el DbContext
        public DireccionDAO(MiDbContext context)
        {
            _context = context;
        }
        */

        // -- CREATE --

        //Este metodo puede lanzar excepciones,que seran capturadas en el evento BRegistrarUsuario_Click (Esto se conoce como propagacion de excepciones). 
        public int Crear_direccion(Direccion direccion)
        {
            using ( var context  = new MiDbContext()) 
            {  
                context.Direcciones.Add(direccion);
                context.SaveChanges();
                return direccion.id_direccion;  
                
            }
        }

        // -- READ -- 
        public List<Direccion> listar_direcciones() 
        {
            using (var context = new MiDbContext())
            {
                return context.Direcciones.ToList();
            }
        } 

        public Direccion buscar_direccion_id(int _id) 
        {
            using (var context = new MiDbContext())
            {
                return context.Direcciones.FirstOrDefault(d => d.id_direccion == _id);
            }
        }


        // -- UPDATE --
        public Direccion update_direccion(Direccion datos_modificados)
        {
            using (var context = new MiDbContext())
            {
                Direccion direccion_modificar = context.Direcciones.FirstOrDefault(d => d.id_direccion == datos_modificados.id_direccion);

                if (direccion_modificar != null)
                {
                    // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                    //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                    // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                    // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                    context.Direcciones.Attach(direccion_modificar);
                    context.Entry(direccion_modificar).CurrentValues.SetValues(datos_modificados);

                    // Para finalmente actualizar los datos en la bdd es necesario invocar al SaveChanges osino solo se modifican en el contexto.  
                    context.SaveChanges();
                }

                return direccion_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
            }
        }

    }
}
