using iTextSharp.tool.xml.css;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionVentas : Form
    {
        public Principal principal;

        public CancellationTokenSource cts;

        public Caja cajaOn;
        public bool state_caja;

        public bool load_ErrorProviderCobrar;

        public bool load_ErrorProviderCarrito;
        public List<Detalle_venta> carrito;

        public bool load_CBCliente;
        public bool load_ErrorProviderCliente;
        public Cliente cliente_seleccionado_venta;

        public GestionVentas(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.carrito = new List<Detalle_venta>();
            this.cajaOn = new Caja();
            this.cts = new CancellationTokenSource();
            this.LoadDetalleVentaProcesando();
            this.VerifyStateCaja();
            this.LoadCBCliente();
        }

        public void LoadDetalleVentaProcesando() 
        { 
            this.LDetalleFecha.Text = DateTime.Now.ToShortDateString();
            this.LDetalleEstado.ForeColor = Color.Yellow;
            this.LDetalleEstado.Text = "Procesando.";
        }

        public void LoadDetalleVentaFinalizado()
        {
            this.LDetalleFecha.Text = DateTime.Now.ToShortDateString();
            this.LDetalleEstado.Text = "Finalizada Correctamente.";
            this.LDetalleEstado.ForeColor = Color.Lime;
            this.LDetalleEstado.Font = new Font(LDetalleEstado.Font, FontStyle.Bold);
        }

        public void SetSuccesfulSale() 
        {
            // Debemos dejar cargados el Resumen con todos los detalles que teniamos de la venta y nuestro ultimo producto.
            this.loadResumen(this.carrito.Count - 1);

            // Debemos dejar cargado el cliente.
            string identificacion = cliente_seleccionado_venta.persona.persona_fisica != null ? $"{cliente_seleccionado_venta.persona.persona_fisica.dni_persona}" : $"{cliente_seleccionado_venta.persona.persona_juridica.cuit}";

            this.TBDniCuit.Text = identificacion;
            this.TBDniCuit.Enabled = false;
            this.BTNBuscarDniCuit.Enabled = false;

            // Los label extras.
            //  + " " + cliente_seleccionado_venta.persona.direcciones.Select(d => d.altura).FirstOrDefault() + "- " + cliente_seleccionado_venta.persona.direcciones.Select(d => d.cod_postal).FirstOrDefault();
            string direccion = cliente_seleccionado_venta.persona.direcciones.Select(d => d.calle).FirstOrDefault() + " " + cliente_seleccionado_venta.persona.direcciones.Select(d => d.altura).FirstOrDefault() + " - (" + cliente_seleccionado_venta.persona.direcciones.Select(d => d.cod_postal).FirstOrDefault() + ")";

            this.Telefono.Text = cliente_seleccionado_venta.persona.contactos.Select(c => c.telefono).FirstOrDefault().ToString();
            this.Direccion.Text = direccion;

            // Limpiamos el carrito.
            this.carrito.Clear();
            this.loadCarrito();

            // Actualizamos estado de venta.
            this.LoadDetalleVentaFinalizado();
        }


        public void VerifyStateCaja()
        {
            CN_Caja caja = new CN_Caja();

            try 
            {
                this.cajaOn = caja.GetActiveCaja(this.principal.GetIdSession());

                if (this.cajaOn != null) 
                { 
                    this.state_caja = true;
                    this.DisplayPanalCajaOn();
                }
                else 
                {
                    this.state_caja = false;
                    this.DisplayPanalCajaOff();
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

        // DGV y Eventos asociados al carrito.
        public object LoadTable(List<Detalle_venta> carrito) 
        { 
            var tabla = carrito.Select((detalle, index) => new
            {
                Codigo = detalle.producto.sku_producto,
                Producto = detalle.producto.producto_completo,
                Cantidad = detalle.cantidad_producto,
                PrecioU = "$" + detalle.precio_unitario,
                Subtotal = "$" + detalle.subtotal,
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
        }

        public void loadCarrito()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            this.dataGridView1.DataSource = LoadTable(this.carrito);
             
            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CBorrar";
            btnColumnCancelar.HeaderText = "Borrar";
            btnColumnCancelar.Text = "Borrar";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard;
            this.dataGridView1.Columns.Add(btnColumnCancelar);
            this.dataGridView1.Columns["CBorrar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.dataGridView1.Columns["CBorrar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;
        }

        private void BTNAddCarrito_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderCarrito = false;

            this.ValidateChildren();
            this.LimpiarEPCobrar();

            if (this.load_ErrorProviderCarrito) 
            {
                return;
            }

            CN_Producto producto = new CN_Producto();

            try 
            {
                // Vamos a verificar el stock antes.
                Producto productoCargar = producto.Get_ProductoSku(this.TBCodigoProducto.Text);
                
                if (productoCargar != null)
                {
                    // Esto esta funcionando pero obviamente seria modificado para cuando directamente apliquemos la clase Carrito.
                    Detalle_venta item = new Detalle_venta();
                    item.producto = productoCargar;
                    item.id_producto = productoCargar.id_producto;
                    item.cantidad_producto = Convert.ToInt32(this.NUDCantidad.Text);

                    // Realizamos una consullta al carrito para conocer si ya se encuentra un producto con dicho codigo en el carrito.
                    int indice = this.carrito.FindIndex(d => d.id_producto == item.id_producto);

                    if (indice > -1) 
                    {
                        int cantidad_verificar = this.carrito[indice].cantidad_producto + item.cantidad_producto;

                        if (cantidad_verificar > productoCargar.stock_producto) 
                        {
                            MessageBox.Show("El producto no cuenta con el stock suficiente.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        this.carrito[indice].cantidad_producto = this.carrito[indice].cantidad_producto + item.cantidad_producto;
                        this.carrito[indice].subtotal = this.carrito[indice].cantidad_producto * this.carrito[indice].precio_unitario;
                        this.loadResumen(indice);
                    }
                    else 
                    { 
                        item.precio_costo = productoCargar.precio_costo;
                        item.precio_unitario = productoCargar.precio_venta;
                        item.subtotal= item.cantidad_producto * item.precio_unitario;

                        if (item.cantidad_producto > productoCargar.stock_producto) 
                        {
                            MessageBox.Show("El producto no cuenta con el stock suficiente.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        this.carrito.Add(item); // En realidad en esta situacion el carrito deberia vereficar la preexistencia de un producto en el carrito y sumnar las cantidades
                        this.loadResumen(this.carrito.Count - 1);
                    }

                    this.loadCarrito();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    this.loadCarrito();
                }
            } 
        }

        public void loadResumen(int indice) 
        {
            this.LRProductosValue.Text = "" + this.carrito.Count;
            this.LRUnidadesValue.Text = "" + this.carrito.Sum(d => d.cantidad_producto);

            this.LRProducto.Text = this.carrito[indice].producto.producto_completo;

            this.LRCantidadValue.Text = "x" + this.carrito[indice].cantidad_producto;
            this.LRSubtotalValue.Text = "$" + this.carrito[indice].subtotal;

            this.LRTotalValue.Text = "$" + this.carrito.Sum(d => d.subtotal);  
        }

        public void LimpiarResumen()
        {
            this.LRProductosValue.Text = "0";
            this.LRUnidadesValue.Text = "0";

            this.LRProducto.Text = "@producto";

            this.LRCantidadValue.Text = "0";
            this.LRSubtotalValue.Text = "$ 00.000.000,00";

            this.LRTotalValue.Text = "$ 00.000.000,00";
        }

        // Botonera y sus respectivos eventos asociados.
        private void BTNCobrar_Click(object sender, EventArgs e)
        {
            this.load_ErrorProviderCobrar = false;
            this.ValidateChildren();
            this.LimpiarEPCarrito();

            if (this.load_ErrorProviderCobrar)
            {
                return;
            }

            // Cargamos la entidad venta.
            Venta nuevaVenta = new Venta();
            // nuevaVenta.id_venta = 0;
            nuevaVenta.fecha_venta = DateTime.Now;
            nuevaVenta.monto_venta = this.carrito.Sum(c => c.subtotal);
            nuevaVenta.detalles = this.carrito;

            nuevaVenta.id_caja = this.cajaOn.id_caja;
            nuevaVenta.caja = this.cajaOn;

            nuevaVenta.id_cliente = this.cliente_seleccionado_venta.id_cliente;
            nuevaVenta.cliente = this.cliente_seleccionado_venta;

            try
            {
                if (this.AbrirFormularioCobrar(nuevaVenta) == DialogResult.OK)
                {
                    // Seteamos todo para indicar que se registro la venta
                    // Podriamos imprimir el ticket
                    this.SetSuccesfulSale();
                    return;
                }

                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void BTNNuevaVenta_Click(object sender, EventArgs e)
        {
            // Limpiamos el carrito.
            this.carrito.Clear();
            this.loadCarrito();
            this.LimpiarPanelCarrito();

            // Limpiamos el cliente.
            this.LoadCBCliente();
            this.LimpiarPanelCliente();

            // Limpiamoms el Detalle.
            this.LoadDetalleVentaProcesando();

            // Limpiamos el sector del resumen.
            this.LimpiarResumen();

            // Limpiamos los EP para finalizar la venta
            this.LimpiarEPCobrar();
        }

        private void BTNMenosCantidad_Click(object sender, EventArgs e)
        {
            // Consultamos la cantidad de filas seleccionadas.
            if (dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }

            // Si hay una sola fila seleccionada obtenemos el id_producto de de la misma.
            DataGridViewRow fila = this.dataGridView1.SelectedRows[0];
            string sku_producto = Convert.ToString(fila.Cells["Codigo"].Value);

            // Una vez obtenido el id_producto lo buscamos en el carrito.
            int indice = this.carrito.FindIndex(d => d.producto.sku_producto == sku_producto);

            if (this.carrito[indice].cantidad_producto > 1)
            {
                this.carrito[indice].cantidad_producto = ((this.carrito[indice].cantidad_producto) - 1);
                this.carrito[indice].subtotal = this.carrito[indice].cantidad_producto * this.carrito[indice].precio_unitario;
            }

            // Funciona todo pero hacem falta algunas correcciones.
            this.loadResumen(indice);
            this.loadCarrito();

            // Seleccionamos nuevamente la fila sobre la cual se realizo la operacion.
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows[indice].Selected = true;

            return;
        }

        private void BTNMasCantidad_Click(object sender, EventArgs e)
        {
            // Consultamos la cantidad de filas seleccionadas.
            if (dataGridView1.SelectedRows.Count != 1)
            {
                return;
            }

            // Si hay una sola fila seleccionada obtenemos el id_producto de de la misma.
            DataGridViewRow fila = this.dataGridView1.SelectedRows[0];
            string sku_producto = Convert.ToString(fila.Cells["Codigo"].Value);

            // Traemos el producto para verificar stock
            CN_Producto producto = new CN_Producto();
            Producto productoCargar = producto.Get_ProductoSku(sku_producto);

            // Una vez obtenido el slu_producto lo buscamos en el carrito.
            int indice = this.carrito.FindIndex(d => d.producto.sku_producto == sku_producto);

            // Validamos ...
            if ((this.carrito[indice].cantidad_producto + 1) > productoCargar.stock_producto)
            {
                MessageBox.Show("El producto no cuenta con el stock suficiente.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.carrito[indice].cantidad_producto = ((this.carrito[indice].cantidad_producto) + 1);
            this.carrito[indice].subtotal = this.carrito[indice].cantidad_producto * this.carrito[indice].precio_unitario; 

            // Funciona todo pero hacem falta algunas correcciones.
            this.loadResumen(indice);
            this.loadCarrito();

            // Seleccionamos nuevamente la fila sobre la cual se realizo la operacion.
            this.dataGridView1.ClearSelection();
            this.dataGridView1.Rows[indice].Selected = true; 

            return;
        }

        private void BTNConsultarPrecio_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioConsultarPrecio();
        }

        private void BTNMovimientoCaja_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioMovimientoCaja();
        }


        private void BTNResumenCaja_Click(object sender, EventArgs e)
        {
            this.principal.AbrirFormHijo(new ResumenCaja(this.cajaOn.id_caja, this));
        }

        // Seccion Cliente
        public void LoadCBCliente()
        {
            CN_Cliente cliente = new CN_Cliente();
            List<Cliente> lista_cliente = cliente.AllClientes();

            this.CBCliente.ValueMember = "id_cliente";
            this.CBCliente.DisplayMember = "nombreCompleto_cliente";

            this.load_CBCliente = true;
            this.CBCliente.DataSource = lista_cliente;
            this.CBCliente.SelectedIndex = -1;
            this.load_CBCliente = false;
        }
        
        private void BTNBuscarDniCuit_Click(object sender, EventArgs e)
        {
            // Hay verificacion de validating Dni / Cuit?  --> Podria implementar una validanting al TB para no aceptar valores que no sean numericos.
            long.TryParse(this.TBDniCuit.Text, out long identificacion);

            CN_Cliente cliente = new CN_Cliente();
            Cliente clienteEncontrado = cliente.ObtenerCliente(identificacion);

            if (clienteEncontrado != null)
            {
                List<Cliente> lista = new List<Cliente>();
                lista.Add(clienteEncontrado);

                this.CBCliente.ValueMember = "id_cliente";
                this.CBCliente.DisplayMember = "nombreCompleto_cliente";
                this.CBCliente.DataSource = lista;
                this.CBCliente.Enabled = false;
            }
            else
            {
                this.CBCliente.SelectedIndex = -1;
                MessageBox.Show("El proveedor no existe o no esta disponible para esta operacion", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void CBCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si se esta cargando el combobox no ejecuto el evento.
            if (this.load_CBCliente)
            {
                return;
            }

            if (this.CBCliente.SelectedIndex == -1 && Convert.ToInt32(this.CBCliente.SelectedValue) < 1)
            {
                return;
            }

            cliente_seleccionado_venta = this.CBCliente.SelectedItem as Cliente;

            // Cargamos el cuit / dni identificador
            string identificacion = cliente_seleccionado_venta.persona.persona_fisica != null ? $"{cliente_seleccionado_venta.persona.persona_fisica.dni_persona}" : $"{cliente_seleccionado_venta.persona.persona_juridica.cuit}";

            this.TBDniCuit.Text = identificacion;
            this.TBDniCuit.Enabled = false;
            this.BTNBuscarDniCuit.Enabled = false;

            // Los label extras.
            //  + " " + cliente_seleccionado_venta.persona.direcciones.Select(d => d.altura).FirstOrDefault() + "- " + cliente_seleccionado_venta.persona.direcciones.Select(d => d.cod_postal).FirstOrDefault();
            string direccion = cliente_seleccionado_venta.persona.direcciones.Select(d => d.calle).FirstOrDefault() + " " + cliente_seleccionado_venta.persona.direcciones.Select(d => d.altura).FirstOrDefault() + " - (" + cliente_seleccionado_venta.persona.direcciones.Select(d => d.cod_postal).FirstOrDefault() + ")";

            this.Telefono.Text = cliente_seleccionado_venta.persona.contactos.Select(c => c.telefono).FirstOrDefault().ToString();
            this.Direccion.Text = direccion;
        }

        private async void CBCliente_TextChanged(object sender, EventArgs e)
        {
            // Si se esta cargando el combobox no ejecuto el evento.
            if (this.load_CBCliente)
            {
                return;
            }

            if (this.cliente_seleccionado_venta != null) 
            {
                this.cliente_seleccionado_venta = null;
                this.LimpiarPanelCliente();
            }

            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            string text = this.CBCliente.Text;

            CN_Cliente cliente = new CN_Cliente();

            try
            {
                if (!string.IsNullOrWhiteSpace(this.CBCliente.Text))
                {
                    // Falta this shittt
                    this.CargarCBCliente(await cliente.ObtenerClienteAsync(this.CBCliente.Text, cts.Token), text);
                }
                else
                {
                    this.LoadCBCliente();
                    this.TBDniCuit.Text = "";
                    this.TBDniCuit.Enabled = true;
                    this.BTNBuscarDniCuit.Enabled = true;
                }
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                List<Cliente> lista = new List<Cliente>();
                Cliente errorcliente = new Cliente();
                Persona persona = new Persona();
                PersonaJuridica pj = new PersonaJuridica();

                persona.persona_juridica = pj;  
                errorcliente.persona = persona;

                errorcliente.persona.persona_juridica.razon_social = "Ha ocurrido un error, vuelva a intentarlo";
                errorcliente.id_cliente = 0;

                lista.Add(errorcliente);

                this.load_CBCliente = true;
                this.CBCliente.DataSource = lista;
            }
            finally
            {
                this.load_CBCliente = false;
            }
        }

        public void CargarCBCliente(List<Cliente> _lista, string text)
        {  
            this.CBCliente.DropDownStyle = ComboBoxStyle.DropDown;

            this.CBCliente.ValueMember = "id_cliente";
            this.CBCliente.DisplayMember = "nombreCompleto_cliente";

            // Cuando escribo algo se muestar la lista
            if (_lista.Count > 0)
            {
                /*
                    Internamente pasa esto:

                    1. cambia DataSource
                    2. cambia Text
                    3. dispara TextChanged OTRA VEZ
                 */ 

                this.load_CBCliente = true;
                this.CBCliente.DataSource = _lista;
                this.CBCliente.SelectedIndex = -1;
                this.CBCliente.Text = text;
                this.CBCliente.SelectionStart = text.Length;
            }
            else
            {
                List<Cliente> lista = new List<Cliente>();
                Cliente sincliente = new Cliente();

                Persona persona = new Persona();
                PersonaJuridica pj = new PersonaJuridica();
                sincliente.persona = persona;
                sincliente.persona.persona_juridica = pj;

                sincliente.persona.persona_juridica.razon_social = "No se encontraron elementos.";
                sincliente.id_cliente = 0;

                // falta definir  en que momentos nullear el cliente seleccionado
                // _ Un caso obvio es cuando finaliza la venta pero faltan determinar mas situaciones.
                if (this.cliente_seleccionado_venta == null)
                {
                    lista.Add(sincliente);
                    this.load_CBCliente = true;
                    this.CBCliente.DataSource = lista;
                    this.CBCliente.SelectedIndex = -1;
                    this.CBCliente.Text = text;
                    this.CBCliente.SelectionStart = text.Length;
                }
                else
                {
                    lista.Add(cliente_seleccionado_venta);
                    this.load_CBCliente = true;
                    this.CBCliente.DataSource = lista;
                    this.CBCliente.SelectionStart = cliente_seleccionado_venta.nombreCompleto_cliente.Length;
                }
            } 
        }

        // Forms y pantallas emergentes.
        // Debe ser BTNAbrirCaja
        private void BTNAbrirCaja_Click(object sender, EventArgs e)
        {
            Form formBG = this.DisplayFormBackGround();

            AperturaCaja frm = this.DisplayFormAperturaCaja();

            formBG.Show();

            frm.Owner = formBG;
            DialogResult resultado = frm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                // Incializamos la caja

                // Dejamos visible el Panel para ventas.
                this.DisplayPanalCajaOn();
            }
            else
            {
                // Dejamos no visible el Panel para ventas.
                this.DisplayPanalCajaOff();
            }

            formBG.Dispose();
        }

        private void BTNCerrarCaja_Click(object sender, EventArgs e)
        {
            Form formBG = this.DisplayFormBackGround();

            CierreCaja frm = this.DisplayFormCierreCaja();

            formBG.Show();

            frm.Owner = formBG;
            DialogResult resultado = frm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                // Dejamos no visible el Panel para ventas.
                this.DisplayPanalCajaOff();
            }
            else
            {
                // Incializamos la caja

                // Dejamos visible el Panel para ventas.
                this.DisplayPanalCajaOn();
            }

            formBG.Dispose();
        }

        // Formularios para funcionalidades especificas
        public Form DisplayFormBackGround()
        {
            Rectangle area = this.principal.GetAreaPContenido();

            Form formBG = new Form();

            formBG.StartPosition = FormStartPosition.Manual;
            formBG.FormBorderStyle = FormBorderStyle.None;
            formBG.Opacity = 0.60;
            formBG.BackColor = Color.Black;

            formBG.Location = area.Location;
            formBG.Size = area.Size;

            formBG.ShowInTaskbar = false;
            formBG.TopMost = false;

            return formBG;
        }

        public AperturaCaja DisplayFormAperturaCaja() 
        {
            Rectangle area = this.principal.GetAreaPContenido();

            AperturaCaja frm = new AperturaCaja(this.principal.GetUsernameSession());

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                area.Left + (area.Width - frm.Width) / 2,
                area.Top + (area.Height - frm.Height) / 2
            );

            return frm;
        }

        public CierreCaja DisplayFormCierreCaja()
        {
            Rectangle area = this.principal.GetAreaPContenido();

            CierreCaja frm = new CierreCaja(this.cajaOn.id_caja);

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                area.Left + (area.Width - frm.Width) / 2,
                area.Top + (area.Height - frm.Height) / 2
            );

            return frm;
        }

        public ConsultarPrecio DisplayFormConsultarPrecio()
        {
            Rectangle area = this.principal.GetAreaPContenido();

            ConsultarPrecio frm = new ConsultarPrecio();

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                area.Left + (area.Width - frm.Width) / 2,
                area.Top + (area.Height - frm.Height) / 2
            );

            return frm;
        }

        public RegistrarPago DisplayFormRegistrarPago(Venta _venta) 
        {
            Rectangle area = this.principal.GetAreaPContenido();

            RegistrarPago frm = new RegistrarPago(_venta);

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                area.Left + (area.Width - frm.Width) / 2,
                area.Top + (area.Height - frm.Height) / 2
            );

            return frm;
        }

        public MovimientoCaja DisplayFormMovimientoCaja()
        {
            Rectangle area = this.principal.GetAreaPContenido();

            MovimientoCaja frm = new MovimientoCaja(this.cajaOn.id_caja);

            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                area.Left + (area.Width - frm.Width) / 2,
                area.Top + (area.Height - frm.Height) / 2
            );

            return frm;
        }

        public void AbrirFormularioConsultarPrecio() 
        {
            Form formBG = this.DisplayFormBackGround();

            ConsultarPrecio frm = this.DisplayFormConsultarPrecio();

            formBG.Show();

            frm.Owner = formBG;

            frm.ShowDialog();

            formBG.Dispose();
        }

        public void AbrirFormularioMovimientoCaja()
        {
            Form formBG = this.DisplayFormBackGround();

            MovimientoCaja frm = this.DisplayFormMovimientoCaja();

            formBG.Show();

            frm.Owner = formBG;

            frm.ShowDialog();

            formBG.Dispose();
        }

        public DialogResult AbrirFormularioCobrar(Venta _venta) 
        {
            DialogResult result = DialogResult.Cancel;  

            Form formBG = this.DisplayFormBackGround();

            // Para poder abrir el formulario de pago voy a tener que Cargar todos los elementos necesarios para la venta y proceder con una validacion de errorProvider.
            RegistrarPago frm = this.DisplayFormRegistrarPago(_venta);

            formBG.Show();
            frm.Owner = formBG;

            result = frm.ShowDialog();

            formBG.Dispose();

            return result;
        }

        // Paneles en funcion del estado de caja.
        public void DisplayPanalCajaOn()
        {
            this.tableLayoutPanel1.Visible = false;
            this.tableLayoutPanel2.Visible = true;
        }

        public void DisplayPanalCajaOff() 
        {
            this.tableLayoutPanel2.Visible = false;
            this.tableLayoutPanel1.Visible = true;
        } 

        // Validaciones.
        private void NUDCantidad_Validating(object sender, EventArgs e) 
        {
            if (string.IsNullOrEmpty(this.NUDCantidad.Text))
            {
                errorProvider1.SetError(this.NUDCantidad, "El campo Cantidad no puede estar vacio.");
                this.load_ErrorProviderCarrito = true;
            }
            else if (!int.TryParse(this.NUDCantidad.Text, out int cantidad))
            {
                errorProvider1.SetError(this.NUDCantidad, "El campo Cantidad debe contener un valor numerico entero.");
                this.load_ErrorProviderCarrito = true;
            }
            else if (cantidad < 1)
            {
                errorProvider1.SetError(this.NUDCantidad, "El campo Cantidad debe ser mayor a cero.");
                this.load_ErrorProviderCarrito = true;
            }
            else
            {
                errorProvider1.SetError(this.NUDCantidad, "");
            }

        }
        
        private void TBCodigoProducto_Validating(object sender, CancelEventArgs  e) 
        { 
            if (string.IsNullOrEmpty(this.TBCodigoProducto.Text))
            {
                errorProvider1.SetError(this.TBCodigoProducto, "El campo Codigo no puede quedar vacio.");
                this.load_ErrorProviderCarrito = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBCodigoProducto.Text, @"^[a-zA-Z0-9\-]+$"))
            {
                errorProvider1.SetError(this.TBCodigoProducto, "El campo Codigo solo puede contener caracteres alfabeticos y numericos.");
                this.load_ErrorProviderCarrito = true;
            }
            else
            {
                errorProvider1.SetError(this.TBCodigoProducto, "");
            }
        }

        private void CBCliente_Validating(object sender, CancelEventArgs e)
        {
            if (this.cliente_seleccionado_venta == null) 
            {
                this.errorProvider1.SetError(this.CBCliente, "Debe seleccionar un cliente.");
                this.load_ErrorProviderCobrar = true;
            }
            else 
            {
                this.errorProvider1.SetError(this.CBCliente, "");
            }
        }
        
        private void dataGridView1_Validating(object sender, CancelEventArgs e)
        {
            if (this.carrito.Count < 1) 
            {
                this.errorProvider1.SetError(this.BTNAddCarrito, "El carrito no puede estar vacio al momento de realizar una compra.");
                this.load_ErrorProviderCobrar = true;
            }
            else
            {
                this.errorProvider1.SetError(this.dataGridView1, "");
            }
        } 

        public void LimpiarPanelCliente() 
        {
            this.TBDniCuit.Text = string.Empty;
            this.TBDniCuit.Enabled = true;
            this.BTNBuscarDniCuit.Enabled = true;

            this.Telefono.Text = "-";
            this.Direccion.Text = "-";
        }

        public void LimpiarPanelCarrito() 
        {
            this.TBCodigoProducto.Text = string.Empty;
            this.NUDCantidad.Text = "1";
        }

        public void LimpiarEPCarrito() 
        {
            errorProvider1.SetError(this.TBCodigoProducto, "");
            errorProvider1.SetError(this.NUDCantidad, "");
        }

        public void LimpiarEPCobrar() 
        {
            errorProvider1.SetError(this.BTNAddCarrito, "");
            errorProvider1.SetError(this.CBCliente, "");
        } 
    }
}
