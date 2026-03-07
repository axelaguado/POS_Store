using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{   
    public partial class GestionPedido : Form, IConfigForm
    {

        // Internal: El tipo o miembro es accesible solo dentro del mismo ensamblado (proyecto).
        // Partial: Permite dividir la definición de una misma clase en varios archivos.

        public Principal principal;
        private List<ItemCarrito> articulos;
        private Dictionary<string, string> validacion;

        public GestionPedido(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.articulos = new List<ItemCarrito>();
            this.validacion = new Dictionary<string, string>();
            this.cargarPanelPedido(); 
            this.loadPedidoPendientes();
            this.loadPedidoConfirmados();
        }

        public void cargarPanelPedido()
        {    
            CBPiso.Items.Add("PB");
            for (int i = 0; i < 100; i++)
            {
                    CBPiso.Items.Add(i + 1);
                    CBDepto.Items.Add(i + 1);
            }  

            LArticulo.ForeColor = System.Drawing.Color.Gray;
            PArticulo.Hide();
        }

        public void CentrarPanelesPrincipales()
        {
            this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPedidosConfirmados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            PGestionPedidos.Left = (this.ClientSize.Width - PGestionPedidos.Width) / 2;  
        } 

        public void MantenerPanelesPrincipales()
        { 
            this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVPedidosConfirmados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
             
        } 

        private void LProveedor_Click(object sender, EventArgs e)
        {
            PArticulo.Hide();
            PProveedor.Show();

            LArticulo.ForeColor = System.Drawing.Color.Gray;  
            LProveedor.ForeColor = System.Drawing.Color.White;
        }

        private void LArticulo_Click(object sender, EventArgs e)
        {
            PProveedor.Hide();
            PArticulo.Show();

            LProveedor.ForeColor = System.Drawing.Color.Gray;
            LArticulo.ForeColor = System.Drawing.Color.White;
        }

        private void restaurarControlsPArticulo()
        {
            this.TBMarca.Text = string.Empty;
            this.TBNombreArticulo.Text = string.Empty;
            this.TBDescripcion.Text = string.Empty;
            this.TBContenido.Text = string.Empty;
            this.TBPrecio.Text = string.Empty;
            this.TBCantidad.Text = string.Empty; 
        }

        private void restaurarControlsPProveedor()
        {
            this.CBRazonSocial.SelectedIndex = -1;
            
            this.TBNombreComercial.Text = string.Empty;
            this.TBCuit.Text = string.Empty;
            this.TBTelefono.Text = string.Empty;
            this.TBEmail.Text = string.Empty;
            this.TBSitioWeb.Text = string.Empty;
            this.TBCalle.Text = string.Empty;
            this.TBAltura.Text = string.Empty;
            this.TBCodPostal.Text = string.Empty;

            CHKBDepto.Checked = true; 

            CBPiso.SelectedIndex = -1; 
            CBDepto.SelectedIndex = -1; 
        }

        private void ClearTablaPedido()
        {     
            this.articulos.Clear();
            this.loadArticulo();
            
        }

        public object LoadTablePedido(List<ItemCarrito> _lista) 
        {  
            var tabla = _lista.Select((articulo, index) => new
            {
                Indice = index + 1,
                Marca = articulo.marca_articulo,
                Nombre = articulo.nombre_articulo,
                Descripcion = articulo.descripcion_articulo,
                Contenido = articulo.contenido_articulo,
                PrecioUnitario = articulo.precio_unitario,
                Cantidad = articulo.cantidad,
                Subtotal = (articulo.precio_unitario * articulo.cantidad )
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  
             
            return tabla;
        } 

        public void loadArticulo() 
        {
            this.DGVPedido.DataSource = null;
            this.DGVPedido.Columns.Clear();
            this.DGVPedido.Rows.Clear(); 

            this.DGVPedido.DataSource = LoadTablePedido(articulos);

            DataGridViewButtonColumn btnColumnBorrar = new DataGridViewButtonColumn();
            btnColumnBorrar.Name = "CBorrar";
            btnColumnBorrar.HeaderText = "Borrar";
            btnColumnBorrar.Text = "Borrar";
            btnColumnBorrar.UseColumnTextForButtonValue = true;
            btnColumnBorrar.FlatStyle = FlatStyle.Standard;
            this.DGVPedido.Columns.Add(btnColumnBorrar);
            this.DGVPedido.Columns["CBorrar"].HeaderCell.Style.BackColor = Color.Red;
            this.DGVPedido.Columns["CBorrar"].HeaderCell.Style.SelectionBackColor = Color.Red;
        }
         
        private void BTAgregarArticulo_Click(object sender, EventArgs e)
        { 

            if(this.ValidateChildren()) 
            {  
                ItemCarrito articulo = new ItemCarrito();

                articulo.marca_articulo = TBMarca.Text;
                articulo.nombre_articulo = TBNombreArticulo.Text;
                articulo.descripcion_articulo = TBDescripcion.Text;
                articulo.contenido_articulo = TBContenido.Text; 
                articulo.precio_unitario = Convert.ToDecimal(TBPrecio.Text);
                articulo.cantidad = Convert.ToInt16(TBCantidad.Text);  

                articulos.Add(articulo);

                this.loadArticulo();
            }
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
                        "¿Seguro que deseas borrar este usuario?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionBorrar == DialogResult.Yes)
                { 
                    articulos.RemoveAt(e.RowIndex); 
                    this.loadArticulo();
                }
            }
        }

        private void BTRegistrarPedido_Click(object sender, EventArgs e)
        {  
            CN_Pedido pedido = new CN_Pedido();
            CN_DetallePedido detalle = new CN_DetallePedido();
            CN_Proveedor proveedor = new CN_Proveedor();
            CN_Direccion direccion = new CN_Direccion();

            List<int> id_articulos = new List<int>();

             
            if (this.ValidateChildren()) 
            {
                // Cargamos la Direccion.
                Direccion nuevaDireccion = this.cargarDireccion(); 

                // Cargamos el Proveedor. 
                Proveedor nuevoProveedor = new Proveedor
                {
                    razon_social = CBRazonSocial.Text,
                    nombre_comercial = TBNombreComercial.Text,
                    CUIT = Convert.ToInt64(TBCuit.Text),
                    cod_postal = Convert.ToInt16(TBCodPostal.Text),
                    telefono = Convert.ToInt64(TBTelefono.Text),
                    email = TBEmail.Text,
                    sitio_web = TBSitioWeb.Text
                    // nuevoProveedor.id_direccion = 12;
                }; 

                // Cargamos el Pedido.
                // Es necesario conocer el monto total del carrito. 
                Pedido nuevoPedido = new Pedido
                {
                    // id_proveedor = id_nuevoProveedor;
                    fecha_emision = DateTime.Now,
                    monto_total = this.montoCarrito(),
                    estado = 1 // Estado pendiente
                };

                // Mapeamos los items del carrito a entidades articulos para poder validarlos.
                List<Articulo> itemsMapeados = this.MapearItems();

                // Cargamos cada detalle correspondiente a cada articulo.
                List<Detalle_pedido> detallesPedido = this.cargarDetallesPedido();

                // Ahora hay que validar toda la garcha esta.
                bool validacionDireccion = direccion.ValidarBool_Direccion(nuevaDireccion);
                bool validacionProveedor = proveedor.ValidarProveedor(nuevoProveedor);
                bool validacionPedido = pedido.ValidarPedido(nuevoPedido);
                bool validacionCarrito = this.ValidarCarrito(itemsMapeados);
                bool validacionDetalle = this.ValidarDetalles(detallesPedido);

                bool validacion = validacionDireccion && validacionProveedor && validacionPedido && validacionCarrito && validacionDetalle;

                if(!validacion)
                {
                    // Mostrar errores en el errorProvider. 
                    this.cargarErrores(proveedor.mostrarErrores());  
                    MessageBox.Show("No se pudo registrar el pedido, verifique los datos cargados nuevamente.");
                }
                else
                {
                    try
                    {
                        // Creamos la direccion y recuperamos el id para asociarla con el nuevo proveedor. 
                        int id_direccion = direccion.CrearDireccion(nuevaDireccion);

                        // Cargamos el id de la direccion en los datos del proveedor. Y recuperamos el id del proveedor, posterior a la creaciom.
                        nuevoProveedor.id_direccion = id_direccion;
                        int id_proveedor = proveedor.CrearProveedor(nuevoProveedor);  

                        // Cargamos el id del proveedor en el pedido, y volvemos a repetir la creacion y recupero de id.
                        nuevoPedido.id_proveedor = id_proveedor;
                        int id_pedido = pedido.CrearPedido(nuevoPedido);

                        // Ese id_pedido recuperado se lo debemos asignar a cada uno de los detalles. Pero antes creamos los articulos.
                        id_articulos = this.cargarArticuloID(itemsMapeados);

                        this.crearDetallesPedido(detallesPedido, id_articulos, id_pedido);

                        this.restaurarControlsPArticulo();
                        this.restaurarControlsPProveedor(); 
                        this.ClearTablaPedido();
                        MessageBox.Show("El pedido ha sido registrado correctamente.");

                    } 
                    catch (ArgumentException ex) 
                    {
                        MessageBox.Show("Error de validacion: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else 
            {
                MessageBox.Show("Ha ocurrido un error y no se puede registrar el pedido, vrifique los datos proporcionados");
            }

        }

        public void cargarErrores(Dictionary<string, string> validacion)
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

        private void crearDetallesPedido(List<Detalle_pedido> _detallesPedido, List<int> id_articulos,int id_pedido) 
        {
            int i = 0;
            CN_DetallePedido detalle = new CN_DetallePedido();

            foreach (Detalle_pedido item in _detallesPedido) 
            { 
                item.id_pedido = id_pedido;
                item.id_articulo = id_articulos[i];
                detalle.CrearDetalle(item);
                i ++; 
                // falta crear el pedido jijooo.
            }
        }  

        public List<Detalle_pedido> cargarDetallesPedido() 
        {
            List<Detalle_pedido> detallesCargados = new List<Detalle_pedido>();

            foreach (ItemCarrito item in articulos)
            {
                Detalle_pedido detalle = new Detalle_pedido 
                {
                    cantidad = item.cantidad  
                };

                detallesCargados.Add(detalle);
            }
             
            return detallesCargados;    
        }

        public Direccion cargarDireccion() 
        {
            // Cargamos la Direccion.
            if (this.CHKBDepto.Checked == true)
            {
                Direccion nuevaDireccion = new Direccion
                {
                    // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                    calle = TBCalle.Text,
                    altura = Convert.ToInt16(TBAltura.Text),
                    piso = CBPiso.Text,
                    depto = Convert.ToInt16(CBDepto.Text)
                };

                return nuevaDireccion;
            }
            else
            {
                Direccion nuevaDireccion = new Direccion
                {
                    // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                    calle = TBCalle.Text,
                    altura = Convert.ToInt16(TBAltura.Text),
                };

                return nuevaDireccion;
            } 
        }

        public decimal montoCarrito() 
        {
            decimal monto_pedido = 0;

            if(this.articulos.Count > 0) 
            {
                foreach (ItemCarrito item in this.articulos)
                {
                    monto_pedido = monto_pedido + (item.precio_unitario * item.cantidad); 
                } 

                return monto_pedido;
            }

            return monto_pedido;        
        } 
         
        private List<Articulo> MapearItems() 
        {
            List<Articulo> articulosMapeados = new List<Articulo>();    

            foreach (ItemCarrito item in articulos)
            {
                Articulo articulo = new Articulo
                {
                    marca_articulo = item.marca_articulo,
                    nombre_articulo = item.nombre_articulo,
                    descripcion_articulo = item.descripcion_articulo,
                    contenido_articulo = item.contenido_articulo,
                    precio_unitario = item.precio_unitario
                };

                articulosMapeados.Add(articulo); 
            }

            return articulosMapeados; 
        }

        private List<int> cargarArticuloID(List<Articulo> _articulos)
        {
            CN_Articulo negocioArticulo = new CN_Articulo();
            List<int> id_articulos = new List<int>();

            foreach (Articulo item in _articulos)
            {
                id_articulos.Add(negocioArticulo.CrearArticulo(item));
            }

            return id_articulos;
        }

        private bool ValidarCarrito(List<Articulo> _articulos) 
        {
            CN_Articulo articulo = new CN_Articulo();   

            foreach (Articulo item in _articulos) 
            {
                if (!articulo.validarArticulo(item)) 
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidarDetalles(List<Detalle_pedido> _detallesPedido)
        {
            CN_DetallePedido detallePeiddo = new CN_DetallePedido();

            foreach (Detalle_pedido item in _detallesPedido)
            {
                if (!detallePeiddo.validarDetalle(item))
                {
                    return false;
                }
            }

            return true;
        }

        // Debemos realizar las validaciones de los controles asociados a proveedor, pedido, detalle y articulo. 
        // Validaciones para el Panel articulo.

        private void TBMarca_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBMarca.Text))
            {
                errorProvider1.SetError(this.TBMarca, "El campo Marca no puede estar vacio.");
                e.Cancel = true;
            } 
            else
            {
                errorProvider1.SetError(this.TBMarca, "");
            }

        }

        private void TBNombreArticulo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNombreArticulo.Text))
            {
                errorProvider1.SetError(this.TBNombreArticulo, "El campo Nombre no puede estar vacio.");
            }
            else
            {
                errorProvider1.SetError(this.TBNombreArticulo, "");
            }

        }

        private void TBContenido_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBContenido.Text))
            {
                errorProvider1.SetError(this.TBContenido, "El campo Contenido no puede estar vacio.");
            } 
            else
            {
                errorProvider1.SetError(this.TBContenido, "");
            }

        }

        private void TBPrecio_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBPrecio.Text)) 
            {
                errorProvider1.SetError(this.TBPrecio, "El campo Precio no puede estar vacio.");
            }
            else if (!decimal.TryParse(this.TBPrecio.Text, out _)) 
            {
                errorProvider1.SetError(this.TBPrecio, "El campo Precio debe contener un valor numerico.");
            }
            else 
            {
                errorProvider1.SetError(this.TBPrecio, "");
            }

        }

        private void TBCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBCantidad.Text))
            {
                errorProvider1.SetError(this.TBPrecio, "El campo Cantidad no puede estar vacio.");
            }
            else if (!int.TryParse(this.TBCantidad.Text, out _))
            {
                errorProvider1.SetError(this.TBCantidad, "El campo Cantidad debe contener un valor numerico.");
            }
            else
            {
                errorProvider1.SetError(this.TBCantidad, "");
            }
        }

        // Validaciones para el panel Proveedor.

        //Direccion 
        // Y manejamos el checkbox Departamento.
        protected void CBDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKBDepto.Checked == true)
            {
                CBDepto.Enabled = true;
                errorProvider1.SetError(CBDepto, "Debe seleccionar el departamento");

                CBPiso.Enabled = true;
                errorProvider1.SetError(CBPiso, "Debe seleccionar el piso");
            }
            else
            {
                CBDepto.Enabled = false;
                CBDepto.SelectedIndex = -1;
                errorProvider1.SetError(CBDepto, "");

                CBPiso.Enabled = false;
                CBPiso.SelectedIndex = -1;
                errorProvider1.SetError(CBPiso, "");
            }
        }


        protected void TBCalle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBCalle.Text))
            {
                errorProvider1.SetError(TBCalle, "El campo Calle no puede estar vacio.");

            } 
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBCalle.Text, @"^[a-zA-Z0-9.\s]+$"))
            {
                errorProvider1.SetError(TBCalle, "El campo solo debe contener caracteres alfabeticos-numericos-puntos y espacios (exceptuando la 'ñ').");
            }
            else
            {
                errorProvider1.SetError(TBCalle, "");
            }

        }

        protected void TBAltura_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBAltura.Text))
            {
                errorProvider1.SetError(TBAltura, "Este campo es obligatorio.");

            }
            else if (!int.TryParse(TBAltura.Text, out _))
            {
                errorProvider1.SetError(TBAltura, "El campo solo debe contener caracteres numericos.");
            }
            else
            {
                errorProvider1.SetError(TBAltura, "");
            }
        }

        protected void CBPiso_Validating(object sender, CancelEventArgs e)
        {
            if (this.CBPiso.Enabled == true)
            {

                if (CBPiso.SelectedIndex == -1)
                {
                    errorProvider1.SetError(CBPiso, "Seleccione el numero de piso.");
                }
                else
                {
                    errorProvider1.SetError(CBPiso, "");
                }

            }
            else
            {
                errorProvider1.SetError(CBPiso, "");
            }
        }

        protected void CBDepto_Validating(object sender, CancelEventArgs e)
        {

            if (this.CBDepto.Enabled == true)
            {

                if (this.CBDepto.SelectedIndex == -1)
                {
                    errorProvider1.SetError(CBDepto, "Seleccione el numero de departamento.");
                }
                else
                {
                    errorProvider1.SetError(CBDepto, "");
                }

            }
            else
            {
                errorProvider1.SetError(CBDepto, "");
            }

        }
        
        // Proveedor
        private void CBRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if(!System.Text.RegularExpressions.Regex.IsMatch(this.CBRazonSocial.Text, @"^[a-zA-Z0-9._%+\-\s]+$")) 
            {
                errorProvider1.SetError(CBRazonSocial, "El campo Razon Social solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
            }
            else  
            {
                errorProvider1.SetError(CBRazonSocial, "");
            }
        }

        private void TBNombreComercial_Validating(object sender, CancelEventArgs e)
        {
            // Validaciones para campo Nombre Comercial. 
            if (string.IsNullOrEmpty(TBNombreComercial.Text))
            {
                 errorProvider1.SetError(TBNombreComercial, "El campo Nombre Comercial no puede estar vacio.");  
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNombreComercial.Text, @"^[a-zA-Z0-9._%+\-\s]+$")) 
            {
                errorProvider1.SetError(TBNombreComercial, "El campo Razon Social solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
            }
        }

        private void TBCuit_Validating(object sender, CancelEventArgs e)
        {
            /*
             * Aca podemos observar como podriamos utilizar el sender (control que produce el evento) para un algoritmo mas dinamico.
                System.Windows.Forms.Control control = sender as System.Windows.Forms.TextBox;
                errorProvider1.SetError(control, "El campo CUIT solo puede contener valores numericos");
            */

            if (!long.TryParse(TBCuit.Text, out _))
            {
                errorProvider1.SetError(TBCuit, "El campo CUIT solo puede contener valores numericos");
            }
            else if (Convert.ToInt64(TBCuit.Text) > 999999999999)
            {
                errorProvider1.SetError(TBCuit, "El campo CUIT solo puede contener 11 cifras");
            }
            else
            {
                errorProvider1.SetError(TBCuit, "");
            }
        }

        protected void TBTelefono_Validating(object sender, CancelEventArgs e)
        {
            
            if (!long.TryParse(TBTelefono.Text, out _))
            {
                errorProvider1.SetError(TBTelefono, "El campo solo debe contener caracteres numericos.");
            }
            else
            {
                errorProvider1.SetError(TBTelefono, "");
            }
        }

        protected void TBEmail_Validating(object sender, CancelEventArgs e)
        { 
            if (!System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(TBEmail, "La direccion email no cumple con el formato.(direccion@example.com)");
            }
            else
            {
                errorProvider1.SetError(TBEmail, "");
            }
        } 

        private void TBSitioWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(TBSitioWeb.Text, @"www\.[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"))
            {
                errorProvider1.SetError(TBSitioWeb, "El Sitio Web ingresado no tiene un formato estandar de dominio (www.example.com).");
            }
            else 
            {
                errorProvider1.SetError(TBSitioWeb, "");
            }
        }

        private void TBCodPostal_Validating(object sender, CancelEventArgs e)
        {
            // Validaciones para campo CodPostal. 
            if (string.IsNullOrEmpty(TBCodPostal.Text))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal no puede estar vacio.");
                 

            }
            else if (!int.TryParse(TBCodPostal.Text, out _))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal debe contener un valor numerico.");
                 
            }
            else if (Convert.ToDecimal(TBCodPostal.Text) > 9999) 
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal no puede tener mas de 4 cifras.");
                 
            }
            else 
            {
                errorProvider1.SetError(TBCodPostal, "");
            }
        }

        private void BTLimpiar_Click(object sender, EventArgs e)
        {
            this.restaurarControlsPProveedor();
            this.restaurarControlsPArticulo();
            this.ClearTablaPedido(); 
        }

        /*
        private void DGVPedidosPendientes_Resize(object sender, EventArgs e)
        {
            if(this.principal.WindowState == FormWindowState.Maximized)
            {
                this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                this.DGVPedidosConfirmados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (this.principal.WindowState == FormWindowState.Normal) 
            { 
                this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.DGVPedidosConfirmados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
           
        } 
        */ 

        // Tabla Pedidos Pendientes.
        public object LoadTablePedidosPendientesConfirmados(List<Pedido> _pedidos)
        {
            var tabla = _pedidos.Select((pedido, index) => new
            { 
                NroPedido = pedido.id_pedido,
                Proveedor = pedido.proveedor.nombre_comercial,
                Monto = pedido.monto_total 
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
        }

        public void loadPedidoPendientes()
        {
            CN_Pedido pendientes = new CN_Pedido();
            List<Pedido> _listaPendientes = new List<Pedido>(); 

            this.DGVPedidosPendientes.DataSource = null;
            this.DGVPedidosPendientes.Columns.Clear();
            this.DGVPedidosPendientes.Rows.Clear();

            _listaPendientes = pendientes.PedidosPendientes(); 

            this.DGVPedidosPendientes.DataSource = LoadTablePedidosPendientesConfirmados(_listaPendientes);

            DataGridViewButtonColumn btnColumnDetalles = new DataGridViewButtonColumn();
            btnColumnDetalles.Name = "CDetalles";
            btnColumnDetalles.HeaderText = "Detalles";
            btnColumnDetalles.Text = "Ver Detalles";
            btnColumnDetalles.UseColumnTextForButtonValue = true;
            btnColumnDetalles.FlatStyle = FlatStyle.Standard;
            this.DGVPedidosPendientes.Columns.Add(btnColumnDetalles);
            this.DGVPedidosPendientes.Columns["CDetalles"].HeaderCell.Style.BackColor = Color.LightBlue;
            this.DGVPedidosPendientes.Columns["CDetalles"].HeaderCell.Style.SelectionBackColor = Color.LightBlue;

            DataGridViewButtonColumn btnColumnRecibir = new DataGridViewButtonColumn();
            btnColumnRecibir.Name = "CRecibir";
            btnColumnRecibir.HeaderText = "Recibir";
            btnColumnRecibir.Text = "Recibir";
            btnColumnRecibir.UseColumnTextForButtonValue = true;
            btnColumnRecibir.FlatStyle = FlatStyle.Standard;
            this.DGVPedidosPendientes.Columns.Add(btnColumnRecibir);
            this.DGVPedidosPendientes.Columns["CRecibir"].HeaderCell.Style.BackColor = Color.LightGreen;
            this.DGVPedidosPendientes.Columns["CRecibir"].HeaderCell.Style.SelectionBackColor = Color.LightGreen;

            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CCancelar";
            btnColumnCancelar.HeaderText = "Cancelar";
            btnColumnCancelar.Text = "Cancelar";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard; 
            this.DGVPedidosPendientes.Columns.Add(btnColumnCancelar);
            this.DGVPedidosPendientes.Columns["CCancelar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.DGVPedidosPendientes.Columns["CCancelar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;  
        }

        // Tabla Pedidos Confirmados.
        public void loadPedidoConfirmados()
        {
            CN_Pedido confirmados = new CN_Pedido();
            List<Pedido> _listaConfirmados = new List<Pedido>();

            this.DGVPedidosConfirmados.DataSource = null;
            this.DGVPedidosConfirmados.Columns.Clear();
            this.DGVPedidosConfirmados.Rows.Clear();

            _listaConfirmados = confirmados.PedidosConfirmados();

            this.DGVPedidosConfirmados.DataSource = LoadTablePedidosPendientesConfirmados(_listaConfirmados);

            DataGridViewButtonColumn btnColumnDetalles = new DataGridViewButtonColumn();
            btnColumnDetalles.Name = "CDetalles";
            btnColumnDetalles.HeaderText = "Detalles";
            btnColumnDetalles.Text = "Ver Detalles";
            btnColumnDetalles.UseColumnTextForButtonValue = true;
            btnColumnDetalles.FlatStyle = FlatStyle.Standard;
            this.DGVPedidosConfirmados.Columns.Add(btnColumnDetalles);
            this.DGVPedidosConfirmados.Columns["CDetalles"].HeaderCell.Style.BackColor = Color.LightBlue;
            this.DGVPedidosConfirmados.Columns["CDetalles"].HeaderCell.Style.SelectionBackColor = Color.LightBlue;  
        }

        // Evento CellClick para tratas las funcionalidades de los distintos botones
        private void DGVPedidosPendientesConfirmados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;
             
            CN_Pedido pedido = new CN_Pedido(); 

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CRecibir")
            {
                DialogResult confirmacionRecibir = MessageBox.Show(
                        "¿Seguro que deseas confirmar la recepcion de este pedido?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionRecibir == DialogResult.Yes)
                {
                    int id_pedido = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells["NroPedido"].Value);
                    pedido.ConfirmarPedido(id_pedido);
                    this.loadPedidoPendientes();
                    this.loadPedidoConfirmados();
                    MessageBox.Show("Se confirmo la recepcion de el pedido numero: " + id_pedido + ", correctamente", "Confirmacion de recepcion.", MessageBoxButtons.OK); 
                }
            }

            if (nombreColumna == "CCancelar")
            { 
                string mensaje = "A continuacion cancelara el pedido nro: " + dgt.Rows[e.RowIndex].Cells["NroPedido"].Value + ", por un monto de $" + dgt.Rows[e.RowIndex].Cells["Monto"].Value;

                DialogResult confirmacionCancelar = MessageBox.Show(mensaje +
                        " ¿Seguro que deseas cancelar este pedido?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionCancelar == DialogResult.Yes)
                {
                    int id_pedido = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells["NroPedido"].Value); 
                    pedido.CancelarPedido(id_pedido);
                    this.loadPedidoPendientes();
                    MessageBox.Show("El pedido numero: " + id_pedido + ", fue cancelado correctamente.", "Cancelacion de Pedido", MessageBoxButtons.OK);
                }
            }

            if (nombreColumna == "CDetalles")
            { 
                int id_pedido = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells["NroPedido"].Value);
                Pedido encontrado = pedido.BuscarPedido(id_pedido);

                if(encontrado != null){
                    Detalle detalle = new Detalle(encontrado);
                    detalle.Show(); 
                } 
                 
            }

        }

        /*
         *  this.DGVPedido = new System.Windows.Forms.DataGridView();
            this.dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
         * */


    }
}
