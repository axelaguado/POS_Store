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
using WindowsFormsApp1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iTextSharp.tool.xml.css;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class RegistrarCompra : Form
    {

        private bool load_CBProveedor;
        private bool load_CBProducto;

        private Producto producto_seleccionado;
        private Proveedor proveedor_seleccionado;

        private bool load_ErrorProviderProducto;
        private bool load_ErrorProviderProveedor;

        private List<Detalle_compra> carrito;
        private CancellationTokenSource cts;
         

        public RegistrarCompra()
        {
            InitializeComponent();
            this.carrito = new List<Detalle_compra>();
            this.cts = new CancellationTokenSource();
            this.LoadInit();
        }

        public void LoadInit() 
        {
            this.LoadCBProducto();
            this.LoadCBProveedor();    
        }

        public void LoadCBProducto()
        {
            CN_Producto producto = new CN_Producto();
            List<Producto> lista_producto = producto.Get_Productos();

            this.CBProducto.ValueMember = "id_producto";
            this.CBProducto.DisplayMember = "producto_completo";

            this.load_CBProducto = true;
            this.CBProducto.DataSource = lista_producto;
            this.CBProducto.SelectedIndex = -1;
            this.load_CBProducto = false; 
        }

        public void LoadCBProveedor()
        {
            CN_Proveedor proveedor = new CN_Proveedor();
            List<Proveedor> lista_proveedor = proveedor.ObtenerProveedores();

            this.CBProveedor.ValueMember = "id_proveedor";
            this.CBProveedor.DisplayMember = "nombreCompleto_proveedor";

            this.load_CBProveedor = true; 
            this.CBProveedor.DataSource = lista_proveedor;
            this.CBProveedor.SelectedIndex = -1;
            this.load_CBProveedor = false;
        }

        // --------------------- Eventos CBProducto y CBProveedor ---------------------  
        // --------------------- Botones de busqueda --------------------- 
        private void BTNBuscarSku_Click(object sender, EventArgs e)
        {
            CN_Producto producto = new CN_Producto();
            Producto productoEncontrado = string.IsNullOrEmpty(this.TBProductoSku.Text)? null : producto.Get_ProductoSku(this.TBProductoSku.Text);

            if (productoEncontrado != null)
            {
                List<Producto> lista = new List<Producto>();
                lista.Add(productoEncontrado);

                this.CBProducto.ValueMember = "id_producto";
                this.CBProducto.DisplayMember = "producto_completo";
                this.CBProducto.DataSource = lista;
                this.CBProducto.Enabled = false;
            }
            else
            {
                this.CBProducto.SelectedIndex = -1;
                MessageBox.Show("El producto no existe o no esta disponible para esta operacion", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTNBuscarCuit_Click(object sender, EventArgs e)
        {
            long.TryParse(this.TBProveedorCuit.Text, out long cuit);
            CN_Proveedor proveedor = new CN_Proveedor();
            Proveedor proveedorEncontrado = proveedor.ObtenerProveedor(cuit);
            
            if(proveedorEncontrado != null)
            {
                List<Proveedor> lista = new List<Proveedor>();
                lista.Add(proveedorEncontrado);

                this.CBProveedor.ValueMember = "id_proveedor";
                this.CBProveedor.DisplayMember = "nombreCompleto_proveedor"; 
                this.CBProveedor.DataSource = lista;
                this.CBProveedor.Enabled = false; 
            }
            else 
            {
                this.CBProveedor.SelectedIndex = -1;
                MessageBox.Show("El proveedor no existe o no esta disponible para esta operacion", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // --------------------- Selected Index Changed --------------------- 
        private void CBProducto_SelectedIndexChanged(object sender, EventArgs e)
        {  
            // Si se esta cargando el combobox no ejecuto el evento.
            if (this.load_CBProducto)
            {
                return;
            }
              
            if (this.CBProducto.SelectedIndex == -1 && Convert.ToInt32(this.CBProducto.SelectedValue) < 1)
            {
                return;
            }
  
            producto_seleccionado = this.CBProducto.SelectedItem as Producto; 

            this.TBProductoSku.Text = string.IsNullOrEmpty(producto_seleccionado.sku_producto)? "-" : producto_seleccionado.sku_producto;
            this.TBProductoSku.Enabled = false;
            this.BTNBuscarSku.Enabled = false; 
        }

        private void CBProveedor_SelectedIndexChanged(object sender, EventArgs e)
        { 
            // Si se esta cargando el combobox no ejecuto el evento.
            if (this.load_CBProveedor)
            {
                return;
            } 

            if (this.CBProveedor.SelectedIndex == -1 && Convert.ToInt32(this.CBProveedor.SelectedValue) < 1)
            {
                return;
            }

            proveedor_seleccionado = this.CBProveedor.SelectedItem as Proveedor;
             
            this.TBProveedorCuit.Text = proveedor_seleccionado.persona.persona_juridica.cuit == 0? "-" : Convert.ToString(proveedor_seleccionado.persona.persona_juridica.cuit);
            this.TBProveedorCuit.Enabled = false;
            this.BTNBuscarCuit.Enabled = false;  
        }

        // --------------------- Text Changed --------------------- 
        private async void CBProdoucto_TextChanged(object sender, EventArgs e)
        { 
            // Si se esta cargando el combobox no ejecuto el evento.
            if (this.load_CBProducto)
            {
                return;
            }
              
            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            string text = this.CBProducto.Text;

            CN_Producto producto = new CN_Producto();

            try
            {
                if (!string.IsNullOrWhiteSpace(this.CBProducto.Text))
                {
                    this.CargarCBProducto(await producto.Get_ProductosDTO(cts.Token, text), text);
                }
                else
                {
                    this.LoadCBProducto();
                    this.TBProductoSku.Text = "";
                    this.TBProductoSku.Enabled = true;
                    this.BTNBuscarSku.Enabled = true;
                }
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                List<Producto> lista = new List<Producto>();
                Producto errorproducto = new Producto();

                errorproducto.nombre_producto = "Ha ocurrido un error, vuelva a intentarlo.";
                errorproducto.id_producto = 0;

                lista.Add(errorproducto);

                this.load_CBProducto = true;
                this.CBProducto.DataSource = lista;
            }
            finally
            {
                this.load_CBProducto = false;
            }
        }

        private async void CBProveedor_TextChanged(object sender, EventArgs e)
        {  
            // Si se esta cargando el combobox no ejecuto el evento.
            if (load_CBProveedor) 
            { 
                return;
            }


            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            string text = this.CBProveedor.Text;

            CN_Proveedor proveedor = new CN_Proveedor();
             
            try
            {
                if (!string.IsNullOrWhiteSpace(this.CBProveedor.Text))
                {
                    this.CargarCBProveedor(await proveedor.ObtenerProveedorAsync(this.CBProveedor.Text, cts.Token), text);
                }
                else 
                {
                    this.LoadCBProveedor();
                    this.TBProveedorCuit.Text = "";
                    this.TBProveedorCuit.Enabled = true;
                    this.BTNBuscarCuit.Enabled = true;
                }
            }
            catch (TaskCanceledException)
            {
                 // La consulta fue cancelada, no hacemos nada   
            } 
            catch (Exception ex)
            {
                List<Proveedor> lista = new List<Proveedor>();
                Proveedor errorproveedor = new Proveedor();

                errorproveedor.persona.persona_juridica.razon_social = "Ha ocurrido un error, vuelva a intentarlo.";
                errorproveedor.id_proveedor = 0;

                lista.Add(errorproveedor);

                this.load_CBProveedor = true;
                this.CBProveedor.DataSource = lista;
            }
            finally
            {  
                this.load_CBProveedor = false;  
            }
        }

        // --------------------- Carga de CB --------------------- 
        public void CargarCBProveedor(List<Proveedor> _lista, string text)
        {
            this.CBProveedor.DropDownStyle = ComboBoxStyle.DropDown;

            this.CBProveedor.ValueMember = "id_proveedor";
            this.CBProveedor.DisplayMember = "nombreCompleto_proveedor"; 

            // Cuando escribo algo se muestar la lista
            if (_lista.Count > 0)
            { 
                /*
                    Internamente pasa esto:

                    1. cambia DataSource
                    2. cambia Text
                    3. dispara TextChanged OTRA VEZ
                 */

                this.load_CBProveedor = true; 
                this.CBProveedor.DataSource = _lista;
                this.CBProveedor.SelectedIndex = -1;
                this.CBProveedor.Text = text;
                this.CBProveedor.SelectionStart = text.Length;
            }
            else 
            { 
                List<Proveedor> lista = new List<Proveedor>();
                Proveedor sinproveedor = new Proveedor();
                Persona persona = new Persona();
                PersonaJuridica pj = new PersonaJuridica();  
                sinproveedor.persona = persona;
                sinproveedor.persona.persona_juridica = pj; 

                sinproveedor.persona.persona_juridica.razon_social = "No se encontraron elementos.";
                sinproveedor.id_proveedor = 0;
                 
                if (this.proveedor_seleccionado == null)
                {
                    lista.Add(sinproveedor);
                    this.load_CBProveedor = true;
                    this.CBProveedor.DataSource = lista;
                    this.CBProveedor.SelectedIndex = -1;
                    this.CBProveedor.Text = text;
                    this.CBProveedor.SelectionStart = text.Length;
                }
                else
                {
                    lista.Add(proveedor_seleccionado);
                    this.load_CBProveedor = true;
                    this.CBProveedor.DataSource = lista;
                    this.CBProveedor.SelectionStart = proveedor_seleccionado.nombreCompleto_proveedor.Length;
                } 
            }  
        }

        public void CargarCBProducto(List<Producto> _lista, string text)
        {
            this.CBProducto.DropDownStyle = ComboBoxStyle.DropDown;

            this.CBProducto.ValueMember = "id_producto";
            this.CBProducto.DisplayMember = "producto_completo";

            // Cuando escribo algo se muestar la lista
            if (_lista.Count > 0)
            { 
                /*
                    Internamente pasa esto:

                    1. cambia DataSource
                    2. cambia Text
                    3. dispara TextChanged OTRA VEZ
                 */

                this.load_CBProducto = true;
                this.CBProducto.DataSource = _lista;
                this.CBProducto.SelectedIndex = -1;
                this.CBProducto.Text = text;
                this.CBProducto.SelectionStart = text.Length;
            }
            else
            {
                List<Producto> lista = new List<Producto>();
                Producto sinproducto = new Producto();

                sinproducto.nombre_producto = "No se encontraron elementos";
                sinproducto.id_producto = 0;
                 
                if (this.producto_seleccionado == null)
                { 
                    lista.Add(sinproducto);
                    this.load_CBProducto = true;
                    this.CBProducto.DataSource = lista;
                    this.CBProducto.SelectedIndex = -1;
                    this.CBProducto.Text = text;
                    this.CBProducto.SelectionStart = text.Length;
                }
                else
                {
                    lista.Add(producto_seleccionado); 
                    this.load_CBProducto = true;
                    this.CBProducto.DataSource = lista;
                    this.CBProducto.SelectionStart = producto_seleccionado.producto_completo.Length; 
                }  
            } 
        }

        // Validaciones Proveedor.
        private void TBProveedorCuit_Validating(object sender, CancelEventArgs e)
        {
            /*
             * Aca podemos observar como podriamos utilizar el sender (control que produce el evento) para un algoritmo mas dinamico.
                System.Windows.Forms.Control control = sender as System.Windows.Forms.TextBox;
                errorProvider1.SetError(control, "El campo CUIT solo puede contener valores numericos");
            */

            if (string.IsNullOrEmpty(this.TBProveedorCuit.Text))
            {
                errorProvider1.SetError(this.TBProveedorCuit, "El campo CUIT no puede estar vacio.");
                this.load_ErrorProviderProveedor = true;
            }
            if (!long.TryParse(this.TBProveedorCuit.Text, out _))
            {
                errorProvider1.SetError(this.TBProveedorCuit, "El campo CUIT solo puede contener valores numericos.");
                this.load_ErrorProviderProveedor = true;
            }
            else if (Convert.ToInt64(this.TBProveedorCuit.Text) > 999999999999)
            {
                errorProvider1.SetError(this.TBProveedorCuit, "El campo CUIT no puede superar los 11 caracteres.");
                this.load_ErrorProviderProveedor = true;
            }
            else
            {
                errorProvider1.SetError(this.TBProveedorCuit, "");
            }
        }

        // Validaciones Producto.
        public void TBProductoSku_Validating(object sender, CancelEventArgs e)
        { 
            if (string.IsNullOrEmpty(this.TBProductoSku.Text))
            {
                errorProvider1.SetError(this.TBProductoSku, "El campo Sku no puede quedar vacio.");
                this.load_ErrorProviderProducto = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBProductoSku.Text, @"^[a-zA-Z0-9\-]+$"))
            {
                errorProvider1.SetError(this.TBProductoSku, "El campo Sku solo puede contener caracteres alfabeticos y numericos.");
                this.load_ErrorProviderProducto = true;
            } 
            else 
            {
                errorProvider1.SetError(this.TBProductoSku, "");
            }
        }

        private void TBProductoPrecio_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBProductoPrecio.Text))
            {
                errorProvider1.SetError(this.TBProductoPrecio, "El campo Precio no puede estar vacio.");
                this.load_ErrorProviderProducto = true;
            }
            else if (!decimal.TryParse(this.TBProductoPrecio.Text, out decimal _precio))
            {
                errorProvider1.SetError(this.TBProductoPrecio, "El campo Precio debe contener un valor numerico.");
                this.load_ErrorProviderProducto = true;
            }
            else if (_precio <= 0)
            {
                errorProvider1.SetError(this.TBProductoPrecio, "El campo Precio debe ser mayor o igual a cero.");
                this.load_ErrorProviderProducto = true;
            }
            else if (decimal.Round(_precio, 2) != _precio)
            {
                errorProvider1.SetError(this.TBProductoPrecio, "El campo Precio solo acepta valores con hasta dos decimales");
                this.load_ErrorProviderProducto = true;
            }
            else
            {
                errorProvider1.SetError(this.TBProductoPrecio, "");
            }

        }

        private void TBProductoCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBProductoCantidad.Text))
            {
                errorProvider1.SetError(this.TBProductoCantidad, "El campo Cantidad no puede estar vacio.");
                this.load_ErrorProviderProducto = true;
            }
            else if (!int.TryParse(this.TBProductoCantidad.Text, out int cantidad))
            {
                errorProvider1.SetError(this.TBProductoCantidad, "El campo Cantidad debe contener un valor numerico entero.");
                this.load_ErrorProviderProducto = true;
            }
            else if (cantidad < 1)
            {
                errorProvider1.SetError(this.TBProductoCantidad, "El campo Cantidad debe ser mayor a cero.");
                this.load_ErrorProviderProducto = true;
            }
            else
            {
                errorProvider1.SetError(this.TBProductoCantidad, "");
            }
        }

        public void TBProductoInformacion_Validating(object sender, CancelEventArgs e)
        {  
            if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBProductoInformacion.Text, @"^[a-zA-Z0-9\s,.]+$"))
            {
                errorProvider1.SetError(this.TBProductoInformacion, "El campo Informacion solo puede contener caracteres alfabeticos (.,), numericos y espacios.");
                this.load_ErrorProviderProducto = true;
            }
            else if (this.TBProductoInformacion.Text.Length > 200)
            {
                errorProvider1.SetError(this.TBProductoInformacion, "El campo Informacion supera la cantidad de caracteres(200) posibles.");
                this.load_ErrorProviderProducto = true;
            }
            else
            {
                errorProvider1.SetError(this.TBProductoInformacion, "");
            }
        }

        // Evento para el textbox precio.         
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

        private void BTLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarProdcto();
            this.limpiarProveedor();
        } 

        public void limpiarProdcto() 
        {
            // Producto.
            this.CBProducto.SelectedIndex = -1;
            this.CBProducto.Text = "";

            this.TBProductoSku.Text = "";
            this.TBProductoCantidad.Text = "";
            this.TBProductoPrecio.Text = "";
            this.TBProductoInformacion.Text = "";

            this.CBProducto.Enabled = true;
            this.BTNBuscarSku.Enabled = true;


            this.errorProvider1.SetError(this.TBProductoSku, "");
            this.errorProvider1.SetError(this.TBProductoCantidad, "");
            this.errorProvider1.SetError(this.TBProductoPrecio, "");
            this.errorProvider1.SetError(this.TBProductoInformacion, "");
        }

        public void limpiarProveedor() 
        {
            // Proveedor.
            this.CBProveedor.SelectedIndex = -1;
            this.CBProveedor.Text = "";

            this.TBProveedorCuit.Text = "";

            this.CBProveedor.Enabled = true;
            this.BTNBuscarCuit.Enabled = true;

            this.errorProvider1.SetError(this.TBProveedorCuit, ""); 
        }

        // Funcionalidad tabla
        private void BTAgregarProducto_Click(object sender, EventArgs e)
        { 
            this.load_ErrorProviderProducto = false;

            this.ValidateChildren();
            this.errorProvider1.SetError(TBProveedorCuit, "");

            if (this.load_ErrorProviderProducto) 
            {
                return;
            }

            Detalle_compra item = new Detalle_compra();
            item.producto = producto_seleccionado;
            item.subtotal_producto = Convert.ToDecimal(this.TBProductoPrecio.Text);
            item.cantidad_producto = Convert.ToInt16(this.TBProductoCantidad.Text);
            item.informacion_acerca = this.TBProductoInformacion.Text;
             
            carrito.Add(item);

            this.loadDGVCarrito();
            this.limpiarProdcto();
            this.producto_seleccionado = null;
        }
         
        public object TableCarrito(List<Detalle_compra> _lista)
        {
            var tabla = _lista.Select((item, index) => new
            {  
                Indice = index + 1,
                Id_producto = item.producto.id_producto,
                Sku = string.IsNullOrEmpty(item.producto.sku_producto)? "-" : item.producto.sku_producto,
                Producto = item.producto.producto_completo,
                Informacion = item.informacion_acerca,
                Cantidad = item.cantidad_producto,
                Precio =  item.subtotal_producto, 
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        public void loadDGVCarrito()
        { 
            this.DGVCompra.DataSource = null;
            this.DGVCompra.Columns.Clear();
            this.DGVCompra.Rows.Clear(); 

            this.DGVCompra.DataSource = this.TableCarrito(this.carrito);
             
            this.DGVCompra.Columns["Id_producto"].Visible = false; 

            DataGridViewButtonColumn btnColumnBorrar = new DataGridViewButtonColumn();
            btnColumnBorrar.Name = "CBorrar";
            btnColumnBorrar.HeaderText = "Borrar";
            btnColumnBorrar.Text = "Borrar";
            btnColumnBorrar.UseColumnTextForButtonValue = true;
            btnColumnBorrar.FlatStyle = FlatStyle.Standard;
            this.DGVCompra.Columns.Add(btnColumnBorrar);
            this.DGVCompra.Columns["CBorrar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.DGVCompra.Columns["CBorrar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;  
        }

        private void DGVCompra_DataSourceChanged(object sender, EventArgs e)
        {
            decimal total = this.calcularTotalCarrito();

            this.LTotal.Text = total == 0 ? "Total: $ - - -" : "Total: $" + Convert.ToString(total);  
        }

        public decimal calcularTotalCarrito() 
        {
            decimal total = 0;

            if (this.carrito.Count > 0)
            {
                foreach (Detalle_compra item in this.carrito)
                {
                    total = total + item.subtotal_producto;
                }
            }

            return total;
        }

        private void DGVPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CBorrar")
            {
                DialogResult confirmacionBorrar = MessageBox.Show(
                        "¿Seguro que deseas eliminar este producto del carrito?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionBorrar == DialogResult.Yes)
                {
                    carrito.RemoveAt(e.RowIndex);
                    this.loadDGVCarrito();
                }
            }
        }
          
        // Evento Registar Compra
        private void BTRegistrarCompra_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderProveedor = false; 

            this.ValidateChildren();
            this.limpiarProdcto();

            if(load_ErrorProviderProveedor)
            {
                return;
            }

            if(this.carrito.Count == 0)
            {
                MessageBox.Show("El carrito se encuentra vacio, cargue productos para realizar la compra.", "Carrito Vacio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
             
            try
            { 
                CN_Compra compra = new CN_Compra();

                Compra  nuevaCompra = new Compra();
                nuevaCompra.fecha_confirmacion = DateTime.Now.Date;
                nuevaCompra.proveedor = this.proveedor_seleccionado;
                nuevaCompra.detalles_compra = this.carrito; 
                nuevaCompra.monto_total = compra.CalcularMontoTotal(nuevaCompra.detalles_compra);
                   
                int resultadoCompra = compra.RegistrarCompra(nuevaCompra);

                if (resultadoCompra > 0)
                {
                    MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limpiarProdcto();
                    this.limpiarProveedor();
                    this.carrito.Clear();
                    this.loadDGVCarrito();
                    this.proveedor_seleccionado = null;
                    return;
                } 
                else
                {  
                    // this.mostrarErrores(compra.GetErrors());
                    MessageBox.Show("Ha ocurrido un error durante el proceso, no se pudo registrar la compra.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
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
    }
}
