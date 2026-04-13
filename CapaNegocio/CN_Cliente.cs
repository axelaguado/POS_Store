using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Cliente
    {
        public Dictionary<string, string> validacion;
        public CN_Cliente()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public int CrearClienteCompleto(PersonaFisica _personaFisica, PersonaJuridica _personaJuridica, Contacto _contacto, Direccion _direccion) 
        {
            // Por el momento no contempla si la personaJuridica (que podria ya existir como proveedor) existe --> Lo mismo tengo que tener en cuenta para el caso que ya existe como cliente cuando quiero introducir un proveedor.
            // Tambien faltaria pulir los if donde decido si es personaFisica o personaJuridica. 

            // Limpiamos el dictionary de validacion.
            this.validacion.Clear();

            // Algunas entidades que vamos a necesitar. 
            CN_PersonaFisica nuevaPersonaFisica = new CN_PersonaFisica();
            CN_PersonaJuridica nuevaPersonaJuridica = new CN_PersonaJuridica();

            CN_Contacto nuevoContacto = new CN_Contacto();
            CN_Direccion nuevaDireccion = new CN_Direccion();
              
            // Validamos toda la bullshit.   
            if (_personaFisica != null) 
            { 
                this.unirDiccionarios(nuevaPersonaFisica.ValidarPersonaFisica(_personaFisica));
            }

            if (_personaJuridica != null) 
            {
                this.unirDiccionarios(nuevaPersonaJuridica.ValidarPersonaJuridica(_personaJuridica));
            }
            
            this.unirDiccionarios(nuevaDireccion.ValidarDireccion(_direccion));
            this.unirDiccionarios(nuevoContacto.ValidarContacto(_contacto)); 

            if (this.validacion.Count() == 0)
            {
                // Hacemos el proceso de creacion.
                using (var context = new MiDbContext())
                {
                    // Algunas entidades que vamos a necesitar.
                    PersonaDAO personaDAO = new PersonaDAO(context);
                    PersonaFisicaDAO personafisicaDAO = new PersonaFisicaDAO(context);
                    PersonaJuridicaDAO personajuridicaDAO = new PersonaJuridicaDAO(context);

                    ContactoDAO contactoDAO = new ContactoDAO(context);
                    DireccionDAO direccionDAO = new DireccionDAO(context);
                     
                    ClienteDAO clienteDAO = new ClienteDAO(context);
 
                    // Datos de la persona fisica  
                    Persona persona = new Persona();
                    personaDAO.Crear_persona(persona);

                    if(_personaFisica != null) 
                    { 
                        _personaFisica.persona = persona;
                        personafisicaDAO.Crear_personafisica(_personaFisica);
                    }
                     
                    if (_personaJuridica != null) 
                    {
                        _personaJuridica.persona = persona;
                        personajuridicaDAO.Crear_personajuridica(_personaJuridica);
                    }

                    // Datos para persona.

                    _contacto.persona = persona;
                    contactoDAO.Crear_contacto(_contacto);

                    _direccion.persona = persona;
                    direccionDAO.Crear_direccion(_direccion);

                    // Datos para usuario.
                    Cliente cliente = new Cliente();
                    cliente.persona = persona;

                    clienteDAO.Crear_cliente(cliente);

                    // Cargamos el usuario con su empleado correspondiente y hasheamos la contraseña. 

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
