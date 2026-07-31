using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class RegistrarPago : Form
    {
        public Venta venta;

        public bool load_ErrorProviderAgregarMetodo;
        public bool load_ErrorProviderFinalizarVenta;

        public List<Pago> pagos;

        public RegistrarPago(Venta _venta)
        {
            InitializeComponent();
            this.pagos = new List<Pago>();
            this.venta = _venta; 
            this.InitLoad();
        }

        public void InitLoad() 
        { 
            this.LoadCBMetodos();
            this.SetValuesVenta();
        }

        public void SetValuesVenta() 
        {
            // Label Principal
            this.LVTotalCobrar.Text = "$ " + this.venta.monto_venta;

            // Labels Inferiores
            this.LVTotaLPagado.Text = this.pagos.Sum(p => p.importe_pago).ToString();

            decimal restante = this.venta.monto_venta - this.pagos.Sum(p => p.importe_pago);
            
            if (restante > 0)  
            {
                this.LRestante.ForeColor = Color.Red;
                this.label5.ForeColor = Color.Red;
                this.LVRestante.ForeColor = Color.Red;
            }
            else 
            {
                this.LRestante.ForeColor = Color.Lime;
                this.label5.ForeColor = Color.Lime;
                this.LVRestante.ForeColor = Color.Lime;
            }

            this.LVRestante.Text = restante.ToString();
        }

        public void LoadCBMetodos() 
        {
            CN_MetodoPago metodoPago = new CN_MetodoPago();
            List<Metodo_pago> lista_metodos = metodoPago.ObtenerMetodos();

            this.CBMetodoPago.ValueMember = "id_metodo";
            this.CBMetodoPago.DisplayMember = "descripcion_metodo";

            if (lista_metodos != null)
            {
                this.CBMetodoPago.DataSource = lista_metodos;
            }

            this.CBMetodoPago.SelectedIndex = -1;
        }

        public object LoadTable(List<Pago> _pagos) 
        {
            var tabla = _pagos.Select((pago, index) => new
            {
                Metodo = pago.metodo.descripcion_metodo,
                Importe = "$ " + pago.importe_pago
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
        }

        public void LoadPagos()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            this.dataGridView1.DataSource = this.LoadTable(this.pagos);

            DataGridViewButtonColumn btnColumnBorrar = new DataGridViewButtonColumn();
            btnColumnBorrar.Name = "CEliminar";
            btnColumnBorrar.HeaderText = "Eliminar";
            btnColumnBorrar.Text = "Eliminar";
            btnColumnBorrar.UseColumnTextForButtonValue = true;
            btnColumnBorrar.FlatStyle = FlatStyle.Standard;
            this.dataGridView1.Columns.Add(btnColumnBorrar);
            this.dataGridView1.Columns["CEliminar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.dataGridView1.Columns["CEliminar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;
        }

        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            // Verificamos los campos 
            this.load_ErrorProviderAgregarMetodo = false;

            this.ValidateChildren();

            if (this.load_ErrorProviderAgregarMetodo) 
            {
                return;
            }

            // Cargamos el pago
            Metodo_pago metodo = this.CBMetodoPago.SelectedItem as Metodo_pago;

            Pago pago = new Pago();
            pago.id_venta = this.venta.id_venta;
            pago.venta = this.venta;
            pago.importe_pago = Convert.ToDecimal(this.TBImporte.Text);
            pago.id_metodo = metodo.id_metodo;
            pago.metodo = metodo;

            this.pagos.Add(pago);

            // Cargamos los paneles
            this.LoadPagos();
            this.SetValuesVenta();

            // Limpiamos el panel
            this.LimpiarPanelAgregarMetodo();
        }

        private async void BTNFinalizarVenta_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderFinalizarVenta = false;

            // Validamos y desactivamos aquello que no son de interes para la funcionalidad
            this.ValidateChildren();

            // Limpieza de validaciones extras del Validate.wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww
            this.LimpiarPanelAgregarMetodo();
            this.LimpiarEPAgregarMetodo();

            if (this.load_ErrorProviderFinalizarVenta) 
            { 
                return; 
            }

            CN_Venta cn_venta = new CN_Venta();
            
            // Debemos cargar el pago tambien, jijooo falta una bandeja de coordinacion 
            this.venta.pagos = this.pagos;

            try
            {
                int confirmacion = await cn_venta.RegistrarVentaAsync(this.venta);

                if(confirmacion == 1) 
                {
                    MessageBox.Show("Se registro la venta correctamente.", "Venta Finalizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Ha ocurrido un error y no se pudo registrar la venta.", "Venta Finalizada.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.mostrarErrores(cn_venta.GetErrors()); // Realmente ya son errores internos.

                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
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

        private void BTNCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;   
            this.Close();
        }

        // Eventos de validacion, clear y extras. 
        private void CBMetodoPago_Validating(object sender, CancelEventArgs e)
        {
            if(this.CBMetodoPago.SelectedIndex < 0) 
            {
                errorProvider1.SetError(this.CBMetodoPago, "Debe seleccionar un metodo.");
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else 
            {
                errorProvider1.SetError(this.CBMetodoPago, "");
            }
        }

        private void TBImporte_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBImporte.Text))
            {
                errorProvider1.SetError(this.TBImporte, "El campo Precio no puede estar vacio.");
                this.load_ErrorProviderAgregarMetodo = true; 
            }
            else if (!decimal.TryParse(this.TBImporte.Text, out decimal _precio))
            {
                errorProvider1.SetError(this.TBImporte, "El campo Precio debe contener un valor numerico.");
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else if (_precio <= 0)
            {
                errorProvider1.SetError(this.TBImporte, "El campo Precio debe ser mayor o igual a cero.");
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else if (decimal.Round(_precio, 2) != _precio)
            {
                errorProvider1.SetError(this.TBImporte, "El campo Precio solo acepta valores con hasta dos decimales.");
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else
            {
                errorProvider1.SetError(this.TBImporte, "");
            }
        }

        private void LVRestante_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.LVRestante.Text))
            {
                errorProvider1.SetError(this.LVRestante, ""); // Situacion que debemos analizar como controlarla correctamente.
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else if (!decimal.TryParse(this.LVRestante.Text, out decimal _restante))
            {
                errorProvider1.SetError(this.LVRestante, ""); // Situacion que debemos analizar como controlarla correctamente.
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else if (decimal.Round(_restante, 2) != _restante)
            {
                errorProvider1.SetError(this.TBImporte, ""); // Situacion que debemos analizar como controlarla correctamente.
                this.load_ErrorProviderAgregarMetodo = true;
            }
            else if (_restante > 0)
            {
                errorProvider1.SetError(this.LVRestante, "Los metodos de cobro no son suficiente para realizar el pago.");
                this.load_ErrorProviderAgregarMetodo = true; 
            }
            else
            {
                errorProvider1.SetError(this.TBImporte, "");
            }
        }

        public void LimpiarPanelAgregarMetodo()
        {
            this.CBMetodoPago.SelectedIndex = -1;
            this.TBImporte.Text = string.Empty;
        }

        public void LimpiarEPAgregarMetodo()
        {
            errorProvider1.SetError(this.CBMetodoPago, string.Empty);
            errorProvider1.SetError(this.TBImporte, string.Empty);

            this.load_ErrorProviderAgregarMetodo = true;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CEliminar")
            {
                DialogResult confirmacionBorrar = MessageBox.Show(
                        "¿Seguro que deseas eliminar este pago?",
                        "Confirmación.",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionBorrar == DialogResult.Yes)
                {
                    pagos.RemoveAt(e.RowIndex);
                    this.LoadPagos();
                    this.SetValuesVenta();
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

    }
}
