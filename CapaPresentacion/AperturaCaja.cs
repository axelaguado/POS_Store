using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class AperturaCaja : Form
    {
        public bool load_errorProvider;

        public AperturaCaja()
        {
            InitializeComponent();
        }

        private void BTNVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BTNAbrirCaja_Click(object sender, EventArgs e)
        {
            this.load_errorProvider = true;

            if (this.ValidateChildren()) 
            {
                if (this.load_errorProvider) 
                { 
                    return;
                }
            }
             
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TBSaldoInicial_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBSaldoInicial.Text))
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial es obligatorio");
            }
            else if (!decimal.TryParse(this.TBSaldoInicial.Text, out decimal monto_gasto))
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial debe ser un valor numerico");
            }
            else if (!(decimal.Round(monto_gasto, 2) == monto_gasto))
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial debe ser un valor numerico con hasta dos decimales.");
            }
            else if (monto_gasto <= 0)
            {
                this.errorProvider1.SetError(this.TBSaldoInicial, "El campo Saldo Inicial debe ser mayor a cero.");
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
