using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionVentas : Form
    {
        Principal principal;

        public GestionVentas(Principal principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.InitLoad();
        }

        public void VerifyStateCaja()
        {
        
        }

        public void InitLoad()
        {
            this.SetConfigCajaClose();
            this.loadCarrito();
        }
        public void SetConfigCajaClose()
        {
            int x = (this.panel3.Size.Width - this.LAnuncio.Width) / 2;
            int y = this.panel3.Size.Height / 3;
            this.LAnuncio.Location = new System.Drawing.Point(x, y);
        }

        public object LoadTable(List<Producto> productos) 
        { 
            var tabla = productos.Select((producto, index) => new
            {
                Codigo = producto.sku_producto,
                Producto = producto.producto_completo,
                Cantidad = 4,
                PrecioU = "$" + producto.precio_venta,
                Subtotal = "$" + (producto.precio_venta * 4) 
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
        }

        public void loadCarrito()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            List<Producto> productos = new List<Producto>();
            Producto ejemplo = new Producto();
            ejemplo.sku_producto = "0222987997998";
            ejemplo.marca_producto = "Pepsico";
            ejemplo.nombre_producto = "Lays";
            ejemplo.descripcion_producto = "Original";
            ejemplo.contenido_producto = "115g";
            ejemplo.precio_venta = 1170;

            productos.Add(ejemplo);

            this.dataGridView1.DataSource = LoadTable(productos);
             
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

        private void button1_Click(object sender, EventArgs e)
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

            AperturaCaja frm = new AperturaCaja();
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(
                area.Left + (area.Width - frm.Width) / 2,
                area.Top + (area.Height - frm.Height) / 2
            );
            formBG.Show();

            frm.Owner = formBG;
            DialogResult resultado = frm.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                // Incializamos la caja

                // Dejamos visible el Panel para ventas.
                this.tableLayoutPanel1.Visible = false;
                this.tableLayoutPanel2.Visible = true;
            }
            else
            {
                // Dejamos no visible el Panel para ventas.
                this.tableLayoutPanel2.Visible = false;
                this.tableLayoutPanel1.Visible = true;
            }

            formBG.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
