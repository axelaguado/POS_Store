using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
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
        private bool load_errorProvider;

        public GestionPedido(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.articulos = new List<ItemCarrito>();  
            this.cargarPanelPedido(); 
            this.loadPedidoPendientes();
            this.loadPedidoConfirmados();
            this.CargarCBRazonSocial();
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

            CHKBDepto.Checked = false; 

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

        public void CargarCBRazonSocial()
        {
            CN_Proveedor proveedor = new CN_Proveedor(); 
            this.CBRazonSocial.DataSource = proveedor.ObtenerProveedores(); 
            this.CBRazonSocial.DisplayMember = "razon_social";
            this.CBRazonSocial.ValueMember = "id_proveedor";

            this.CBRazonSocial.DropDownStyle = ComboBoxStyle.DropDown;
            this.CBRazonSocial.SelectedIndex = -1; 
        }

        private void CBRazonSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id_proveedor = 0;

            if (this.CBRazonSocial.ValueMember != string.Empty && this.CBRazonSocial.SelectedIndex != -1) 
            {  
                id_proveedor = Convert.ToInt64(this.CBRazonSocial.SelectedValue);
                MessageBox.Show("id_proveedor: " + id_proveedor);
            }

            CN_Proveedor proveedor = new CN_Proveedor();

            Proveedor encontrado = proveedor.ObtenerProveedor(id_proveedor);

            // Faltaria deshabilitar los controles. 
            if(encontrado != null) 
            {
                this.CBRazonSocial.Enabled = false;
                this.LRazonSocial.ForeColor = Color.Gray; 

                this.TBNombreComercial.Text = encontrado.persona.persona_juridica.nombre_comercial;
                this.LNombreComercial.ForeColor = Color.Gray;
                this.TBNombreComercial.Enabled = false;
                this.TBCuit.Text = Convert.ToString(encontrado.persona.persona_juridica.cuit);
                this.LCUIT.ForeColor = Color.Gray;
                this.TBCuit.Enabled = false;

                this.TBTelefono.Text = Convert.ToString(encontrado.persona.contactos.FirstOrDefault()?.telefono);
                this.LTelefono.ForeColor = Color.Gray;
                this.TBTelefono.Enabled = false;
                this.TBEmail.Text = Convert.ToString(encontrado.persona.contactos.FirstOrDefault()?.email == null ? "" : encontrado.persona.contactos.FirstOrDefault()?.email);
                this.LEmail.ForeColor = Color.Gray;
                this.TBEmail.Enabled = false;
                this.TBSitioWeb.Text = Convert.ToString(encontrado.persona.contactos.FirstOrDefault()?.sitio_web == null ? "" : encontrado.persona.contactos.FirstOrDefault()?.sitio_web);
                this.LSitioWeb.ForeColor = Color.Gray;
                this.TBSitioWeb.Enabled = false;

                this.TBCodPostal.Text = Convert.ToString(encontrado.persona.direcciones.FirstOrDefault()?.cod_postal);
                this.LCodPostal.ForeColor = Color.Gray;
                this.TBCodPostal.Enabled = false;
                this.TBCalle.Text = encontrado.persona.direcciones.FirstOrDefault()?.calle;
                this.LCalle.ForeColor = Color.Gray;
                this.TBCalle.Enabled = false;
                this.TBAltura.Text = Convert.ToString(encontrado.persona.direcciones.FirstOrDefault()?.altura);
                this.LAltura.ForeColor = Color.Gray;
                this.TBAltura.Enabled = false;

                this.CBDepto.Text = encontrado.persona.direcciones.FirstOrDefault()?.depto == 0 ? "" : Convert.ToString(encontrado.persona.direcciones.FirstOrDefault()?.depto);
                this.LDepto.ForeColor = Color.Gray;
                this.CBDepto.Enabled = false;
                this.CBPiso.Text = encontrado.persona.direcciones.FirstOrDefault()?.depto == null ? "" : encontrado.persona.direcciones.FirstOrDefault()?.piso;
                this.LPiso.ForeColor = Color.Gray;
                this.CBPiso.Enabled = false;

                this.LDepartamento.ForeColor = Color.Gray; 
                this.CHKBDepto.Enabled = false; 
            } 
        } 

        public void cargarEntidades(PersonaJuridica _personaJuridica, Direccion _direccion, Contacto _contacto, Pedido _pedido, List<Detalle_pedido> _detalle, List<Articulo> _items) 
        {
            // Cargamos la direccion.
            this.cargarDireccion(_direccion);

            // // Cargamos la Persona Juridica. 
            _personaJuridica.razon_social = CBRazonSocial.Text; 
            _personaJuridica.nombre_comercial = TBNombreComercial.Text;
            _personaJuridica.cuit = Convert.ToInt64(TBCuit.Text);

            // Cargamos el Contacto. 
            _contacto.telefono = Convert.ToInt64(TBTelefono.Text);
            _contacto.email = TBEmail.Text;
            _contacto.sitio_web = TBSitioWeb.Text;
             
            // Cargamos el Pedido. 
            _pedido.fecha_emision = DateTime.Now;
            _pedido.monto_total = this.montoCarrito();
            _pedido.estado = 2; // Estado pendiente 

            // Mapeamos los items del carrito a entidades articulos para poder validarlos.
            this.MapearItems(_items);

            // Cargamos cada detalle correspondiente a cada articulo.
            this.cargarDetallesPedido(_detalle); 
        }
         
        private void BTRegistrarPedido_Click(object sender, EventArgs e)
        {
            this.load_errorProvider = false;
            long id_proveedor = Convert.ToInt64(this.CBRazonSocial.SelectedValue);

            if (this.ValidateChildren())
            {
                if (this.load_errorProvider)
                {
                    return;
                }
            } 

            // Proveedor.
            PersonaJuridica nuevaPersonaFisica = new PersonaJuridica();
            Contacto nuevoContacto = new Contacto();
            Direccion nuevaDireccion = new Direccion();

            // Articulos.
            List<Articulo> items = new List<Articulo>(); 
            // Detalles.
            List<Detalle_pedido> detallesPedido = new List<Detalle_pedido>(); 
            // Pedido.
            Pedido nuevoPedido = new Pedido();

            this.cargarEntidades(nuevaPersonaFisica, nuevaDireccion, nuevoContacto, nuevoPedido, detallesPedido, items);

            try
            { 
                CN_Proveedor proveedor = new CN_Proveedor();
                CN_Pedido pedido = new CN_Pedido(); 

                Proveedor ProveedorCreado = proveedor.CrearProveedorCompleto(nuevaPersonaFisica, nuevaDireccion, nuevoContacto); 

                if (ProveedorCreado != null) 
                {
                    int resultadoPedido = pedido.CrearPedidoCompleto(ProveedorCreado, nuevoPedido, items, detallesPedido);

                    if (resultadoPedido != 0)

                    MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else
                {
                    this.mostrarErrores(proveedor.GetErrors());
                    this.mostrarErrores(pedido.GetErrors());
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

        public void cargarDetallesPedido(List<Detalle_pedido> _detalles) 
        { 

            foreach (ItemCarrito item in articulos)
            {
                Detalle_pedido detalle = new Detalle_pedido 
                {
                    cantidad = item.cantidad  
                };

                _detalles.Add(detalle);
            }
              
        }

        public void cargarDireccion(Direccion _direccion) 
        {
            // Cargamos la Direccion.
            if (this.CHKBDepto.Checked == true)
            { 
                // id_persona =  0, // Convert.ToInt32(validacionPersona["Exito"]),
                _direccion.cod_postal = Convert.ToInt16(TBCodPostal.Text);
                _direccion.calle = TBCalle.Text;
                _direccion.altura = Convert.ToInt16(TBAltura.Text);
                _direccion.piso = CBPiso.Text;
                _direccion.depto = Convert.ToInt16(CBDepto.Text);
                 
            }
            else
            {
                _direccion.cod_postal = Convert.ToInt16(TBCodPostal.Text);
                _direccion.calle = TBCalle.Text;
                _direccion.altura = Convert.ToInt16(TBAltura.Text);
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
         
        private void MapearItems(List<Articulo> _items) 
        { 
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

                _items.Add(articulo); 
            } 
        }
         
        // Debemos realizar las validaciones de los controles asociados a proveedor, pedido, detalle y articulo. 
        // Validaciones para el Panel articulo. 
        private void TBMarca_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBMarca.Text))
            {
                errorProvider1.SetError(this.TBMarca, "El campo Marca no puede estar vacio.");
                this.load_errorProvider = true;
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
                this.load_errorProvider = true;
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
                this.load_errorProvider = true;
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
                this.load_errorProvider = true;
            }
            else if (!decimal.TryParse(this.TBPrecio.Text, out _)) 
            {
                errorProvider1.SetError(this.TBPrecio, "El campo Precio debe contener un valor numerico.");
                this.load_errorProvider = true;
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
                errorProvider1.SetError(this.TBCantidad, "El campo Cantidad no puede estar vacio.");
                this.load_errorProvider = true;
            }
            else if (!int.TryParse(this.TBCantidad.Text, out _))
            {
                errorProvider1.SetError(this.TBCantidad, "El campo Cantidad debe contener un valor numerico.");
                this.load_errorProvider = true;
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
                this.load_errorProvider = true;

                CBPiso.Enabled = true;
                errorProvider1.SetError(CBPiso, "Debe seleccionar el piso");
                this.load_errorProvider = true;
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
                this.load_errorProvider = true; 
            } 
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBCalle.Text, @"^[a-zA-Z0-9.\s]+$"))
            {
                errorProvider1.SetError(TBCalle, "El campo solo debe contener caracteres alfabeticos-numericos-puntos y espacios (exceptuando la 'ñ').");
                this.load_errorProvider = true;
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
                this.load_errorProvider = true; 
            }
            else if (!int.TryParse(TBAltura.Text, out _))
            {
                errorProvider1.SetError(TBAltura, "El campo solo debe contener caracteres numericos.");
                this.load_errorProvider = true;
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
                    this.load_errorProvider = true;
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
                    this.load_errorProvider = true;
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
            if (string.IsNullOrEmpty(CBRazonSocial.Text))
            {
                errorProvider1.SetError(CBRazonSocial, "El campo Razon Social no puede estar vacio.");
                this.load_errorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.CBRazonSocial.Text, @"^[a-zA-Z0-9._%+\-\s]+$")) 
            {
                errorProvider1.SetError(CBRazonSocial, "El campo Razon Social solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                this.load_errorProvider = true;
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
                 this.load_errorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNombreComercial.Text, @"^[a-zA-Z0-9._%+\-\s]+$")) 
            {
                errorProvider1.SetError(TBNombreComercial, "El campo Nombre Comercial solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                this.load_errorProvider = true;
            }
            else 
            {
                errorProvider1.SetError(TBNombreComercial, "");  
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
                this.load_errorProvider = true;
            }
            else if (Convert.ToInt64(TBCuit.Text) > 999999999999)
            {
                errorProvider1.SetError(TBCuit, "El campo CUIT solo puede contener 11 cifras");
                this.load_errorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBCuit, "");
            }
        }

        protected void TBTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBTelefono.Text))
            {
                errorProvider1.SetError(TBTelefono, "El campo Telefono no puede estar vacio.");
                this.load_errorProvider = true;
            }
            else if (!long.TryParse(TBTelefono.Text, out _))
            {
                errorProvider1.SetError(TBTelefono, "El campo solo debe contener caracteres numericos.");
                this.load_errorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBTelefono, "");
            }
        }

        protected void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBEmail.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    errorProvider1.SetError(TBEmail, "La direccion email no cumple con el formato.(direccion@example.com)");
                    this.load_errorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBEmail, "");
                }
            }
            else
            {
                errorProvider1.SetError(TBEmail, "");
            }
        } 

        private void TBSitioWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBSitioWeb.Text)) 
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(TBSitioWeb.Text, @"www\.[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"))
                {
                    errorProvider1.SetError(TBSitioWeb, "El Sitio Web ingresado no tiene un formato estandar de dominio (www.example.com).");
                    this.load_errorProvider = true;
                }
                else 
                {
                    errorProvider1.SetError(TBSitioWeb, "");
                }
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
                this.load_errorProvider = true;
            }
            else if (!int.TryParse(TBCodPostal.Text, out _))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal debe contener un valor numerico.");
                this.load_errorProvider = true; 
            }
            else if (Convert.ToDecimal(TBCodPostal.Text) > 9999) 
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal no puede tener mas de 4 cifras.");
                this.load_errorProvider = true; 
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
        
        // Tabla Pedidos Pendientes.
        public object LoadTablePedidosPendientesConfirmados(List<Pedido> _pedidos)
        {
            var tabla = _pedidos.Select((pedido, index) => new
            { 
                NroPedido = pedido.id_pedido,
                Proveedor = pedido.proveedor.persona.persona_juridica.nombre_comercial,
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

                if(encontrado != null)
                {
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
         */
          
    }
}
