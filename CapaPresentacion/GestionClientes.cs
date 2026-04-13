using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionClientes : Form, IConfigForm
    {
        public Principal principal;
        public bool load_ErrorProvider;

        public GestionClientes(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.ConfigWindowState();
        }


        private void LPFisica_Click(object sender, EventArgs e)
        {
            this.PDatosPJuridica.Hide();
            this.PDatosPJuridica.Enabled = false;
            this.PDatosPFisica.Enabled = true;
            this.PDatosPFisica.Show();

            this.LPJuridica.ForeColor = System.Drawing.Color.Gray;
            this.LPFisica.ForeColor = System.Drawing.Color.White;
        }

        private void LPJuridica_Click(object sender, EventArgs e)
        {
            this.PDatosPFisica.Hide();
            this.PDatosPFisica.Enabled = false;
            this.PDatosPJuridica.Enabled = true;
            this.PDatosPJuridica.Show();

            this.LPFisica.ForeColor = System.Drawing.Color.Gray;
            this.LPJuridica.ForeColor = System.Drawing.Color.White;
        }
         

        // Comportamiento de DGV en funcion de WindowState
        public void ConfigWindowState()
        {
            if (this.principal.WindowState == FormWindowState.Maximized)
            {
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            }

            if (this.principal.WindowState == FormWindowState.Normal)
            { 
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        public void CentrarPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario 
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.panel1.Left = (this.ClientSize.Width - this.panel1.Width) / 2;
        }

        public void MantenerPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario 
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.panel1.Left = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.load_ErrorProvider = false;

            if (this.ValidateChildren())
            {
                if (this.load_ErrorProvider)
                {
                    return;
                }
            }

            // Creamos las variables que vamos a utilizar 
            PersonaFisica personaFisica = new PersonaFisica();
            PersonaJuridica personaJuridica = new PersonaJuridica();
            Direccion direccion = new Direccion();  
            Contacto contacto = new Contacto(); 

            // Cargamos las entidades.
            this.CargarEntidadesCliente(personaFisica, personaJuridica, contacto, direccion);

            // Validaciones y creacion de Cliente completo.
            try
            { 
                CN_Cliente nuevoCliente = new CN_Cliente();

                int resultado = nuevoCliente.CrearClienteCompleto(personaFisica, personaJuridica, contacto, direccion); 
                /*
                if ( )
                {
                     
                }
                else
                {
                 //   this.mostrarErrores( );
                   // this.mostrarErrores( );
                    MessageBox.Show("Verififque que los datos suministrados sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                */
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

        public void CargarEntidadesCliente(PersonaFisica _personaFisica, PersonaJuridica _personaJuridica, Contacto _contacto, Direccion _direccion) 
        {
            // Preguntamos cual de los paneles se encuentra activo.
            if (this.PDatosPFisica.Enabled)
            {
                _personaFisica.nombre_persona = this.TBNombre.Text;
                _personaFisica.apellido_persona = this.TBApellido.Text;
                _personaFisica.dni_persona = Convert.ToInt32(this.TBDni.Text);
                _personaFisica.fecha_nacimiento = Convert.ToDateTime(this.DTPFechaNacimiento.Value);

                string sexo = string.Empty;

                if (RBHombre.Checked)
                {
                    sexo = "Hombre";
                }
                else if (RBMujer.Checked)
                {
                    sexo = "Mujer";
                }

                _personaFisica.sexo = sexo;
            }

            if (this.PDatosPJuridica.Enabled)
            {
                _personaJuridica.razon_social = this.TBRazonSocial.Text;
                _personaJuridica.nombre_comercial = this.TBNombreComercial.Text;
                _personaJuridica.cuit = Convert.ToInt64(this.TBCuit.Text);
            }

            // Cargamos Direccion y Contacto.
            if (this.CHKBDepto.Checked == true)
            {
                // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                _direccion.calle = this.TBCalle.Text;
                _direccion.altura = Convert.ToInt16(this.TBAltura.Text);
                _direccion.piso = this.CBPiso.Text;
                _direccion.depto = Convert.ToInt16(this.CBDepto.Text);
            }
            else
            {
                _direccion.calle = this.TBCalle.Text;
                _direccion.altura = Convert.ToInt16(this.TBAltura.Text);
            }

            _contacto.telefono = Convert.ToInt64(TBTelefono.Text);
            _contacto.email = this.TBEmail.Text;
            _contacto.sitio_web = this.TBSitioWeb.Text;
        }

        // -------------- Validaciones -------------- 
        // Persona Fisica. 
        private void TBDni_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBDni.Text))
            {
                errorProvider1.SetError(TBDni, "Este campo es obligatorio.");
                this.load_ErrorProvider = true;
            }
            if (!long.TryParse(TBDni.Text, out _))
            {
                errorProvider1.SetError(TBDni, "El campo DNI solo puede contener valores numericos");
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

        // Persona Juridica. 
        private void CBRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBRazonSocial.Text))
            {
                errorProvider1.SetError(TBRazonSocial, "El campo Razon Social no puede estar vacio.");
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBRazonSocial.Text, @"^[a-zA-Z0-9._%+\-\s]+$"))
            {
                errorProvider1.SetError(TBRazonSocial, "El campo Razon Social solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBRazonSocial, "");
            }
        }

        private void TBNombreComercial_Validating(object sender, CancelEventArgs e)
        {
            // Validaciones para campo Nombre Comercial. 
            if (string.IsNullOrEmpty(TBNombreComercial.Text))
            {
                errorProvider1.SetError(TBNombreComercial, "El campo Nombre Comercial no puede estar vacio.");
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNombreComercial.Text, @"^[a-zA-Z0-9._%+\-\s]+$"))
            {
                errorProvider1.SetError(TBNombreComercial, "El campo Nombre Comercial solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBNombreComercial, "");
            }
        }

        private void TBCuit_Validating(object sender, CancelEventArgs e)
        {
            /*
             * Aca podemos observar como podriamos utilizar el sender (control que produce el evento) para un algoritmo mas dinamico.
                System.Windows.Forms.Control control = sender as System.Windows.Forms.TextBox;
                errorProvider1.SetError(control, "El campo CUIT solo puede contener valores numericos");
            */

            if (!long.TryParse(TBCuit.Text, out _))
            {
                errorProvider1.SetError(TBCuit, "El campo CUIT solo puede contener valores numericos");
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBCuit, "");
            }
        }

        // Contacto.
        protected void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
                errorProvider1.SetError(TBEmail, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(TBEmail, "La direccion email no cumple con el formato.(direccion@example.com)"); 
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
                this.load_ErrorProvider = true;
            }
            else if (!long.TryParse(TBTelefono.Text, out _))
            {
                errorProvider1.SetError(TBTelefono, "El campo solo debe contener caracteres numericos."); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBTelefono, "");
            }
        }

        private void TBSitioWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBSitioWeb.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(TBSitioWeb.Text, @"www\.[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"))
                {
                    errorProvider1.SetError(TBSitioWeb, "El Sitio Web ingresado no tiene un formato estandar de dominio (www.example.com).");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBSitioWeb, "");
                }
            }
            else
            {
                errorProvider1.SetError(TBSitioWeb, "");
            }
        }

        // Direccion. 
        private void TBCodPostal_Validating(object sender, CancelEventArgs e)
        {
            // Validaciones para campo CodPostal. 
            if (string.IsNullOrEmpty(TBCodPostal.Text))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal no puede estar vacio.");
                this.load_ErrorProvider = true;
            }
            else if (!int.TryParse(TBCodPostal.Text, out _))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal debe contener un valor numerico.");
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBCodPostal, "");
            }
        }

        protected void TBCalle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBCalle.Text))
            {
                errorProvider1.SetError(TBCalle, "Este campo es obligatorio."); 
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
                this.load_ErrorProvider = true;
            }
            else if (!int.TryParse(TBAltura.Text, out _))
            {
                errorProvider1.SetError(TBAltura, "El campo solo debe contener caracteres numericos."); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBAltura, "");
            }
        }

        protected void CBPiso_Validating(object sender, CancelEventArgs e)
        {
            if (this.CBPiso.Enabled == true)
            {

                if (CBPiso.SelectedIndex == -1)
                {
                    errorProvider1.SetError(CBPiso, "Seleccione el numero de piso."); 
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(CBPiso, "");
                }

            }
            else
            {
                errorProvider1.SetError(CBPiso, "");
            }
        }

        protected void CBDepto_Validating(object sender, CancelEventArgs e)
        {

            if (this.CBDepto.Enabled == true)
            {

                if (this.CBDepto.SelectedIndex == -1)
                {
                    errorProvider1.SetError(CBDepto, "Debe seleccionar el depto."); 
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(CBDepto, "");
                }

            }
            else
            {
                errorProvider1.SetError(CBDepto, "");
            } 
        }

        // -------------- Otros eventos -------------- 
        protected void CBDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKBDepto.Checked == true)
            {
                CBDepto.Enabled = true;
                errorProvider1.SetError(CBDepto, "Debe seleccionar el departamento");
                this.load_ErrorProvider = true;

                CBPiso.Enabled = true;
                errorProvider1.SetError(CBPiso, "Debe seleccionar el piso");
                this.load_ErrorProvider = true;
            }
            else
            {
                CBDepto.Enabled = false;
                CBDepto.SelectedIndex = -1;
                errorProvider1.SetError(CBDepto, "");

                CBPiso.Enabled = false;
                CBPiso.SelectedIndex = -1;
                errorProvider1.SetError(CBPiso, "");
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
    }
}
