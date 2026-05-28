using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Listado : Form, IConfigForm
    {
        private Principal principal;
        private CancellationTokenSource cts;

        public Listado(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.cts = new CancellationTokenSource();
            this.ConfigWindowState();
            this.cargarLista(); 
        }

        public void ConfigWindowState()
        {
            if (this.principal.WindowState == FormWindowState.Maximized)
            {
                this.DGVLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            }

            if (this.principal.WindowState == FormWindowState.Normal)
            {
                this.DGVLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 
            }
        }

        public void CentrarPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario
            this.DGVLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            this.PListado.Left = (this.ClientSize.Width - this.PListado.Width) / 2;
        } 

        public void MantenerPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario
            this.DGVLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; 
            this.PListado.Left = 2;
        }

        public void cargarLista()
        {
            CN_Usuario nuevo = new CN_Usuario();
            List<UsuarioDTO> lista = nuevo.listarUsuariosDTO(); 

            this.LoadTableUser(lista); 
        }

        public void LoadTableUser(List<UsuarioDTO> _lista)
        {
            this.DGVLista.DataSource = null;
            this.DGVLista.Columns.Clear();
            this.DGVLista.Rows.Clear();

            DGVLista.DataSource = this.LoadTable(_lista);

            this.DGVLista.Columns["Estado"].Visible = false;

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            DGVLista.Columns.Add(btnColumnEditar);
            DGVLista.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Khaki;
            DGVLista.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Khaki;

            DataGridViewButtonColumn btnColumnEstado = new DataGridViewButtonColumn();
            btnColumnEstado.Name = "CEstado";
            btnColumnEstado.HeaderText = "Estado";
            btnColumnEstado.UseColumnTextForButtonValue = true;
            btnColumnEstado.FlatStyle = FlatStyle.Standard;
            btnColumnEstado.UseColumnTextForButtonValue = false; // Para poder modificar el texto.
            DGVLista.Columns.Add(btnColumnEstado);
            DGVLista.Columns["CEstado"].HeaderCell.Style.BackColor = Color.LightGray;
            DGVLista.Columns["CEstado"].HeaderCell.Style.SelectionBackColor = Color.LightGray;
        } 

        public object LoadTable(List<UsuarioDTO> _lista)
        {
            var tabla = _lista.Select((usuario, index) => new
            { 
                Dni = usuario.dni, // Se asigna el valor del DNI a la columna "DNI"
                Apellido = usuario.apellido,
                Nombre = usuario.nombre,  // Se asigna el Nombre a la columna "Nombre"
                Usuario = usuario.username,
                TipoUsuario = usuario.descripcion_tipo,
                Telefono = usuario.telefono,
                Email = usuario.email,
                Calle = usuario.calle,
                Altura = usuario.altura,
                Piso = usuario.piso == null ? "-" : usuario.piso.ToString(),
                Depto = usuario.depto == 0 ? "-" : usuario.depto.ToString(),
                Estado = usuario.estado 
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  


            return tabla;
        }

        private void BTNuevo_Click(object sender, EventArgs e)
        {
            GestionUsuario gestion = new GestionUsuario();
            this.principal.AbrirFormHijo(gestion);
        }

        // El filtro esta funcionando sin tener en cuenta el estado por lo tanto se carga todo en la tabla de usuarios no eliminados.
        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            int tipo = this.COMBOBTipoUsuario.SelectedIndex + 1;
            string genero = (string)this.COMBOBGenero.SelectedItem;

            CN_Usuario usuario = new CN_Usuario();
            List<Usuario> listaTipo = new List<Usuario>();
            List<Usuario> listaGenero = new List<Usuario>();
            List<UsuarioDTO> todos = new List<UsuarioDTO>();

            // Si se utilizan los dos filtros 
            if (!(string.IsNullOrEmpty(genero)) && (tipo > 0))
            {  
                this.LoadTableUser(usuario.listarUsuariosGenerotipo(tipo, genero)); 
            }

            // Si se utiliza el filtro tipoUsuario.
            if (string.IsNullOrEmpty(genero))
            {
                if (tipo > 0)
                { 
                    //this.limpiarFiltros();
                    this.LoadTableUser(usuario.listarUsuariosTipo(tipo)); 
                }
            }

            // Si se utiliza en filtro genero.
            if (tipo < 1)
            {
                if (!string.IsNullOrEmpty(genero))
                {     
                    //this.limpiarFiltros();
                    this.LoadTableUser(usuario.listarUsuariosGenero(genero)); 
                }
            } 

        }

        public void limpiarFiltros()
        {
            // Limpio los botones.
            this.COMBOBTipoUsuario.SelectedIndex = -1;
            this.COMBOBTipoUsuario.Text = "Seleccionar";

            this.COMBOBGenero.SelectedIndex = -1;
            this.COMBOBGenero.Text = "Seleccionar";
        }

        private void DGVLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

            // Cargo siempre el username como metodo de busqueda.
            string username = (string)dgt.Rows[filaIndex].Cells["Usuario"].Value;
            CN_Usuario usuarios = new CN_Usuario();
            Usuario user_editar = usuarios.buscar_usuario_username(username);
            // List<Usuario> listado = usuarios.listarUsuarios(); 
            // Usuario user_editar = listado.FirstOrDefault(u => u.username == username);

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
                    // Buscamos el usuario de la fila seleccionada para cargar sus datos
                    // ? Falopa total hacer ese listado, deberia llamar al metodo en la CN que traiga el elemento y no la lista.

                    string permiso = this.principal.GetSessionTypeUser();

                    if (user_editar != null)
                    {
                        EdicionUsuario editar = new EdicionUsuario(user_editar, permiso);
                        this.principal.AbrirFormHijo(editar);
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado el usuario", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (nombreColumna == "CEstado")
            {
                string estado_cambiar = Convert.ToBoolean(dgt.Rows[filaIndex].Cells["Estado"].Value) == true ? "desactivar" : "activar";

                DialogResult confirmacion = MessageBox.Show(
                    "¿Seguro que deseas " + estado_cambiar + " este usuario?",
                    "Confirmación.",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion == DialogResult.Yes)
                { 
                    try
                    {
                        user_editar.estado = !user_editar.estado;
                        string userNombre = Convert.ToString(dgt.Rows[filaIndex].Cells["Nombre"].Value);
                        string userApellido = Convert.ToString(dgt.Rows[filaIndex].Cells["Apellido"].Value);
                        Usuario actualizado = usuarios.UpdateUser(user_editar);

                        if (actualizado != null)
                        {
                            string nuevoEstado = actualizado.estado == true ? "activo." : "desactivado.";
                            MessageBox.Show("El Usuario " + userApellido + ", " + userNombre + " ha cambiado su estado a " + nuevoEstado, "Informacion.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.cargarLista();
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error inesperado, vuelva a intentar.");
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

            this.cargarLista();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGVLista.Columns[e.ColumnIndex].Name == "CEstado" && e.RowIndex >= 0)
            {
                bool estado = Convert.ToBoolean(DGVLista.Rows[e.RowIndex].Cells["Estado"].Value);

                e.Value = estado ? "Desactivar" : "Activar";
            }
        }

        private void TBBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox.Text.Equals(" Buscar por dni o nombre ..."))
            {
                textBox.Text = "";
            }
        }

        private async void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            CN_Usuario usuario = new CN_Usuario();
            List<UsuarioDTO> lista = new List<UsuarioDTO>();

            if (!string.IsNullOrWhiteSpace(this.TBBuscar.Text))
            {
                try
                {
                    if (int.TryParse(this.TBBuscar.Text, out _))
                    {
                        int dni = Convert.ToInt32(TBBuscar.Text);

                        this.LoadTableUser(await usuario.listarUsuariosDni(dni, cts.Token)); 
                    }


                    if (!int.TryParse(this.TBBuscar.Text, out _) && !this.TBBuscar.Text.Equals((" Buscar por dni o nombre ...")))
                    {
                        this.LoadTableUser(await usuario.listarUsuariosNombre(this.TBBuscar.Text, cts.Token)); 
                    }
                }
                catch (TaskCanceledException)
                {
                    // La consulta fue cancelada, no hacemos nada   
                }
            }
        }
    }
}