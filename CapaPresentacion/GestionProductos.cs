using iTextSharp.text;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionProductos : Form, IConfigForm
    {

        public Principal principal;
        public Producto producto_editar;
        public CancellationTokenSource cts;
        public bool load_errorProviderCategoria;
        public bool load_errorProviderProducto;

        public GestionProductos(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.cts = new CancellationTokenSource();
            this.LoadInit();
            this.LoadTableProductos();
            this.ConfigWindowState();
            this.CargarCBCategoriaProducto();
            this.ConfigToolTips();
        }
         
        public void LoadInit()
        {
            this.BTNActualizar.Hide();
            this.BTNReestablecer.Hide();

            this.textBox1.Text = "Buscar por marca, producto o codigo ...";
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

        private void BTNInsertar_Click(object sender, EventArgs e)
        {
            this.load_errorProviderCategoria = false;
             
            if (this.ValidateChildren())
            {
                this.limpiarEPCamposProducto();

                if (this.load_errorProviderCategoria) 
                {
                    this.errorProvider1.SetError(this.LNuevaCategoria, "");
                    this.errorProvider1.SetError(this.LNuevaCategoria, "El campo Categoria no puede estar vacio.");
                    return;
                }
            } 
             
            Categoria_producto nueva_categoria = new Categoria_producto();
            nueva_categoria.descripcion_categoria = this.TBCategoriaProducto.Text;

            CN_CategoriaProducto categoria = new CN_CategoriaProducto();
            categoria.ValidarCategoria(nueva_categoria);
            
            try
            { 
                if(categoria.GetErrors().Count == 0) 
                {
                    categoria.CrearCategoria(nueva_categoria); 
                    this.TBCategoriaProducto.Text = string.Empty;
                    this.CargarCBCategoriaProducto();
                    MessageBox.Show("La categoria se registro correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    this.mostrarErrores(categoria.GetErrors());
                    MessageBox.Show($"Ha ocurrido un error, verifique los datos suministrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void CargarCBCategoriaProducto() 
        {
            this.CBCategoriaProducto.DisplayMember = "descripcion_categoria";
            this.CBCategoriaProducto.ValueMember = "id_categoria";

            CN_CategoriaProducto categoria = new CN_CategoriaProducto();
            List<Categoria_producto> lista = categoria.listarCategorias();

            if(lista != null) 
            { 
                this.CBCategoriaProducto.DataSource = lista; 
                this.CBCategoriaProducto.SelectedIndex = -1;
            }
        }

        public void ConfigToolTips() 
        {
            toolTip1.SetToolTip(BTNCalcularMargen, "Calculadora de Margenes y Precio de Venta."); 
        }

        // ---------------------- Registro y atulizacion de productos ----------------------
        private void Registrar_Click(object sender, EventArgs e)
        {   
            this.load_errorProviderProducto = false;
            this.limpiarEPCamposProducto();

            if (this.ValidateChildren())
            {
                if (this.load_errorProviderProducto)
                {
                    return;
                }
            }  

            Producto nuevoProducto = new Producto();
            this.CargarEntidadProducto(nuevoProducto);

            // Validaciones y creacion de Cliente completo.
            try
            {
                CN_Producto producto = new CN_Producto();

                int resultado = producto.CrearProducto(nuevoProducto);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limpiarCamposProducto();
                    // this.LoadTableProductos();
                }
                else
                {
                    this.mostrarErrores(producto.GetErrors());
                    MessageBox.Show("Verififque que los datos suministrados sean correctos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void BTNActualizar_Click(object sender, EventArgs e)
        { 
            this.load_errorProviderProducto = false;
            this.errorProvider1.Clear();

            if (this.ValidateChildren())
            {
                if (this.load_errorProviderProducto)
                {
                    return;
                }
            } 

            this.CargarEntidadProducto(producto_editar);
             
            try
            {
                CN_Producto producto = new CN_Producto();

                int resultado = producto.UpdateProducto(this.producto_editar);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente.", "Actualizado.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.BTNLimpiar.Show();
                    this.BTNReestablecer.Hide();

                    this.BTAgregar.Show();
                    this.BTNActualizar.Hide();

                    this.limpiarCamposProducto(); 
                    this.LoadTableProductos();
                }
                else
                {
                    this.mostrarErrores(producto.GetErrors());
                    MessageBox.Show("Ha ocurrido un error, verifique los datos suministrados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // ---------------------- Manejo de DGV ----------------------
        public void LoadTableProductos()
        {
            CN_Producto producto = new CN_Producto();
            List<Producto> _lista = new List<Producto>();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            _lista = producto.Get_Productos();

            dataGridView1.DataSource = this.LoadTable(_lista);

            dataGridView1.Columns["Id_producto"].Visible = false;
            dataGridView1.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            dataGridView1.Columns.Add(btnColumnEditar);
            dataGridView1.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Khaki;
            dataGridView1.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Khaki;

            DataGridViewButtonColumn btnColumnEstado = new DataGridViewButtonColumn();
            btnColumnEstado.Name = "CEstado";
            btnColumnEstado.HeaderText = "Estado";
            btnColumnEstado.UseColumnTextForButtonValue = true;
            btnColumnEstado.FlatStyle = FlatStyle.Standard;
            btnColumnEstado.UseColumnTextForButtonValue = false; // Para poder modificar el texto.
            dataGridView1.Columns.Add(btnColumnEstado);
            dataGridView1.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridView1.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        }

        public void LoadTableProductos(List<Producto> _lista)
        { 
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();
             
            dataGridView1.DataSource = this.LoadTable(_lista);

            dataGridView1.Columns["Id_producto"].Visible = false;
            dataGridView1.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            dataGridView1.Columns.Add(btnColumnEditar);
            dataGridView1.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Khaki;
            dataGridView1.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Khaki;

            DataGridViewButtonColumn btnColumnEstado = new DataGridViewButtonColumn();
            btnColumnEstado.Name = "CEstado";
            btnColumnEstado.HeaderText = "Estado";
            btnColumnEstado.UseColumnTextForButtonValue = true;
            btnColumnEstado.FlatStyle = FlatStyle.Standard;
            btnColumnEstado.UseColumnTextForButtonValue = false; // Para poder modificar el texto.
            dataGridView1.Columns.Add(btnColumnEstado);
            dataGridView1.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            dataGridView1.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        }

        public object LoadTable(List<Producto> _lista)
        {
            var tabla = _lista.Select((producto, index) => new
            {
                Id_producto = producto.id_producto,
                Marca = producto.marca_producto,
                Producto = producto.nombre_producto,
                Descripcion = producto.descripcion_producto,
                Contenido = producto.contenido_producto,
                Stock = Convert.ToString(producto.stock_producto),
                PrecioCosto = "$" + Convert.ToString(producto.precio_costo),
                PrecioVenta = "$" + Convert.ToString(producto.precio_venta),
                Margen = producto.precio_venta != 0 && producto.precio_venta != 0 ? decimal.Round((((producto.precio_venta - producto.precio_costo) / producto.precio_venta)) * 100 , 2)+ "%" : "-",
                Estado = producto.estado_producto,
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "CEstado" && e.RowIndex >= 0)
            {
                bool estado = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Estado"].Value);

                e.Value = estado ? "Desactivar" : "Activar";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            producto_editar = null;
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Obtenemos la identificaicon del cliente para realizar la busqueda
            int id_producto = Convert.ToInt32(dgt.Rows[filaIndex].Cells["Id_producto"].Value);

            CN_Producto producto = new CN_Producto();

            if (id_producto > 0) 
            { 
                producto_editar = producto.Get_Producto(id_producto); 
            }
           
            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CEditar")
            {
                DialogResult confirmacionEditar = MessageBox.Show(
                    "¿Seguro que deseas editar este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionEditar == DialogResult.Yes)
                {
                    try
                    {
                        if (producto_editar != null)
                        {
                            // cargamos los paneles con los datos correspondientes al producto_editar.
                            this.CargarProducto(producto_editar);
                            
                            this.BTNLimpiar.Hide();
                            this.BTNReestablecer.Show();

                            this.BTAgregar.Hide();
                            this.BTNActualizar.Show();
                        }
                        else
                        {
                            MessageBox.Show("No se ha encontrado el producto, vuelva a intentar.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information); 
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
                    "¿Seguro que deseas " + estado_cambiar + " este producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes)
                {
                    try
                    {
                        producto_editar.estado_producto = !producto_editar.estado_producto;
                        string producto_nombre = producto_editar.nombre_producto;
                        string producto_descripcion = producto_editar.descripcion_producto;
                        string producto_contenido = producto_editar.contenido_producto;
                        string product = producto_nombre + " " + producto_descripcion + " (" + producto_contenido + ")";

                        Producto confirmacion = producto.UpdateProductoEstado(producto_editar);

                        if (confirmacion != null)
                        {
                            string nuevoEstado = confirmacion.estado_producto == true ? "activado." : "desactivado.";
                            MessageBox.Show("El producto " + product + " se ha " + nuevoEstado);
                            this.LoadTableProductos();
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

        private void BTNReestablecer_Click(object sender, EventArgs e)
        {
            this.CargarProducto(producto_editar);
        } 

        // ---------------------- Cargar entidades ----------------------

        public void CargarEntidadProducto(Producto _producto) 
        { 
            _producto.marca_producto = this.TBMarcaProducto.Text;
            _producto.nombre_producto = this.TBNombreProducto.Text;
            _producto.descripcion_producto = this.TBDescripcionProducto.Text;
            _producto.contenido_producto = this.TBContenidoProducto.Text;
            _producto.categoria_producto = Convert.ToInt32(this.CBCategoriaProducto.SelectedValue);

            int.TryParse(this.TBStockProducto.Text, out int stock);
            _producto.stock_producto = stock;

            int.TryParse(this.TBStockMinimo.Text, out int stockmin);
            _producto.stock_minimo = stockmin;

            decimal.TryParse(this.TBPrecioCosto.Text, out decimal precio_c);
            _producto.precio_costo = precio_c;

            decimal.TryParse(this.TBPrecioVenta.Text, out decimal precio_v);
            _producto.precio_venta = precio_v;
             
            _producto.sku_producto = this.TBSkuProducto.Text; 
        }

        public void CargarProducto(Producto _producto)
        {
            this.TBMarcaProducto.Text = _producto.marca_producto;
            this.TBNombreProducto.Text = _producto.nombre_producto;
            this.TBDescripcionProducto.Text = _producto.descripcion_producto;
            this.TBContenidoProducto.Text = _producto.contenido_producto; 
            this.CBCategoriaProducto.SelectedValue = Convert.ToInt32(_producto.categoria.id_categoria);
            this.TBStockProducto.Text = Convert.ToString(_producto.stock_producto);
            this.TBStockMinimo.Text = Convert.ToString(_producto.stock_minimo);
            this.TBPrecioCosto.Text = Convert.ToString(_producto.precio_costo);
            this.TBPrecioVenta.Text = Convert.ToString(_producto.precio_venta);
            this.TBSkuProducto.Text = _producto.sku_producto;
        }

        // ---------------------- Eventos de Validacion ----------------------
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


        // ---------------------- Validacion para nueva categoria ----------------------
        private void TBCategoriaProducto_Validating(object sender, CancelEventArgs e)
        { 
            if (string.IsNullOrEmpty(this.TBCategoriaProducto.Text))
            { 
                this.load_errorProviderCategoria = true;
            }
            else
            {
                this.errorProvider1.SetError(TBCategoriaProducto, "");
            }
        } 

        // ---------------------- Validacion para nuevo producfto ----------------------
        private void TBMarcaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBMarcaProducto.Text))
            {
                this.errorProvider1.SetError(TBMarcaProducto, "El campo Marca no puede estar vacio.");
                this.load_errorProviderProducto = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBMarcaProducto.Text, @"^[a-zA-Z0-9\s\-]+$"))
            {
                this.errorProvider1.SetError(TBMarcaProducto, "El campo Marca solo puede caracteres alfabeticos, numericos, espacios y guiones.");
                this.load_errorProviderProducto = true;
            }
            else 
            {
                this.errorProvider1.SetError(TBMarcaProducto, "");
            }
        }

        private void TBNombreProducto_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBNombreProducto.Text))
            {
                this.errorProvider1.SetError(TBNombreProducto, "El campo Producto no puede estar vacio.");
                this.load_errorProviderProducto = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNombreProducto.Text, @"^[a-zA-Z0-9\s\-]+$"))
            {
                this.errorProvider1.SetError(TBNombreProducto, "El campo Producto solo puede caracteres alfabeticos, numericos, espacios y guiones.");
                this.load_errorProviderProducto = true;
            }
            else
            {
                this.errorProvider1.SetError(TBNombreProducto, "");
            }
        }

        private void TBDescripcionProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TBDescripcionProducto.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBDescripcionProducto.Text, @"^[a-zA-Z0-9\s,.]+$"))
                {
                    this.errorProvider1.SetError(TBDescripcionProducto, "El campo Descripcion solo puede contener caracteres alfabeticos (.,), numericos, espacios.");
                    this.load_errorProviderProducto = true;
                }
                else
                {
                    this.errorProvider1.SetError(TBDescripcionProducto, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(TBDescripcionProducto, "");
            }
        }

        private void CBCategoriaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (this.CBCategoriaProducto.SelectedIndex < 0) 
            {
                this.errorProvider1.SetError(CBCategoriaProducto, "Debe seleccionar una categoria.");
                this.load_errorProviderProducto = true;
            }
            else
            {
                this.errorProvider1.SetError(CBCategoriaProducto, "");
            }
        }

        private void TBContenidoProducto_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBContenidoProducto.Text))
            {
                this.errorProvider1.SetError(TBContenidoProducto, "El campo Contenido no puede estar vacio.");
                this.load_errorProviderProducto = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBContenidoProducto.Text, @"^[a-zA-Z0-9\s,.]+$"))
            {
                this.errorProvider1.SetError(TBContenidoProducto, "El campo Contenido solo puede contener caracteres alfabeticos (.,), numericos y espacios.");
                this.load_errorProviderProducto = true;
            }
            else
            {
                this.errorProvider1.SetError(TBContenidoProducto, "");
            }
        }

        private void TBStockProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TBStockProducto.Text))
            {
                if (!int.TryParse(this.TBStockProducto.Text, out _)) 
                {
                    this.errorProvider1.SetError(TBStockProducto, "El campo Stock solo puede contener caracteres numericos.");
                    this.load_errorProviderProducto = true;
                }
                else
                {
                    this.errorProvider1.SetError(TBStockProducto, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(TBStockProducto, "");
            }
        }

        private void TBStockMinimo_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TBStockMinimo.Text))
            {
                if (!int.TryParse(this.TBStockMinimo.Text, out _))
                {
                    this.errorProvider1.SetError(TBStockMinimo, "El campo Stock Minimo solo puede contener caracteres numericos");
                    this.load_errorProviderProducto = true;
                }
                else
                {
                    this.errorProvider1.SetError(TBStockMinimo, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(TBStockMinimo, "");
            }
        }

        private void TBPrecioCosto_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TBPrecioCosto.Text))
            {
                if (!decimal.TryParse(this.TBPrecioCosto.Text, out _))
                {
                    this.errorProvider1.SetError(TBPrecioCosto, "El campo Precio solo puede contener caracteres numericos");
                    this.load_errorProviderProducto = true;
                }
                else
                {
                    this.errorProvider1.SetError(TBPrecioCosto, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(TBPrecioCosto, "");
            }
        }

        private void TBPrecioVenta_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TBPrecioVenta.Text))
            {
                if (!decimal.TryParse(this.TBPrecioVenta.Text, out _))
                {
                    this.errorProvider1.SetError(TBPrecioVenta, "El campo Precio solo puede contener caracteres numericos");
                    this.load_errorProviderProducto = true;
                }
                else
                {
                    this.errorProvider1.SetError(TBPrecioVenta, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(TBPrecioVenta, "");
            }
        }

        private void TBSkuProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TBSkuProducto.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBSkuProducto.Text, @"^[a-zA-Z0-9]+$"))
                {
                    this.errorProvider1.SetError(TBSkuProducto, "El campo Codigo solo puede contener caracteres alfabeticos y numericos.");
                    this.load_errorProviderProducto = true;
                }
                else
                {
                    this.errorProvider1.SetError(TBSkuProducto, "");
                }
            }
            else
            {
                this.errorProvider1.SetError(TBSkuProducto, "");
            }
        }

        // ---------------------- Eventos panel creacion productos ----------------------
        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCamposProducto();
            this.limpiarEPCamposProducto();
        }

        public void limpiarCamposProducto() 
        {
            this.TBMarcaProducto.Text = string.Empty;
            this.TBNombreProducto.Text = string.Empty;
            this.TBDescripcionProducto.Text = string.Empty;
            this.TBContenidoProducto.Text = string.Empty;
            this.CBCategoriaProducto.SelectedIndex = -1;
            this.TBStockProducto.Text = string.Empty;
            this.TBStockMinimo.Text = string.Empty;
            this.TBPrecioCosto.Text = string.Empty;
            this.TBPrecioVenta.Text = string.Empty;
            this.TBSkuProducto.Text = string.Empty;
        }

        public void limpiarEPCamposProducto()
        {
            this.errorProvider1.SetError(TBMarcaProducto, "");
            this.errorProvider1.SetError(TBNombreProducto, "");
            this.errorProvider1.SetError(TBDescripcionProducto, "");
            this.errorProvider1.SetError(TBContenidoProducto, "");
            this.errorProvider1.SetError(CBCategoriaProducto, "");
            this.errorProvider1.SetError(TBStockProducto, "");
            this.errorProvider1.SetError(TBStockMinimo, "");
            this.errorProvider1.SetError(TBPrecioCosto, "");
            this.errorProvider1.SetError(TBPrecioVenta, "");
            this.errorProvider1.SetError(TBSkuProducto, "");
        }

        private void BTNCalcularMargen_Click(object sender, EventArgs e)
        {
            Calculadora calculadora = new Calculadora();
            calculadora.Show();
        }

        private void BTNCalcularMargen_MouseEnter(object sender, EventArgs e)
        {
            this.BTNCalcularMargen.BackColor = Color.Cyan;
        }

        private void BTNCalcularMargen_MouseLeave(object sender, EventArgs e)
        {
            this.BTNCalcularMargen.BackColor = Color.DarkTurquoise;
        }

        private void TBBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox.Text.Equals("Buscar por marca, producto o codigo ..."))
            {
                textBox.Text = "";
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            CN_Producto producto = new CN_Producto();
            List<Producto> lista = new List<Producto>();

            if (!string.IsNullOrWhiteSpace(this.textBox1.Text) && this.textBox1.Text != "Buscar por marca, producto o codigo ...")
            {
                try
                {
                    this.LoadTableProductos(await producto.Get_Productos(cts.Token, this.textBox1.Text));
                }
                catch (TaskCanceledException)
                {
                    // La consulta fue cancelada, no hacemos nada   
                }
            }
            else
            {
                this.LoadTableProductos(); 
            }
        }

    }
}
