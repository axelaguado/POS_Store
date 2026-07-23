using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;


namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class AperturaCaja : Form
    {
        public bool load_errorProvider;
        private string username;

        public AperturaCaja(string _username)
        {
            InitializeComponent();
            this.username = _username;
        }

        private void BTNVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTNAbrirCaja_Click(object sender, EventArgs e)
        {
            this.load_errorProvider = false;

            if (this.ValidateChildren()) 
            {
                if (this.load_errorProvider) 
                { 
                    return;
                }
            }

            Caja nuevaCaja = new Caja(); 
            nuevaCaja.fecha_apertura = DateTime.Now;
            nuevaCaja.fecha_cierre = null;
            nuevaCaja.saldo_inicial = Convert.ToDecimal(this.TBSaldoInicial.Text);
            nuevaCaja.estado_caja = true;

            // Falta el user 
            Usuario user = new Usuario();
            CN_Usuario usuario = new CN_Usuario();

            CN_Caja caja = new CN_Caja();

            try
            {
                user = usuario.buscar_usuario_username(username);
                nuevaCaja.usuario = user;

                int confirmacion = caja.CrearCaja(nuevaCaja);

                if (confirmacion != 0) 
                {
                    MessageBox.Show("Apertura de caja exitosa.", "Apertura.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    // Mensaje de error
                    this.mostrarErrores(caja.GetErrors());
                    MessageBox.Show("Ha ocurrido un error, no se pudo iniciar la apertura de Caja.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            } 
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("" + error.Key + ": " + error.Value);

                    // Control[] controlesEncontrados = this.Controls.Find(error.Key, true); // 'true' busca en controles hijos también 
                    // errorProvider1.SetError(controlesEncontrados[0], error.Value);
                }
            }
        }

        private void TBSaldoInicial_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBSaldoInicial.Text))
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial es obligatorio");
                this.load_errorProvider = true;
            }
            else if (!decimal.TryParse(this.TBSaldoInicial.Text, out decimal monto_gasto))
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial debe ser un valor numerico");
                this.load_errorProvider = true;
            }
            else if (!(decimal.Round(monto_gasto, 2) == monto_gasto))
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial debe ser un valor numerico con hasta dos decimales.");
                this.load_errorProvider = true;
            }
            else if (monto_gasto <= 0)
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial debe ser mayor a cero.");
                this.load_errorProvider = true;
            }
            else
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "");
            }
        }

        private void TB_TextChanged(object sender, EventArgs e)
        {
            // Convierte el objeto sender en un TextBox.
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.Contains("."))
                {
                    string modificado = textBox.Text.Replace(".", ",");
                    textBox.Text = modificado;

                    // Mover el cursor al final del texto.
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }
    }
}
