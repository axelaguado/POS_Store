using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using static System.Collections.Specialized.BitVector32;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionUsuario : Form, IConfigForm
    {   
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

        // Por el momento funciona correctamente, falta ver un poco mas lo que seria la validacion. 
        private void BRegistrarUsuario_Click(object sender, EventArgs e)
        {

            if (this.ValidateChildren())
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

                Persona nuevaPersona = new Persona
                {
                    dni_persona = Convert.ToInt32(TBDni.Text),
                    nombre_persona = TBNombre.Text,
                    apellido_persona = TBApellido.Text,
                    fecha_nacimiento = DTPFechaNacimiento.Value,
                    email = TBEmail.Text,
                    telefono = Convert.ToInt64(TBTelefono.Text),
                    sexo = sexo
                };

                CN_Persona persona = new CN_Persona();
                var validacionPersona = persona.ValidarPersona(nuevaPersona);

                //Aca tenemos un problema en como tratar el combo box depto y piso en caso de que estos datos no sean cargados.
                //Por ejemplo COMBOBDepto es int y por lo tanto no puede ser null.
                //
                // Manejamos la direccion del nuevo usuario. 
                Direccion nuevaDireccion = new Direccion();

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
                    // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                    nuevaDireccion.calle = TBCalle.Text;

                    // En caso de no ingresar un valor en el formulario y al ser altura un int salta una excepcion.
                    nuevaDireccion.altura = Convert.ToInt16(TBAltura.Text);
                }

                CN_Direccion direccion = new CN_Direccion();
                var validacionDireccion = direccion.ValidarDireccion(nuevaDireccion);

                Usuario nuevoUsuario = new Usuario
                {
                    // id_persona = id_personaRegistrada,
                    username = TBGUUsername.Text,
                    contraseña = TBGUContraseña.Text,
                    tipo_perfil = (COMBOBTipoUsuario.SelectedIndex + 1),
                    estado = Convert.ToBoolean(1)
                };

                CN_Usuario usuario = new CN_Usuario();
                var validacionUsuario = usuario.ValidarUsuario(nuevoUsuario);

                // Validacion realizada por la capa negocio.
                var validacionCompleta = this.unirDiccionarios(validacionPersona, validacionDireccion, validacionUsuario);
                 
                if (validacionCompleta.Count != 0)
                {

                    this.mostrarErrores(validacionCompleta);
                    MessageBox.Show("Se encontraron errores, verifique los datos ingresados.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                { 
                    try {

                        // Se crea una nueva persona en la BDD. 
                        int idPersona = persona.CrearPersona(nuevaPersona);

                        // Se le asigna la id a direccion.
                        nuevaDireccion.id_persona = idPersona;
                        // Se crea la nueva direccion.
                        direccion.CrearDireccion(nuevaDireccion);

                        // Se crea el nuevo usuario.
                        nuevoUsuario.id_persona = idPersona;
                        usuario.CrearUsuario(nuevoUsuario); 


                        MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error de validación: " + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("Ha surgido un error y no se pudo registrar el usuario.");
            }

        }  

        private bool ValidateControls()
        {
            // Innecesaria primer linea.
            // GestionUsuario FormgestionUsuario = this;
            return this.ValidateChildren(); 

        }

        private void TBDni_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBDni.Text))
            {
                errorProvider1.SetError(TBDni, "Este campo es obligatorio.");
                
            }
            else if (!long.TryParse(TBDni.Text, out _))
            {
                errorProvider1.SetError(TBDni, "El campo DNI debe ser un valor numerico.");
            }
            else if (TBDni.Text.Length > 8)
            {
                errorProvider1.SetError(TBDni, "El campo DNI no puede contener mas de 8 caracteres.");
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
                
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBNombre.Text, @"^[a-zA-Z\s]+$"))
            {
                errorProvider1.SetError(TBNombre, "El campo solo puede contener letras.");
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
                 
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBApellido.Text, @"^[a-zA-Z\s]+$"))
            {
                errorProvider1.SetError(TBApellido, "El campo solo puede contener letras.");
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
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBGUUsername.Text, @"^[a-zA-Z\d]+$"))
            {
                errorProvider1.SetError(TBGUUsername, "El campo no debe contener espacios.");
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
                 
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBGUContraseña.Text, @"\d"))
            {
                errorProvider1.SetError(TBGUContraseña, "La contraseña debe contener al menos un caracter nuemerico");
            }
            else if (!string.IsNullOrEmpty(TBGURepetir.Text) && !TBGUContraseña.Text.Equals(TBGURepetir.Text))
            {
                errorProvider1.SetError(TBGURepetir, "Las contraseñas no coinciden.");
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
                     
                }
                else if (!TBGUContraseña.Text.Equals(TBGURepetir.Text))
                {
                    errorProvider1.SetError(TBGURepetir, "Las contraseñas deben ser iguales.");
                }
                else
                {
                    errorProvider1.SetError(TBGURepetir, "");
                }
            }
            else
            {
                errorProvider1.SetError(TBGURepetir, "Debe ingresar una contraseña");
            }
        }

        protected void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
                errorProvider1.SetError(TBEmail, "Este campo es obligatorio.");
                
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(TBEmail, "La direccion email no cumple con el formato.(direccion@example.com)");
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
                 
            }
            else if (!long.TryParse(TBTelefono.Text, out _))
            {
                errorProvider1.SetError(TBTelefono, "El campo solo debe contener caracteres numericos.");
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
                 
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBCalle.Text, @"^[a-zA-Z\s]+$"))
            {
                errorProvider1.SetError(TBCalle, "El campo solo debe contener caracteres alfabeticos.");
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
               
            }
            else if (!int.TryParse(TBAltura.Text, out _))
            {
                errorProvider1.SetError(TBAltura, "El campo solo debe contener caracteres numericos.");
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
                    errorProvider1.SetError(COMBOBDepto, "Debe seleccionar el piso.");
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
        public Dictionary<string, string> unirDiccionarios(Dictionary<string, string> primero, Dictionary<string, string> segundo, Dictionary<string, string> tercero)
        {
            Dictionary<string, string> union = new Dictionary<string, string>();


            if (primero != null)
            {
                foreach (var error in primero)
                {
                    union[error.Key] = error.Value; // Agrega o actualiza
                }
            }

            if (segundo != null)
            {
                foreach (var error in segundo)
                {
                    union[error.Key] = error.Value; // Agrega o actualiza
                }
            }

            if (tercero != null)
            {
                foreach (var error in tercero)
                {
                    union[error.Key] = error.Value;
                }
            }

            return union;

        } 

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

