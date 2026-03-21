using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionUsuario : Form, IConfigForm
    {
        protected bool load_ErrorProvider;

        public GestionUsuario( )
        {   
            InitializeComponent();
            cargarElementosCB();  
        }
         
        private void cargarElementosCB()
        {
            COMBOBPiso.Items.Add("PB");
            for (int i = 0; i < 100; i++)
            {
                COMBOBPiso.Items.Add(i + 1);
                COMBOBDepto.Items.Add(i + 1); 
            }
             
        }  

        protected void CBDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (CBDepartamento.Checked == true)
            {
                COMBOBDepto.Enabled = true;
                errorProvider1.SetError(COMBOBDepto, "Debe seleccionar el departamento"); 

                COMBOBPiso.Enabled = true;
                errorProvider1.SetError(COMBOBPiso, "Debe seleccionar el piso");
            }
            else
            {
                COMBOBDepto.Enabled = false;
                COMBOBDepto.SelectedIndex = -1;
                errorProvider1.SetError(COMBOBDepto, "");

                COMBOBPiso.Enabled = false;
                COMBOBPiso.SelectedIndex = -1;
                errorProvider1.SetError(COMBOBPiso, "");
            }
        } 

        private void TBNombre_TextChanged(object sender, EventArgs e)
        {
            // Convierte el objeto sender en un TextBox.
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                // Divide el texto en palabras.
                string[] palabras = textBox.Text.Split(' ');

                // Recorre cada palabra y capitaliza la primera letra.
                for (int i = 0; i < palabras.Length; i++)
                {
                    if (palabras[i].Length > 0)
                    {
                        palabras[i] = char.ToUpper(palabras[i][0]) + palabras[i].Substring(1).ToLower();
                    }
                }

                // Une las palabras con un espacio entre ellas.
                string textoFormateado = string.Join(" ", palabras);
                textBox.Text = textoFormateado;

                // Mover el cursor al final del texto.
                textBox.SelectionStart = textBox.Text.Length;
            }
        } 

        private void BRestaurar_Click(object sender, EventArgs e)
        {
            // Datos Personales
            TBDni.Text = string.Empty;
            errorProvider1.SetError(TBDni, "");

            TBNombre.Text = string.Empty;
            errorProvider1.SetError(TBNombre, "");

            TBApellido.Text = string.Empty;
            errorProvider1.SetError(TBApellido, "");

            DTPFechaNacimiento.Value = DateTime.Today;
            errorProvider1.SetError(DTPFechaNacimiento, "");

            RBHombre.Checked = true;

            // Informacion de Cuenta
            TBGUUsername.Text = string.Empty;
            errorProvider1.SetError(TBGUUsername, "");

            TBGUContraseña.Text = string.Empty;
            errorProvider1.SetError(TBGUContraseña, "");

            TBGURepetir.Text = string.Empty;
            errorProvider1.SetError(TBGURepetir, "");

            COMBOBTipoUsuario.SelectedIndex = -1;
            errorProvider1.SetError(COMBOBTipoUsuario, "");

            // Informacion de Contacto
            TBEmail.Text = string.Empty;
            errorProvider1.SetError(TBEmail, "");

            TBTelefono.Text = string.Empty;
            errorProvider1.SetError(TBTelefono, "");

            TBCalle.Text = string.Empty;
            errorProvider1.SetError(TBCalle, "");

            TBAltura.Text = string.Empty;
            errorProvider1.SetError(TBAltura, "");

            CBDepartamento.Checked = true;

            COMBOBPiso.SelectedIndex = -1;
            errorProvider1.SetError(COMBOBPiso, "");

            COMBOBDepto.SelectedIndex = -1;
            errorProvider1.SetError(COMBOBDepto, "");

        } 

        public void cargarEntidades(PersonaFisica nuevaPersonaFisica, Contacto nuevoContacto, Direccion nuevaDireccion, Usuario nuevoUsuario) 
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
            nuevaPersonaFisica.dni_persona = Convert.ToInt32(TBDni.Text);
            nuevaPersonaFisica.nombre_persona = TBApellido.Text;
            nuevaPersonaFisica.apellido_persona = TBApellido.Text;
            nuevaPersonaFisica.fecha_nacimiento = DTPFechaNacimiento.Value;
            nuevaPersonaFisica.sexo = sexo;

            // Manejamos los datos de contacto.
            nuevoContacto.telefono = Convert.ToInt64(TBTelefono.Text);
            nuevoContacto.email = TBEmail.Text;
             
            // Aca tenemos un problema en como tratar el combo box depto y piso en caso de que estos datos no sean cargados.
            // Por ejemplo COMBOBDepto es int y por lo tanto no puede ser null.
            //
            // Manejamos la direccion del nuevo usuario.  

            if (this.CBDepartamento.Checked == true)
            {
                // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                nuevaDireccion.calle = TBCalle.Text;
                nuevaDireccion.altura = Convert.ToInt16(TBAltura.Text);
                nuevaDireccion.piso = COMBOBPiso.Text;
                nuevaDireccion.depto = Convert.ToInt16(COMBOBDepto.Text);
            }
            else
            { 
                nuevaDireccion.calle = TBCalle.Text;  
                nuevaDireccion.altura = Convert.ToInt16(TBAltura.Text);
            }

            // Manejamos los datos del usuario.
            nuevoUsuario.username = TBGUUsername.Text;
            nuevoUsuario.contraseña = TBGUContraseña.Text;
            nuevoUsuario.tipo_perfil = (COMBOBTipoUsuario.SelectedIndex + 1);
            nuevoUsuario.estado = Convert.ToBoolean(1); 
        } 

        // Por el momento funciona correctamente, falta ver un poco mas lo que seria la validacion. 
        private void BRegistrarUsuario_Click(object sender, EventArgs e)
        {
            this.load_ErrorProvider = false;

            if (this.ValidateChildren())
            {
                if (this.load_ErrorProvider) 
                {
                    return;
                }
            } 

            PersonaFisica nuevaPersonaFisica = new PersonaFisica();
            Contacto nuevoContacto = new Contacto();
            Direccion nuevaDireccion = new Direccion();
            Usuario nuevoUsuario = new Usuario();

            this.cargarEntidades(nuevaPersonaFisica, nuevoContacto, nuevaDireccion, nuevoUsuario); 
             
            try {

                CN_Usuario usuario = new CN_Usuario();

                int resultado = usuario.CrearUsuarioCompleto(nuevaPersonaFisica, nuevoUsuario, nuevoContacto, nuevaDireccion);
                 
                if (resultado != 0)
                {
                    MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }  
                else
                {
                    this.mostrarErrores(usuario.GetErrors());
                    MessageBox.Show("Los datos suministrados no son correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Execpcion: " + ex.InnerException + " -- " + ex.Source + " / " + ex.TargetSite);
            } 
        }  

        private void TBDni_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBDni.Text))
            {
                errorProvider1.SetError(TBDni, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBDni, "");
            }

        }

        private void TBNombre_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBNombre.Text))
            {
                errorProvider1.SetError(TBNombre, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBNombre, "");
            }
        }

        private void TBApellido_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBApellido.Text))
            {
                errorProvider1.SetError(TBApellido, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBApellido, ""); 
            }
        }

        private void DTPFechaNacimiento_Validating(object sender, CancelEventArgs e)
        {

            // Falta rigurosidad con respecto de los mesese y dias.
            DateTime fechaNacimiento = DTPFechaNacimiento.Value;
            int edad = DateTime.Today.Year - fechaNacimiento.Year;


            if (edad < 18)
            {
                errorProvider1.SetError(DTPFechaNacimiento, "La fecha seleccionada corresponde a un menor de 18 años."); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(DTPFechaNacimiento, "");
            }
        }

        protected void TBGUUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBGUUsername.Text))
            {
                errorProvider1.SetError(TBGUUsername, "El campo Usuario es obligatorio."); 
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBGUUsername, "");
            }
        }

        protected void COMBOBTipoUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (COMBOBTipoUsuario.SelectedIndex == -1)
            {
                errorProvider1.SetError(COMBOBTipoUsuario, "Debe seleccionar un tipo de usuario."); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(COMBOBTipoUsuario, "");
            }
        }

        private void TBGUContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBGUContraseña.Text))
            {
                errorProvider1.SetError(TBGUContraseña, "El campo Contraseña es obligatorio"); 
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBGUContraseña.Text, @"\d"))
            {
                errorProvider1.SetError(TBGUContraseña, "La contraseña debe contener al menos un caracter nuemerico"); 
                this.load_ErrorProvider = true;
            }
            else if (!string.IsNullOrEmpty(TBGURepetir.Text) && !TBGUContraseña.Text.Equals(TBGURepetir.Text))
            {
                errorProvider1.SetError(TBGURepetir, "Las contraseñas no coinciden."); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBGUContraseña, "");
            }
        }

        //Cuando cambiamos de control y nos vamos al TBContraseña, la realizar la modificacion en este no salta el EP acerca de que las contraseñas no son iguales.
        private void TBGURepetir_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBGUContraseña.Text))
            {
                if (string.IsNullOrEmpty(TBGURepetir.Text))
                {
                    errorProvider1.SetError(TBGURepetir, "El campo Repetir Contraseña es obligatorio"); 
                    this.load_ErrorProvider = true;

                }
                else if (!TBGUContraseña.Text.Equals(TBGURepetir.Text))
                {
                    errorProvider1.SetError(TBGURepetir, "Las contraseñas deben ser iguales."); 
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBGURepetir, "");
                }
            }
            else
            {
                errorProvider1.SetError(TBGURepetir, "Debe ingresar una contraseña"); 
                this.load_ErrorProvider = true;
            }
        }

        protected void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
                errorProvider1.SetError(TBEmail, "Este campo es obligatorio.");
                MessageBox.Show("Soy mail");
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(TBEmail, "La direccion email no cumple con el formato.(direccion@example.com)");
                MessageBox.Show("Soy mail");
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBEmail, "");
            }
        }

        protected void TBTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBTelefono.Text))
            {
                errorProvider1.SetError(TBTelefono, "Este campo es obligatorio.");
                MessageBox.Show("Soy telefono");
                this.load_ErrorProvider = true;
            }
            else if (!long.TryParse(TBTelefono.Text, out _))
            {
                errorProvider1.SetError(TBTelefono, "El campo solo debe contener caracteres numericos.");
                MessageBox.Show("Soy telefono");
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBTelefono, "");
            }
        }

        protected void TBCalle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBCalle.Text))
            {
                errorProvider1.SetError(TBCalle, "Este campo es obligatorio.");
                MessageBox.Show("Soy calle");
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBCalle, "");
            }

        }

        protected void TBAltura_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBAltura.Text))
            {
                errorProvider1.SetError(TBAltura, "Este campo es obligatorio.");
                MessageBox.Show("Soy altura");
                this.load_ErrorProvider = true;
            }
            else if (!int.TryParse(TBAltura.Text, out _))
            {
                errorProvider1.SetError(TBAltura, "El campo solo debe contener caracteres numericos.");
                MessageBox.Show("Soy altura");
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBAltura, "");
            }
        }

        protected void COMBOBPiso_Validating(object sender, CancelEventArgs e)
        {
            if (this.COMBOBPiso.Enabled == true)
            {

                if (COMBOBPiso.SelectedIndex == -1)
                {
                    errorProvider1.SetError(COMBOBPiso, "Seleccione el numero de piso.");
                    MessageBox.Show("Soy piso");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(COMBOBPiso, "");
                }

            }
            else
            {
                errorProvider1.SetError(COMBOBPiso, "");
            }
        }

        protected void COMBOBDepto_Validating(object sender, CancelEventArgs e)
        {

            if (this.COMBOBDepto.Enabled == true)
            {

                if (this.COMBOBDepto.SelectedIndex == -1)
                {
                    errorProvider1.SetError(COMBOBDepto, "Debe seleccionar el depto.");
                    MessageBox.Show("Soy depto");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(COMBOBDepto, "");
                }

            }
            else
            {
                errorProvider1.SetError(COMBOBDepto, "");
            }

        }

        public void CentrarPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario
            PCrearUsuario.Left = (this.ClientSize.Width - PCrearUsuario.Width) / 2;
            PFormularioCrearUsuario.AutoScroll = false;
            // PListadoUsuarios.Left = (this.ClientSize.Width - PListadoUsuarios.Width) / 2;
        }


        public void MantenerPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario
            PCrearUsuario.Left = 2;
            PFormularioCrearUsuario.AutoScroll = false;

        }

        // Ver que mierda hago con esto. 

        public void mostrarErrores(Dictionary<string, string> validacion)
        {
            if (validacion != null)
            {
                foreach (var error in validacion)
                {
                    Control[] controlesEncontrados = this.Controls.Find(error.Key, true); // 'true' busca en controles hijos también 
                    errorProvider1.SetError(controlesEncontrados[0], error.Value);
                }
            }
        }
         
    }
}

