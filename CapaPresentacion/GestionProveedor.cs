using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionProveedor : Form , IConfigForm
    {
        private Proveedor proveedor_edit;
        private Principal principal;
        private CancellationTokenSource cts; 
        private bool load_errorProvider; 

        public GestionProveedor(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;    
            this.cts = new CancellationTokenSource();
            this.LoadTableProveedor();
            this.LoadInit();
            
            this.ConfigWindowState();
        } 

        // Configuraciones iniciales.
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

        public void LoadInit()
        {
            CBPiso.Items.Add("PB");
            for (int i = 0; i < 100; i++)
            {
                CBPiso.Items.Add(i + 1);
                CBDepto.Items.Add(i + 1);
            } 

            this.BTNActualizar.Hide();
            this.BTNActualizar.Enabled = false;
            this.BTNReestablecer.Hide();
            this.BTNReestablecer.Enabled = false;
        } 

        // Cargamos las emtidades.  
        public void cargarEntidades(PersonaJuridica _personaJuridica, Direccion _direccion, Contacto _contacto)
        {
            // Cargamos la Direccion.
            _direccion.cod_postal = Convert.ToInt16(TBCodPostal.Text);
            _direccion.calle = TBCalle.Text;
            _direccion.altura = Convert.ToInt16(TBAltura.Text);

            if (this.CHKBDepto.Checked == true)
            { 
                _direccion.piso = CBPiso.Text;
                _direccion.depto = Convert.ToInt16(CBDepto.Text); 
            } 

            // // Cargamos la Persona Juridica. 
            _personaJuridica.razon_social = TBRazonSocial.Text;
            _personaJuridica.nombre_comercial = TBNombreComercial.Text;
            _personaJuridica.cuit = Convert.ToInt64(TBCuit.Text);

            // Cargamos el Contacto. 
            _contacto.telefono = Convert.ToInt64(TBTelefono.Text);
            _contacto.email = TBEmail.Text;
            _contacto.sitio_web = TBSitioWeb.Text; 
        }

        // Botones limpiar / Reestablecer, Registrar / Actualizar.  
        private void BTRegistrarProveedor_Click(object sender, EventArgs e)
        {
            this.load_errorProvider = false; 

            if (this.ValidateChildren())
            {
                if (this.load_errorProvider)
                {
                    return;
                }
            }

            // Proveedor. 
            PersonaJuridica existentePersonaJuridica = new PersonaJuridica();
            PersonaJuridica nuevaPersonaJuridica = new PersonaJuridica();
            Contacto nuevoContacto = new Contacto();
            Direccion nuevaDireccion = new Direccion();

            this.cargarEntidades(nuevaPersonaJuridica, nuevaDireccion, nuevoContacto);

            try
            {  
                CN_Proveedor proveedor = new CN_Proveedor(); 
                CN_PersonaJuridica personaJuridica = new CN_PersonaJuridica();

                // Antes verificamos que no se encuentre en existencia los datos de la persona juridica (Recordemos que se puede encontrar un cliente ya registrado con los datos de dicha persona juridica)
                existentePersonaJuridica = personaJuridica.GetPersonaJuridica(nuevaPersonaJuridica.razon_social, nuevaPersonaJuridica.cuit);
                bool esCliente = existentePersonaJuridica?.persona?.clientes?.FirstOrDefault() != null;
                bool esProveedor = existentePersonaJuridica?.persona?.proveedores?.FirstOrDefault() != null; 

                if (esCliente && !esProveedor)
                {
                    DialogResult confirmacion = MessageBox.Show(
                      "Los datos correspondientes a la personeria juridica del Proveedor ya estan siendo utilizadas por un Cliente. Desea que tambien sea registrado como Proveedor?",
                      "Confirmación",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Warning
                      );

                    if (confirmacion == DialogResult.Yes)
                    {
                        int resultado = proveedor.CrearProveedorPersonaExistente(existentePersonaJuridica.id_persona);

                        if (resultado > 0)
                        {
                            this.LoadTableProveedor();
                            MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error, vuelva a interlo.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (esProveedor) 
                {
                    MessageBox.Show("El Proveedor ya ha sido registrado anteriormente.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    // Si no es cliente creamos todo de cero. 
                    Proveedor nuevoProveedor = proveedor.CrearProveedorCompleto(nuevaPersonaJuridica, nuevaDireccion, nuevoContacto);

                    if (nuevoProveedor != null)
                    {
                        this.LoadTableProveedor();
                        MessageBox.Show("Los datos han sido guardados correctamente.", "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.mostrarErrores(proveedor.GetErrors());
                        MessageBox.Show("Verififque que los datos suministrados sean correctos", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarControlesProveedor();
        }

        private void LimpiarControlesProveedor()
        { 
            this.TBRazonSocial.Text = string.Empty; 
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

        private void BTNReestablecer_Click(object sender, EventArgs e)
        {
            this.cargarPanelPJuridica(this.proveedor_edit.persona.persona_juridica);
            this.cargarPanelDireccion(this.proveedor_edit.persona.direcciones.FirstOrDefault());
            this.cargarPanelContacto(this.proveedor_edit.persona.contactos.FirstOrDefault());
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

        // Carga de DGV y Eventos.
        public void LoadTableProveedor()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            CN_Proveedor proveedor = new CN_Proveedor();
            List<ProveedorDTO> lista = proveedor.ObtenerProveedoresDTO();

            dataGridView1.DataSource = this.LoadTable(lista);

            // Si dejamos visible la columna esta se muestra como una especie de CheckBox --> interesante para ver eventos relacionados. 
            dataGridView1.Columns["Estado"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;

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

        public void LoadTableProveedor(List<ProveedorDTO> lista)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear(); 

            dataGridView1.DataSource = this.LoadTable(lista);

            dataGridView1.Columns["Estado"].Visible = false;
            dataGridView1.Columns["Id"].Visible = false;

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

        public object LoadTable(List<ProveedorDTO> _lista)
        {
            var tabla = _lista.Select((proveedor, index) => new
            {     
                Id = proveedor.id_proveedor, 
                Proveedor = proveedor.razon_social,
                Cuit = Convert.ToString(proveedor.cuit),
                Telefono = Convert.ToString(proveedor.telefono),
                Email = proveedor.email,
                SitioWeb = string.IsNullOrEmpty(proveedor.sitio_web)? "-" : proveedor.sitio_web,
                CodPostal = Convert.ToString(proveedor.cod_postal),
                Calle = proveedor.calle,
                Altura = Convert.ToString(proveedor.altura),
                // Piso = proveedor.piso == null ? "-" : proveedor.piso.ToString(),
                // Depto = proveedor.depto == 0 ? "-" : proveedor.depto.ToString(),
                Estado = proveedor.estado
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
            proveedor_edit = null;
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Obtenemos la identificaicon del cliente para realizar la busqueda
            int id = Convert.ToInt32(dgt.Rows[filaIndex].Cells["Id"].Value);

            CN_Proveedor proveedor = new CN_Proveedor();
            proveedor_edit = proveedor.ObtenerProveedor(id);
                       

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CEditar")
            {
                DialogResult confirmacionEditar = MessageBox.Show(
                    "¿Seguro que deseas editar este proveedor?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionEditar == DialogResult.Yes)
                { 
                    if (proveedor_edit != null)
                    {   
                        // cargamos los paneles con los datos correspondientes al cliente que corresponde con una persona juridica.
                        if (proveedor_edit.persona.persona_juridica != null)
                        { 
                            this.cargarPanelPJuridica(proveedor_edit.persona.persona_juridica);
                            this.cargarPanelDireccion(proveedor_edit.persona.direcciones.FirstOrDefault());
                            this.cargarPanelContacto(proveedor_edit.persona.contactos.FirstOrDefault());  
                        }

                        this.errorProvider1.Clear();

                        this.BTNRegistrarProveedor.Enabled = false;
                        this.BTNRegistrarProveedor.Hide();

                        this.BTNLimpiar.Enabled = false;
                        this.BTNLimpiar.Hide();

                        this.BTNActualizar.Show();
                        this.BTNActualizar.Enabled = true;

                        this.BTNReestablecer.Show();
                        this.BTNReestablecer.Enabled = true;
                    }
                    else
                    {
                            MessageBox.Show("No se ha encontrado el proveedor, vuelva a intentar.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    } 
                }
            }
            else if (nombreColumna == "CEstado")
            { 
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true ? "desactivar" : "activar";

                DialogResult confirmacionActivar = MessageBox.Show(
                    "¿Seguro que deseas " + estado_cambiar + " este proveedor?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes)
                {
                    try
                    {
                        proveedor_edit.estado_proveedor = !proveedor_edit.estado_proveedor;
                        string proveedorNombre = Convert.ToString(dgt.Rows[filaIndex].Cells["Proveedor"].Value);
                        Proveedor confirmacion = proveedor.UpdateProveedor(proveedor_edit);

                        if (confirmacion != null)
                        {
                            string nuevoEstado = confirmacion.estado_proveedor == true ? "activo." : "desactivado.";
                            MessageBox.Show("El proveedor " + proveedorNombre + " ha cambiado su estado a " + nuevoEstado, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LoadTableProveedor();
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

        private void BTNActualizar_Click(object sender, EventArgs e)
        {
            this.load_errorProvider = false;
            this.errorProvider1.Clear();

            if (this.ValidateChildren())
            {
                if (this.load_errorProvider)
                {
                    return;
                }
            }

            this.cargarEntidades(this.proveedor_edit.persona.persona_juridica, this.proveedor_edit.persona.direcciones.FirstOrDefault(), this.proveedor_edit.persona.contactos.FirstOrDefault()); 

            try
            {
                CN_Proveedor proveedor = new CN_Proveedor();

                int resultado = proveedor.ActualizarProveedorCompleto(this.proveedor_edit);

                if (resultado != 0)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente.", "Actualizado.", MessageBoxButtons.OK, MessageBoxIcon.Information); 

                    this.BTNActualizar.Hide();
                    this.BTNActualizar.Enabled = false;

                    this.BTNRegistrarProveedor.Enabled = true;
                    this.BTNRegistrarProveedor.Show();

                    this.BTNLimpiar.Enabled = true;
                    this.BTNLimpiar.Show();

                    this.LimpiarControlesProveedor();
                    this.LoadTableProveedor();
                }
                else
                {
                    this.mostrarErrores(proveedor.GetErrors());
                    MessageBox.Show("Ha ocurrido un error, verifique los datos suministrados.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public void cargarPanelPJuridica(PersonaJuridica _personaJuridica)
        {
            this.TBRazonSocial.Text = _personaJuridica.razon_social;
            this.TBNombreComercial.Text = _personaJuridica.nombre_comercial;
            this.TBCuit.Text = Convert.ToString(_personaJuridica.cuit);
        }

        public void cargarPanelDireccion(Direccion _direccion)
        {
            // Cargamos los datos de direccion.  
            this.TBCalle.Text = _direccion.calle;
            this.TBAltura.Text = Convert.ToString(_direccion.altura);
            this.TBCodPostal.Text = Convert.ToString(_direccion.cod_postal);

            // Preguntamos si hay un piso establecido para activar los botones 
            if (!string.IsNullOrEmpty(_direccion.piso))
            {
                // Indicamos que es departamento.
                this.CHKBDepto.Checked = true;

                //Asignamos el valor de los combobox piso y depto y eliminamos el mensaje del errorProvider
                this.CBPiso.Text = Convert.ToString(_direccion.piso);
                this.errorProvider1.SetError(CBPiso, "");

                this.CBDepto.Text = Convert.ToString(_direccion.depto);
                this.errorProvider1.SetError(CBDepto, "");
            }
            else 
            {
                this.CHKBDepto.Checked = false;
                this.CBPiso.SelectedIndex = -1;
                this.CBPiso.Enabled = false;
                this.errorProvider1.SetError(CBPiso, "");

                this.CBDepto.SelectedIndex = -1;
                this.CBDepto.Enabled = false;
                this.errorProvider1.SetError(CBDepto, "");
            }
        }

        public void cargarPanelContacto(Contacto _contacto)
        {
            this.TBEmail.Text = _contacto.email;
            this.TBSitioWeb.Text = _contacto.sitio_web;
            this.TBTelefono.Text = Convert.ToString(_contacto.telefono);
        }

        private void TBBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox.Text.Equals("Buscar por nombre o cuit ..."))
            {
                textBox.Text = "";
            }
        }
         
        private async void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            CN_Proveedor proveedor = new CN_Proveedor();
            List<ProveedorDTO> lista = new List<ProveedorDTO>();

            if (!string.IsNullOrWhiteSpace(this.TBBuscar.Text))
            {
                try
                {
                    if (int.TryParse(this.TBBuscar.Text, out _))
                    {
                        this.LoadTableProveedor(await proveedor.ObtenerProveedores(cts.Token, Convert.ToInt64(this.TBBuscar.Text)));
                    }
                    else 
                    {
                        this.LoadTableProveedor(await proveedor.ObtenerProveedores(cts.Token, this.TBBuscar.Text));
                    }
                         
                }
                catch (TaskCanceledException)
                {
                    // La consulta fue cancelada, no hacemos nada   
                }
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
            if (string.IsNullOrEmpty(TBRazonSocial.Text))
            {
                errorProvider1.SetError(TBRazonSocial, "El campo Razon Social no puede estar vacio.");
                this.load_errorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBRazonSocial.Text, @"^[a-zA-Z0-9._%+\-\s]+$"))
            {
                errorProvider1.SetError(TBRazonSocial, "El campo Razon Social solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                this.load_errorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBRazonSocial, "");
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

        private void CHKBDepto_CheckedChanged(object sender, EventArgs e)
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
    }
}
