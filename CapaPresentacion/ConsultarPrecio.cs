using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class ConsultarPrecio : Form
    {
        public bool load_ErrorProvider;

        public ConsultarPrecio()
        {
            InitializeComponent();
        }

        private void BTNBuscar_Click(object sender, EventArgs e)
        {
            this.load_ErrorProvider = false;

            this.ValidateChildren();

            if (this.load_ErrorProvider) 
            {
                return;
            }

            CN_Producto producto = new CN_Producto();

            try
            {
                Producto productoCargar = producto.Get_ProductoSku(this.TBCodigoProducto.Text);

                if (productoCargar != null)
                {
                    this.LVProducto.Text = productoCargar.producto_completo;
                    this.LVStock.Text = productoCargar.stock_producto.ToString();
                    this.LVPrecio.Text = "$" + productoCargar.precio_venta.ToString();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado un producto del catalogo que contenga el codigo ingresado.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void TBCodigoProducto_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBCodigoProducto.Text))
            {
                errorProvider1.SetError(this.TBCodigoProducto, "El campo Codigo no puede quedar vacio.");
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBCodigoProducto.Text, @"^[a-zA-Z0-9\-]+$"))
            {
                errorProvider1.SetError(this.TBCodigoProducto, "El campo Codigo solo puede contener caracteres alfabeticos y numericos.");
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(this.TBCodigoProducto, "");
            }
        }

        private void BTNVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void TBCodigoProducto_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox.Text.Equals("Ingrese el codigo del producto ..."))
            {
                textBox.Text = "";
                textBox.ForeColor = System.Drawing.Color.Black;
            }
        }

        public void limpiarControles() 
        {
            this.TBCodigoProducto.Text = "Ingrese el codigo del producto ...";
            this.TBCodigoProducto.ForeColor = System.Drawing.Color.Gray;

            this.LVProducto.Text = "-";
            this.LVStock.Text = "-";
            this.LVPrecio.Text = "-";

        }
    }
}
