using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class MovimientoCaja : Form
    {
        public Caja cajaMovimiento;

        public bool load_errorProviderTipoNuevo;
        public bool load_errorProviderMovimientoNuevo;
        public bool load_errorProviderIngresoAutorizado;

        public MovimientoCaja(int id_caja)
        {
            InitializeComponent();
            this.cajaMovimiento = this.GetCajaMovimiento(id_caja);
            this.InitLoad();
        }

        // Cargas necesarias cuando iniciamos el formulario.
        public void InitLoad() 
        {
            if (this.cajaMovimiento.usuario.tipo_perfil == 1) 
            {
                this.DisplayPanelAutorizado();

                this.LoadCBTipoMovimiento();
                this.LoadTipos();
            }
            else 
            {
                this.tableLayoutPanel1.Visible = false;
                this.tableLayoutPanel1.Enabled = false;

                this.panel7.Visible = true;
                this.panel7.Enabled = true;
            }
        }

        public Caja GetCajaMovimiento(int id_caja)
        {
            CN_Caja caja = new CN_Caja();

            try
            {
                Caja encontrada = caja.ObtenerCaja(id_caja);

                if (encontrada != null)
                {
                    return encontrada;
                }

                return null;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        public void DisplayPanelAutorizado() 
        {
            this.tableLayoutPanel1.Visible = true;
            this.tableLayoutPanel1.Enabled = true;

            this.panel7.Visible = false;
            this.panel7.Enabled = false;
        }

        public void LoadCBTipoMovimiento() 
        { 
            CN_TipoMovimiento tipo = new CN_TipoMovimiento();
            List<Tipo_movimiento> tipos = tipo.ObtenerTipos().Where(t => t.estado_tipo == true).ToList();

            this.CBTipoMovimiento.ValueMember = "id_tipo";
            this.CBTipoMovimiento.DisplayMember = "descripcion_tipo";

            this.CBTipoMovimiento.DataSource = tipos;
            this.CBTipoMovimiento.SelectedIndex = -1;
            this.CBTipoMovimiento.Text = "-- Selecciones un tipo --";
        }

        public object LoadTable(List<Tipo_movimiento> lista) 
        {
            var tabla = lista.Select((tipo, index) => new
            {
                Id_tipo = tipo.id_tipo, 
                TipoMovimiento = tipo.descripcion_tipo,   
                Estado = tipo.estado_tipo 
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
        }

        public void LoadTipos()
        {
            this.DGVTipos.DataSource = null;
            this.DGVTipos.Columns.Clear();
            this.DGVTipos.Rows.Clear();

            CN_TipoMovimiento tipo = new CN_TipoMovimiento();
            List<Tipo_movimiento> tipos = tipo.ObtenerTipos();

            this.DGVTipos.DataSource = LoadTable(tipos);

            this.DGVTipos.Columns["Id_tipo"].Visible = false;
            this.DGVTipos.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CEstado";
            btnColumnCancelar.HeaderText = "Estado";
            btnColumnCancelar.Text = "Estado";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard;
            this.DGVTipos.Columns.Add(btnColumnCancelar);
            this.DGVTipos.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            this.DGVTipos.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        }
         
        private void BTNCerrar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Evento para accesos autorizados 
        private void BTNIngresar_Click(object sender, EventArgs e)
        {
            this.load_errorProviderIngresoAutorizado = false;

            this.ValidateChildren();
            this.ClearEPNuevoMovimiento();
            this.ClearEPAgregarMetodo();

            if (this.load_errorProviderIngresoAutorizado) 
            {
                return;
            }

            string username = this.TBUsername.Text;
            string contraseña = this.TBPassword.Text;

            CN_Usuario usuario = new CN_Usuario();

            try
            { 
                Usuario autorizado = usuario.loginUsuario(username, contraseña);

                if (autorizado != null && autorizado.tipo_perfil == 1)
                {
                    MessageBox.Show("Cuenta autorizada.", "Autorizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DisplayPanelAutorizado();
                }
                else 
                {
                    MessageBox.Show("La cuenta ingresada no se encuentra autarizada.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (UnauthorizedAccessException na)
            {
                MessageBox.Show("Error: " + na.Message, "Datos no validos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
                // MessageBox.Show($"Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eventos relacionados con nuevos Tipos de Movimentos
        private void BTNAgregar_Click(object sender, EventArgs e)
        {
            this.load_errorProviderTipoNuevo = false;

            this.ValidateChildren();

            if (this.load_errorProviderTipoNuevo) 
            {
                return;
            }

            CN_TipoMovimiento movimiento = new CN_TipoMovimiento();

            Tipo_movimiento nuevoTipo = new Tipo_movimiento();
            nuevoTipo.descripcion_tipo = this.TBNuevoTipo.Text;

            try
            {
                int confirmacion = movimiento.RegistrarTipo(nuevoTipo);

                if(confirmacion == 1)
                {
                    MessageBox.Show("El nuevo tipo de movimiento ha sido registrado correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadCBTipoMovimiento();
                    this.LoadTipos();
                }
                else 
                {
                    MessageBox.Show("Ha ocurriodo un error y no se pudo registrar el nuevo tipo de movimiento", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);   
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Atencion" + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGVTipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Obtenemos la identificaicon de la categoria para realizar la busqueda
            int id_tipo = Convert.ToInt32(dgt.Rows[filaIndex].Cells["Id_tipo"].Value);

            CN_TipoMovimiento tipo = new CN_TipoMovimiento();
            Tipo_movimiento tipoModificar = new Tipo_movimiento();

            tipoModificar = tipo.ObtenerTipo(id_tipo);

            if (nombreColumna == "CEstado")
            {
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true ? "desactivar" : "activar";

                DialogResult confirmacionActivar = MessageBox.Show(
                    "¿Seguro que deseas " + estado_cambiar + " esta categoria?",
                    "Confirmación.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes && tipoModificar != null)
                {
                    try
                    {
                        tipoModificar.estado_tipo = !tipoModificar.estado_tipo;
                        string ddescripcion_tipo = tipoModificar.descripcion_tipo;

                        int confirmacion = tipo.UpdateTipo(tipoModificar);

                        if (confirmacion > 0)
                        {
                            string nuevoEstado = tipoModificar.estado_tipo == true ? "activado" : "desactivado";
                            MessageBox.Show("El tipo " + tipoModificar.descripcion_tipo + " se ha " + nuevoEstado + " correctamente.", "Confirmado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadCBTipoMovimiento();
                            this.LoadTipos();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error inesperado, vuelva a intentar.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error de validación: " + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: " + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void DGVTipos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "CEstado" && e.RowIndex >= 0)
            {
                bool estado = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Estado"].Value);

                e.Value = estado ? "Desactivar" : "Activar";
            }
        }

        // Eventos registrar movmientos
        private void BTNRegistrarMovimiento_Click(object sender, EventArgs e)
        {
            this.load_errorProviderMovimientoNuevo = false;

            this.ValidateChildren();
            this.ClearEPAgregarMetodo();

            if (this.load_errorProviderMovimientoNuevo)
            {
                return;
            }

            CN_MovimientoCaja movimiento = new CN_MovimientoCaja(); 
            Movimiento_caja nuevoMovimiento = new Movimiento_caja();
            nuevoMovimiento.caja = this.cajaMovimiento;
            nuevoMovimiento.tipo_movimiento = this.CBTipoMovimiento.SelectedItem as Tipo_movimiento;
            nuevoMovimiento.monto_movimiento = Convert.ToDecimal(this.TBMonto.Text);
            nuevoMovimiento.descripcion_movimiento = this.TBDescripcion.Text;
            nuevoMovimiento.fecha_movimiento = DateTime.Now;

            try
            {
                int confirmacion = movimiento.RegistrarMovimiento(nuevoMovimiento);

                if (confirmacion > 0) 
                {
                    MessageBox.Show("El movimiento ha sido registrado exitosamente.", "Registrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else 
                {
                    MessageBox.Show("Ha ocurrido un error y el movimeiento no se pudo registrar, vuelva a intentarlo.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        // Eventos validating
        private void TBNuevoTipo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBNuevoTipo.Text))
            {
                this.errorProvider1.SetError(this.TBNuevoTipo, "El campo nuevo tipo es obligatorio.");
                this.load_errorProviderTipoNuevo = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNuevoTipo.Text, @"^[a-zA-Z\s]+$"))
            {
                this.errorProvider1.SetError(this.TBNuevoTipo, "El campo nuevo tipo solo puede contener letras y espacios.");
                this.load_errorProviderTipoNuevo = true;
            }
            else 
            {
                this.errorProvider1.SetError(this.TBNuevoTipo, "");
            }
        }

        private void TBDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBDescripcion.Text))
            {
                this.errorProvider1.SetError(this.TBDescripcion, "El campo descripcion es obligatorio.");
                this.load_errorProviderMovimientoNuevo = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBDescripcion.Text, @"^[a-zA-Z\s.,-]+$"))
            {
                this.errorProvider1.SetError(this.TBDescripcion, "El campo descripcion solo puede contener letras, espacios y caracteres especiales (.,-).");
                this.load_errorProviderMovimientoNuevo = true;
            }
            else
            {
                this.errorProvider1.SetError(this.TBDescripcion, "");
            }
        }

        private void TBMonto_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBMonto.Text))
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo monto es obligatorio.");
                this.load_errorProviderMovimientoNuevo = true;
            } 
            else if (!decimal.TryParse(this.TBMonto.Text, out decimal monto)) 
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo monto debe contener valores numericos.");
                this.load_errorProviderMovimientoNuevo = true;
            }
            else if (monto <= 0)
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo monto debe ser mayor a cero.");
                this.load_errorProviderMovimientoNuevo = true;
            }
            else if (decimal.Round(monto, 2) != monto)
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo monto solo puede tener hasta dos decimales.");
                this.load_errorProviderMovimientoNuevo = true;
            }
            else
            {
                this.errorProvider1.SetError(this.TBMonto, "");
            }
        }

        private void CBTipoMovimiento_Validating(object sender, CancelEventArgs e)
        {
            if(this.CBTipoMovimiento.SelectedIndex == -1) 
            {
                this.errorProvider1.SetError(this.CBTipoMovimiento, "Debe seleccionar un tipo de movimiento.");
                this.load_errorProviderMovimientoNuevo = true;
            }
            else 
            {
                this.errorProvider1.SetError(this.CBTipoMovimiento, "");
            }
        }

        private void TBUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBUsername.Text))
            {
                this.errorProvider1.SetError(this.TBUsername, "Debe ingresar el nombre de usuario de la cuenta autorizad.");
                this.load_errorProviderIngresoAutorizado = true;
            }
            else
            {
                this.errorProvider1.SetError(this.TBUsername, "");
            }
        }

        private void TBPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBPassword.Text)) 
            {
                this.errorProvider1.SetError(this.TBPassword, "Debe ingresar la contraseña de la cuenta autorizada.");
                this.load_errorProviderIngresoAutorizado = true;
            } 
            else
            {
                this.errorProvider1.SetError(this.TBPassword, "");
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

        public void ClearEPAgregarMetodo() 
        {
            this.errorProvider1.SetError(this.TBNuevoTipo, "");
        }

        public void ClearEPNuevoMovimiento()
        {
            this.errorProvider1.SetError(this.CBTipoMovimiento, "");
            this.errorProvider1.SetError(this.TBDescripcion, "");
            this.errorProvider1.SetError(this.TBMonto, "");
        }

        public void ClearEPIngreso()
        {
            this.errorProvider1.SetError(this.TBUsername, "");
            this.errorProvider1.SetError(this.TBPassword, "");
        }
    }
}
