using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class EdicionUsuario : GestionUsuario
    { 
        private Usuario user_edit;
        private string permisos;

        public EdicionUsuario(Usuario _usuario, string _permisos)
        {
            InitializeComponent();

            this.user_edit = _usuario;
            this.permisos = _permisos;

            this.CargarDatosUsuarioEdit(this.user_edit);
            this.DesactivarControlesNoEdit();   

        }

        private void DesactivarControlesNoEdit()
        {
            // Desactivamos controles que contengan datos que no puedan ser modificados.
            // Datos persona. 
            if (this.permisos == "Gerente")
            {
                this.TBGUUsername.Enabled = false;
                this.COMBOBTipoUsuario.Enabled = false;
            }

        }
        private void DescativarControlesNoEditGerente()
        {
            // Desactivamos controles que contengan datos que no puedan ser modificados.
            // Datos usuario.
            this.TBGUUsername.Enabled = false;
            this.COMBOBTipoUsuario.Enabled = false; 
        } 

        private void DescativarControlesNoEditAdministrador()
        {
            // Desactivamos controles que contengan datos que no puedan ser modificados.
            // Datos persona.
            this.TBDni.Enabled = false;
            this.TBNombre.Enabled = false;
            this.TBApellido.Enabled = false;

            this.RBHombre.Enabled = false;
            this.RBMujer.Enabled = false;

            this.DTPFechaNacimiento.Enabled = false;
        }

        private void CargarDatosUsuarioEdit(Usuario _usuario)
        { 
            this.TBDni.Text = Convert.ToString(_usuario.empleado.persona.persona_fisica.dni_persona);

            this.TBNombre.Text = _usuario.empleado.persona.persona_fisica.nombre_persona;

            this.TBApellido.Text = _usuario.empleado.persona.persona_fisica.apellido_persona;

            // Configuración de sexo 
            if (_usuario.empleado.persona.persona_fisica.sexo == "Hombre")
            {
                this.RBHombre.Checked = true;
            }
            else if (_usuario.empleado.persona.persona_fisica.sexo == "Mujer")
            {
                this.RBMujer.Checked = true;
            }

            // Fecha de nacimiento.   
            // Propiedad checked = true para poder modificar la fecha en el DTP. 
            this.DTPFechaNacimiento.Checked = true;
            this.DTPFechaNacimiento.Value = _usuario.empleado.persona.persona_fisica.fecha_nacimiento;

            // Datos de contacto y dirección 
            Contacto contacto = _usuario.empleado.persona.contactos.FirstOrDefault();
            Direccion direccion = _usuario.empleado.persona.direcciones.FirstOrDefault();

            this.TBEmail.Text = contacto.email;
            this.TBTelefono.Text = Convert.ToString(contacto.telefono);

            // Cargamos los datos de direccion.  
            this.TBCalle.Text = direccion.calle;
            this.TBAltura.Text = Convert.ToString(direccion.altura);

            // Preguntamos si hay un piso establecido para activar los botones 
            if (!string.IsNullOrEmpty(direccion.piso))
            {

                // Indicamos que es departamento.
                this.CBDepartamento.Checked = true;

                //Asignamos el valor de los combobox piso y depto y eliminamos el mensaje del errorProvider
                this.COMBOBPiso.Text = Convert.ToString(direccion.piso);
                this.errorProvider1.SetError(COMBOBPiso, "");


                this.COMBOBDepto.Text = Convert.ToString(direccion.depto);
                this.errorProvider1.SetError(COMBOBDepto, "");
            }

            //Cargamos los datos de usuario.
            this.TBGUUsername.Text = _usuario.username;
            this.COMBOBTipoUsuario.Text = _usuario.tipo_usuario.descripcion_tipo;
        }


        // Esto esta mal porque no es obligatoria la insercion de la contraseña en caso de que no vaya a modificarse, caso contrario si es necesario.
        // Ya se modifico para que sea solo en caso de que el campo TBNuevaContraseña no sea nulo o vacio.
        private void TBGUContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBNuevaContraseña.Text))
            {
                if (string.IsNullOrEmpty(TBEUContraseña.Text)) 
                {
                    errorProvider1.SetError(TBEUContraseña, "Debe ingresar su contraseña actual.");
                    this.load_ErrorProvider = true;
                } 
            }  
             
        }

        private void TBGUNuevaContraseña_Validating(object sender, CancelEventArgs e)
        { 

            if (!string.IsNullOrEmpty(TBNuevaContraseña.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(TBNuevaContraseña.Text, @"\d"))
                {
                    errorProvider1.SetError(TBNuevaContraseña, "La contraseña debe contener al menos un caracter nuemerico");
                    this.load_ErrorProvider = true;
                }  
            }
             
        }

        //Cuando cambiamos de control y nos vamos al TBContraseña, la realizar la modificacion en este no salta el EP acerca de que las contraseñas no son iguales.
        private void TBGURepetir_Validating(object sender, CancelEventArgs e)
        {

            if (!string.IsNullOrEmpty(TBNuevaContraseña.Text))
            { 
                if (!TBNuevaContraseña.Text.Equals(TBEURepetir.Text))
                {
                    errorProvider1.SetError(TBEURepetir, "Las contraseñas deben coincidir.");
                    this.load_ErrorProvider = true;
                } 
            }
            else
            {
                errorProvider1.SetError(TBEURepetir, "");
            }
        } 

        private void BTNRestablecer_Click(object sender, EventArgs e)
        {
            this.CargarDatosUsuarioEdit(this.user_edit);
            // Falta eliminar los posibles mensaje del error provider. 
        }

        private void cargarNuevosValores() 
        {
            // Trabajamos los radio button y los asignamos a la variable sexo. 
            string sexo = string.Empty;

            if (RBHombre.Checked)
            {
                sexo = "Hombre";
            }
            else if (RBMujer.Checked)
            {
                sexo = "Mujer";
            }

            // Manejamos los datos personales del nuevo usaurio. 
            this.user_edit.empleado.persona.persona_fisica.dni_persona = Convert.ToInt32(TBDni.Text);
            this.user_edit.empleado.persona.persona_fisica.nombre_persona = TBNombre.Text;
            this.user_edit.empleado.persona.persona_fisica.apellido_persona = TBApellido.Text;
            this.user_edit.empleado.persona.persona_fisica.fecha_nacimiento = DTPFechaNacimiento.Value;
            this.user_edit.empleado.persona.persona_fisica.sexo = sexo;

            // Manejamos los datos de contacto.

            this.user_edit.empleado.persona.contactos.FirstOrDefault().telefono = Convert.ToInt64(TBTelefono.Text);
            this.user_edit.empleado.persona.contactos.FirstOrDefault().email = TBEmail.Text;

            // Aca tenemos un problema en como tratar el combo box depto y piso en caso de que estos datos no sean cargados.
            // Por ejemplo COMBOBDepto es int y por lo tanto no puede ser null.
            //
            // Manejamos la direccion del nuevo usuario.  

            if (this.CBDepartamento.Checked == true)
            {
                // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                this.user_edit.empleado.persona.direcciones.FirstOrDefault().calle = TBCalle.Text;
                this.user_edit.empleado.persona.direcciones.FirstOrDefault().altura = Convert.ToInt16(TBAltura.Text);
                this.user_edit.empleado.persona.direcciones.FirstOrDefault().piso = COMBOBPiso.Text;
                this.user_edit.empleado.persona.direcciones.FirstOrDefault().depto = Convert.ToInt16(COMBOBDepto.Text);
            }
            else
            {
                this.user_edit.empleado.persona.direcciones.FirstOrDefault().calle = TBCalle.Text;
                this.user_edit.empleado.persona.direcciones.FirstOrDefault().altura = Convert.ToInt16(TBAltura.Text);
            }

            // Manejamos los datos del usuario.
            this.user_edit.username = TBGUUsername.Text;  

            // Hay que verificar si se ingresa una cotnraseña nueva y asignar en caso ed ser asi.
            if(!string.IsNullOrEmpty(this.TBNuevaContraseña.Text))
            {
                this.user_edit.contraseña = TBNuevaContraseña.Text;
            } 

            this.user_edit.tipo_perfil = (COMBOBTipoUsuario.SelectedIndex + 1); 
        }

        private void BActualizarUsuario_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(this.TBEUContraseña, "");
            this.load_ErrorProvider = false;

            if (this.ValidateChildren())
            {
                if (this.load_ErrorProvider)
                { 
                    return;
                }
            }

            CN_Usuario usuario = new CN_Usuario();

            // Comprobamos que la contraseña antigua sea correcta para poder realizar el cambio
            if (!string.IsNullOrEmpty(this.TBEUContraseña.Text)) 
            {
                if (!usuario.PassValidarCambio(this.user_edit.id_usuario, this.TBEUContraseña.Text))
                {
                    errorProvider1.SetError(this.TBEUContraseña, "La contraseña ingresada no es correcta.");
                    return;
                }     
            }

            this.cargarNuevosValores();  

            try
            {  
                int resultado = usuario.ActualizarUsuarioCompleto(this.user_edit); 
                
                if (resultado != 0)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.mostrarErrores(usuario.GetErrors());
                    MessageBox.Show("Ha ocurrido un error, verifique los datos suministrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in entityErrors.ValidationErrors)
                    {
                        MessageBox.Show(
                            "Propiedad: " + error.PropertyName +
                            "\nError: " + error.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 

    }
}

