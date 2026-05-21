using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        // Permiteel despalzamiento del formulario por la pantalla.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void PHeaderPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void BTNMCalcular_Click(object sender, EventArgs e)
        {
            bool precio_c = decimal.TryParse(this.TBPCMargen.Text, out decimal precio_costo);
            bool precio_v = decimal.TryParse(this.TBPrecioVenta.Text, out decimal precio_venta);

            if (precio_c && precio_v) 
            {
                decimal margen = (precio_venta - precio_costo) / precio_venta;
                this.label7.Text = "= " + decimal.Round((margen * 100), 2) + "%.";

                MessageBox.Show("El margen sobre el precio de venta es de: " + decimal.Round((margen * 100), 2) + "%.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Verifique los datos suministrados.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTNPVCalcular_Click(object sender, EventArgs e)
        {
            bool precio_c = decimal.TryParse(this.TBPVPrecio.Text, out decimal precio_costo);
            bool margen_pv = decimal.TryParse(this.TBMargen.Text, out decimal margen);

            if (precio_c && margen_pv)
            {
                decimal precio_venta = precio_costo / (1 - (margen / 100));
                this.label6.Text = "Precio de Venta = $" + decimal.Round((precio_venta), 2);

                MessageBox.Show("El precio de venta es de: $" + decimal.Round((precio_venta), 2) + ".", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Verifique los datos suministrados.", "Resultado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PBCerrarPrincipal_Click(object sender, EventArgs e)
        { 
                this.Close(); 
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            this.TBPCMargen.Text = string.Empty;
            this.TBPrecioVenta.Text = string.Empty;
            this.label7.Text = "= ";


            this.TBPVPrecio.Text = string.Empty;
            this.TBMargen.Text = string.Empty;
            this.label6.Text = "Precio de Venta = ";
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
