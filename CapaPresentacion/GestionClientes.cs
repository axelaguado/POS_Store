using iTextSharp.tool.xml.css;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Mapping;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
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
    public partial class GestionClientes : Form, IConfigForm
    {
        public Principal principal;
        public bool load_ErrorProvider;
        private Cliente cliente_editar;
        private CancellationTokenSource cts;
        public GestionClientes(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.cts = new CancellationTokenSource();
            this.LoadInit();
            this.ConfigWindowState();
        }

        private void LoadInit()
        {
            // Como el form se inicia mostrando el PDatosPFisica y hay cierto comportamiento con respecto a las validaciones
            // Establecemos 

            this.PDatosPJuridica.Enabled = false;

            // Controlamos el btn actualizar.
            this.BTNActualizar.Hide();
            this.BTNActualizar.Enabled = false;

            this.LoadTableClientes();
        }

        private void LPFisica_Click(object sender, EventArgs e)
        {
            this.PDatosPJuridica.Hide();
            this.PDatosPJuridica.Enabled = false;

            this.PDatosPFisica.Enabled = true;
            this.PDatosPFisica.Show();

            this.LPJuridica.ForeColor = System.Drawing.Color.Gray;
            this.LPFisica.ForeColor = System.Drawing.Color.White;
        }

        private void LPJuridica_Click(object sender, EventArgs e)
        {
            this.PDatosPFisica.Hide();
            this.PDatosPFisica.Enabled = false;

            this.PDatosPJuridica.Enabled = true;
            this.PDatosPJuridica.Show();

            this.LPFisica.ForeColor = System.Drawing.Color.Gray;
            this.LPJuridica.ForeColor = System.Drawing.Color.White;
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

        private void Registrar_Click(object sender, EventArgs e)
        {
            this.load_ErrorProvider = false;
            this.errorProvider1.Clear();

            if (this.ValidateChildren())
            {
                if (this.load_ErrorProvider)
                {
                    return;
                }
            }

            PersonaFisica personaFisica = null;
            PersonaJuridica personaJuridica = null;

            // Tenemos el mismo problema de que la variable que se carga en la funcion es una copia y no la que verdaderamente estamos enviando por eso 
            // permanece como null.
            if (this.PDatosPFisica.Enabled == true)
            {
                personaFisica = new PersonaFisica();
                this.CargarEntidadPFisica(personaFisica);
            }

            if (this.PDatosPJuridica.Enabled == true)
            {
                personaJuridica = new PersonaJuridica();
                this.CargarEntidadPJuridica(personaJuridica);
            }

            // Cargamos las entidades.
            Direccion direccion = new Direccion();
            Contacto contacto = new Contacto();
            this.CargarEntidadesCliente(contacto, direccion);

            // Validaciones y creacion de Cliente completo.
            try
            {
                CN_Cliente nuevoCliente = new CN_Cliente();

                int resultado = nuevoCliente.CrearClienteCompleto(personaFisica, personaJuridica, contacto, direccion);

                if (resultado > 0)
                {
                    MessageBox.Show("Los datos han sido guardados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadTableClientes();
                }
                else
                {
                    this.mostrarErrores(nuevoCliente.GetErrors());
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

        public void LoadTableClientes()
        {
            CN_Cliente cliente = new CN_Cliente();
            List<ClienteDTO> _lista = new List<ClienteDTO>();

            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            _lista = cliente.GetClientes();

            dataGridView1.DataSource = this.LoadTable(_lista);

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

        public void LoadTableClientes(List<ClienteDTO> lista)
        { 
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear(); 

            dataGridView1.DataSource = this.LoadTable(lista);

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
         
        public object LoadTable(List<ClienteDTO> _lista)
        {
            var tabla = _lista.Select((cliente, index) => new
            {
                Identificacion = cliente.identificacion,
                Cliente = cliente.cliente, 
                Telefono = cliente.telefono,
                Email = cliente.email,
                CodPostal = cliente.codPostal,
                Calle = cliente.calle,
                Altura = cliente.altura,
                Piso = cliente.piso == null ? "-" : cliente.piso.ToString(),
                Depto = cliente.depto == 0 ? "-" : cliente.depto.ToString(),
                Estado = cliente.estado  
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
            cliente_editar = null;
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;
             
            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Obtenemos la identificaicon del cliente para realizar la busqueda
            string identificacion = Convert.ToString(dgt.Rows[filaIndex].Cells["Identificacion"].Value); 
             
            CN_Cliente cliente = new CN_Cliente(); 

            if (identificacion.Length > 0 && identificacion.Length <= 8)
            {
                cliente_editar = cliente.GetClientePFisica(Convert.ToInt32(identificacion)); 
            } 

            if (identificacion.Length > 8) 
            {
                cliente_editar = cliente.GetClientePJuridica(Convert.ToInt64(identificacion));
            }  

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CEditar")
            {
                DialogResult confirmacionEditar = MessageBox.Show(
                    "¿Seguro que deseas editar este usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                 
                if (confirmacionEditar == DialogResult.Yes)
                {    
                    try
                    {
                        if (cliente_editar != null)
                        {    
                            // cargamos los paneles con los datos correspondientes al cliente que corresponde con una persona fisica.
                            if (cliente_editar.persona.persona_fisica != null) 
                            {
                                this.PDatosPJuridica.Hide();
                                this.PDatosPFisica.Show();

                                this.cargarPanelPFisica(cliente_editar.persona.persona_fisica);
                                this.cargarPanelDireccion(cliente_editar.persona.direcciones.FirstOrDefault());
                                this.cargarPanelContacto(cliente_editar.persona.contactos.FirstOrDefault()); 

                                this.LPJuridica.Enabled = false;
                            }   

                            // cargamos los paneles con los datos correspondientes al cliente que corresponde con una persona juridica.
                            if (cliente_editar.persona.persona_juridica != null) 
                            {
                                this.PDatosPFisica.Hide();
                                this.PDatosPJuridica.Show(); 

                                this.cargarPanelPJuridica(cliente_editar.persona.persona_juridica);
                                this.cargarPanelDireccion(cliente_editar.persona.direcciones.FirstOrDefault());
                                this.cargarPanelContacto(cliente_editar.persona.contactos.FirstOrDefault());

                                this.LPFisica.Enabled = false;
                            }   

                            this.BTNRegistrar.Enabled = false;  
                            this.BTNRegistrar.Hide();
                            this.BTNActualizar.Enabled = true;
                            this.BTNActualizar.Show(); 
                        }
                        else
                        {
                            MessageBox.Show("No se ha encontrado el cliente, vuelva a intentar.", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
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
            else if (nombreColumna == "CEstado")
            { 
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true ? "desactivar" : "activar";
                 
                DialogResult confirmacionActivar = MessageBox.Show(
                    "¿Seguro que deseas " + estado_cambiar + " este usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes)
                { 
                    try
                    {
                        cliente_editar.estado_cliente = !cliente_editar.estado_cliente;
                        string clientenombre = Convert.ToString(dgt.Rows[filaIndex].Cells["Cliente"].Value);
                        Cliente confirmacion = cliente.UpdateCliente(cliente_editar);

                        if (confirmacion != null) 
                        {
                            string nuevoEstado = confirmacion.estado_cliente == true ? "activo." : "desactivado."; 
                            MessageBox.Show("El cliente " + clientenombre + " ha cambiado su estado a " + nuevoEstado); 
                            this.LoadTableClientes();
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
            this.load_ErrorProvider = false;
            this.errorProvider1.Clear();

            if (this.ValidateChildren())
            {
                if (this.load_ErrorProvider)
                {
                    return;
                }
            } 
             
            if (this.PDatosPFisica.Enabled == true)
            {  
                this.CargarEntidadPFisica(this.cliente_editar.persona.persona_fisica); 
            }

            if (this.PDatosPJuridica.Enabled == true)
            {
                this.CargarEntidadPJuridica(this.cliente_editar.persona.persona_juridica);
            }
             
            this.CargarEntidadesCliente(this.cliente_editar.persona.contactos.FirstOrDefault(), this.cliente_editar.persona.direcciones.FirstOrDefault());

            try
            {
                CN_Cliente cliente = new CN_Cliente();

                int resultado = cliente.ActualizarClienteCompleto(this.cliente_editar);

                if (resultado != 0)
                {
                    MessageBox.Show("Los datos han sido actualizados correctamente.", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LPJuridica.Enabled = true;
                    this.LPFisica.Enabled = true;

                    this.BTNActualizar.Hide();
                    this.BTNActualizar.Enabled = false;

                    this.BTNRegistrar.Enabled = true;
                    this.BTNRegistrar.Show(); 

                    this.limpiarForm();
                    this.LoadTableClientes(); 
                }
                else
                {
                    this.mostrarErrores(cliente.GetErrors());
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

        public void limpiarForm()
        {
            // Persona FIsica
            this.TBDni.Text = "";
            this.TBNombre.Text = "";
            this.TBApellido.Text = "";
 
            this.RBHombre.Checked = true; 
             
            // Fecha de nacimiento.   
            // Propiedad checked = true para poder modificar la fecha en el DTP. 
            this.DTPFechaNacimiento.Checked = true;
            this.DTPFechaNacimiento.Value = DateTime.Now;

            // Persona Juridica
            this.TBCuit.Text = "";
            this.TBRazonSocial.Text = "";
            this.TBNombreComercial.Text = "";

            // Informacion de Contacto
            this.TBEmail.Text = string.Empty;
            this.TBTelefono.Text = string.Empty;
            this.TBSitioWeb.Text = string.Empty;

            this.TBCodPostal.Text = "";
            this.TBCalle.Text = string.Empty;
            this.TBAltura.Text = string.Empty; 
            this.CHKBDepto.Checked = false; 
            this.CBPiso.SelectedIndex = -1;  
            this.CBDepto.SelectedIndex = -1;

            this.errorProvider1.Clear();
            this.load_ErrorProvider = false;
        }

        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarForm();
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

        public void cargarPanelPFisica(PersonaFisica _personaFisica) 
        {
            this.TBDni.Text = Convert.ToString(_personaFisica.dni_persona);
            this.TBNombre.Text = _personaFisica.nombre_persona;
            this.TBApellido.Text = _personaFisica.apellido_persona;

            // Configuración de sexo 
            if (_personaFisica.sexo == "Hombre")
            {
                this.RBHombre.Checked = true;
            }
            else if (_personaFisica.sexo == "Mujer")
            {
                this.RBMujer.Checked = true;
            }

            // Fecha de nacimiento.   
            // Propiedad checked = true para poder modificar la fecha en el DTP. 
            this.DTPFechaNacimiento.Checked = true;
            this.DTPFechaNacimiento.Value = _personaFisica.fecha_nacimiento; 
        }

        public void cargarPanelPJuridica(PersonaJuridica _personaJuridica)
        {
            this.TBCuit.Text = Convert.ToString(_personaJuridica.cuit);
            this.TBRazonSocial.Text = _personaJuridica.razon_social;
            this.TBNombreComercial.Text = _personaJuridica.nombre_comercial;
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
        }

        public void cargarPanelContacto(Contacto _contacto) 
        {
            this.TBEmail.Text = _contacto.email;
            this.TBSitioWeb.Text = _contacto.sitio_web;
            this.TBTelefono.Text = Convert.ToString(_contacto.telefono);
        } 

        public void CargarEntidadesCliente(Contacto _contacto, Direccion _direccion)
        {
            // Cargamos Direccion y Contacto.
            if (this.CHKBDepto.Checked == true)
            {
                _direccion.cod_postal = Convert.ToInt16(this.TBCodPostal.Text);
                _direccion.calle = this.TBCalle.Text;
                _direccion.altura = Convert.ToInt16(this.TBAltura.Text);
                _direccion.piso = this.CBPiso.Text;
                _direccion.depto = Convert.ToInt16(this.CBDepto.Text);
            }
            else
            {
                _direccion.cod_postal = Convert.ToInt16(this.TBCodPostal.Text);
                _direccion.calle = this.TBCalle.Text;
                _direccion.altura = Convert.ToInt16(this.TBAltura.Text);
            }

            _contacto.telefono = Convert.ToInt64(TBTelefono.Text);
            _contacto.email = this.TBEmail.Text;
            _contacto.sitio_web = this.TBSitioWeb.Text;
        }

        public void CargarEntidadPJuridica(PersonaJuridica _personaJuridica) 
        {  
            _personaJuridica.razon_social = this.TBRazonSocial.Text;
            _personaJuridica.nombre_comercial = this.TBNombreComercial.Text;
            _personaJuridica.cuit = Convert.ToInt64(this.TBCuit.Text);  
        }

        public void CargarEntidadPFisica(PersonaFisica _personaFisica)
        {  
            // Preguntamos cual de los paneles se encuentra activo. 
            _personaFisica.nombre_persona = this.TBNombre.Text;
            _personaFisica.apellido_persona = this.TBApellido.Text;
            _personaFisica.dni_persona = Convert.ToInt32(this.TBDni.Text);
            _personaFisica.fecha_nacimiento = Convert.ToDateTime(this.DTPFechaNacimiento.Value);

            string sexo = string.Empty;

            if (RBHombre.Checked)
            {
                sexo = "Hombre";
            }
            else if (RBMujer.Checked)
            {
                sexo = "Mujer";
            }

            _personaFisica.sexo = sexo;   
        }

        private void TBBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox.Text.Equals("Buscar por identificacion ..."))
            {
                textBox.Text = "";
            }
        }

        private async void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            CN_Cliente cliente = new CN_Cliente(); 
            List<ClienteDTO> lista = new List<ClienteDTO>();

            if (!string.IsNullOrWhiteSpace(this.TBBuscar.Text))
            {
                try
                {
                    if (int.TryParse(this.TBBuscar.Text, out _))
                    {
                        this.LoadTableClientes(await cliente.GetClientes_Identificacion(cts.Token, Convert.ToInt32(this.TBBuscar.Text))); 
                    } 
                }
                catch (TaskCanceledException)
                {
                    // La consulta fue cancelada, no hacemos nada   
                }
            }
        } 

        // -------------- Validaciones -------------- 
        // Persona Fisica. 
        private void TBDni_Validating(object sender, CancelEventArgs e)
        {
            if (this.PDatosPFisica.Enabled == true) 
            {
                if (string.IsNullOrEmpty(TBDni.Text))
                {
                    errorProvider1.SetError(TBDni, "Este campo es obligatorio.");
                    this.load_ErrorProvider = true;
                }
                else if (!long.TryParse(TBDni.Text, out _))
                {
                    errorProvider1.SetError(TBDni, "El campo DNI solo puede contener valores numericos");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBDni, "");
                }
            } 
        }

        private void TBNombre_Validating(object sender, CancelEventArgs e)
        {
            if (this.PDatosPFisica.Enabled == true)
            {
                if (string.IsNullOrEmpty(TBNombre.Text))
                {
                    errorProvider1.SetError(TBNombre, "Este campo es obligatorio.");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBNombre, "");
                }
            }
        }

        private void TBApellido_Validating(object sender, CancelEventArgs e)
        {
            if (this.PDatosPFisica.Enabled == true)
            {
                if (string.IsNullOrEmpty(TBApellido.Text))
                {
                    errorProvider1.SetError(TBApellido, "Este campo es obligatorio.");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBApellido, "");
                }
            }
        }

        private void DTPFechaNacimiento_Validating(object sender, CancelEventArgs e)
        {
            if (this.PDatosPFisica.Enabled == true)
            {
                // Falta rigurosidad con respecto de los mesese y dias.
                DateTime fechaNacimiento = DTPFechaNacimiento.Value;
                int edad = DateTime.Today.Year - fechaNacimiento.Year;


                if (edad < 18)
                {
                    errorProvider1.SetError(DTPFechaNacimiento, "La fecha seleccionada corresponde a un menor de 18 años.");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(DTPFechaNacimiento, "");
                }
            }
        }

        // Persona Juridica. 
        private void CBRazonSocial_Validating(object sender, CancelEventArgs e)
        {
            if (this.PDatosPJuridica.Enabled == true)
            {
                if (string.IsNullOrEmpty(TBRazonSocial.Text))
                {
                    errorProvider1.SetError(TBRazonSocial, "El campo Razon Social no puede estar vacio.");
                    this.load_ErrorProvider = true;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBRazonSocial.Text, @"^[a-zA-Z0-9._%+\-\s]+$"))
                {
                    errorProvider1.SetError(TBRazonSocial, "El campo Razon Social solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBRazonSocial, "");
                }
            }
        }

        private void TBNombreComercial_Validating(object sender, CancelEventArgs e)
        {
            if (this.PDatosPJuridica.Enabled == true)
            {
                // Validaciones para campo Nombre Comercial. 
                if (string.IsNullOrEmpty(TBNombreComercial.Text))
                {
                    errorProvider1.SetError(TBNombreComercial, "El campo Nombre Comercial no puede estar vacio.");
                    this.load_ErrorProvider = true;
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(this.TBNombreComercial.Text, @"^[a-zA-Z0-9._%+\-\s]+$"))
                {
                    errorProvider1.SetError(TBNombreComercial, "El campo Nombre Comercial solo permite caracteres alfabeticos, numericos y los siguientes (-, _, +, %");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBNombreComercial, "");
                }
            }
        }

        private void TBCuit_Validating(object sender, CancelEventArgs e)
        {
            /*
             * Aca podemos observar como podriamos utilizar el sender (control que produce el evento) para un algoritmo mas dinamico.
                System.Windows.Forms.Control control = sender as System.Windows.Forms.TextBox;
                errorProvider1.SetError(control, "El campo CUIT solo puede contener valores numericos");
            */
            if (this.PDatosPJuridica.Enabled == true)
            {

                if (!long.TryParse(TBCuit.Text, out _))
                {
                    errorProvider1.SetError(TBCuit, "El campo CUIT solo puede contener valores numericos");
                    this.load_ErrorProvider = true;
                }
                else
                {
                    errorProvider1.SetError(TBCuit, "");
                }
            }
        }

        // Contacto.
        protected void TBEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBEmail.Text))
            {
                errorProvider1.SetError(TBEmail, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(TBEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(TBEmail, "La direccion email no cumple con el formato.(direccion@example.com)"); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBEmail, "");
            }
        }

        protected void TBTelefono_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBTelefono.Text))
            {
                errorProvider1.SetError(TBTelefono, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
            }
            else if (!long.TryParse(TBTelefono.Text, out _))
            {
                errorProvider1.SetError(TBTelefono, "El campo solo debe contener caracteres numericos."); 
                this.load_ErrorProvider = true;
            }
            else
            {
                errorProvider1.SetError(TBTelefono, "");
            }
        }

        private void TBSitioWeb_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(TBSitioWeb.Text))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(TBSitioWeb.Text, @"www\.[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}"))
                {
                    errorProvider1.SetError(TBSitioWeb, "El Sitio Web ingresado no tiene un formato estandar de dominio (www.example.com).");
                    this.load_ErrorProvider = true;
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

        // Direccion. 
        private void TBCodPostal_Validating(object sender, CancelEventArgs e)
        {
            // Validaciones para campo CodPostal. 
            if (string.IsNullOrEmpty(TBCodPostal.Text))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal no puede estar vacio.");
                this.load_ErrorProvider = true;
            }
            else if (!int.TryParse(TBCodPostal.Text, out _))
            {
                errorProvider1.SetError(TBCodPostal, "El campo Codigo Postal debe contener un valor numerico.");
                this.load_ErrorProvider = true;
            } 
            else
            {
                errorProvider1.SetError(TBCodPostal, "");
            }
        }

        protected void TBCalle_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TBCalle.Text))
            {
                errorProvider1.SetError(TBCalle, "Este campo es obligatorio."); 
                this.load_ErrorProvider = true;
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
                this.load_ErrorProvider = true;
            }
            else if (!int.TryParse(TBAltura.Text, out _))
            {
                errorProvider1.SetError(TBAltura, "El campo solo debe contener caracteres numericos."); 
                this.load_ErrorProvider = true;
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
                    this.load_ErrorProvider = true;
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
                    errorProvider1.SetError(CBDepto, "Debe seleccionar el depto."); 
                    this.load_ErrorProvider = true;
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

        // -------------- Otros eventos -------------- 
        protected void CBDepartamento_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKBDepto.Checked == true)
            {
                CBDepto.Enabled = true;
                errorProvider1.SetError(CBDepto, "Debe seleccionar el departamento");
                this.load_ErrorProvider = true;

                CBPiso.Enabled = true;
                errorProvider1.SetError(CBPiso, "Debe seleccionar el piso");
                this.load_ErrorProvider = true;
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

        
    }
}
