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
            cargarLista();

        }

        public void CentrarPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario
            this.PListado.Left = (this.ClientSize.Width - this.PListado.Width) / 2;
        }


        public void MantenerPanelesPrincipales()
        {
            // Centra el panel en función del tamaño del formulario
            this.PListado.Left = 2;
        }

        public void cargarLista()
        {
            CN_Usuario nuevo = new CN_Usuario();
            List<Usuario> listaActivos = nuevo.listarUsuariosActivos();
            List<Usuario> listaInactivos = nuevo.listarUsuariosInactivos();

            this.LoadTableUserActive(listaActivos);
            this.LoadTableUserInactive(listaInactivos);
        }

        public void LoadTableUserActive(List<Usuario> _lista)
        {
            this.DGVLista.DataSource = null;
            this.DGVLista.Columns.Clear();
            this.DGVLista.Rows.Clear();

            DGVLista.DataSource = this.LoadTable(_lista);

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            DGVLista.Columns.Add(btnColumnEditar);
            DGVLista.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Orange;
            DGVLista.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Orange;

            DataGridViewButtonColumn btnColumnBorrar = new DataGridViewButtonColumn();
            btnColumnBorrar.Name = "CBorrar";
            btnColumnBorrar.HeaderText = "Borrar";
            btnColumnBorrar.Text = "Borrar";
            btnColumnBorrar.UseColumnTextForButtonValue = true;
            btnColumnBorrar.FlatStyle = FlatStyle.Standard;
            DGVLista.Columns.Add(btnColumnBorrar);
            DGVLista.Columns["CBorrar"].HeaderCell.Style.BackColor = Color.Red;
            DGVLista.Columns["CBorrar"].HeaderCell.Style.SelectionBackColor = Color.Red;
        }

        public void LoadTableUserInactive(List<Usuario> _lista)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            dataGridView1.DataSource = this.LoadTable(_lista);

            DataGridViewButtonColumn btnColumnEditar = new DataGridViewButtonColumn();
            btnColumnEditar.Name = "CEditar";
            btnColumnEditar.HeaderText = "Editar";
            btnColumnEditar.Text = "Editar";
            btnColumnEditar.UseColumnTextForButtonValue = true;
            btnColumnEditar.FlatStyle = FlatStyle.Standard;
            dataGridView1.Columns.Add(btnColumnEditar);
            dataGridView1.Columns["CEditar"].HeaderCell.Style.BackColor = Color.Orange;
            dataGridView1.Columns["CEditar"].HeaderCell.Style.SelectionBackColor = Color.Orange;

            DataGridViewButtonColumn btnColumnActivar = new DataGridViewButtonColumn();
            btnColumnActivar.Name = "CActivar";
            btnColumnActivar.HeaderText = "Activar";
            btnColumnActivar.Text = "Activar";
            btnColumnActivar.UseColumnTextForButtonValue = true;
            btnColumnActivar.FlatStyle = FlatStyle.Standard;
            dataGridView1.Columns.Add(btnColumnActivar);
            dataGridView1.Columns["CActivar"].HeaderCell.Style.BackColor = Color.DarkTurquoise;
            dataGridView1.Columns["CActivar"].HeaderCell.Style.SelectionBackColor = Color.DarkTurquoise;
        }

        public object LoadTable(List<Usuario> _lista)
        {
            var tabla = _lista.Select((usuario, index) => new
            {
                Indice = index + 1,
                Apellido = usuario.persona.apellido_persona,
                Nombre = usuario.persona.nombre_persona,  // Se asigna el Nombre a la columna "Nombre"
                Dni = usuario.persona.dni_persona, // Se asigna el valor del DNI a la columna "DNI"
                Usuario = usuario.username,
                TipoUsuario = usuario.tipo_usuario.descripcion_tipo,
                Telefono = usuario.persona.telefono,
                Email = usuario.persona.email,
                Calle = usuario.persona.direccion.calle,  // Usa ?. para evitar errores si la dirección es null
                Altura = usuario.persona.direccion.altura,
                Piso = usuario.persona.direccion.piso == null ? "-" : usuario.persona.direccion.piso,
                Depto = usuario.persona.direccion.depto == 0 ? "-" : usuario.persona.direccion.depto.ToString(),
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  


            return tabla;
        }

        private void BTNuevo_Click(object sender, EventArgs e)
        {
            GestionUsuario gestion = new GestionUsuario();
            this.principal.AbrirFormHijo(gestion);
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            int tipo = this.COMBOBTipoUsuario.SelectedIndex + 1;
            string genero = (string)this.COMBOBGenero.SelectedItem;

            CN_Usuario usuario = new CN_Usuario();
            List<Usuario> listaTipo = new List<Usuario>();
            List<Usuario> listaGenero = new List<Usuario>();
            List<Usuario> todos = new List<Usuario>();

            // Si se utilizan los dos filtros


            if (!(string.IsNullOrEmpty(genero)) && (tipo > 0))
            {
                todos = usuario.listarUsuariosGenerotipo(tipo, genero);
                //this.limpiarFiltros();
                this.LoadTableUserActive(todos);
            }

            // Si se utiliza el filtro tipoUsuario.
            if (string.IsNullOrEmpty(genero))
            {
                if (tipo > 0)
                {
                    todos = usuario.listarUsuariosTipo(tipo);
                    //this.limpiarFiltros();
                    this.LoadTableUserActive(todos);
                }
            }

            // Si se utiliza en filtro genero.
            if (tipo < 1)
            {
                if (!string.IsNullOrEmpty(genero))
                {
                    todos = usuario.listarUsuariosGenero(genero);
                    //this.limpiarFiltros();
                    this.LoadTableUserActive(todos);
                }
            }

            // Si no muestra la lista vacia.
            this.LoadTableUserActive(todos);

        }
        /*
        public void limpiarFiltros() 
        {
            // Limpio los botones.
            this.COMBOBTipoUsuario.SelectedIndex = -1;
            this.COMBOBTipoUsuario.Text = "Seleccionar"; 
             
            this.COMBOBGenero.SelectedIndex = -1;
            this.COMBOBGenero.Text = "Seleccionar";
        }  
        */

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
            CN_Usuario usuarios = new CN_Usuario();
            List<Usuario> listado = usuarios.listarUsuarios();
            string username = (string)dgt.Rows[filaIndex].Cells["Usuario"].Value;
            Usuario user_editar = listado.FirstOrDefault(u => u.username == username);

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

                    string permisos = this.principal.GetSessionTypeUser();

                    if (user_editar != null)
                    {
                        EdicionUsuario editar = new EdicionUsuario(user_editar, permisos);
                        this.principal.AbrirFormHijo(editar);
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado el usuario", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (nombreColumna == "CBorrar")
            {
                DialogResult confirmacionBorrar = MessageBox.Show(
                    "¿Seguro que deseas borrar este usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionBorrar == DialogResult.Yes)
                {
                    user_editar.estado = false;

                    usuarios.updateUser(user_editar);

                    MessageBox.Show($"Borrar usuario en la fila {filaIndex + 1}");
                    // Aquí puedes llamar al método para eliminar el usuario de la base de datos
                }
            }
            else if (nombreColumna == "CActivar")
            {
                DialogResult confirmacionActivar = MessageBox.Show(
                    "¿Seguro que deseas Activar este usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacionActivar == DialogResult.Yes)
                {
                    user_editar.estado = true;

                    usuarios.updateUser(user_editar);

                    MessageBox.Show($"Activar usuario en la fila {filaIndex + 1}");
                    // Aquí puedes llamar al método para eliminar el usuario de la base de datos
                }
            }

            this.cargarLista();
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
            List<Usuario> lista = new List<Usuario>();

            if (!string.IsNullOrWhiteSpace(this.TBBuscar.Text))
            {
                try
                {
                    if (int.TryParse(this.TBBuscar.Text, out _))
                    {
                        int dni = Convert.ToInt32(TBBuscar.Text);

                        this.LoadTableUserActive(await usuario.listarUsuariosDniEstado(dni, true, cts.Token));
                        this.LoadTableUserInactive(await usuario.listarUsuariosDniEstado(dni, false, cts.Token));
                    }


                    if (!int.TryParse(this.TBBuscar.Text, out _) && !this.TBBuscar.Text.Equals((" Buscar por dni o nombre ...")))
                    {
                        this.LoadTableUserActive(await usuario.listarUsuariosNombreEstado(this.TBBuscar.Text, true, cts.Token));
                        this.LoadTableUserInactive(await usuario.listarUsuariosNombreEstado(this.TBBuscar.Text, false, cts.Token));
                    }
                }
                catch (TaskCanceledException)
                {
                    // La consulta fue cancelada, no hacemos nada   
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Direccion nuevaDireccion = new Direccion();
            CN_Direccion direccion = new CN_Direccion();    

            nuevaDireccion.calle = "Av Junin";
            nuevaDireccion.altura = 4220;

            try
            {
                direccion.CrearDireccion(nuevaDireccion);
            }
            catch (TaskCanceledException ex) 
            {
                MessageBox.Show("Error :" + ex.Message); 
            }   
        }
    }
}