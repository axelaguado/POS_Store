using iTextSharp.tool.xml.css;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionCompras : Form, IConfigForm
    {
        private Principal principal;
        private CancellationTokenSource cts;

        public GestionCompras(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal; 
            this.cts = new CancellationTokenSource();   
            this.loadTableInit(); 
        }
         
        public void loadTableInit() 
        { 
            CN_Compra compra = new CN_Compra();
            List<Compra> pendientes = compra.ComprasPendientes();
            List<Compra> confirmadas = compra.ComprasConfirmadas(); 
             
            this.loadComprasPendientes(pendientes);
            this.loadComprasConfirmadas(confirmadas);
        }

        public void CentrarPanelesPrincipales()
        {
            this.loadTableInit();
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
        }

        public void MantenerPanelesPrincipales()
        {
            this.loadTableInit();
        }
         
        public void ConfigWindowStateDGVPedidosConfirmados(int elementos)
        { 
            this.DGVPedidosConfirmados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
        }
         
        public void ConfigWindowStateDGVPedidosPendientes(int elementos)
        {
            // Seteamos la propiedade del DGV para que se vea bien.
            if (this.principal.WindowState == FormWindowState.Maximized)
            {
                this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (this.principal.WindowState == FormWindowState.Normal)
            {
                if (elementos == 0)
                {
                    this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                else
                {
                    this.DGVPedidosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrarCompra nuevo = new RegistrarCompra();
            this.principal.AbrirFormHijo(nuevo);   
        }

        // Tabla Pedidos Pendientes.
        public object LoadTableCompras(List<Compra> _compras)
        {
            var tabla = _compras.Select((compra, index) => new
            {
                NroCompra = compra.id_compra,
                Proveedor = compra.proveedor.persona.persona_juridica.nombre_comercial, 
                Monto = "$" + compra.monto_total
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
        }

        public void loadComprasPendientes(List<Compra> listaCompra)
        { 
            this.DGVPedidosPendientes.DataSource = null;
            this.DGVPedidosPendientes.Columns.Clear();
            this.DGVPedidosPendientes.Rows.Clear();

            int elementos = listaCompra == null? 0 : listaCompra.Count; 

            this.ConfigWindowStateDGVPedidosPendientes(elementos);

            this.DGVPedidosPendientes.DataSource = LoadTableCompras(listaCompra);

            DataGridViewButtonColumn btnColumnDetalles = new DataGridViewButtonColumn();
            btnColumnDetalles.Name = "CDetalles";
            btnColumnDetalles.HeaderText = "Detalles";
            btnColumnDetalles.Text = "Ver Detalles";
            btnColumnDetalles.UseColumnTextForButtonValue = true;
            btnColumnDetalles.FlatStyle = FlatStyle.Standard;
            this.DGVPedidosPendientes.Columns.Add(btnColumnDetalles);
            this.DGVPedidosPendientes.Columns["CDetalles"].HeaderCell.Style.BackColor = Color.PaleTurquoise;
            this.DGVPedidosPendientes.Columns["CDetalles"].HeaderCell.Style.SelectionBackColor = Color.PaleTurquoise;

            DataGridViewButtonColumn btnColumnRecibir = new DataGridViewButtonColumn();
            btnColumnRecibir.Name = "CConfirmar";
            btnColumnRecibir.HeaderText = "Confirmar";
            btnColumnRecibir.Text = "Confirmar";
            btnColumnRecibir.UseColumnTextForButtonValue = true;
            btnColumnRecibir.FlatStyle = FlatStyle.Standard;
            this.DGVPedidosPendientes.Columns.Add(btnColumnRecibir);
            this.DGVPedidosPendientes.Columns["CConfirmar"].HeaderCell.Style.BackColor = Color.LightGreen;
            this.DGVPedidosPendientes.Columns["CConfirmar"].HeaderCell.Style.SelectionBackColor = Color.LightGreen;

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
        public void loadComprasConfirmadas(List<Compra> listaCompra)
        {  
            this.DGVPedidosConfirmados.DataSource = null;
            this.DGVPedidosConfirmados.Columns.Clear();
            this.DGVPedidosConfirmados.Rows.Clear();

            int elementos = listaCompra == null ? 0 : listaCompra.Count; 

            this.ConfigWindowStateDGVPedidosConfirmados(elementos);

            this.DGVPedidosConfirmados.DataSource = LoadTableCompras(listaCompra);

            DataGridViewButtonColumn btnColumnDetalles = new DataGridViewButtonColumn();
            btnColumnDetalles.Name = "CDetalles";
            btnColumnDetalles.HeaderText = "Detalles";
            btnColumnDetalles.Text = "Ver Detalles";
            btnColumnDetalles.UseColumnTextForButtonValue = true;
            btnColumnDetalles.FlatStyle = FlatStyle.Standard;
            this.DGVPedidosConfirmados.Columns.Add(btnColumnDetalles);
            this.DGVPedidosConfirmados.Columns["CDetalles"].HeaderCell.Style.BackColor = Color.PaleTurquoise;
            this.DGVPedidosConfirmados.Columns["CDetalles"].HeaderCell.Style.SelectionBackColor = Color.PaleTurquoise;
        }

        // Evento CellClick para tratas las funcionalidades de los distintos botones
        private void DGVPedidosPendientesConfirmados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgt = sender as DataGridView;

            CN_Compra compra = new CN_Compra();

            // Evitar clics en el encabezado
            if (e.RowIndex < 0) return;

            // Obtener el nombre de la columna clickeada
            string nombreColumna = dgt.Columns[e.ColumnIndex].Name;

            // Dependiendo de la columna, ejecutar acciones
            if (nombreColumna == "CConfirmar")
            {
                DialogResult confirmacionRecibir = MessageBox.Show(
                        "¿Seguro que deseas confirmar esta compra?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionRecibir == DialogResult.Yes)
                { 
                    int id_compra = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells["NroCompra"].Value);

                    try 
                    { 
                        Compra compraConfirmar = compra.BuscarCompra(id_compra);
                         
                        int confirmacion = compraConfirmar == null? 0 : compra.ImpactarCompra(compraConfirmar);

                        if (confirmacion > 0) 
                        {
                            this.loadTableInit();
                            MessageBox.Show("Se confirmo la compra numero: " + id_compra + ", correctamente", "Confirmacion de compra.", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        }
                        else 
                        {
                            this.mostrarErrores(compra.GetErrors());
                            MessageBox.Show("Ocurrio un error, no se ha podido confirmal la compra numero: " + id_compra, "Error de Confirmacion de compra.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error de Confirmacion de compra.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (nombreColumna == "CCancelar")
            {
                string mensaje = "A continuacion cancelara la compra nro: " + dgt.Rows[e.RowIndex].Cells["NroCompra"].Value + ", por un monto de $" + dgt.Rows[e.RowIndex].Cells["Monto"].Value;

                DialogResult confirmacionCancelar = MessageBox.Show(mensaje +
                        " ¿Seguro que deseas cancelar esta compra?",
                        "Confirmación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                );

                if (confirmacionCancelar == DialogResult.Yes)
                {
                    int id_compra = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells["NroCompra"].Value);
                    compra.CancelarPedido(id_compra);
                    this.loadTableInit();
                    MessageBox.Show("El pedido numero: " + id_compra + ", fue cancelado correctamente.", "Cancelacion de Pedido", MessageBoxButtons.OK);
                }
            }

            if (nombreColumna == "CDetalles")
            {
                int id_compra = Convert.ToInt32(dgt.Rows[e.RowIndex].Cells["NroCompra"].Value);
                Compra encontrado = compra.BuscarCompra(id_compra);

                if (encontrado != null)
                {
                    Detalle detalle = new Detalle(encontrado);
                    detalle.Show();
                }

            }

        }

        public void mostrarErrores(Dictionary<string, string> errores) 
        { 
            foreach (var error in errores) 
            {
                MessageBox.Show("en: " + error.Key + " - error: " + error.Value);
            }
        }

        private void TBBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (textBox.Text.Equals("Buscar por proveedor o por numero de compra ..."))
            {
                textBox.Text = "";
            }
        }

        private async void TBBuscar_TextChanged(object sender, EventArgs e)
        {
            cts.Cancel(); // Cancela la consulta anterior si aún está en proceso
            cts = new CancellationTokenSource(); // Crea un nuevo token de cancelación

            CN_Compra compra = new CN_Compra();
            List<Compra> compras = new List<Compra>();

            if (!string.IsNullOrWhiteSpace(this.TBBuscar.Text))
            {
                string buscado = this.TBBuscar.Text; 

                try
                {
                    this.loadComprasConfirmadas(await compra.BusquedaAsync_compraConfirmada(cts.Token, buscado));
                    this.loadComprasPendientes(await compra.BusquedaAsync_compraPendiente(cts.Token, buscado)); 
                }
                catch (TaskCanceledException)
                {
                    // La consulta fue cancelada, no hacemos nada   
                }
            }
        }
    }
}
