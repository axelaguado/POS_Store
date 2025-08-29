using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using System.Data.Entity;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.Entity.Migrations;

namespace WindowsFormsApp1.CapaDatos
{
    public class UsuarioDAO
    {
        /*
        DAO significa Data Access Object (Objeto de Acceso a Datos). 
        Es un patrón de diseño que se utiliza para separar la lógica de acceso a la base de datos del resto de la aplicación. 
        La idea detrás de este patrón es encapsular todas las operaciones relacionadas con la base de datos (como consultas, inserciones, actualizaciones y eliminaciones) 
        dentro de un objeto, para que la capa de negocio no tenga que interactuar directamente con la base de datos. 
        */


        // READONLY --> Hace que dicho atriubto no puede ser modificado.
        //private readonly MiDbContext _context;

        /* Constructor que recibe el DbContext
        public UsuarioDAO(MiDbContext context)
        {
            _context = context;
        }
        */

        // Crear un nuevo Usuario -- CREATE --
        public int Crear_usuario(Usuario usuario)
        {
            using (var context = new MiDbContext())
            { 
                context.Usuarios.Add(usuario);
                context.SaveChanges(); 
                return usuario.id_persona;
                 
            }
        }
         
        // -- READ -- 
        public List<Usuario> listar_UserOnly() 
        {
            using (var context = new MiDbContext())

                return context.Usuarios.ToList();
        } 

        public List<Usuario> listar_Usuarios()
        {
            using (var context = new MiDbContext())

            return context.Usuarios.Include(u => u.persona)
                                       .Include(u => u.persona.direccion)
                                       .Include(u => u.tipo_usuario)
                                       .OrderBy(u => u.persona.apellido_persona)
                                       .ToList(); 
        }

        public Usuario buscar_usuario_id(int _id)
        {
            using (var context = new MiDbContext())
            {
                return context.Usuarios.FirstOrDefault(u => u.id_persona == _id);
            }
        }

        // -- UPDATE -- 
        public Usuario update_AllUserRelationship(Usuario datos_modificados)
        {
            using (var context = new MiDbContext())
            {
                Usuario usuario_modificar = context.Usuarios
                                                   .Include(u => u.persona)
                                                   .Include(u => u.persona.direccion)
                                                   .Include(u => u.tipo_usuario)
                                                   .FirstOrDefault(u => u.id_persona == datos_modificados.id_persona);


                // Se debe hacer comprobaciones por cada entidad.
                if (usuario_modificar != null)
                {
                    // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                    //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                    // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                    // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                    context.Entry(usuario_modificar).CurrentValues.SetValues(datos_modificados);

                    // Para finalmente actualizar los datos en la bdd es necesario invocar al SaveChanges osino solo se modifican en el contexto.  
                    context.SaveChanges();
                }

                return usuario_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
            }
        }

        public Usuario update_user(Usuario datos_modificados)
        {
            using (var context = new MiDbContext())
            {
                Usuario usuario_modificar = this.buscar_usuario_id(datos_modificados.id_persona);

                if (usuario_modificar != null)
                {
                    // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                    //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                    // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                    // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                    context.Usuarios.Attach(usuario_modificar);
                    context.Entry(usuario_modificar).CurrentValues.SetValues(datos_modificados); 

                    // Para finalmente actualizar los datos en la bdd es necesario invocar al SaveChanges osino solo se modifican en el contexto.  
                    context.SaveChanges();
                }

                return usuario_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
            }
        } 

    }
}
 
