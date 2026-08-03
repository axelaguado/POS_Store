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
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class GestionCajas : Form
    {
        public GestionVentas actual;

        public GestionCajas(GestionVentas _actual)
        {
            InitializeComponent();
            this.SetUpDGVCajas();
            this.actual = _actual;
        }

        public void LoadPanelInfo(List<Caja> cajas) 
        {
            List<Venta> ventas = cajas.SelectMany(c => c.ventas).ToList();
            List<Detalle_venta> detalles = ventas.SelectMany(v => v.detalles).ToList();

            //Ventas
            decimal ventas_total = ventas.Sum(v => v.monto_venta);
            this.LVVentas.Text = "$ " + ventas_total;

            //Ganancias
            decimal costos_total = detalles.Sum(d => (d.precio_costo * d.cantidad_producto));
            decimal ganancias_brutas = ventas_total - costos_total;
            this.LVGanancias.Text = "$ " + ganancias_brutas;

            //Abiertas
            int abiertas = cajas.Where(c => c.estado_caja == true).Count();
            this.LVAbiertas.Text = abiertas.ToString();

            //Cerradas
            int cerradas = cajas.Where(c => c.estado_caja == false).Count();
            this.LVCerradas.Text = cerradas.ToString();
        }

        public object LoadCajas(List<Caja> cajas) 
        {
            CN_Caja cn_caja = new CN_Caja();

            var tabla = cajas.Select((caja, index) => new
            {
                Caja = caja.id_caja,
                Empleado = caja.usuario.empleado.nombreCompleto_empleado,
                Apertura = caja.fecha_apertura.ToShortDateString() + " - " + caja.fecha_apertura.ToShortTimeString(),
                Estado = caja.estado_caja == true ? "Abierta" : "Cerrada",
                EfectivoApertura = "$ " + caja.saldo_inicial,
                EfectivoActual = "$ " + (caja.saldo_inicial + caja.ventas.SelectMany(v => v.pagos).Where(p => p.metodo.descripcion_metodo == "Efectivo").Sum(p => p.importe_pago) + cn_caja.ObtenerImporteIngresos(caja) - cn_caja.ObtenerMontoEgresos(caja)),
                Ventas = "$ " + caja.ventas.Sum(v => v.monto_venta),
                Ganancias = "$ " + ( caja.ventas.SelectMany(v => v.detalles).Sum(d => d.subtotal) - caja.ventas.SelectMany(v => v.detalles).Sum(d => (d.precio_costo * d.cantidad_producto))),
            }).ToList();

            return tabla;
        }

        public void SetUpDGVCajas()
        {
            this.DGVCajas.DataSource = null;
            this.DGVCajas.Columns.Clear();
            this.DGVCajas.Rows.Clear();

            List<Caja> cajas = this.ObtenerCajas();
            this.LoadPanelInfo(cajas);

            this.DGVCajas.DataSource = LoadCajas(cajas);

            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CAccion";
            btnColumnCancelar.HeaderText = "Accion";
            btnColumnCancelar.Text = "Accion";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard;
            this.DGVCajas.Columns.Add(btnColumnCancelar);
            this.DGVCajas.Columns["CAccion"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.DGVCajas.Columns["CAccion"].HeaderCell.Style.SelectionBackColor = Color.LightCoral; 
        }

        public List<Caja> ObtenerCajas()
        { 
            CN_Caja caja = new CN_Caja();

            try
            {
                return caja.ObtenerCajas();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        
        }

        private void BTVolver_Click(object sender, EventArgs e)
        {
            this.actual.principal.AbrirFormHijo(this.actual);
        }
    }
}
