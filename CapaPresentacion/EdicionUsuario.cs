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

            this.TBDni.Text = Convert.ToString(_usuario.persona.dni_persona);

            this.TBNombre.Text = _usuario.persona.nombre_persona;

            this.TBApellido.Text = _usuario.persona.apellido_persona;

            // Configuración de sexo 
            if (_usuario.persona.sexo == "Hombre")
            {
                this.RBHombre.Checked = true;
            }
            else if (_usuario.persona.sexo == "Mujer")
            {
                this.RBMujer.Checked = true;
            }

            // Fecha de nacimiento.   
            // Propiedad checked = true para poder modificar la fecha en el DTP. 
            this.DTPFechaNacimiento.Checked = true;
            this.DTPFechaNacimiento.Value = _usuario.persona.fecha_nacimiento;

            // Datos de contacto y dirección 
            this.TBEmail.Text = _usuario.persona.email;

            this.TBTelefono.Text = Convert.ToString(_usuario.persona.telefono);

            // Cargamos los datos de direccion.  
            this.TBCalle.Text = _usuario.persona.direccion.FirstOrDefault().calle;

            this.TBAltura.Text = Convert.ToString(_usuario.persona.direccion.FirstOrDefault().altura);

            // Preguntamos si hay un piso establecido para activar los botones
            if (!string.IsNullOrEmpty(_usuario.persona.direccion.FirstOrDefault().piso))
            {

                // Indicamos que es departamento.
                this.CBDepartamento.Checked = true;

                //Asignamos el valor de los combobox piso y depto y eliminamos el mensaje del errorProvider
                this.COMBOBPiso.Text = Convert.ToString(_usuario.persona.direccion.FirstOrDefault()?.piso);
                this.errorProvider1.SetError(COMBOBPiso, "");


                this.COMBOBDepto.Text = Convert.ToString(_usuario.persona.direccion.FirstOrDefault()?.depto);
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
                }
                else if (!string.IsNullOrEmpty(TBEURepetir.Text) && !TBNuevaContraseña.Text.Equals(TBEURepetir.Text))
                {
                    errorProvider1.SetError(TBEURepetir, "La repeticion no coincide con la nueva contraseña.");
                } 
            }
             
        }

        //Cuando cambiamos de control y nos vamos al TBContraseña, la realizar la modificacion en este no salta el EP acerca de que las contraseñas no son iguales.
        private void TBGURepetir_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBNuevaContraseña.Text))
            {
                if (string.IsNullOrEmpty(TBEURepetir.Text))
                {
                    errorProvider1.SetError(TBEURepetir, "El campo Repetir Contraseña es obligatorio");

                }
                else if (!TBNuevaContraseña.Text.Equals(TBEURepetir.Text))
                {
                    errorProvider1.SetError(TBEURepetir, "Las repiticion debe coincidir con la nueva contraseña.");
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

        private void BActualizarUsuario_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            CN_Usuario usuario = new CN_Usuario(); 
            CN_Persona persona = new CN_Persona();
            CN_Direccion direccion = new CN_Direccion(); 

            if (this.ValidateChildren())
            {
                // Simplemente se cargan los valores.
                bool validacionDireccion = this.UpdateDataDireccion();
                bool validacionPersona = this.UpdateDataPersona(); 
                bool validacionUsuario = this.UpdateDataUser(); 
                 
                // Agregamos la condicion en funcion da dicha validacion. 
                if ( validacionDireccion && validacionPersona  && validacionUsuario )
                {  

                    try
                    {    
                        // Actualizar las entidades.
                        persona.updatePersona(user_edit.persona);
                        direccion.updateDireccion(user_edit.persona.direccion.FirstOrDefault());
                        usuario.updateUser(user_edit); // Hay que ver que pasa con el hash de la contraseña

                        MessageBox.Show("Los datos han sido actualizados correctamente.", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 

                }
                else
                {
                    MessageBox.Show("Se encontraron errores, verifique los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Ha surgido un error y no se pudo actualizar el usuario.");
            }

        } 

        // Funciona correctamente.
        private bool UpdateDataDireccion()
        {
            CN_Direccion direccion = new CN_Direccion();

            bool modificadoCalle = false;
            bool modificadoAltura = false;
            bool modificadoDepartamento = false;

            bool estado = true;

            // Modificacion calle. 
            if (!(this.user_edit.persona.direccion.FirstOrDefault()?.calle == this.TBCalle.Text))
            {
                modificadoCalle = true;
            }

            //Modificacion altura
            if (!(this.user_edit.persona.direccion.FirstOrDefault()?.altura == Convert.ToInt16(this.TBAltura.Text)))
            {
                modificadoAltura = true;
            }

            // Modificacion piso/depto. 
            // En caso que no haya asignado un departamento en la direccion y que el combo box presente un cambio.
            if ( string.IsNullOrEmpty(this.user_edit.persona.direccion.FirstOrDefault()?.piso) && this.COMBOBPiso.SelectedIndex != -1)
            {
                modificadoDepartamento = true;
            }

            // En caso de que haya asignado un departamento y se haya cambiado ya sea el piso o el depto. 
            if (this.user_edit.persona.direccion.FirstOrDefault()?.piso != this.COMBOBPiso.Text || this.user_edit.persona.direccion.FirstOrDefault()?.depto != this.COMBOBDepto.SelectedIndex + 1)
            {
                modificadoDepartamento = true;
            }  

            // En caso que haya asignado un departamento y se busca eliminar el mismo.
            if (!string.IsNullOrEmpty(this.user_edit.persona.direccion.FirstOrDefault()?.piso) && this.CBDepartamento.Checked) 
            {
                modificadoDepartamento = true;
            }

            if (modificadoCalle) 
            { 
                var validacion = direccion.validarCalle(this.TBCalle.Text);

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false;
                }
                else
                {
                    this.user_edit.persona.direccion.FirstOrDefault().calle = this.TBCalle.Text;
                }
            }

            if (modificadoAltura)
            {
                var validacion = direccion.validarAltura(Convert.ToInt32(this.TBAltura.Text));

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false;
                }
                else
                {
                    this.user_edit.persona.direccion.FirstOrDefault().altura = Convert.ToInt16(this.TBAltura.Text);
                }

            }

            if (modificadoDepartamento) 
            { 
                if (this.CBDepartamento.Checked == true)  
                { 
                    this.user_edit.persona.direccion.FirstOrDefault().piso = this.COMBOBPiso.Text;
                    this.user_edit.persona.direccion.FirstOrDefault().depto = this.COMBOBDepto.SelectedIndex + 1;
                } 

                if (this.CBDepartamento.Checked == false) 
                {
                    this.user_edit.persona.direccion.FirstOrDefault().piso = null;
                    this.user_edit.persona.direccion.FirstOrDefault().depto = 0;
                }
                
            } 

            // En caso de que solo haya queda seleccionado el CheckBox sin asignar piso y depto.
            if(this.CBDepartamento.Checked == true && this.COMBOBPiso.SelectedIndex == -1 && this.COMBOBDepto.SelectedIndex == -1 ) 
            {
                estado = false;
            } 

            return estado;
        }

        private bool UpdateDataPersona()
        {
            //Modificacion datos persona.
            CN_Persona persona = new CN_Persona();
             
            bool modificadoTelefono = false;
            bool modificadoEmail = false;
            bool modificadoNombre = false;
            bool modificadoApellido = false;
            bool modificadoDni = false;
            bool modificadoSexo = false;
            bool modificadoFNacimiento = false; 

            // Cargamos el sexo.
            string sexo = string.Empty;

            if (this.RBHombre.Checked)
            {
                sexo = "Hombre";
            }
            else if (this.RBMujer.Checked)
            {
                sexo = "Mujer";
            }
            // -----------------------

            bool estado = true;    

            if (!(this.user_edit.persona.telefono == Convert.ToInt64(this.TBTelefono.Text)))
            {
                modificadoTelefono = true;
            }

            if (!(this.user_edit.persona.email == this.TBEmail.Text))
            {
                modificadoEmail = true;
            }

            if(!(this.user_edit.persona.nombre_persona == this.TBNombre.Text))
            {
                modificadoNombre = true; 
            }

            if(!(this.user_edit.persona.apellido_persona == this.TBApellido.Text))
            {
                modificadoApellido = true;
            }

            if(!(this.user_edit.persona.dni_persona == Convert.ToInt32(this.TBDni.Text)))
            { 
                modificadoDni = true;
            }

            // Menor importancia
            if (!(this.user_edit.persona.sexo == sexo)) 
            { 
                modificadoSexo = true;
            }

            if(!(this.user_edit.persona.fecha_nacimiento == this.DTPFechaNacimiento.Value))
            {
                modificadoFNacimiento = true;
            }



            // Debemos comprobar que dicho numero no exista.
            if (modificadoTelefono)
            { 
                var validacion = persona.validarTelefono(Convert.ToInt64(this.TBTelefono.Text));

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false; 
                }
                else
                {
                    this.user_edit.persona.telefono = Convert.ToInt64(this.TBTelefono.Text); 
                }  
            }

            if (modificadoEmail)
            {
                var validacion = persona.validarEmail(this.TBEmail.Text);

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false;
                }
                else
                {
                    this.user_edit.persona.email = this.TBEmail.Text; 
                }
            }

            if (modificadoDni) 
            {
                var validacion = persona.validarDni(Convert.ToInt32(this.TBDni.Text));

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false;
                }
                else
                {
                    this.user_edit.persona.dni_persona = Convert.ToInt32(this.TBDni.Text);
                } 
            }

            return estado; 
        }

        //Funciona correctammente.
        private bool UpdateDataUser()
        {
            CN_Usuario usuario = new CN_Usuario();

            bool modificadoUsername = false;
            bool modificadoContraseña = false;
            bool modificadoTipoPerfil = false;

            bool estado = true; 

            //Compruebo que campos fueron modificados.
            if (!(this.user_edit.username == this.TBGUUsername.Text))
            {
                modificadoUsername = true;
            }

            if (!(string.IsNullOrEmpty(this.TBEUContraseña.Text) && string.IsNullOrEmpty(this.TBNuevaContraseña.Text) && string.IsNullOrEmpty(this.TBEURepetir.Text))) 
            {
                modificadoContraseña = true; 
            }
              
            if (!(this.user_edit.tipo_perfil == this.COMBOBTipoUsuario.SelectedIndex + 1))
            {
                modificadoTipoPerfil = true;
            }


            // Tratamiento Username
            if (modificadoUsername)
            { 
                var validacion = usuario.validarUsername(this.TBGUUsername.Text);

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false; 
                }
                else 
                { 
                    this.user_edit.username  = this.TBGUUsername.Text;
                } 
            } 


            // Tratameinto contraseña
            if (modificadoContraseña)
            { 
                // Es correcto usar el passwordVerify ?
                bool validacionContraseña = usuario.VerificarPassword(this.TBEUContraseña.Text, this.user_edit.contraseña);
                 
                
                if (validacionContraseña)
                {
                    // Aca no voy a preguntar por si son iguales, simplemente asigno, de esto se deberia encargar la validacion subyacente. 
                    if ( !string.IsNullOrEmpty(this.TBNuevaContraseña.Text) && this.TBNuevaContraseña.Text.Equals(this.TBEURepetir.Text))
                    {
                        var validacion = usuario.validarContraseña(this.TBNuevaContraseña.Text);

                        if (validacion.Count != 0)
                        {
                            this.mostrarErrores(validacion);
                            estado = false;
                        }
                        else 
                        {
                            this.user_edit.contraseña = this.TBNuevaContraseña.Text;
                        }
                    }
                    else
                    { 
                        errorProvider1.SetError(TBEURepetir, "La repeticion no coincide con la nueva contraseña. ");
                        estado = false;
                    }
                }
                else
                {
                    errorProvider1.SetError(TBEUContraseña, "Debe ingresar su contraseña actual."); 
                    estado = false;
                }
            }

            // Tratamiento tipo perfil.
            if (modificadoTipoPerfil)
            {
                var validacion = usuario.validarTipoUsuario(this.COMBOBTipoUsuario.SelectedIndex + 1);

                if (validacion.Count != 0)
                {
                    this.mostrarErrores(validacion);
                    estado = false;
                }
                else 
                {
                    this.user_edit.tipo_perfil = this.COMBOBTipoUsuario.SelectedIndex + 1;
                }
               
            }

            return estado; 
        } 
    }
}

