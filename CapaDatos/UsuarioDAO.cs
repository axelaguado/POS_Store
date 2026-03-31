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
using System.ComponentModel;
using System.Threading;
using System.Net;
using System.Runtime.Remoting.Contexts;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.CapaNegocio;
using System.Diagnostics;

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
        private readonly MiDbContext _context;

        // Constructor que recibe el DbContext
        public UsuarioDAO(MiDbContext context)
        {
            _context = context;
        } 

        // Crear un nuevo Usuario -- CREATE --
        public void Crear_usuario(Usuario usuario)
        {    
            _context.Usuarios.Add(usuario);  
        }
         
        // -- READ -- 
        public Usuario BuscarUsername(string _username)
        {
            return _context.Usuarios.Include(u => u.empleado)
                                .Include(u => u.tipo_usuario)
                                .Include(u => u.empleado.persona)
                                .Include(u => u.empleado.persona.contactos)
                                .Include(u => u.empleado.persona.direcciones)
                                .Include(u => u.empleado.persona.persona_fisica)
                                .FirstOrDefault(u => u.username == _username); 
        } 

        public bool UsernameExist(Usuario _usuario) 
        {
           return _context.Usuarios
                            .Any(u => u.username == _usuario.username && u.id_usuario != _usuario.id_usuario);  // existe el username                         existe el username
                                                                                                                // los id_son distntos --> retorna existe     los id_son iguales --> retorna false
        }

        public List<Usuario> listar_UserOnly() 
        { 
            return _context.Usuarios.ToList();
        } 

        
        public List<Usuario> listar_Usuarios()
        {   
            return _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)
                                       .Include(u => u.tipo_usuario)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .ToList(); 
        }

        // Opcion 1
        public List<Usuario> listar_UsuariosActivos()
        {
            return _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.tipo_usuario)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.persona_fisica)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)   
                                       .Where(u => u.estado == true)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .ToList();
        }

        // Opcion 2
        public List<UsuarioDTO> listar_UsuariosActivosDTO()
        {
            return  _context.Usuarios.Where(u => u.estado == true) 
                                     .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                     .Select(u => new UsuarioDTO { 
                                            id_usuario = u.id_usuario,
                                            apellido = u.empleado.persona.persona_fisica.apellido_persona, 
                                            nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                            dni = u.empleado.persona.persona_fisica.dni_persona,
                                            username = u.username,   
                                            descripcion_tipo = u.tipo_usuario.descripcion_tipo,   
                                            telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),   
                                            email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                            calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                            altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                            piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                            depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                     }).ToList();
        }
         

        public List<Usuario> listar_UsuariosInactivos()
        {
            return _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.tipo_usuario)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.persona_fisica)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)
                                       .Where(u => u.estado == false)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .ToList();
        }

        public List<UsuarioDTO> listar_UsuariosInactivosDTO()
        {
            return _context.Usuarios.Where(u => u.estado == false)
                                     .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                     .Select(u => new UsuarioDTO
                                     {
                                         id_usuario = u.id_usuario,
                                         apellido = u.empleado.persona.persona_fisica.apellido_persona,
                                         nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                         dni = u.empleado.persona.persona_fisica.dni_persona,
                                         username = u.username,
                                         descripcion_tipo = u.tipo_usuario.descripcion_tipo,
                                         telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                         email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                         calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                         altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                         piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                         depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                     }).ToList();
        }

        // Metodos asincrono para el TB de navegacion,
        public async Task<List<Usuario>> listar_UsuariosDniEstado(int dni, bool state, CancellationToken token)
        {
            return await _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)
                                       .Include(u => u.tipo_usuario)
                                       .Where(u => (u.empleado.persona.persona_fisica.dni_persona.ToString().StartsWith(dni.ToString())) && u.estado == state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .ToListAsync(token);
        }

        public async Task<List<Usuario>> listar_UsuariosNombreEstado(string _nombre, bool state, CancellationToken token)
        { 
            return await _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)
                                       .Include(u => u.tipo_usuario)
                                       .Where(u => (u.empleado.persona.persona_fisica.nombre_persona.StartsWith(_nombre) || u.empleado.persona.persona_fisica.apellido_persona.StartsWith(_nombre)) && u.estado == state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .ToListAsync(token);
        }

        // Los mismos metodos que los anteriores pero con DTO.
        public async Task<List<UsuarioDTO>> listar_UsuariosDniEstadoDTO(int dni, bool state, CancellationToken token)
        {
            return await _context.Usuarios.Where(u => (u.empleado.persona.persona_fisica.dni_persona.ToString().StartsWith(dni.ToString())) && u.estado == state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .Select(u => new UsuarioDTO
                                       {
                                           id_usuario = u.id_usuario,
                                           apellido = u.empleado.persona.persona_fisica.apellido_persona,
                                           nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                           dni = u.empleado.persona.persona_fisica.dni_persona,
                                           username = u.username,
                                           descripcion_tipo = u.tipo_usuario.descripcion_tipo,
                                           telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                           email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                           calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                           altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                           piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                           depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                       })
                                       .ToListAsync(token);
        }

        public async Task<List<UsuarioDTO>> listar_UsuariosNombreEstadoDTO(string _nombre, bool state, CancellationToken token)
        {
            return await _context.Usuarios.Where(u => (u.empleado.persona.persona_fisica.nombre_persona.StartsWith(_nombre) || u.empleado.persona.persona_fisica.apellido_persona.StartsWith(_nombre)) && u.estado == state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .Select(u => new UsuarioDTO
                                       {
                                           id_usuario = u.id_usuario,
                                           apellido = u.empleado.persona.persona_fisica.apellido_persona,
                                           nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                           dni = u.empleado.persona.persona_fisica.dni_persona,
                                           username = u.username,
                                           descripcion_tipo = u.tipo_usuario.descripcion_tipo,
                                           telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                           email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                           calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                           altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                           piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                           depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                       })
                                       .ToListAsync(token);
        }

        // Otrs metodos.
        public List<Usuario> listar_UsuariosDni(int _dni)
        {
            return _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)
                                       .Include(u => u.tipo_usuario)
                                       .Where(u => u.empleado.persona.persona_fisica.dni_persona.ToString().StartsWith(_dni.ToString()))
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .ToList();
        }

        public List<UsuarioDTO> listar_UsuariosPorTipo(int _tipo, bool _state)
        {
            return _context.Usuarios.Where(u => u.tipo_perfil == _tipo && u.estado == _state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .Select(u => new UsuarioDTO
                                       {
                                           id_usuario = u.id_usuario,
                                           apellido = u.empleado.persona.persona_fisica.apellido_persona,
                                           nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                           dni = u.empleado.persona.persona_fisica.dni_persona,
                                           username = u.username,
                                           estado = u.estado,
                                           descripcion_tipo = u.tipo_usuario.descripcion_tipo,
                                           telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                           email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                           calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                           altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                           piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                           depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                       })
                                       .ToList();
        }

        public List<UsuarioDTO> listar_UsuariosPorGenero(string _genero, bool _state)
        {
            return _context.Usuarios.Where(u => u.empleado.persona.persona_fisica.sexo == _genero && u.estado == _state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                       .Select(u => new UsuarioDTO
                                       {
                                           id_usuario = u.id_usuario,
                                           apellido = u.empleado.persona.persona_fisica.apellido_persona,
                                           nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                           dni = u.empleado.persona.persona_fisica.dni_persona,
                                           username = u.username,
                                           estado = u.estado,
                                           descripcion_tipo = u.tipo_usuario.descripcion_tipo,
                                           telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                           email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                           calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                           altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                           piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                           depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                       })
                                       .ToList();
        }

        public List<UsuarioDTO> listar_UsuarioPorGeneroTipo(int _tipo, string _genero, bool _state)
        {
            return _context.Usuarios.Where(u => u.empleado.persona.persona_fisica.sexo == _genero && u.tipo_perfil == _tipo && u.estado == _state)
                                       .OrderBy(u => u.empleado.persona.persona_fisica.apellido_persona)
                                        .Select(u => new UsuarioDTO
                                        {
                                            id_usuario = u.id_usuario,
                                            apellido = u.empleado.persona.persona_fisica.apellido_persona,
                                            nombre = u.empleado.persona.persona_fisica.nombre_persona,
                                            dni = u.empleado.persona.persona_fisica.dni_persona,
                                            username = u.username,
                                            estado = u.estado,
                                            descripcion_tipo = u.tipo_usuario.descripcion_tipo,
                                            telefono = u.empleado.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                            email = u.empleado.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                            calle = u.empleado.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                            altura = u.empleado.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                            piso = u.empleado.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                            depto = u.empleado.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                        }) 
                                       .ToList();
        } 

        public Usuario buscar_usuario_id(int _id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.id_usuario == _id); 
        }

        // -- UPDATE -- 
        public Usuario update_AllUserRelationship(Usuario datos_modificados)
        {
           
            Usuario usuario_modificar = _context.Usuarios.Include(u => u.empleado)
                                       .Include(u => u.empleado.persona)
                                       .Include(u => u.empleado.persona.contactos)
                                       .Include(u => u.empleado.persona.direcciones)
                                       .Include(u => u.tipo_usuario)
                                       .FirstOrDefault(u => u.empleado.id_persona == datos_modificados.empleado.id_persona);


            // Se debe hacer comprobaciones por cada entidad.
            if (usuario_modificar != null)
            {
                _context.Entry(usuario_modificar).CurrentValues.SetValues(datos_modificados); 
            }
            
            return usuario_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
            
        } 

        public Usuario update_user(Usuario datos_modificados)
        {
            Usuario usuario_modificar = this.buscar_usuario_id(datos_modificados.id_usuario);

            if (usuario_modificar != null)
            {
                // Attach: Le dice al contexto que comience a rastrear la entidad (usuario_modificar) y la marca como UNCHANGED por defecto.
                // Si luego se modifican propiedades del objeto usuario_modificar, EF detectara los cambios y cambiara el estado de la entidad a MODIFIED.
                // Cuando se llama a SaveChanges solo se ejecutaran las consultas UPDATE para los campos que realmente se cambiaron.
                // _context.Usuarios.Attach(usuario_modificar); 

                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                //        Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.   
                _context.Entry(usuario_modificar).CurrentValues.SetValues(datos_modificados);  

             }

             return usuario_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar.  
        }  
    }
}
 
