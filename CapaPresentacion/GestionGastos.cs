using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.CapaEntidad;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionGastos : Form
    {
        public Principal principal;
        private Gasto gasto_editar;
        private bool load_ErrorProviderNCategoria;
        private bool load_ErrorProviderGasto;
        private bool load_ErrorProviderFiltro;

        public GestionGastos(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.LoadCBCategorias();
            this.LoadCBPeriodo();
            this.LoadTableCategorias();
            this.LoadTableGastos();
            this.LoadMontoAcumuladoPeridoActual();
        }

        // ------------- Cargas Iniciales ------------- 

        public void LoadMontoAcumuladoPeridoActual() 
        { 
            CN_Gasto gasto = new CN_Gasto();
            string periodo_actual = DateTime.Now.Year + "-" + DateTime.Now.Month + "-01";

            List<Gasto> lista_gastos = gasto.GetGastoFiltro(Convert.ToDateTime(periodo_actual));
            decimal monto_total = gasto.MontoAcumuladoActivos(lista_gastos);

            this.LTotalPeriodoActual.Text = monto_total == 0 ? "$ - - -" : "$ " + monto_total;  
        }


        public void LoadCBPeriodo()
        {
            // Periodo mes.
            Dictionary<int, string> meses = new Dictionary<int, string>();

            meses.Add(1, "Enero");
            meses.Add(2, "Febrero");
            meses.Add(3, "Marzo");
            meses.Add(4, "Abril");
            meses.Add(5, "Mayo");
            meses.Add(6, "Junio");
            meses.Add(7, "Julio");
            meses.Add(8, "Agosto");
            meses.Add(9, "Septiembre");
            meses.Add(10, "Octubre");
            meses.Add(11, "Noviembre");
            meses.Add(12, "Diciembre");

            this.CBPeriodoMes.DisplayMember = "Value";
            this.CBPeriodoMes.ValueMember = "Key";
            this.CBPeriodoMes.DataSource = meses.ToList();
            this.CBPeriodoMes.SelectedIndex = -1;

            this.CBDesdePeriodoMes.DisplayMember = "Value";
            this.CBDesdePeriodoMes.ValueMember = "Key";
            this.CBDesdePeriodoMes.DataSource = meses.ToList();
            this.CBDesdePeriodoMes.SelectedIndex = -1;

            this.CBHastaPeriodoMes.DisplayMember = "Value";
            this.CBHastaPeriodoMes.ValueMember = "Key";
            this.CBHastaPeriodoMes.DataSource = meses.ToList();
            this.CBHastaPeriodoMes.SelectedIndex = -1;

            // Periodo año.
            int i;
            int year = DateTime.Now.Year;
            int inicio = year - 5;
            int fin = year + 5;

            for (i = inicio; i <= fin; i++)
            {
                this.CBPeriodoAño.Items.Add(i);
                this.CBDesdePeriodoAño.Items.Add(i);
                this.CBHastaPeriodoAño.Items.Add(i);
            }

        }

        public void LoadCBCategorias()
        {
            CN_CategoriaGasto categoria = new CN_CategoriaGasto();
            List<Categoria_gasto> lista_categorias = categoria.AllCategoriesActive();

            this.CBCategorias.DisplayMember = "descripcion_categoria";
            this.CBCategorias.ValueMember = "id_categoria";

            this.CBFiltroCategoria.DisplayMember = "descripcion_categoria";
            this.CBFiltroCategoria.ValueMember = "id_categoria";

            if (lista_categorias != null)
            {
                this.CBCategorias.DataSource = lista_categorias.ToList();
                this.CBCategorias.SelectedIndex = -1;

                this.CBFiltroCategoria.DataSource = lista_categorias.ToList();
                this.CBFiltroCategoria.SelectedIndex = -1;
            }

            this.BTNLimpiar.Show();
            this.BTNReestablecer.Hide();

            this.BTNAgregarGasto.Show();
            this.BTNActualizar.Hide();
        }

        // ------------- Manipulacion de tabla Categoria con sus respectivos eventos ------------- 
        public object LoadTable(List<Categoria_gasto> _lista)
        {
            var tabla = _lista.Select((categoria, index) => new
            {
                Id_categoria = categoria.id_categoria,
                Descripcion = categoria.descripcion_categoria,
                Estado = categoria.estado_categoria,
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        public void LoadTableCategorias()
        {
            this.DGVCategorias.DataSource = null;
            this.DGVCategorias.Columns.Clear();
            this.DGVCategorias.Rows.Clear();

            CN_CategoriaGasto categoria = new CN_CategoriaGasto();
            List<Categoria_gasto> lista_categorias = categoria.AllCategories();

            DGVCategorias.DataSource = this.LoadTable(lista_categorias);

            DGVCategorias.Columns["Id_categoria"].Visible = false;
            DGVCategorias.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnEstado = new DataGridViewButtonColumn();
            btnColumnEstado.Name = "CEstado";
            btnColumnEstado.HeaderText = "Estado";
            btnColumnEstado.UseColumnTextForButtonValue = true;
            btnColumnEstado.FlatStyle = FlatStyle.Standard;
            btnColumnEstado.UseColumnTextForButtonValue = false; // Para poder modificar el texto.
            DGVCategorias.Columns.Add(btnColumnEstado);
            DGVCategorias.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            DGVCategorias.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        }

        private void BTNAgregarCategoria_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderNCategoria = false;

            if (this.ValidateChildren())
            {
                this.LimpiarErrorProviderGasto();

                if (this.load_ErrorProviderNCategoria)
                {
                    return;
                }
            }

            try
            {
                CN_CategoriaGasto categoria = new CN_CategoriaGasto();
                Categoria_gasto nuevaCategoria = new Categoria_gasto();

                nuevaCategoria.descripcion_categoria = this.TBNuevaCategoria.Text;

                int confirmacionRegistro = categoria.CrearCategoria(nuevaCategoria);

                if (confirmacionRegistro == 1)
                {
                    MessageBox.Show("La nueva categoria de gasto: " + nuevaCategoria.descripcion_categoria + ", se ha registrado correctamente.", "Registrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarPamelNCategoria();
                    this.LoadCBCategorias();
                    this.LoadTableCategorias();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error y no se pudo registrar la nueva categoria, verifique los datos suministrados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.mostrarErrores(categoria.GetErrors());
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DGVCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Obtenemos la identificaicon de la categoria para realizar la busqueda
            int id_categoria = Convert.ToInt32(dgt.Rows[filaIndex].Cells["Id_categoria"].Value);

            CN_CategoriaGasto categoria = new CN_CategoriaGasto();
            Categoria_gasto categoriaModificar = new Categoria_gasto();

            categoriaModificar = categoria.GetIdCategoria(id_categoria);

            if (nombreColumna == "CEstado")
            {
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true ? "desactivar" : "activar";

                DialogResult confirmacionActivar = MessageBox.Show(
                    "¿Seguro que deseas " + estado_cambiar + " esta categoria?",
                    "Confirmación.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes && categoriaModificar != null)
                {
                    try
                    {
                        categoriaModificar.estado_categoria = !categoriaModificar.estado_categoria;
                        string categoria_descripcion = categoriaModificar.descripcion_categoria;

                        Categoria_gasto confirmacion = categoria.UpdateCategoriaEstado(categoriaModificar);

                        if (confirmacion != null)
                        {
                            string nuevoEstado = confirmacion.estado_categoria == true ? "activado" : "desactivado";
                            MessageBox.Show("La categoria " + confirmacion.descripcion_categoria + " se ha " + nuevoEstado + " correctamente.", "Confirmado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadTableCategorias();
                            this.LoadCBCategorias();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error inesperado, vuelva a intentar.");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "CEstado" && e.RowIndex >= 0)
            {
                bool estado = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Estado"].Value);

                e.Value = estado ? "Desactivar" : "Activar";
            }
        }

        public void LimpiarErrorProviderNCategoria()
        {
            this.errorProvider1.SetError(this.TBNuevaCategoria, "");
        }

        public void LimpiarPamelNCategoria()
        {
            this.TBNuevaCategoria.Text = string.Empty;
            this.LimpiarErrorProviderNCategoria();
        }

        // ------------- Implementacion Metodos Gasto ------------------ 

        private void BTNAgregarGasto_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderGasto = false;

            if (this.ValidateChildren())
            {
                this.LimpiarErrorProviderNCategoria();

                if (this.load_ErrorProviderGasto)
                {
                    return;
                }
            }

            try
            {
                CN_Gasto gasto = new CN_Gasto();
                Gasto nuevoGasto = new Gasto();

                this.CargarEntidadGasto(nuevoGasto);

                int confirmacionRegistro = gasto.RegistrarGasto(nuevoGasto);

                if (confirmacionRegistro == 1)
                {
                    MessageBox.Show("El gasto: " + nuevoGasto.descripcion_gasto + " - $" + nuevoGasto.monto_gasto + ", se ha registrado correctamente.", "Registrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControlesPanelGasto();
                    this.LoadTableGastos();
                    this.LoadMontoAcumuladoPeridoActual();
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error y no se pudo registrar la nueva categoria, verifique los datos suministrados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.mostrarErrores(gasto.GetErrores());
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                var error = ex.Message;

                if (ex.InnerException != null)
                {
                    if (ex.InnerException.InnerException != null)
                    {
                        error += "\n" + ex.InnerException.InnerException.Message;
                    }
                }

                MessageBox.Show(error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Obtenemos la identificaicon del cliente para realizar la busqueda
            int id_gasto = Convert.ToInt32(dgt.Rows[filaIndex].Cells["Id_gasto"].Value);

            CN_Gasto gasto = new CN_Gasto();

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CEditar")
            {
                DialogResult confirmacionEditar = MessageBox.Show(
                    "¿Seguro que deseas editar este gastao?",
                    "Confirmación.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionEditar == DialogResult.Yes)
                {
                    try
                    {
                        gasto_editar = null;
                        gasto_editar = gasto.GetGasto(id_gasto);

                        if (gasto_editar != null)
                        {
                            // cargamos los paneles con los datos correspondientes al producto_editar.
                            this.CargarGastoEditar();

                            this.BTNLimpiar.Hide();
                            this.BTNReestablecer.Show();

                            this.BTNAgregarGasto.Hide();
                            this.BTNActualizar.Show();
                        }
                        else
                        {
                            MessageBox.Show("No se ha encontrado el gasto, vuelva a intentar.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error de validación: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (nombreColumna == "CEstado")
            {
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true ? "desactivar" : "activar";

                DialogResult confirmacionActivar = MessageBox.Show(
                    "¿Seguro que deseas " + estado_cambiar + " este gasto?",
                    "Confirmación.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes)
                {
                    try
                    {
                        gasto_editar = null;
                        gasto_editar = gasto.GetGasto(id_gasto);
                        gasto_editar.estado_gasto = !gasto_editar.estado_gasto;

                        int confirmacion = gasto.UpdateGasto(gasto_editar);

                        if (confirmacion == 1)
                        {
                            string nuevoEstado = gasto_editar.estado_gasto == true ? "activado." : "desactivado.";

                            MessageBox.Show("El gasto " + gasto_editar.categoria.descripcion_categoria + " - $" + gasto_editar.monto_gasto + " se ha " + nuevoEstado, "Completo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadTableGastos();
                            this.LoadMontoAcumuladoPeridoActual();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error inesperado, vuelva a intentar.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public object LoadTable(List<Gasto> _lista)
        {
            var tabla = _lista.Select((gasto, index) => new
            {
                Id_gasto = gasto.id_gasto,
                Periodo = gasto.periodo_gasto.Month + "/" + gasto.periodo_gasto.Year,
                Categoria = gasto.categoria.descripcion_categoria,
                Descripcion = gasto.descripcion_gasto,
                Monto = "$" + gasto.monto_gasto,
                Estado = gasto.estado_gasto,
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        public void LoadTableGastos()
        {
            this.DGVGastos.DataSource = null;
            this.DGVGastos.Columns.Clear();
            this.DGVGastos.Rows.Clear();

            CN_Gasto gasto = new CN_Gasto();
            List<Gasto> lista_gastos = gasto.AllGastos();

            DGVGastos.DataSource = this.LoadTable(lista_gastos);

            DGVGastos.Columns["Id_gasto"].Visible = false;
            DGVGastos.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            DGVGastos.Columns.Add(btnColumnEditar);
            DGVGastos.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Khaki;
            DGVGastos.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Khaki;

            DataGridViewButtonColumn btnColumnEstado = new DataGridViewButtonColumn();
            btnColumnEstado.Name = "CEstado";
            btnColumnEstado.HeaderText = "Estado";
            btnColumnEstado.UseColumnTextForButtonValue = true;
            btnColumnEstado.FlatStyle = FlatStyle.Standard;
            btnColumnEstado.UseColumnTextForButtonValue = false; // Para poder modificar el texto.
            DGVGastos.Columns.Add(btnColumnEstado);
            DGVGastos.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            DGVGastos.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        }

        public void LoadTableGastos(List<Gasto> lista_gastos)
        {
            this.DGVGastos.DataSource = null;
            this.DGVGastos.Columns.Clear();
            this.DGVGastos.Rows.Clear();

            DGVGastos.DataSource = this.LoadTable(lista_gastos);

            DGVGastos.Columns["Id_gasto"].Visible = false;
            DGVGastos.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            DGVGastos.Columns.Add(btnColumnEditar);
            DGVGastos.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Khaki;
            DGVGastos.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Khaki;

            DataGridViewButtonColumn btnColumnEstado = new DataGridViewButtonColumn();
            btnColumnEstado.Name = "CEstado";
            btnColumnEstado.HeaderText = "Estado";
            btnColumnEstado.UseColumnTextForButtonValue = true;
            btnColumnEstado.FlatStyle = FlatStyle.Standard;
            btnColumnEstado.UseColumnTextForButtonValue = false; // Para poder modificar el texto.
            DGVGastos.Columns.Add(btnColumnEstado);
            DGVGastos.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            DGVGastos.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        }

        public void CargarEntidadGasto(Gasto gasto)
        {
            gasto.periodo_gasto = this.GetPeriodoGasto();
            gasto.descripcion_gasto = this.TBDescripcion.Text;
            gasto.monto_gasto = Convert.ToDecimal(this.TBMonto.Text);
            gasto.categoria_gasto = Convert.ToInt32(this.CBCategorias.SelectedValue);
        }

        public void CargarGastoEditar()
        {
            this.CBPeriodoMes.SelectedIndex = this.gasto_editar.periodo_gasto.Month - 1;
            this.CBPeriodoAño.Text = Convert.ToString(this.gasto_editar.periodo_gasto.Year);
            this.CBCategorias.SelectedValue = Convert.ToInt32(this.gasto_editar.categoria.id_categoria);
            this.TBDescripcion.Text = this.gasto_editar.descripcion_gasto;
            this.TBMonto.Text = Convert.ToString(this.gasto_editar.monto_gasto);
        }

        private DateTime GetPeriodoGasto()
        {
            string periodo_gasto;
            string periodo_año = this.CBPeriodoAño.Text;

            int month = this.CBPeriodoMes.SelectedIndex + 1;

            int.TryParse(periodo_año, out int año);
            periodo_gasto = año + "-" + month + "-" + "01";

            DateTime periodo_registrar = Convert.ToDateTime(periodo_gasto);

            return periodo_registrar;
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarControlesPanelGasto();
            this.LimpiarErrorProviderGasto();
        }

        public void LimpiarControlesPanelGasto()
        {
            this.CBPeriodoMes.SelectedIndex = -1;
            this.CBPeriodoAño.SelectedIndex = -1;
            this.CBCategorias.SelectedIndex = -1;

            this.TBDescripcion.Text = string.Empty;
            this.TBMonto.Text = string.Empty;
        }

        public void LimpiarErrorProviderGasto()
        {
            this.errorProvider1.SetError(this.CBPeriodoMes, "");
            this.errorProvider1.SetError(this.CBPeriodoAño, "");
            this.errorProvider1.SetError(this.CBCategorias, "");

            this.errorProvider1.SetError(this.TBDescripcion, "");
            this.errorProvider1.SetError(this.TBMonto, "");
        }

        private void BTNReestablecer_Click(object sender, EventArgs e)
        {
            this.CargarGastoEditar();
        }

        private void BTNActualizar_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderGasto = false;

            if (this.ValidateChildren())
            {
                this.LimpiarErrorProviderNCategoria();

                if (this.load_ErrorProviderGasto)
                {
                    return;
                }

            }

            CN_Gasto gasto = new CN_Gasto();

            this.CargarEntidadGasto(this.gasto_editar);

            try
            {
                int confimracion = gasto.UpdateGasto(this.gasto_editar);

                if (confimracion == 1)
                {
                    MessageBox.Show("El gasto se ha actualizado correctamente.", "Confirmacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LimpiarControlesPanelGasto();
                    this.LoadTableGastos();
                    this.LoadMontoAcumuladoPeridoActual();

                    this.BTNLimpiar.Show();
                    this.BTNReestablecer.Hide();

                    this.BTNAgregarGasto.Show();
                    this.BTNActualizar.Hide();
                }
                else
                {
                    MessageBox.Show("No se ha podido actualizar el gasto, vuelva a intentar.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ------------- Validaciones Panel Categoria  ------------- 

        private void TBNuevaCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNuevaCategoria.Text))
            {
                this.errorProvider1.SetError(this.TBNuevaCategoria, "El campo Categoria no puede estar vacio.");
                this.load_ErrorProviderNCategoria = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNuevaCategoria.Text, @"^[a-zA-Z\s]+$"))
            {
                this.errorProvider1.SetError(this.TBNuevaCategoria, "El campo Categoria solo puede contener letras y espacios.");
                this.load_ErrorProviderNCategoria = true;
            }
            else
            {
                this.LimpiarErrorProviderNCategoria();
            }
        }

        // ------------- Validaciones Panel Gasto ------------- 

        private void CBPeriodoMes_Validating(object sender, CancelEventArgs e)
        {
            if (this.CBPeriodoMes.SelectedIndex < 0)
            {
                this.errorProvider1.SetError(this.CBPeriodoMes, "Debe seleccionar un mes para el periodo.");
                this.load_ErrorProviderGasto = true;
            }
            else
            {
                this.errorProvider1.SetError(this.CBPeriodoMes, "");
            }
        }

        private void CBPeriodoAño_Validating(object sender, CancelEventArgs e)
        {
            if (this.CBPeriodoMes.SelectedIndex < 0)
            {
                this.errorProvider1.SetError(this.CBPeriodoAño, "Debe seleccionar un año para el periodo.");
                this.load_ErrorProviderGasto = true;
            }
            else
            {
                this.errorProvider1.SetError(this.CBPeriodoAño, "");
            }
        }

        private void CBCategorias_Validating(object sender, CancelEventArgs e)
        {
            if (this.CBCategorias.SelectedIndex < 0)
            {
                this.errorProvider1.SetError(this.CBCategorias, "Debe seleccionar una categoria para el periodo.");
                this.load_ErrorProviderGasto = true;
            }
            else
            {
                this.errorProvider1.SetError(this.CBCategorias, "");
            }
        }

        private void TBDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBDescripcion.Text))
            {
                this.errorProvider1.SetError(this.TBDescripcion, "El campo Descripcion es obligatorio.");
                this.load_ErrorProviderGasto = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBDescripcion.Text, @"^[a-zA-Z0-9\s\-,.]+$"))
            {
                this.errorProvider1.SetError(TBDescripcion, "El campo Descripcion solo puede caracteres alfabeticos, numericos, espacios y guiones.");
                this.load_ErrorProviderGasto = true;
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
                this.errorProvider1.SetError(this.TBMonto, "El campo Monto es obligatorio");
                this.load_ErrorProviderGasto = true;
            }
            else if (!decimal.TryParse(this.TBMonto.Text, out decimal monto_gasto))
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo Monto debe ser un valor numerico");
                this.load_ErrorProviderGasto = true;
            }
            else if (!(decimal.Round(monto_gasto, 2) == monto_gasto))
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo Monto debe ser un valor numerico con hasta dos decimales.");
                this.load_ErrorProviderGasto = true;
            }
            else if (monto_gasto <= 0)
            {
                this.errorProvider1.SetError(this.TBMonto, "El campo Monto debe ser mayor a cero.");
                this.load_ErrorProviderGasto = true;
            }
            else
            {
                this.errorProvider1.SetError(this.TBMonto, "");
            }
        }

        // ------------- Manejo Errores ------------- 
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

        private void BTNLimpiarFiltro_Click(object sender, EventArgs e)
        {
            this.CBDesdePeriodoMes.SelectedIndex = -1;
            this.CBDesdePeriodoAño.SelectedIndex = -1;

            this.CBHastaPeriodoMes.SelectedIndex = -1;
            this.CBHastaPeriodoAño.SelectedIndex = -1;

            this.CBFiltroCategoria.SelectedIndex = -1;
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            bool desde_seleccionado = false;
            bool hasta_seleccionado = false;
            bool categoria_seleccionado = false;

            string periodo_desde = string.Empty;
            string periodo_hasta = string.Empty;
            int categoria = -1;

            CN_Gasto gasto = new CN_Gasto();

            if (this.CBDesdePeriodoAño.SelectedIndex > -1 && this.CBDesdePeriodoMes.SelectedIndex > -1)
            {
                periodo_desde = this.CBDesdePeriodoAño.Text + "-" + (this.CBDesdePeriodoMes.SelectedIndex + 1) + "-01";
                desde_seleccionado = true;
            }

            if (this.CBHastaPeriodoAño.SelectedIndex > -1 && this.CBHastaPeriodoMes.SelectedIndex > -1)
            {
                periodo_hasta = this.CBHastaPeriodoAño.Text + "-" + (this.CBHastaPeriodoMes.SelectedIndex + 1) + "-01";
                hasta_seleccionado = true;
            }

            if (this.CBFiltroCategoria.SelectedIndex > -1)
            {
                categoria = Convert.ToInt32(this.CBFiltroCategoria.SelectedValue);
                categoria_seleccionado = true;
            }

            // Solamente este seleccionado el periodo desde.
            if (desde_seleccionado && !hasta_seleccionado && !categoria_seleccionado)
            {
                List<Gasto> lista_gastos = gasto.GetGastoFiltro(Convert.ToDateTime(periodo_desde));
                decimal monto_total = gasto.MontoAcumuladoActivos(lista_gastos);
                this.LoadTableGastos(lista_gastos);
                this.LTotalFiltrado.Text = monto_total == 0? "$ - - -" : "$ " + monto_total;
            }

            // Solamente haya seleccionada una categoria.
            if (!desde_seleccionado && !hasta_seleccionado && categoria_seleccionado)
            {
                List<Gasto> lista_gastos = gasto.GetGastoFiltro(categoria);
                decimal monto_total = gasto.MontoAcumuladoActivos(lista_gastos);
                this.LoadTableGastos(lista_gastos);
                this.LTotalFiltrado.Text = monto_total == 0 ? "$ - - -" : "$ " + monto_total;
            }

            // Este seleccionado tanto el periodo desde como el periodo hasta. 
            if (desde_seleccionado && hasta_seleccionado && !categoria_seleccionado)
            {
                if (Convert.ToDateTime(periodo_hasta) <= Convert.ToDateTime(periodo_desde))
                {
                    MessageBox.Show(
                        "El período 'Hasta' debe ser posterior al período 'Desde'.\n\n" +
                        "Si desea filtrar un único período, complete solamente el período 'Desde'.",
                        "Período inválido.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    List<Gasto> lista_gastos = gasto.GetGastoFiltro(Convert.ToDateTime(periodo_desde), Convert.ToDateTime(periodo_hasta));
                    decimal monto_total = gasto.MontoAcumuladoActivos(lista_gastos);
                    this.LoadTableGastos(lista_gastos);
                    this.LTotalFiltrado.Text = monto_total == 0 ? "$ - - -" : "$ " + monto_total;
                }
            }

            // Este seleccionado tanto el periodo desde como el periodo hasta y tambien haya seleccionada una categoria.
            if (desde_seleccionado && hasta_seleccionado && categoria_seleccionado)
            {
                if (Convert.ToDateTime(periodo_hasta) <= Convert.ToDateTime(periodo_desde))
                {
                    MessageBox.Show(
                        "El período 'Hasta' debe ser posterior al período 'Desde'.\n\n" +
                        "Si desea filtrar un único período, complete solamente el período 'Desde'.",
                        "Período inválido.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    List<Gasto> lista_gastos = gasto.GetGastoFiltro(Convert.ToDateTime(periodo_desde), Convert.ToDateTime(periodo_hasta), categoria);
                    decimal monto_total = gasto.MontoAcumuladoActivos(lista_gastos);
                    this.LoadTableGastos(lista_gastos);
                    this.LTotalFiltrado.Text = monto_total == 0 ? "$ - - -" : "$ " + monto_total;
                }
            }

            // Este sleccionao el periodo desde y una categoria
            if (desde_seleccionado && !hasta_seleccionado && categoria_seleccionado)
            {
                List<Gasto> lista_gastos = gasto.GetGastoFiltro(Convert.ToDateTime(periodo_desde), categoria);
                decimal monto_total = gasto.MontoAcumuladoActivos(lista_gastos);
                this.LoadTableGastos(lista_gastos);
                this.LTotalFiltrado.Text = monto_total == 0 ? "$ - - -" : "$ " + monto_total;
            }

            return;
        }

    }
}