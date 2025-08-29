using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Listado : Form, IConfigForm
    {
        private Principal principal;

        public Listado(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
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
            List<Usuario> lista = nuevo.listarUsuarios();

            this.tablaUsuarios(lista);
        }


        public void tablaUsuarios(List<Usuario> _lista)
        {
            this.DGVLista.DataSource = null;
            this.DGVLista.Columns.Clear();
            this.DGVLista.Rows.Clear();

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
                Calle = usuario.persona.direccion.FirstOrDefault()?.calle,  // Usa ?. para evitar errores si la dirección es null
                Altura = usuario.persona.direccion.FirstOrDefault()?.altura,
                Piso = usuario.persona.direccion.FirstOrDefault()?.piso == null ? "-" : usuario.persona.direccion.FirstOrDefault()?.piso,
                Depto = usuario.persona.direccion.FirstOrDefault()?.depto == 0 ? "-" : usuario.persona.direccion.FirstOrDefault()?.depto.ToString(),
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView 
            DGVLista.DataSource = tabla;

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

        private void BTNuevo_Click(object sender, EventArgs e)
        {
            GestionUsuario gestion = new GestionUsuario();
            this.principal.AbrirFormHijo(gestion);
        }

        private void BTNFiltrar_Click(object sender, EventArgs e)
        {
            int tipo = this.COMBOBTipoUsuario.SelectedIndex + 1;

            if (tipo > 0)
            {
                CN_Usuario usuario = new CN_Usuario();
                List<Usuario> lista = new List<Usuario>();

                lista = usuario.listarUsuariosTipo(tipo);
                this.tablaUsuarios(lista);
            }
        } 

        private void DGVLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = DGVLista.Columns[e.ColumnIndex].Name;

            // Obtener el índice de la fila seleccionada
            int filaIndex = e.RowIndex;

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
                    CN_Usuario usuarios = new CN_Usuario();
                    List<Usuario> listado = usuarios.listarUsuarios();

                    string username = (string)DGVLista.Rows[filaIndex].Cells[6].Value;

                    Usuario user_editar = listado.FirstOrDefault(u => u.username == username);

                    if (user_editar != null)
                    { 
                        EdicionUsuario editar = new EdicionUsuario(user_editar);
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
                    MessageBox.Show($"Borrar usuario en la fila {filaIndex + 1}");
                    // Aquí puedes llamar al método para eliminar el usuario de la base de datos
                }
            } 
        }

    }
}
