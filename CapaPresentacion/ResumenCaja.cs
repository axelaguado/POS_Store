using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class ResumenCaja : Form
    {
        public Caja cajaResumen;
        public GestionVentas gestion;

        public ResumenCaja(int id_caja, GestionVentas _gestion)     
        {
            InitializeComponent();
            this.cajaResumen = this.GetCajaResumen(id_caja);
            this.gestion = _gestion;
            this.LoadInit();
        }
          
        public void LoadInit()
        {
            this.LoadPInfoGeneral();
            this.LoadPVentas();
            this.LoadPMovimientos();
            this.LoadPPagos();
            this.LoadPTopProductos();
        }

        public Caja GetCajaResumen(int id_caja) 
        { 
            CN_Caja caja = new CN_Caja();

            try 
            { 
                Caja encontrada = caja.ObtenerCaja(id_caja);

                if (encontrada != null)
                {
                    return encontrada;
                }

                return null;
            
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }

        // Cargamos la info inicial en los distintos paneles.
        public void LoadPInfoGeneral() 
        {
            this.LVUsuario.Text = this.cajaResumen.usuario.username;
            this.LVCaja.Text = this.cajaResumen.id_caja.ToString();
            this.LVApertura.Text = this.cajaResumen.fecha_apertura.ToString();
            TimeSpan transcurrido = DateTime.Now.Subtract(this.cajaResumen.fecha_apertura);
            string transcurridoHoras = transcurrido.Hours + "hs:" + transcurrido.Minutes + "min:" + transcurrido.Seconds +"sec";
            this.LVTiempo.Text = transcurrido.Days != 0? transcurrido.Days + " dias - " + transcurridoHoras : transcurridoHoras;
            this.LVEstado.Text = this.cajaResumen.estado_caja == true? "Abierta.": "Cerrada.";
        }

        public void LoadPVentas() 
        {
            this.SetUpDGVVentas();

            int tickets = this.cajaResumen.ventas.Count;
            decimal total = this.cajaResumen.ventas.Sum(v => v.monto_venta);
            decimal promedio = decimal.Round((total / tickets), 2);

            this.LVTickets.Text = tickets.ToString();
            this.LVTicketPromedio.Text = "$ " + promedio;
            this.LVTotalVentas.Text = "$ " + total;
        }

        public void LoadPMovimientos()
        {
            this.SetUpDGVMovimientos();

            decimal ingresos = this.cajaResumen.movimientos.Where(m => m.tipo_movimiento.descripcion_tipo == "Ingreso").Sum(m => m.monto_movimiento);
            decimal egresos = this.cajaResumen.movimientos.Where(m => m.tipo_movimiento.descripcion_tipo == "Egreso").Sum(m => m.monto_movimiento);

            this.LVIngresos.Text = "$ " + ingresos;
            this.LVEgresos.Text = "$ " + egresos;
        }

        public void LoadPPagos()
        {
            this.SetUpDGVPagos();

            // Metodos
            List<Pago> pagos = this.cajaResumen.ventas
                                      .SelectMany(v => v.pagos)
                                      .ToList();

            this.LVEfectivo.Text = "$" + pagos.Where(p => p.metodo.descripcion_metodo == "Efectivo").Sum(p => p.importe_pago);
            this.LVTransferencia.Text = "$" + pagos.Where(p => p.metodo.descripcion_metodo == "Transferencia").Sum(p => p.importe_pago);
            this.LVDebito.Text = "$" + pagos.Where(p => p.metodo.descripcion_metodo == "Debito").Sum(p => p.importe_pago);
            this.LVCredito.Text = "$" + pagos.Where(p => p.metodo.descripcion_metodo == "Credito").Sum(p => p.importe_pago);
            this.LVOtros.Text = "$" + pagos.Where(p => p.metodo.id_metodo > 4).Sum(p => p.importe_pago);

        }

        public void LoadPTopProductos()
        {
            // 1. Agrupamos y obtenemos los más vendidos ordenados de MAYOR a MENOR
            var detalles = this.cajaResumen.ventas
                                    .SelectMany(v => v.detalles)
                                    .GroupBy(d => d.id_producto)
                                    .Select(g => new
                                    {
                                        // Tomamos el nombre del primer detalle del grupo
                                        NombreProducto = g.FirstOrDefault()?.producto?.producto_completo ?? "Desconocido",
                                        Cantidad = g.Sum(d => d.cantidad_producto)
                                    })
                                    .OrderByDescending(g => g.Cantidad) // De mayor a menor para el Top
                                    .ToList();

            int indice = 0;
              
            // 2. Recorremos las 5 posiciones de tus controles visuales de forma segura
            foreach(var detalle in detalles)
            {
                indice = indice + 1;

                if (indice > detalles.Count) return;

                string nombreControl = "LVTop" + indice;

                Control[] controlEncontrado = this.Controls.Find(nombreControl, true);

                if (controlEncontrado != null) 
                {
                    controlEncontrado[0].Text = detalle.NombreProducto + " (" + detalle.Cantidad + "u.)" ; 
                }

            }
        }

        // Cargamoms las tablas.
        public object LoadVentas(List<Venta> _ventas )
        {
            var tabla = _ventas.Select((venta, index) => new 
            {
                Nro = index + 1,
                Fecha = venta.fecha_venta.Day + "/" + venta.fecha_venta.Month + " - " + venta.fecha_venta.ToShortTimeString(),
                Cliente = venta.cliente.nombreCompleto_cliente,
                Productos = venta.detalles.Count,
                Total = "$ " + venta.monto_venta,
            }
            ).ToList();

            return tabla;
        }

        public object LoadMovimientos(List<Movimiento_caja> _movimientos)
        {
            var tabla = _movimientos.Select((movimiento, index) => new
            {
                Nro = index + 1,
                Fecha = movimiento.fecha_movimiento.Day + "/" + movimiento.fecha_movimiento.Month + " - " + movimiento.fecha_movimiento.ToShortTimeString(),
                Tipo = movimiento.tipo_movimiento.descripcion_tipo,
                Descripcion = movimiento.descripcion_movimiento,
                Monto = "$ " + movimiento.monto_movimiento,
            }
            ).ToList();

            return tabla;
        }

        public object LoadPagos(List<Pago> _pagos)
        {  
            var tabla = _pagos.Select((pago, index) => new
            {
                Nro = index + 1,
                Venta = pago.id_venta.ToString(),
                Fecha = pago.fecha_pago.Day + "/" + pago.fecha_pago.Month + " - " + pago.fecha_pago.ToShortTimeString(),
                Metodo_pago = pago.metodo.descripcion_metodo,
                Importe = "$ " + pago.importe_pago,
            }
           ).ToList();

            return tabla;
        }

        // Configuramos las tablas
        public void SetUpDGVVentas()
        {
            this.DGVVentas.DataSource = null;
            this.DGVVentas.Columns.Clear();
            this.DGVVentas.Rows.Clear();

            this.DGVVentas.DataSource = LoadVentas(this.cajaResumen.ventas.OrderBy(v => v.fecha_venta).ToList());

            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CCancelar";
            btnColumnCancelar.HeaderText = "Cancelar";
            btnColumnCancelar.Text = "Cancelar";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard;
            this.DGVVentas.Columns.Add(btnColumnCancelar);
            this.DGVVentas.Columns["CCancelar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.DGVVentas.Columns["CCancelar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;

            if (this.cajaResumen.usuario.tipo_perfil != 1)
            {
                this.DGVVentas.Columns["CCancelar"].Visible = false;
            }
        }

        public void SetUpDGVMovimientos()
        {
            this.DGVMovimientos.DataSource = null;
            this.DGVMovimientos.Columns.Clear();
            this.DGVMovimientos.Rows.Clear();

            this.DGVMovimientos.DataSource = LoadMovimientos(this.cajaResumen.movimientos.OrderBy(m => m.fecha_movimiento).ToList());

            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CCancelar";
            btnColumnCancelar.HeaderText = "Cancelar";
            btnColumnCancelar.Text = "Cancelar";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard;
            this.DGVMovimientos.Columns.Add(btnColumnCancelar);
            this.DGVMovimientos.Columns["CCancelar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.DGVMovimientos.Columns["CCancelar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;

            if (this.cajaResumen.usuario.tipo_perfil != 1)
            {
                this.DGVMovimientos.Columns["CCancelar"].Visible = false;
            }
        }

        public void SetUpDGVPagos()
        {
            this.DGVPagos.DataSource = null;
            this.DGVPagos.Columns.Clear();
            this.DGVPagos.Rows.Clear();
            
            List<Pago> pagos = this.cajaResumen.ventas
                                      .SelectMany(v => v.pagos)
                                      .ToList();

            this.DGVPagos.DataSource = LoadPagos(pagos);

            DataGridViewButtonColumn btnColumnCancelar = new DataGridViewButtonColumn();
            btnColumnCancelar.Name = "CCancelar";
            btnColumnCancelar.HeaderText = "Cancelar";
            btnColumnCancelar.Text = "Cancelar";
            btnColumnCancelar.UseColumnTextForButtonValue = true;
            btnColumnCancelar.FlatStyle = FlatStyle.Standard;
            this.DGVPagos.Columns.Add(btnColumnCancelar);
            this.DGVPagos.Columns["CCancelar"].HeaderCell.Style.BackColor = Color.LightCoral;
            this.DGVPagos.Columns["CCancelar"].HeaderCell.Style.SelectionBackColor = Color.LightCoral;

            if (this.cajaResumen.usuario.tipo_perfil != 1)
            {
                this.DGVPagos.Columns["CCancelar"].Visible = false;
            }
        }

        // Extras
        private void BTNVolver_MouseEnter(object sender, EventArgs e)
        {
            this.BTVolver.ForeColor = Color.Black;
        }

        private void BTNVolver_MouseLeave(object sender, EventArgs e)
        {
            this.BTVolver.ForeColor = Color.Cyan;
        }

        private void BTNVolver_Click(object sender, EventArgs e)
        {
            this.BTVolver.ForeColor = Color.Cyan;
            this.gestion.principal.AbrirFormHijo(this.gestion);
        }
    }
}
