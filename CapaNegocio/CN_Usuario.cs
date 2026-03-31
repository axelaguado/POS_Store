using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.DTO;
using System.ComponentModel;
using BCrypt.Net;
using WindowsFormsApp1.CapaPresentacion;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using System.Data.Entity;


namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Usuario
    {
        public Dictionary<string, string> validacion;
        public CN_Usuario() 
        { 
            this.validacion = new Dictionary<string, string>();
        }
         
        public void CrearUsuario(Usuario _usuario)
        {
            // Hasheamos la contraseña para guardarla.
            var hash = hashPassword(_usuario.contraseña);
            _usuario.contraseña = hash;

            using (var context = new MiDbContext())
            {
                // Llamar a la capa de datos para guardar el usuario.
                UsuarioDAO usuarioDAO = new UsuarioDAO(context);
                usuarioDAO.Crear_usuario(_usuario);
            }
        }

        public int CrearUsuarioCompleto(PersonaFisica _personaFisica, Usuario _usuario, Contacto _contacto, Direccion _direccion)
        {
            // Limpiamos el dictionary de validacion.
            this.validacion.Clear();

            // Algunas entidades que vamos a necesitar.
            CN_Persona nuevaPersona = new CN_Persona();
            CN_PersonaFisica nuevaPersonaFisica = new CN_PersonaFisica();

            CN_Contacto nuevoContacto = new CN_Contacto();
            CN_Direccion nuevaDireccion = new CN_Direccion();

            CN_Empleado nuevoEmpleado = new CN_Empleado();

            // Validamos toda la bullshit.   
            this.unirDiccionarios(nuevaPersonaFisica.ValidarPersonaFisica(_personaFisica));
            this.unirDiccionarios(nuevaDireccion.ValidarDireccion(_direccion));
            this.unirDiccionarios(nuevoContacto.ValidarContacto(_contacto));
            this.unirDiccionarios(this.ValidarUsuario(_usuario));

            if (this.validacion.Count() == 0)
            {
                // Hacemos el proceso de creacion.
                using (var context = new MiDbContext())
                {
                    // Algunas entidades que vamos a necesitar.
                    PersonaDAO personaDAO = new PersonaDAO(context);
                    PersonaFisicaDAO personafisicaDAO = new PersonaFisicaDAO(context);

                    ContactoDAO contactoDAO = new ContactoDAO(context);
                    DireccionDAO direccionDAO = new DireccionDAO(context);

                    EmpleadoDAO empleadoDAO = new EmpleadoDAO(context);
                    UsuarioDAO usuarioDAO = new UsuarioDAO(context);    
                      
                    // Datos de la persona fisica  
                    Persona persona = new Persona(); 
                    personaDAO.Crear_persona(persona);


                    _personaFisica.persona = persona;
                    personafisicaDAO.Crear_personafisica(_personaFisica);

                    // Datos para persona.
                    
                    _contacto.persona = persona;
                    contactoDAO.Crear_contacto(_contacto);

                    _direccion.persona = persona;
                    direccionDAO.Crear_direccion(_direccion);

                    // Datos para usuario.
                    Empleado empleado = new Empleado(); 
                    empleado.persona = persona; 

                    empleadoDAO.Crear_empleado(empleado);  

                    // Cargamos el usuario con su empleado correspondiente y hasheamos la contraseña.
                    _usuario.empleado = empleado;

                    string hash = this.hashPassword(_usuario.contraseña);
                    _usuario.contraseña = hash; 

                    usuarioDAO.Crear_usuario(_usuario);
                     
                    /*  Para ver la salida por consola de la consulta que se realiza y demas
                    foreach (var entry in context.ChangeTracker.Entries())
                    {
                        System.Diagnostics.Debug.WriteLine(
                            entry.Entity.GetType().Name + " - " + entry.State
                        );
                    }
                    */ 
                    
                    return context.SaveChanges(); 
                }
            } 
            else 
            {
                return 0;
            } 

        }

        public int ActualizarUsuarioCompleto(Usuario user_edit)
        {
            // Limpiamos el dictionary de validacion.
            this.validacion.Clear();

            // Algunas entidades que vamos a necesitar. 
            CN_PersonaFisica nuevaPersonaFisica = new CN_PersonaFisica();

            CN_Contacto nuevoContacto = new CN_Contacto();
            CN_Direccion nuevaDireccion = new CN_Direccion(); 

            // Validamos toda la bullshit.   
            this.unirDiccionarios(nuevaPersonaFisica.ValidarPersonaFisica(user_edit.empleado.persona.persona_fisica));
            this.unirDiccionarios(nuevaDireccion.ValidarDireccion(user_edit.empleado.persona.direcciones.FirstOrDefault()));
            this.unirDiccionarios(nuevoContacto.ValidarContacto(user_edit.empleado.persona.contactos.FirstOrDefault()));
            this.unirDiccionarios(this.ValidarUsuario(user_edit));

            if (this.validacion.Count() == 0)
            {
                // Hacemos el proceso de creacion.
                using (var context = new MiDbContext())
                {
                    PersonaFisicaDAO pf = new PersonaFisicaDAO(context);
                    ContactoDAO c = new ContactoDAO(context);
                    DireccionDAO d = new DireccionDAO(context);
                    UsuarioDAO u = new UsuarioDAO(context);

                    Usuario datos_actuales = u.buscar_usuario_id(user_edit.id_usuario); 

                    // Verificamos porque si en el user_edit no se creo una nueva contrañesa, significa que tiene la antigua y no es necesario hashearla ya que no se va actualizar.
                    if (!this.VerificarPassword(user_edit.contraseña, datos_actuales.contraseña))
                    {
                        user_edit.contraseña = this.hashPassword(user_edit.contraseña);
                    }

                    pf.update_personafisica(user_edit.empleado.persona.persona_fisica);
                    c.update_contacto(user_edit.empleado.persona.contactos.FirstOrDefault());
                    d.update_direccion(user_edit.empleado.persona.direcciones.FirstOrDefault());
                    u.update_user(user_edit);

                    return context.SaveChanges();
                }
            }
            else
            {
                return 0;
            }

        }

        public Usuario UpdateUser(Usuario datos_modficar)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                Usuario retorno = usuario.update_user(datos_modficar);

                context.SaveChanges();

                return retorno;
            }
        }

        // Metodo para verificar si la contraseña viejas es valida para realizar el cambio

        public bool PassValidarCambio(int id_user, string contraseniaavieja)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO user = new UsuarioDAO(context);
                Usuario encontrado = user.buscar_usuario_id(id_user);

                if (encontrado != null) 
                { 
                    if (this.VerificarPassword(contraseniaavieja, encontrado.contraseña))
                    {
                        return true;
                    }
                    else 
                    {
                        return false;
                    }
                }
                else { return false; }  
            }
        }


        // Método para verificar si una contraseña es válida (útil para el login)
        private bool VerificarPassword(string contraseña, string hashAlmacenado)
        {
            return BCrypt.Net.BCrypt.Verify(contraseña, hashAlmacenado);
        }

        private string hashPassword(string _contraseña)
        {
            // Generar un hash con bcrypt y la "salt" automática. "Salt" --> Evita que contraseñas iguales tengan el mismo hash.
            return BCrypt.Net.BCrypt.HashPassword(_contraseña);
        } 

        public Dictionary<string, string> ValidarUsuario(Usuario _usuario)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();
              
            // Validacion instancia usuario.
            if (_usuario == null)
            {
                errores.Add("Usuario", "Los datos de la cuenta no son validos.");
            }

            // Validaciones campo usuario. 
            if (string.IsNullOrEmpty(_usuario.username))
            {
                errores.Add("TBGUUsername", "El campo usuario es obligatorio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_usuario.username, @"^[a-zA-Z\d._-]+$"))
            {
                errores.Add("TBGUUsername", "El campo usuario solo puede contener letras, numeros, puntos, guion y guion bajo");
            }
            // Ver como modificar para la edicion
            // Si el usuario aun no se cargo en la BD y el username existe.
            else if (this.Username_Exist(_usuario))
            {
                errores.Add("TBGUUsername", "El nombre de usuario ingresado ya existe.");
            } 

            // Validaciones campo tipo_perfil. 
            CN_TipoUsuario tipoUsuario = new CN_TipoUsuario();
            if (tipoUsuario.buscarTipo(_usuario.tipo_perfil) == null)
            {
                errores.Add("COMBOBTipoUsuario", "El tipo de usuario no es valido.");
            }

            // Validaciones campo contraseña. 
            if (string.IsNullOrEmpty(_usuario.contraseña))
            {
                errores.Add("TBGUContraseña", "El campo contraseña es obligatorio.");
            }
            if (_usuario.contraseña.Length < 8)
            {
                errores.Add("TBGUContraseña", "La contraseña ingresada es muy corta. Ingrese mas caracteres para mayor seguridad.");
            }

            return errores;

        }

        

        public bool Username_Exist(Usuario _usuario)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO userDAO = new UsuarioDAO(context);
                return userDAO.UsernameExist(_usuario);
            }
        }

        public Usuario buscar_usuario_id(int id_persona)
        {
            Usuario user_found = new Usuario();
            return user_found = this.listarUsuarios().FirstOrDefault(u => u.empleado.id_persona == id_persona);
        } 

        public Usuario buscar_usuario_username(string _username)
        {  
            using (var context = new MiDbContext()) 
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                return usuario.BuscarUsername(_username);
            } 
        }

        public List<Usuario> listarUsuarios()
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO nuevo = new UsuarioDAO(context);
                List<Usuario> lista = nuevo.listar_Usuarios();

                return lista;
            }
        }

        // Metodo para listar activo con Include y con DTO
        public List<Usuario> listarUsuariosActivos()
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO nuevo = new UsuarioDAO(context);
                List<Usuario> lista = nuevo.listar_UsuariosActivos();

                return lista;
            }
        }

        public List<UsuarioDTO> listarUsuariosActivosDTO()
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO nuevo = new UsuarioDAO(context);
                List<UsuarioDTO> lista = nuevo.listar_UsuariosActivosDTO();

                return lista;
            }
        }

        // Metodo para listar inactivo con Include y con DTO
        public List<Usuario> listarUsuariosInactivos()
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO nuevo = new UsuarioDAO(context);
                List<Usuario> lista = nuevo.listar_UsuariosInactivos();

                return lista;
            }
        }

        public List<UsuarioDTO> listarUsuariosInactivosDTO()
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO nuevo = new UsuarioDAO(context);
                List<UsuarioDTO> lista = nuevo.listar_UsuariosInactivosDTO();

                return lista;
            }
        }

        public Usuario loginUsuario(string username, string contraseña)
        {
            // Buscamos el usuario por su username para verificar que existe. 
            Usuario encontrado = this.buscar_usuario_username(username);

            // Si el usuario no fue encontrado o la contraseña no coincide se lanza una excepcion.    
            if (encontrado == null || !this.VerificarPassword(contraseña, encontrado.contraseña))
            {
                throw new UnauthorizedAccessException("Usuario y/o contraseña incorrectos");
            }

            return encontrado;
        }


        public List<UsuarioDTO> listarUsuariosTipo(int _tipo, bool _state)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                List<UsuarioDTO> lista = new List<UsuarioDTO>();

                lista = usuario.listar_UsuariosPorTipo(_tipo, _state);

                return lista;
            }
        }

        public List<UsuarioDTO> listarUsuariosGenerotipo(int _tipo, string _genero, bool _state)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                List<UsuarioDTO> lista = usuario.listar_UsuarioPorGeneroTipo(_tipo, _genero, _state);

                return lista;
            }
        }

        public List<Usuario> listarUsuariosDni(int _dni)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                List<Usuario> lista = usuario.listar_UsuariosDni(_dni);

                return lista;
            }
        }

        public async Task<List<UsuarioDTO>> listarUsuariosDniEstado(int _dni, bool state, CancellationToken token)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                List<UsuarioDTO> lista = await usuario.listar_UsuariosDniEstadoDTO(_dni, state, token);

                return lista;
            }
        }


        public async Task<List<UsuarioDTO>> listarUsuariosNombreEstado(string nombre, bool state, CancellationToken token)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                List<UsuarioDTO> lista = await usuario.listar_UsuariosNombreEstadoDTO(nombre, state, token);

                return lista;
            }
        }

        public List<UsuarioDTO> listarUsuariosGenero(string _genero, bool _state)
        {
            using (var context = new MiDbContext())
            {
                UsuarioDAO usuario = new UsuarioDAO(context);
                List<UsuarioDTO> lista = usuario.listar_UsuariosPorGenero(_genero, _state);

                return lista;
            }
        } 

        public Dictionary<string, string> unirDiccionarios(Dictionary<string, string> _diccionario)
        {
            if (_diccionario != null)
            {
                foreach (var error in _diccionario)
                {
                    validacion[error.Key] = error.Value; // Agrega o actualiza
                }
            }

            return validacion;
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }
    } 
}
 
