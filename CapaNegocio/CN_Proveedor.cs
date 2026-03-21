using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Proveedor
    {
        Dictionary<string, string> validacion;

        public CN_Proveedor()
        {
            this.validacion = new Dictionary<string, string>();
        } 

        public void CrearProveedor(Proveedor _proveedor)
        {
            // Deberia preguntar si se cumple ValidarProveedor y utilizar los bloques Try - catch.
            using (var context = new MiDbContext()) 
            {
                ProveedorDAO proveedorDAO = new ProveedorDAO(context);
                proveedorDAO.Crear_proveedor(_proveedor); // Retornar el ID de la dirección
            }     
        }
         
        public Proveedor CrearProveedorCompleto(PersonaJuridica _personaJuridica, Direccion _direccion, Contacto _contacto)
        {
            // Limpiamos el dictionary de validacion.
            this.validacion.Clear();

            // Algunas entidades que vamos a necesitar.
            CN_Persona nuevaPersona = new CN_Persona();
            CN_PersonaJuridica nuevaPersonaJuridica = new CN_PersonaJuridica();

            CN_Contacto nuevoContacto = new CN_Contacto();
            CN_Direccion nuevaDireccion = new CN_Direccion();

            CN_Proveedor nuevoProveedor = new CN_Proveedor();

            // Validamos toda la bullshit.     
            this.unirDiccionarios(nuevaPersonaJuridica.ValidarPersonaJuridica(_personaJuridica));
            this.unirDiccionarios(nuevaDireccion.ValidarDireccion(_direccion));
            this.unirDiccionarios(nuevoContacto.ValidarContacto(_contacto)); 

            if (this.validacion.Count() == 0)
            {
                // Hacemos el proceso de creacion.
                using (var context = new MiDbContext())
                {
                    // Algunas entidades que vamos a necesitar.
                    PersonaDAO personaDAO = new PersonaDAO(context);
                    PersonaJuridicaDAO personajuridcaDAO = new PersonaJuridicaDAO(context);

                    ContactoDAO contactoDAO = new ContactoDAO(context);
                    DireccionDAO direccionDAO = new DireccionDAO(context);

                    ProveedorDAO proveedorDAO = new ProveedorDAO(context);
                      
                    // Datos de la persona fisica  
                    Persona persona = new Persona();
                    personaDAO.Crear_persona(persona); 

                    _personaJuridica.persona = persona;
                    personajuridcaDAO.Crear_personajuridica(_personaJuridica);

                    // Datos para persona.

                    _contacto.persona = persona;
                    contactoDAO.Crear_contacto(_contacto);

                    _direccion.persona = persona;
                    direccionDAO.Crear_direccion(_direccion);

                    // Datos para usuario.
                    Proveedor proveedor = new Proveedor();
                    proveedor.persona = persona;

                    proveedorDAO.Crear_proveedor(proveedor);
 
                    // Para ver la salida por consola de la consulta que se realiza y demas
                    foreach (var entry in context.ChangeTracker.Entries())
                    {
                        System.Diagnostics.Debug.WriteLine(
                            entry.Entity.GetType().Name + " - " + entry.State
                        );
                    } 

                    context.SaveChanges();
                    return proveedor;
                }
            }
            else 
            {
                return null;
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

        public List<ProveedorDTO> ObtenerProveedores() 
        {
            using (var context = new MiDbContext()) 
            { 
                ProveedorDAO proveedorDAO = new ProveedorDAO(context);
                return proveedorDAO.Get_proveedores(); 
            } 
        }

        public Proveedor ObtenerProveedor(long id_proveedor)
        {
            using (var context = new MiDbContext())
            {
                ProveedorDAO proveedorDAO = new ProveedorDAO(context);
                return proveedorDAO.Get_proveedor(id_proveedor);
            }
        }
    }
}
