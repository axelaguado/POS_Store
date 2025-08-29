using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaDatos;
using System.ComponentModel;
using BCrypt.Net;
using WindowsFormsApp1.CapaPresentacion;
using System.Data.Entity.Infrastructure;
using System.Windows.Forms;
using System.Runtime.Remoting.Contexts;


namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Usuario
    {
        public int CrearUsuario(Usuario _usuario)
        {
            // Hasheamos la contraseña para guardarla.
            var hash = hashPassword(_usuario.contraseña);
            _usuario.contraseña = hash;

            // Llamar a la capa de datos para guardar el usuario.
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            return usuarioDAO.Crear_usuario(_usuario);
        }

        public string hashPassword(string _contraseña)
        {
            // Generar un hash con bcrypt y la "salt" automática. "Salt" --> Evita que contraseñas iguales tengan el mismo hash.
            return BCrypt.Net.BCrypt.HashPassword(_contraseña);
        }

        // Método para verificar si una contraseña es válida (útil para el login)
        public bool VerificarPassword(string contraseña, string hashAlmacenado)
        {
            // Compara la contraseña con el hash almacenado en la base de datos
            try
            {
                return BCrypt.Net.BCrypt.Verify(contraseña, hashAlmacenado);
            }
            catch (UnauthorizedAccessException na) 
            {
                return false;
            }
        } 

        public Dictionary<string, string> ValidarUsuario(Usuario _usuario)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();
            MiDbContext context = new MiDbContext();

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
            //Ver como modificar para la edicion
            else if (context.Usuarios.FirstOrDefault(u => u.username == _usuario.username) != null)
            {
                errores.Add("TBGUUsername", "El nombre de usuario ingresado ya existe.");
            } 


            // Validaciones campo tipo_perfil. 

            if (!context.Tipo_Usuarios.Any(tu => tu.id_tipo == _usuario.tipo_perfil))
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

        public Dictionary<string, string> validarUsername (string _ussername )
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(_ussername))
            {
                errores.Add("TBGUUsername", "El campo usuario es obligatorio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_ussername, @"^[a-zA-Z\d._-]+$"))
            {
                errores.Add("TBGUUsername", "El campo usuario solo puede contener letras, numeros, puntos, guion y guion bajo");
            }
            //Ver como modificar para la edicion
            else if (this.buscar_usuario_username(_ussername) != null)
            {
                errores.Add("TBGUUsername", "El nombre de usuario ingresado ya existe.");
            }

            return errores;
        }

        public Dictionary<string, string> validarContraseña(string _contraseña)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();

            if (string.IsNullOrEmpty(_contraseña))
            {
                errores.Add("TBGUContraseña", "El campo contraseña es obligatorio.");
            }
            if (_contraseña.Length < 8)
            {
                errores.Add("TBGUContraseña", "La contraseña ingresada es muy corta. Ingrese mas caracteres para mayor seguridad.");
            }

            return errores;
        }

        public Dictionary<string, string> validarTipoUsuario(int _tipo)
        {
            Dictionary<string, string> errores = new Dictionary<string, string>();
            CN_TipoUsuario tipo = new CN_TipoUsuario();
             
            // Validaciones campo tipo_perfil. 

            if (tipo.buscarTipo(_tipo) == null )
            {
                errores.Add("COMBOBTipoUsuario", "El tipo de usuario no es valido.");
            }

            return errores;
        }

        public Usuario buscar_usuario_id(int id_persona)
        {
            Usuario user_found = new Usuario();

            return user_found = this.listarUsuarios().FirstOrDefault(u => u.id_persona == id_persona);
        }

        public Usuario buscar_usuario_username(string _username)
        {
            Usuario user_found = new Usuario();

            return user_found = this.listarUsuarios().FirstOrDefault(u => u.username == _username);
        } 
        
        public List<Usuario> listarUsuarios()
        {
            UsuarioDAO nuevo = new UsuarioDAO();

            List<Usuario> lista = nuevo.listar_Usuarios(); 

            if (lista == null)
            {
                throw new Exception("No se han encontrado elementos.");
            }
            else
            {
                return lista;
            }
        }

            public void loginUsuario(string username, string contraseña)
            {

                // Buscamos el usuario por su username para verificar que existe.

                Usuario encontrado = this.buscar_usuario_username(username);

                // Si el usuario no fue encontrado o la contraseña no coincide se lanza una excepcion.
                if (encontrado == null || !this.VerificarPassword(contraseña, encontrado.contraseña))
                {
                    throw new UnauthorizedAccessException("Usuario y/o contraseña incorrectos");
                }

            } 


            public List<Usuario> listarUsuariosTipo(int _tipo)
            {
                UsuarioDAO usuario = new UsuarioDAO();
                List<Usuario> lista = new List<Usuario>();

                lista = usuario.listar_Usuarios().Where(u => u.tipo_perfil == _tipo).ToList();

                if (lista == null)
                {
                    throw new Exception("No se han encontrado elementos.");
                }
                else
                {
                    return lista;
                }
            }

            public Usuario updateUser(Usuario datos_modificar)
            {
                UsuarioDAO usuario = new UsuarioDAO();
                Usuario usuarioActual = usuario.buscar_usuario_id(datos_modificar.id_persona);

                // Si la contraseña no se modificó, no la hasheamos nuevamente
                if (!usuarioActual.contraseña.Equals(datos_modificar.contraseña))
                {
                    datos_modificar.contraseña = this.hashPassword(datos_modificar.contraseña);
                }

                return usuario.update_user(datos_modificar);
                  
            }


        }
    }
 
