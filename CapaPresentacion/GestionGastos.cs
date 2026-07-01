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

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionGastos : Form
    {
        public Principal principal; 
        private bool load_ErrorProviderNCategoria;
         
        public GestionGastos(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.LoadCBCategorias();
            this.LoadTableCategorias(); 
        }

        public void LoadCBCategorias() 
        {
            CN_CategoriaGasto categoria = new CN_CategoriaGasto(); 
            List<Categoria_gasto> lista_categorias = categoria.AllCategoriesActive();
             
            this.CBCategorias.DisplayMember = "descripcion_categoria";
            this.CBCategorias.ValueMember = "id_categoria";

            if(lista_categorias != null) 
            {
                this.CBCategorias.DataSource = lista_categorias;
                this.CBCategorias.SelectedIndex = -1;
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

        public void LoadTableCategorias()
        {
            this.DGVCategorias.DataSource = null;
            this.DGVCategorias.Columns.Clear();
            this.DGVCategorias.Rows.Clear();

            CN_CategoriaGasto categoria = new CN_CategoriaGasto();
            List<Categoria_gasto> lista_categorias = categoria.AllCategories();

            DGVCategorias.DataSource = this.LoadTableCategorias(lista_categorias);

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

        public object LoadTableCategorias(List<Categoria_gasto> _lista)
        {
            var tabla = _lista.Select((categoria, index) => new
            {
                Id_categoria = categoria.id_categoria,
                Descripcion = categoria.descripcion_categoria,
                Estado = categoria.estado_categoria,
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "CEstado" && e.RowIndex >= 0)
            {
                bool estado = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["Estado"].Value);

                e.Value = estado? "Desactivar" : "Activar";
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
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true? "desactivar" : "activar";

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
                            string nuevoEstado = confirmacion.estado_categoria == true? "activado" : "desactivado";
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

        private void BTNAgregarCategoria_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderNCategoria = false;

            if(this.ValidateChildren())
            {
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