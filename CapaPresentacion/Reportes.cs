using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Reportes : Form
    {
        public Principal principal;
        public DateTime PEmpleadoPeriodoDesde;
        public DateTime PEmpleadoPeriodoHasta;
        public CancellationTokenSource cts;

        // Botones de reportes
        public bool BTNVentasState;
        public bool BTNGastosComprasState;
        public bool BTNGananciasNetasState;

        // Algunos botones de Ventas
        public bool BTNEmpleadoActive;
        public bool BTNProductoActive;
        public bool BTNCategoriaActive;

        public bool FiltroDesdeHasta;
        public bool FiltroDesdeHastaChart3;

        public Reportes(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.cts = new CancellationTokenSource();
            this.DisplayVentasPanel();
            this.InitDailyChart(DateTime.Now, DateTime.Now);
            this.LoadInit();
        }

        public void InitDailyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorDia(desde, hasta);

            if (ventas != null && ventas.Count > 0)
            {
                // Definimos la serie.
                string serie = "Ventas diarias";

                this.SetUpChart1(serie, ventas);

                // Cargamos el PEmpleadoPeriodoHasta 
                this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
                this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddDays(1);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde;
                DateTime fechaInit = fechaFin.AddDays(-6);

                this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                // AxisX.Minimum y AxisX.Maximum siempre se interpretan según el tipo de dato que tenga ese eje.
                /*
                    ToOADate:    
                    Convierte un DateTime en un double que representa esa fecha mediante el sistema de fechas de OLE Automation.
                    Ese double representa la fecha para componentes que trabajan internamente con números, como este Chart.
                */

                this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";

                this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                this.chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            else
            {
                return;
            }
        }

        public void InitWeeklyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();

            List<ReporteVentaDTO> ventas = venta.VentasPorSemana(desde, hasta);

            if (ventas != null && ventas.Count > 0)
            {
                // Definimos la cantidad de periodos acumulados que se muestra
                this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
                this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddDays(7).AddMilliseconds(-1);

                // Definimos la serie.
                string serie = "Ventas Semanales";

                this.SetUpChart1(serie, ventas);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde;
                DateTime fechaInit = fechaFin.AddDays(-42);

                this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yy";

                this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;
                this.chart1.ChartAreas[0].AxisX.Interval = 1;

                this.chart1.ChartAreas[0].AxisX.IntervalOffsetType = DateTimeIntervalType.Days;
                this.chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            }
            else
            {
                return;
            }
        }

        public void InitMonthlyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorMes(desde, hasta);

            if (ventas != null && ventas.Count > 0)
            {
                // Definimos la serie.
                string serie = "Ventas Mensuales";

                this.SetUpChart1(serie, ventas);

                this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
                this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(1).AddMilliseconds(-1);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde;
                DateTime fechaInit = fechaFin.AddMonths(-6);

                this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yy";

                this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                this.chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            else
            {
                return;
            }
        }

        public void InitQuarterlyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorTrimestre(desde, hasta);

            if (ventas != null && ventas.Count > 0)
            {
                // Definimos la serie.
                string serie = "Ventas Trimestrales";

                this.SetUpChart1(serie, ventas);

                this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
                this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(3);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde;
                DateTime fechaInit = fechaFin.AddMonths(-18);

                this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM-yyyy";

                this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                this.chart1.ChartAreas[0].AxisX.Interval = 3;
            }
            else
            {
                return;
            }
        }

        public void InitSemiannualChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorSemestre(desde, hasta);

            if (ventas != null && ventas.Count > 0)
            {
                // Definimos la serie.
                string serie = "Ventas Semestrales";

                this.SetUpChart1(serie, ventas);

                this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
                this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(6);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde;
                DateTime fechaInit = fechaFin.AddMonths(-36);

                this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM-yyyy";

                this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                this.chart1.ChartAreas[0].AxisX.Interval = 6;
            }
            else
            {
                return;
            }
        }

        public void InitAnnualChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorAño(desde, hasta);

            if (ventas != null && ventas.Count > 0)
            {
                // Definimos la serie.
                string serie = "Ventas Anuales";

                this.SetUpChart1(serie, ventas);

                this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
                this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddYears(1);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde;
                DateTime fechaInit = fechaFin.AddYears(-6);

                this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy";

                this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                this.chart1.ChartAreas[0].AxisX.Interval = 1;
            }
            else
            {
                return;
            }
        }

        private async void BTNFiltrar_Click(object sender, EventArgs e)
        {
            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventasEmpleado = new List<ReporteVentaEmpleadoDTO>();
            List<ReporteVentaProductoDTO> ventasProducto = new List<ReporteVentaProductoDTO>();
            List<ReporteVentaCategoriaDTO> ventasCategoria = new List<ReporteVentaCategoriaDTO>();

            // Si son iguales ambas fecha significa que no se requiere la utilizacion del filtro
            DateTime desde = this.DTPFiltroDesde.Value;
            DateTime hasta = this.DTPFiltroHasta.Value;

            this.FiltroDesdeHasta = desde < hasta;
            bool load_granularidad = this.CBGranularidad.SelectedIndex > -1;

            // Verificamos que se cumplan las condiciones neesarias para el filtrado. --> Falta mayor analisis y definir el retorno
            if (!FiltroDesdeHasta && !load_granularidad)
            {
                return;
            }

            try
            {
                // Analizamos la situacion en la que no haya seleccionada ninguna granlaridad.
                if (this.CBGranularidad.SelectedIndex < 0)
                {
                    this.InitDailyChart(desde, hasta);

                    if (this.BTNEmpleadoActive)
                    {
                        ventasEmpleado = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    if (this.BTNProductoActive)
                    {
                        ventasProducto = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    if (this.BTNCategoriaActive)
                    {
                        ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    return;
                }

                // Tambien debemos cargar el DGV con los datos que representan al ultimo elemento del Chart
                // Invocamos el metodo encargado de los datos.
                switch (this.CBGranularidad.Text)
                {
                    case "Diario":
                        this.InitDailyChart(desde, hasta);

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Semanal":
                        this.InitWeeklyChart(desde, hasta);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoSemanalProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoSemanalCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Mensual":
                        this.InitMonthlyChart(desde, hasta);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoMensualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoMensualCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Trimestral":
                        this.InitQuarterlyChart(desde, hasta);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoTrimestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoTrimestralCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Semestral":
                        this.InitSemiannualChart(desde, hasta);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoSemestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoSemestralCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Anual":
                        this.InitAnnualChart(desde, hasta);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoAnualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoAnualCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;
                }

                // Cargamos el periodo que muetra la tabla o el chart
                this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));

                // Cargamps la tabla o el chart
                if (this.BTNEmpleadoActive)
                {
                    this.LoadTableEmpleado(ventasEmpleado);
                }

                if (this.BTNProductoActive)
                {
                    this.LoadTableProducto(ventasProducto);
                }

                if (this.BTNCategoriaActive)
                {
                    this.LoadChartVentaCategoria(ventasCategoria);
                }

                // Cargamos el Panel Tickets.
                List<Venta> all_ventasPorPeriodo = venta.AllFilterVentas(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta);

                if (all_ventasPorPeriodo != null && all_ventasPorPeriodo.Count > 0)
                {
                    this.LoadPanelTicket(all_ventasPorPeriodo);
                }
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Asignaciones del Chart1 que se repiten
        public void SetUpChart1(string serie_name, List<ReporteVentaDTO> reportes)
        {
            this.chart1.Series.Clear();
            this.chart1.ChartAreas.Clear();

            // ChartArea --> Es el área donde se dibuja el gráfico. Pensalo como el "lienzo" o "panel" donde se representan una o varias series.
            this.chart1.ChartAreas.Add("ChartArea1");
            this.chart1.Series.Add(serie_name);

            // Definimos el tipo de datos que va mostrar cada eje del grafico.
            this.chart1.Series[serie_name].XValueType = ChartValueType.Date;
            this.chart1.Series[serie_name].YValueType = ChartValueType.Double;

            this.chart1.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;

            // Cargamos los datos en la serie.
            foreach (ReporteVentaDTO reporte in reportes)
            {
                this.chart1.Series[serie_name].Points.AddXY(
                reporte.fecha_acumulada,
                reporte.monto_acumulado
                );
            }

            // Seteamos el color de las etiquetas que se utilzan en los ejes.
            this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            // Determinamos que el eje Y va mostrar el double segun la CultureInfo determinada en la maquina donde se ejecuta la aplicacion --> $ en ARG
            this.chart1.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            this.chart1.ChartAreas[0].AxisY.Interval = 10000;

            // Configuramos como se ve el ChartArea
            this.chart1.ChartAreas[0].BackColor = Color.PaleTurquoise;
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;

            // Definimos el tipo de grafico que vamos a represetar
            this.chart1.Series[serie_name].ChartType = SeriesChartType.Column;

            // Hacemos esto para que no se descordine el tamaño de las columnas en funcion de la cantidad de puntos de la serie.
            if (this.principal.WindowState == FormWindowState.Maximized)
            {
                this.chart1.Series[serie_name].CustomProperties = "PixelPointWidth=30";
            }
            else
            {
                this.chart1.Series[serie_name].CustomProperties = "PixelPointWidth=8";
            }
        }

        // ----- Manejo de la seccion DGV con respecto de Ventas por: -----
        public void LoadInit()
        {
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventas_agrupadas = venta.VentasDiarioEmpleado(DateTime.Now, DateTime.Now);
            List<Venta> all_ventas = venta.AllFilterVentas(DateTime.Now, DateTime.Now);

            // Configuramos el boton incialmente.
            this.BTNVentasPor_SetUpState(this.BTNVentasPorEmpleado);

            this.BTNProductoActive = false;
            this.BTNCategoriaActive = false;

            this.BTNEmpleadoActive = true;

            if (ventas_agrupadas != null && ventas_agrupadas.Count > 0)
            {
                this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                this.LoadTableEmpleado(ventas_agrupadas.Where(v => v.periodo == this.PEmpleadoPeriodoDesde).ToList());
            }

            if (all_ventas != null && all_ventas.Count > 0)
            {
                this.LoadPanelTicket(all_ventas);
            }
        }

        // ----- Empleado y Ventas
        public object LoadTable(List<ReporteVentaEmpleadoDTO> reporte)
        {
            var tabla = reporte.Select((datos, index) => new
            {
                Empleado = datos.nombreCompleto_empleado,
                Tickets = datos.cantidad_ventas,
                ImportePromedio = "$ " + decimal.Round(datos.monto_promedio, 2).ToString(),
                MontoTotal = "$ " + datos.monto_total.ToString(),
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        public void LoadTableEmpleado(List<ReporteVentaEmpleadoDTO> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                List<ReporteVentaEmpleadoDTO> reporte = new List<ReporteVentaEmpleadoDTO>();
                this.DGVVentas.DataSource = this.LoadTable(reporte);

                this.LVTotalTickets.Text = "-";
                this.LVMontoPromedioTicket.Text = "-";
                return;
            }

            this.DGVVentas.DataSource = null;
            this.DGVVentas.Columns.Clear();
            this.DGVVentas.Rows.Clear();

            this.DGVVentas.DataSource = this.LoadTable(lista);

            // Panel Tickets
            // Vamos a crear un metodo que reciba las ventas del periodo mostrado por el DGV o por el ChartType.Pie
            this.LVTotalTickets.Text = lista.Sum(l => l.cantidad_ventas).ToString();
            this.LVMontoPromedioTicket.Text = "$" + decimal.Round((lista.Sum(l => l.monto_total) / lista.Sum(l => l.cantidad_ventas)), 2);
        }

        // ----- Producto y ventas.
        public object LoadTable(List<ReporteVentaProductoDTO> reporte)
        {
            var tabla = reporte.Select((datos, index) => new
            {
                Producto = datos.producto_completo,
                Vendidos = datos.cantidad_vendida,
                ImporteVendido = "$ " + decimal.Round(datos.importe_vendido, 2).ToString(),
                PocentajeImporteTotal = "% " + datos.porcentaje_venta_importe.ToString(),
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView   

            return tabla;
        }

        public void LoadTableProducto(List<ReporteVentaProductoDTO> lista)
        {
            if (lista == null || lista.Count == 0)
            {
                List<ReporteVentaProductoDTO> reporte = new List<ReporteVentaProductoDTO>();
                this.DGVVentas.DataSource = this.LoadTable(reporte);

                this.LVTotalTickets.Text = "-";
                this.LVMontoPromedioTicket.Text = "-";
                return;
            }

            this.DGVVentas.DataSource = null;
            this.DGVVentas.Columns.Clear();
            this.DGVVentas.Rows.Clear();

            this.DGVVentas.DataSource = this.LoadTable(lista);
        }

        // ----- Eventos botones Chart -----
        private void BTNAdelante_Click(object sender, EventArgs e)
        {
            DateTime fechaFin = DateTime.FromOADate(this.chart1.ChartAreas[0].AxisX.Maximum);
            DateTime fechaInit = DateTime.FromOADate(this.chart1.ChartAreas[0].AxisX.Minimum);

            if (this.FiltroDesdeHasta)
            {
                if (fechaFin > this.DTPFiltroHasta.Value.Date)
                {
                    return;
                }
            }

            // En caso de qu no haya seleccionada ninguna granularidad.
            if (this.CBGranularidad.SelectedIndex < 0 && this.chart1.ChartAreas[0].AxisX.Maximum < DateTime.Now.Date.ToOADate())
            {
                this.chart1.ChartAreas[0].AxisX.Minimum++;
                this.chart1.ChartAreas[0].AxisX.Maximum++;
            }

            switch (this.CBGranularidad.Text)
            {
                case "Diario":
                    this.chart1.ChartAreas[0].AxisX.Minimum++;
                    this.chart1.ChartAreas[0].AxisX.Maximum++;
                    break;

                case "Semanal":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddDays(7).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddDays(7).ToOADate();
                    break;

                case "Mensual":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(1).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(1).ToOADate();
                    break;

                case "Trimestral":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(3).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(3).ToOADate();
                    break;

                case "Semestral":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(6).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(6).ToOADate();
                    break;

                case "Anual":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddYears(1).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddYears(1).ToOADate();
                    break;
            }
        }

        private void BTNAtras_Click(object sender, EventArgs e)
        {
            DateTime fechaFin = DateTime.FromOADate(this.chart1.ChartAreas[0].AxisX.Maximum);
            DateTime fechaInit = DateTime.FromOADate(this.chart1.ChartAreas[0].AxisX.Minimum);

            if (this.FiltroDesdeHasta)
            {
                if (fechaInit < this.DTPFiltroDesde.Value.Date && this.CBGranularidad.SelectedText != "Semanal")
                {
                    return;
                }

                if (fechaInit < this.DTPFiltroDesde.Value.Date && this.CBGranularidad.SelectedText == "Semanal")
                {
                    // La semana arranca en domingo == 0, Lunes == 1, etc ...
                    int InitWeekly = (int)this.DTPFiltroDesde.Value.Date.DayOfWeek - (int)DayOfWeek.Monday; // int diasDesdeLunes = (int)fecha.DayOfWeek - (int)DayOfWeek.Monday;

                    if (InitWeekly < 0)
                    {
                        InitWeekly += 7;
                    }

                    fechaInit.AddDays(-InitWeekly);

                    if ((fechaInit - this.DTPFiltroDesde.Value.Date).Days > 6) return;
                }
            }

            // En caso de que no haya seleccionada ninguna granularidad
            if (this.CBGranularidad.SelectedIndex < 0 && this.chart1.ChartAreas[0].AxisX.Minimum > 0)
            {
                this.chart1.ChartAreas[0].AxisX.Minimum--;
                this.chart1.ChartAreas[0].AxisX.Maximum--;
            }

            switch (this.CBGranularidad.Text)
            {
                case "Diario":
                    this.chart1.ChartAreas[0].AxisX.Minimum--;
                    this.chart1.ChartAreas[0].AxisX.Maximum--;
                    break;

                case "Semanal":
                    // Como es tan mogolico el grafico hay que cargarle los valores totalmente nuevos
                    DateTime nuevoFin = fechaFin.AddDays(-7);
                    DateTime nuevoInit = nuevoFin.AddDays(-42);
                    this.chart1.ChartAreas[0].AxisX.Minimum = nuevoInit.ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = nuevoFin.ToOADate();
                    break;

                case "Mensual":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-1).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-1).ToOADate();
                    break;

                case "Trimestral":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-3).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-3).ToOADate();
                    break;

                case "Semestral":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-6).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-6).ToOADate();
                    break;

                case "Anual":
                    this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.AddYears(-1).ToOADate();
                    this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.AddYears(-1).ToOADate();
                    break;
            }
        }

        private async void BTNAdelantePVentaPor_Click(object sender, EventArgs e)
        {
            if (this.PEmpleadoPeriodoDesde == null)
            {
                MessageBox.Show("Y que hijodbeuu");
                return;
            }

            if (this.FiltroDesdeHasta)
            {
                if (this.PEmpleadoPeriodoHasta > this.DTPFiltroHasta.Value.Date)
                {
                    MessageBox.Show("Actualmente se encuentra filtrando por fecha y solo podra seguir desplazando dentro de dicho periodo.", "Fuera de rango.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Verificar que la condicion es realmente la que necesitamos
            if (this.PEmpleadoPeriodoHasta == null || this.PEmpleadoPeriodoHasta > DateTime.Now) return;

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventasEmpleado = new List<ReporteVentaEmpleadoDTO>();
            List<ReporteVentaProductoDTO> ventasProducto = new List<ReporteVentaProductoDTO>();
            List<ReporteVentaCategoriaDTO> ventasCategoria = new List<ReporteVentaCategoriaDTO>();

            try
            {
                if (this.CBGranularidad.SelectedIndex < 0)
                {
                    this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(1);
                    this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(1);

                    if (this.BTNEmpleadoActive)
                    {
                        ventasEmpleado = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    if (this.BTNProductoActive)
                    {
                        ventasProducto = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    if (this.BTNCategoriaActive)
                    {
                        ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }
                }

                // Probablemente la porcion de codigo a estandarizar va ser el manejo mediante el switch. -- Principalmente el PEmpleadoPeriodoDesde y PEmpleadoPeriodoHasta.
                // La carga incial ya funciona falta reveer la asignaciones de fecha aca porque PEmpladoHasta ya viene cargado, cosa que antes no ocurria.
                switch (this.CBGranularidad.Text)
                {
                    case "Diario":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(1);

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Semanal":

                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMilliseconds(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddDays(7).AddMilliseconds(-1);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoSemanalProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Mensual":

                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMilliseconds(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(1).AddMilliseconds(-1);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoMensualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Trimestral":

                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMilliseconds(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(3).AddMilliseconds(-1);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoTrimestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Semestral":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMilliseconds(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(6).AddMilliseconds(-1);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoSemestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Anual":

                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMilliseconds(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddYears(1).AddMilliseconds(-1);

                        if (this.FiltroDesdeHasta)
                        {
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date.AddDays(1).AddMilliseconds(-1);
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoAnualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;
                }

                this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));

                if (this.BTNEmpleadoActive)
                {
                    this.LoadTableEmpleado(ventasEmpleado);
                }

                if (this.BTNProductoActive)
                {
                    this.LoadTableProducto(ventasProducto);
                }

                if (this.BTNCategoriaActive)
                {
                    this.LoadChartVentaCategoria(ventasCategoria);
                }

                // Cargamos el Panel Tickets.
                List<Venta> all_ventasPorPeriodo = venta.AllFilterVentas(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta);

                if (all_ventasPorPeriodo != null && all_ventasPorPeriodo.Count > 0)
                {
                    this.LoadPanelTicket(all_ventasPorPeriodo);
                }

            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BTNAtrasPVentaPor_Click(object sender, EventArgs e)
        {
            // Podriamos pegar una limpieza al DGV.
            if (this.PEmpleadoPeriodoDesde == null) return;

            if (this.FiltroDesdeHasta)
            {
                if (this.PEmpleadoPeriodoDesde <= this.DTPFiltroDesde.Value.Date)
                {
                    MessageBox.Show("Actualmente se encuentra filtrando por fecha y solo podra seguir desplazando dentro de dicho periodo.", "Fuera de rango.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventasEmpleado = new List<ReporteVentaEmpleadoDTO>();
            List<ReporteVentaProductoDTO> ventasProducto = new List<ReporteVentaProductoDTO>();
            List<ReporteVentaCategoriaDTO> ventasCategoria = new List<ReporteVentaCategoriaDTO>();

            try
            {
                if (this.CBGranularidad.SelectedIndex < 0)
                {
                    this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(-1);
                    this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(-1);

                    if (this.BTNEmpleadoActive)
                    {
                        ventasEmpleado = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    if (this.BTNProductoActive)
                    {
                        ventasProducto = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }

                    if (this.BTNCategoriaActive)
                    {
                        ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                    }
                }

                // Probablemente la porcion de codigo a estandarizar va ser el manejo mediante el switch. -- Principalmente el PEmpleadoPeriodoDesde y PEmpleadoPeriodoHasta.
                // La carga incial ya funciona falta reveer la asignaciones de fecha aca porque PEmpladoHasta ya viene cargado, cosa que antes no ocurria.
                switch (this.CBGranularidad.Text)
                {
                    case "Diario":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(-1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(-1);

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Semanal":

                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMilliseconds(-1);
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddDays(-7).AddMilliseconds(1);

                        if (this.FiltroDesdeHasta)
                        {
                            // Creo que basta con consultar por solo el if del limite inferior.
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date;
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoSemanalProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoSemanalCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Mensual":

                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMilliseconds(-1);
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMonths(-1).AddMilliseconds(1);

                        if (this.FiltroDesdeHasta)
                        {
                            // Creo que basta con consultar por solo el if del limite inferior.
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date;
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoMensualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoMensualCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Trimestral":

                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMilliseconds(-1);
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMonths(-3).AddMilliseconds(1);

                        if (this.FiltroDesdeHasta)
                        {
                            // Creo que basta con consultar por solo el if del limite inferior.
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date;
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoTrimestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoTrimestralCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Semestral":
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMilliseconds(-1);
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddMonths(-6).AddMilliseconds(1);

                        if (this.FiltroDesdeHasta)
                        {
                            // Creo que basta con consultar por solo el if del limite inferior.
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date;
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoSemestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoSemestralCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;

                    case "Anual":
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMilliseconds(-1);
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoHasta.AddYears(-1).AddMilliseconds(1);

                        if (this.FiltroDesdeHasta)
                        {
                            // Creo que basta con consultar por solo el if del limite inferior.
                            if (this.DTPFiltroHasta.Value.Date < this.PEmpleadoPeriodoHasta)
                            {
                                this.PEmpleadoPeriodoHasta = this.DTPFiltroHasta.Value.Date;
                            }

                            if (this.DTPFiltroDesde.Value.Date > this.PEmpleadoPeriodoDesde)
                            {
                                this.PEmpleadoPeriodoDesde = this.DTPFiltroDesde.Value.Date;
                            }
                        }

                        if (this.BTNEmpleadoActive)
                        {
                            ventasEmpleado = await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNProductoActive)
                        {
                            ventasProducto = await venta.VentasPeriodoAnualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        if (this.BTNCategoriaActive)
                        {
                            ventasCategoria = await venta.VentasPeriodoAnualCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        }

                        break;
                }

                // Cargamos el Labell del periodo mostrado.
                this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));

                // Cargamos el DGV o el Chart correspondiente.
                if (this.BTNEmpleadoActive)
                {
                    this.LoadTableEmpleado(ventasEmpleado);
                }

                if (this.BTNProductoActive)
                {
                    this.LoadTableProducto(ventasProducto);
                }

                if (this.BTNCategoriaActive)
                {
                    this.LoadChartVentaCategoria(ventasCategoria);
                }

                // Cargamos el Panel Tickets.
                List<Venta> all_ventasPorPeriodo = venta.AllFilterVentas(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta);

                if (all_ventasPorPeriodo != null && all_ventasPorPeriodo.Count > 0)
                {
                    this.LoadPanelTicket(all_ventasPorPeriodo);
                }
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadPeriodoDesdeHasta(DateTime desde, DateTime hasta)
        {
            if (desde.Date == hasta.Date)
            {
                this.LPeriodo.Visible = true;
                this.LPeriodoDesdeHasta.Visible = false;
                this.LPeriodo.Text = desde.ToShortDateString();
            }
            else
            {
                this.LPeriodoDesdeHasta.Visible = true;
                this.LPeriodo.Visible = false;
                this.LPeriodoDesdeHasta.Text = desde.ToShortDateString() + " - " + hasta.ToShortDateString();
            }
        }

        // En estos dos eventos Cclick nos faltaria tener en cuenta la granularidad, es decir, filtrar de nuevo
        private async void BTNVentasPorProducto_Click(object sender, EventArgs e)
        {
            this.DGVVentas.Visible = true;
            this.chart2.Visible = false;

            // Instanciamos algunas variables necesarias.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaProductoDTO> reporte = new List<ReporteVentaProductoDTO>();
            Button boton = sender as Button; // Recibo el boton que ejecuta el evento

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            // Y lo configuro
            this.BTNVentasPor_SetUpState(boton);

            // Luego seteo las variables bool para controlar los botones
            this.BTNEmpleadoActive = false;
            this.BTNCategoriaActive = false;

            this.BTNProductoActive = true;

            // Segun la granularidad al momento de presionar el boton cargamos los valores correspondientes
            try
            {
                switch (this.CBGranularidad.Text)
                {
                    case "":
                        reporte = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Diario":
                        reporte = await venta.VentasPeriodoDiarioProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Semanal":
                        reporte = await venta.VentasPeriodoSemanalProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Mensual":
                        reporte = await venta.VentasPeriodoMensualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Trimestral":
                        reporte = await venta.VentasPeriodoTrimestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Semestral":
                        reporte = await venta.VentasPeriodoSemestralProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Anual":
                        reporte = await venta.VentasPeriodoAnualProductoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;
                }

                // Cargamos el DGV
                this.LoadTableProducto(reporte);
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void BTNVentasPorEmpleado_Click(object sender, EventArgs e)
        {
            this.DGVVentas.Visible = true;
            this.chart2.Visible = false;

            // Instanciamos algunas variables necesarias.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> reporte = new List<ReporteVentaEmpleadoDTO>();
            Button boton = sender as Button; // Recibo el boton que ejecuta el evento

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            // Y lo configuro
            this.BTNVentasPor_SetUpState(boton);

            // Luego seteo las variables bool para controlar los botones
            this.BTNProductoActive = false;
            this.BTNCategoriaActive = false;

            this.BTNEmpleadoActive = true;

            // Segun la granularidad al momento de presionar el boton cargamos los valores correspondientes
            try
            {
                switch (this.CBGranularidad.Text)
                {
                    case "":
                        reporte = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Diario":
                        reporte = await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Semanal":
                        reporte = await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Mensual":
                        reporte = await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Trimestral":
                        reporte = await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Semestral":
                        reporte = await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Anual":
                        reporte = await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;
                }

                // Cargamos el DGV
                this.LoadTableEmpleado(reporte);
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Aca tenemos las funciones necesarias para cargar el Char para el reporte de Categoria - Ventas.
        private async void BTNVentasPorCategoria_Click(object sender, EventArgs e)
        {
            this.DGVVentas.Visible = false;
            this.chart2.Visible = true;

            // Instanciamos algunas variables necesarias.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaCategoriaDTO> reporte = new List<ReporteVentaCategoriaDTO>();
            Button boton = sender as Button; // Recibo el boton que ejecuta el evento

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            // Y lo configuro
            this.BTNVentasPor_SetUpState(boton);

            // Luego seteo las variables bool para controlar los botones
            this.BTNProductoActive = false;
            this.BTNEmpleadoActive = false;

            this.BTNCategoriaActive = true;

            try
            {
                switch (this.CBGranularidad.Text)
                {
                    case "":
                        reporte = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Diario":
                        reporte = await venta.VentasPeriodoDiarioCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Semanal":
                        reporte = await venta.VentasPeriodoSemanalCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Mensual":
                        reporte = await venta.VentasPeriodoMensualCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Trimestral":
                        reporte = await venta.VentasPeriodoTrimestralCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Semestral":
                        reporte = await venta.VentasPeriodoSemestralCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;

                    case "Anual":
                        reporte = await venta.VentasPeriodoAnualCategoriaAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token);
                        break;
                }

                // Debemos setearr el Chart2
                this.LoadChartVentaCategoria(reporte);
            }
            catch (TaskCanceledException)
            {
                // La consulta fue cancelada, no hacemos nada   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------
        public void BTNVentasPor_SetUpState(Button boton)
        {
            foreach (Control control in this.flowLayoutPanel1.Controls)
            {
                if (control is Button)
                {
                    if (control.Name != boton.Name)
                    {
                        control.BackColor = System.Drawing.Color.LightGray;
                    }
                    else
                    {
                        boton.BackColor = System.Drawing.Color.DarkGray;
                    }
                }
            }
        }
        public void LoadChartVentaCategoria(List<ReporteVentaCategoriaDTO> reporte)
        {
            string serie = "Ventas por Categoria";

            this.SetUpChart2(serie, reporte);
        }

        public void SetUpChart2(string serie_name, List<ReporteVentaCategoriaDTO> reportes)
        {
            // Vamos agrupar en una nueva lista de reportes a aquellos que no represente un porcentaje significativo en la torta y a ese grupo lo llamaremos "Otros".
            // List<ReporteVentaCategoriaDTO> 
            this.chart2.Series.Clear();
            this.chart2.ChartAreas.Clear();

            if (reportes == null || reportes.Count == 0) return;

            // ChartArea --> Es el área donde se dibuja el gráfico. Pensalo como el "lienzo" o "panel" donde se representan una o varias series.
            this.chart2.ChartAreas.Add("ChartArea1");
            this.chart2.Series.Add(serie_name);

            // Definimos el tipo de datos que va mostrar cada eje del grafico.
            this.chart2.Series[serie_name].XValueType = ChartValueType.String;
            this.chart2.Series[serie_name].YValueType = ChartValueType.Double;

            // Cargamos los datos en la serie.
            foreach (ReporteVentaCategoriaDTO reporte in reportes)
            {
                this.chart2.Series[serie_name].Points.AddXY(
                    reporte.nombre_categoria,
                    reporte.importe_vendido
                );
            }

            this.chart2.Series[serie_name].IsValueShownAsLabel = true;
            this.chart2.Series[serie_name].Label = "$#VALY (#PERCENT)";
            this.chart2.Series[serie_name].LegendText = "#VALX";

            // Definimos el tipo de grafico que vamos a represetar
            this.chart2.Series[serie_name].ChartType = SeriesChartType.Pie;
        }

        public void LoadPanelTicket(List<Venta> _ventas)
        {
            if (_ventas == null || _ventas.Count == 0)
            {
                this.LVTotalTickets.Text = "-";
                this.LVMontoPromedioTicket.Text = "-";
            }
            else
            {
                decimal monto_acumulado = _ventas.Sum(v => v.monto_venta);
                this.LVTotalTickets.Text = "$" + monto_acumulado;
                this.LVMontoPromedioTicket.Text = "$" + decimal.Round((monto_acumulado / _ventas.Count), 2);
            }
        }

        private void Reportes_Resize(object sender, EventArgs e)
        {
            if (this.BTNVentasState) return;

            this.BTNVentasState = true;

            string serie_name = this.chart1.Series.First().Name;

            if (this.principal.WindowState == FormWindowState.Maximized)
            {
                this.chart1.Series[serie_name].CustomProperties = "PixelPointWidth=30";
            }
            else
            {
                this.chart1.Series[serie_name].CustomProperties = "PixelPointWidth=8";
            }
        }

        // Tratamiento y eventos asociados al control principal de los reportes.
        private void BTNVentas_Click(object sender, EventArgs e)
        {
            this.DisplayVentasPanel();
        }

        private void BTNGastosCompras_Click(object sender, EventArgs e)
        {
            this.DisplayGastosComprasPanel();
            this.LoadInitRerporteGastosCompras();
            this.LoadCBAñoGastosCompras();
        }

        private void BTNGanancias_Click(object sender, EventArgs e)
        {
            this.DisplayGananciasPanel();
        }

        public void DisplayVentasPanel()
        {
            this.TLPGastosCompras.Visible = false;
            // this.TLPGanancia.Visible = false;

            this.TLPVentas.Visible = true;
        }

        public void DisplayGastosComprasPanel()
        {
            this.TLPVentas.Visible = false;
            // this.TLPGanancia.Visible = false;

            this.TLPGastosCompras.Visible = true;
        }

        public void DisplayGananciasPanel()
        {
            this.TLPVentas.Visible = false;
            this.TLPGastosCompras.Visible = false;

            // this.TLPGanancia.Visible = true;
        }

        // Cargamos los CB para el Panel Gastos / Compras
        public void LoadInitRerporteGastosCompras()
        {
            // Periodo mes.
            Dictionary<int, string> meses = new Dictionary<int, string>();

            meses.Add(1, "Enero");
            meses.Add(2, "Febrero");
            meses.Add(3, "Marzo");
            meses.Add(4, "Abril");
            meses.Add(5, "Mayo");
            meses.Add(6, "Junio");
            meses.Add(7, "Julio");
            meses.Add(8, "Agosto");
            meses.Add(9, "Septiembre");
            meses.Add(10, "Octubre");
            meses.Add(11, "Noviembre");
            meses.Add(12, "Diciembre");

            this.CBMesDesdeGastoCompra.DisplayMember = "Value";
            this.CBMesDesdeGastoCompra.ValueMember = "Key";
            this.CBMesDesdeGastoCompra.DataSource = meses.ToList();
            this.CBMesDesdeGastoCompra.SelectedIndex = -1;

            this.CBMesHastaGastoCompra.DisplayMember = "Value";
            this.CBMesHastaGastoCompra.ValueMember = "Key";
            this.CBMesHastaGastoCompra.DataSource = meses.ToList();
            this.CBMesHastaGastoCompra.SelectedIndex = -1;

            this.InitMonthlyChartGastosCompras(DateTime.Now, DateTime.Now);
        }

        public void InitMonthlyChartGastosCompras(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos. -- Aca vamos a consultar los gastos y las compras
            CN_Gasto gasto = new CN_Gasto();
            CN_Compra compra = new CN_Compra();

            List<ReporteGastoCategoriaDTO> reportes_gastos = gasto.GastosCategoriaPorMes(desde, hasta);
            List<ReporteComprasDTO> reportes_compras = compra.ComprasConfirmadasPorMes(desde, hasta);

            if ((reportes_gastos != null && reportes_gastos.Count > 0) || (reportes_compras != null && reportes_compras.Count > 0))
            {
                // Definimos la serie.
                this.SetUpChartGastosCompras(reportes_gastos, reportes_compras);

                DateTime fechaFin = this.PEmpleadoPeriodoDesde.AddMonths(1);
                DateTime fechaInit = fechaFin.AddMonths(-6);

                this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                // Debemos rellenar los Points que no tengan periodo acumulado

                this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yy";

                this.chart3.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                this.chart3.ChartAreas[0].AxisX.Interval = 1;
            }
            else
            {
                return;
            }
        }

        public void InitQuarterlyChartGastosCompras(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos. -- Aca vamos a consultar los gastos y las compras
            CN_Gasto gasto = new CN_Gasto();
            CN_Compra compra = new CN_Compra();

            List<ReporteGastoCategoriaDTO> reportes_gastos = gasto.GastosCategoriaPorTrimestre(desde, hasta);
            List<ReporteComprasDTO> reportes_compras = compra.ComprasConfirmadasPorTrimestre(desde, hasta);

            if ((reportes_gastos != null && reportes_gastos.Count > 0) || (reportes_compras != null && reportes_compras.Count > 0))
            {
                // Definimos la serie.
                this.SetUpChartGastosCompras(reportes_gastos, reportes_compras);

                // DateTime fechaFin = ventas.Last().fecha_acumulada;
                DateTime fechaFin = this.PEmpleadoPeriodoDesde.AddMonths(3);
                DateTime fechaInit = fechaFin.AddMonths(-18);

                this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "MM-yyyy";

                this.chart3.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                this.chart3.ChartAreas[0].AxisX.Interval = 3;
            }
            else
            {
                return;
            }
        }

        public void InitSemiannualChartGastosCompras(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos. -- Aca vamos a consultar los gastos y las compras
            CN_Gasto gasto = new CN_Gasto();
            CN_Compra compra = new CN_Compra();

            List<ReporteGastoCategoriaDTO> reportes_gastos = gasto.GastosCategoriaPorSemestre(desde, hasta);
            List<ReporteComprasDTO> reportes_compras = compra.ComprasConfirmadasPorSemestre(desde, hasta);

            if ((reportes_gastos != null && reportes_gastos.Count > 0) || (reportes_compras != null && reportes_compras.Count > 0))
            {
                // Definimos la serie.
                this.SetUpChartGastosCompras(reportes_gastos, reportes_compras);

                DateTime fechaFin = this.PEmpleadoPeriodoDesde.AddMonths(6);
                DateTime fechaInit = fechaFin.AddMonths(-36);

                this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "MM-yyyy";

                this.chart3.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
                this.chart3.ChartAreas[0].AxisX.Interval = 6;
            }
            else
            {
                return;
            }
        }

        public void InitAnnualChartGastosCompras(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos. -- Aca vamos a consultar los gastos y las compras
            CN_Gasto gasto = new CN_Gasto();
            CN_Compra compra = new CN_Compra();

            List<ReporteGastoCategoriaDTO> reportes_gastos = gasto.GastosCategoriaPorAño(desde, hasta);
            List<ReporteComprasDTO> reportes_compras = compra.ComprasConfirmadasPorAño(desde, hasta);

            if ((reportes_gastos != null && reportes_gastos.Count > 0) || (reportes_compras != null && reportes_compras.Count > 0))
            {
                // Definimos la serie.
                this.SetUpChartGastosCompras(reportes_gastos, reportes_compras);

                DateTime fechaFin = this.PEmpleadoPeriodoDesde.AddYears(1);
                DateTime fechaInit = fechaFin.AddYears(-6);

                this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
                this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

                this.chart3.ChartAreas[0].AxisX.LabelStyle.Format = "yyyy";

                this.chart3.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Years;
                this.chart3.ChartAreas[0].AxisX.Interval = 1;
            }
            else
            {
                MessageBox.Show("No se han encontrado elementos que cumplan con la condicion de filtrado.", "Busqueda sin resultados.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        public void SetUpChartGastosCompras(List<ReporteGastoCategoriaDTO> reportes_gastos, List<ReporteComprasDTO> reportes_compras)
        {
            DateTime fechaInit = new DateTime();
            DateTime fechaFin = new DateTime();

            this.chart3.Series.Clear();
            this.chart3.ChartAreas.Clear();

            // Aca realizamos el manejo correspondiente de la fecha.
            bool exist_reporteGastos = reportes_gastos != null && reportes_gastos.Count > 0 ? true : false;
            bool exist_reporteCompras = reportes_compras != null && reportes_compras.Count > 0 ? true : false;
            bool init_param = exist_reporteGastos && exist_reporteCompras ? true : false;

            if (init_param)
            {
                this.PEmpleadoPeriodoDesde = reportes_gastos.Last().periodo_reportado >= reportes_compras.Last().periodo_reportado ? reportes_gastos.Last().periodo_reportado : reportes_compras.Last().periodo_reportado;
                fechaFin = this.PEmpleadoPeriodoDesde;
                fechaInit = reportes_gastos.First().periodo_reportado <= reportes_compras.First().periodo_reportado ? fechaInit = reportes_gastos.First().periodo_reportado : reportes_compras.First().periodo_reportado;
            }

            // Creo que no cubre todas las posibilidades
            if (!init_param && !exist_reporteGastos && exist_reporteCompras)
            {
                this.PEmpleadoPeriodoDesde = reportes_compras.Last().periodo_reportado;
                fechaFin = this.PEmpleadoPeriodoDesde;
                fechaInit = reportes_compras.First().periodo_reportado;
            }

            if (!init_param && !exist_reporteCompras && exist_reporteGastos)
            {
                this.PEmpleadoPeriodoDesde = reportes_gastos.Last().periodo_reportado;
                fechaFin = this.PEmpleadoPeriodoDesde;
                fechaInit = reportes_gastos.First().periodo_reportado;
            }

            // ChartArea --> Es el área donde se dibuja el gráfico. Pensalo como el "lienzo" o "panel" donde se representan una o varias series.
            this.chart3.ChartAreas.Add("ChartArea3");

            // Iniciamos Series para Compras y todas las categorias de gasto.
            CN_CategoriaGasto categoria = new CN_CategoriaGasto();
            List<Categoria_gasto> categorias = categoria.AllCategoriesActive();

            this.chart3.Series.Add("Compras");
            this.chart3.Series["Compras"].XValueType = ChartValueType.Date;
            this.chart3.Series["Compras"].YValueType = ChartValueType.Double;
            this.chart3.Series["Compras"].ChartType = SeriesChartType.StackedColumn;

            this.chart3.Series["Compras"].Font = new System.Drawing.Font("Arial", 6.5f, System.Drawing.FontStyle.Bold);
            this.chart3.Series["Compras"].LabelForeColor = System.Drawing.Color.Black;

            foreach (Categoria_gasto item in categorias)
            {
                this.chart3.Series.Add(item.descripcion_categoria);

                this.chart3.Series[item.descripcion_categoria].XValueType = ChartValueType.Date;
                this.chart3.Series[item.descripcion_categoria].YValueType = ChartValueType.Double;
                this.chart3.Series[item.descripcion_categoria].ChartType = SeriesChartType.StackedColumn;

                this.chart3.Series[item.descripcion_categoria].Font = new System.Drawing.Font("Arial", 6.5f /* 10.5f*/, System.Drawing.FontStyle.Bold);
                this.chart3.Series[item.descripcion_categoria].LabelForeColor = System.Drawing.Color.Black;
            }
             
            this.LoadInitSeriesGastosCompras(fechaInit, fechaFin);

            // Aca, como nuestro chart es un StackedColumn, yo debo cargar cada uno de los elementos agrupados (categoria y fecha) y las compras (fecha) como series.
            // Me parece que tambien sera un foreach qwue recorra los reportes
            if (exist_reporteCompras)
            {
                foreach (ReporteComprasDTO reporte in reportes_compras)
                {
                    int data_preLoad = -1;
                    DataPoint encontrado = this.chart3.Series["Compras"].Points.FindByValue(reporte.periodo_reportado.ToOADate(), "X");

                    if (encontrado != null)
                    {
                        data_preLoad = this.chart3.Series["Compras"].Points.IndexOf(encontrado); //this.chart3.Series["Compras"].Points.FindByValue(reporte.periodo_reportado.ToOADate());
                    }

                    if (data_preLoad > -1)
                    {
                        this.chart3.Series["Compras"].Points[data_preLoad].XValue = reporte.periodo_reportado.ToOADate();
                        this.chart3.Series["Compras"].Points[data_preLoad].SetValueY(reporte.monto_acumulado); // this.chart3.Series["Compras"].Points[data_preLoad].YValues[0] = reporte.monto_acumulado;

                        this.chart3.Series["Compras"].Points[data_preLoad].IsValueShownAsLabel = true;
                        this.chart3.Series["Compras"].Points[data_preLoad].LabelFormat = "C0";
                    }

                }
            }

            // Cargamos los datos por categorias en la series.
            if (exist_reporteGastos)
            {
                foreach (ReporteGastoCategoriaDTO reporte in reportes_gastos)
                {
                    int data_preLoad = -1;
                    DataPoint encontrado = this.chart3.Series[reporte.nombre_categoria].Points.FindByValue(reporte.periodo_reportado.ToOADate(), "X");

                    if (encontrado != null)
                    {
                        data_preLoad = this.chart3.Series[reporte.nombre_categoria].Points.IndexOf(encontrado);
                    }

                    if (data_preLoad > -1)
                    {
                        this.chart3.Series[reporte.nombre_categoria].Points[data_preLoad].XValue = reporte.periodo_reportado.ToOADate();
                        this.chart3.Series[reporte.nombre_categoria].Points[data_preLoad].SetValueY(reporte.gasto_acumulado);

                        this.chart3.Series[reporte.nombre_categoria].Points[data_preLoad].IsValueShownAsLabel = true;
                        this.chart3.Series[reporte.nombre_categoria].Points[data_preLoad].LabelFormat = "C0";
                    }
                }
            }
              
            this.chart3.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;

            // Seteamos el color de las etiquetas que se utilzan en los ejes.
            this.chart3.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            this.chart3.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            // Determinamos que el eje Y va mostrar el double segun la CultureInfo determinada en la maquina donde se ejecuta la aplicacion --> $ en ARG
            this.chart3.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
            this.chart3.ChartAreas[0].AxisY.Interval = double.NaN;

            // Configuramos como se ve el ChartArea
            this.chart3.ChartAreas[0].BackColor = Color.PaleTurquoise;
            this.chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            this.chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
        }

        private void BTNGastosComprasAtras_Click(object sender, EventArgs e)
        {
            DateTime fechaFin = DateTime.FromOADate(this.chart3.ChartAreas[0].AxisX.Maximum);
            DateTime fechaInit = DateTime.FromOADate(this.chart3.ChartAreas[0].AxisX.Minimum);

            int anioDesde = 2000;
            int mesDesde = 1;

            int anioHasta = 2000;
            int mesHasta = 1;

            if (this.CBMesDesdeGastoCompra.SelectedIndex > -1 && this.CBAnioDesdeGastoCompra.SelectedIndex > -1) 
            { 
                anioDesde = int.TryParse(this.CBAnioDesdeGastoCompra.SelectedText, out int anio)? anio: DateTime.Now.Year;
                mesDesde = this.CBMesDesdeGastoCompra.SelectedIndex + 1;
            }

            DateTime fechaDesde = new DateTime(anioDesde, mesDesde, 1);
           
            if (this.CBMesHastaGastoCompra.SelectedIndex > -1 && this.CBAnioHastaGastoCompra.SelectedIndex > -1)
            {
                anioHasta = int.TryParse(this.CBAnioHastaGastoCompra.SelectedText, out int anio2) ? anio2 : DateTime.Now.Year;
                mesHasta = this.CBMesHastaGastoCompra.SelectedIndex + 1;
            }
            
            DateTime fechaHasta = new DateTime(anioDesde, mesDesde, 1);

            bool filter_active = fechaDesde < fechaHasta;

            if (filter_active)
            {
                if (fechaInit < fechaDesde)
                {
                    return;
                }
            }

            // En caso de que no haya seleccionada ninguna granularidad
            if (this.CBGranularidadGastosCompras.SelectedIndex < 0 && this.chart3.ChartAreas[0].AxisX.Minimum > 0)
            {
                this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-1).ToOADate();
                this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-1).ToOADate();

                return;
            }

            switch (this.CBGranularidad.Text)
            { 
                case "Mensual":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-1).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-1).ToOADate();
                    break;

                case "Trimestral":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-3).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-3).ToOADate();
                    break;

                case "Semestral":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(-6).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(-6).ToOADate();
                    break;

                case "Anual":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddYears(-1).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddYears(-1).ToOADate();
                    break;
            }
        }

        private void BTNGastosComprasAdelante_Click(object sender, EventArgs e)
        {
            DateTime fechaFin = DateTime.FromOADate(this.chart3.ChartAreas[0].AxisX.Maximum);
            DateTime fechaInit = DateTime.FromOADate(this.chart3.ChartAreas[0].AxisX.Minimum);

            int anioDesde = 2000;
            int mesDesde = 1;

            int anioHasta = 2000;
            int mesHasta = 1;

            if (this.CBMesDesdeGastoCompra.SelectedIndex > -1 && this.CBAnioDesdeGastoCompra.SelectedIndex > -1)
            {
                anioDesde = int.TryParse(this.CBAnioDesdeGastoCompra.SelectedText, out int anio) ? anio : DateTime.Now.Year;
                mesDesde = this.CBMesDesdeGastoCompra.SelectedIndex + 1;
            }

            DateTime fechaDesde = new DateTime(anioDesde, mesDesde, 1);

            if (this.CBMesHastaGastoCompra.SelectedIndex > -1 && this.CBAnioHastaGastoCompra.SelectedIndex > -1)
            {
                anioHasta = int.TryParse(this.CBAnioHastaGastoCompra.SelectedText, out int anio2) ? anio2 : DateTime.Now.Year;
                mesHasta = this.CBMesHastaGastoCompra.SelectedIndex + 1;
            }

            DateTime fechaHasta = new DateTime(anioHasta, mesHasta, 1);

            bool filter_active = fechaDesde < fechaHasta;

            if (filter_active)
            {
                if (fechaFin > fechaHasta)
                {
                    return;
                }
            }

            if (fechaFin > new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)) return;

            // En caso de que no haya seleccionada ninguna granularidad
            if (this.CBGranularidadGastosCompras.SelectedIndex < 0 )// && this.chart3.ChartAreas[0].AxisX.Minimum > 0)
            {
                this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(1).ToOADate();
                this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(1).ToOADate();

                return;
            }

            switch (this.CBGranularidad.Text)
            {
                case "Mensual":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(1).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(1).ToOADate();
                    break;

                case "Trimestral":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(3).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(3).ToOADate();
                    break;

                case "Semestral":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddMonths(6).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddMonths(6).ToOADate();
                    break;

                case "Anual":
                    this.chart3.ChartAreas[0].AxisX.Minimum = fechaInit.AddYears(1).ToOADate();
                    this.chart3.ChartAreas[0].AxisX.Maximum = fechaFin.AddYears(1).ToOADate();
                    break;
            }
        }

        private void BTNFiltrarGastosCompras_Click(object sender, EventArgs e)
        {
            // Traemos los datos que necesitamos. -- Aca vamos a consultar los gastos y las compras
            CN_Gasto gasto = new CN_Gasto();
            CN_Compra compra = new CN_Compra();

            List<ReporteGastoCategoriaDTO> reportes_gastos = new List<ReporteGastoCategoriaDTO>();
            List<ReporteComprasDTO> reportes_compras = new List<ReporteComprasDTO>();

            DateTime fechaFin = DateTime.FromOADate(this.chart3.ChartAreas[0].AxisX.Maximum);
            DateTime fechaInit = DateTime.FromOADate(this.chart3.ChartAreas[0].AxisX.Minimum);

            DateTime fechaDesde = DateTime.Now.Date;
            DateTime fechaHasta = DateTime.Now.Date;

            if (this.CBMesDesdeGastoCompra.SelectedIndex > -1 && this.CBAnioDesdeGastoCompra.SelectedIndex > -1)
            {
                int anioDesde = int.TryParse(this.CBAnioDesdeGastoCompra.SelectedText, out int anio) ? anio : DateTime.Now.Year;
                int mesDesde = this.CBMesDesdeGastoCompra.SelectedIndex + 1;
                fechaDesde = new DateTime(anioDesde, mesDesde, 1);
            }

            if (this.CBMesHastaGastoCompra.SelectedIndex > -1 && this.CBAnioHastaGastoCompra.SelectedIndex > -1)
            {
                int anioHasta = int.TryParse(this.CBAnioHastaGastoCompra.SelectedText, out int anio) ? anio : DateTime.Now.Year;
                int mesHasta = this.CBMesHastaGastoCompra.SelectedIndex + 1;
                fechaHasta = new DateTime(anioHasta, mesHasta, 1);
                fechaHasta = fechaHasta.AddMonths(1).AddMilliseconds(-1);
            }

            if (fechaDesde == fechaHasta && this.CBGranularidadGastosCompras.SelectedIndex < 0) return;

            switch (this.CBGranularidadGastosCompras.Text) 
            {
                case "":
                    this.InitMonthlyChartGastosCompras(fechaDesde, fechaHasta);
                    break;
                case "Mensual":
                    this.InitMonthlyChartGastosCompras(fechaDesde, fechaHasta);
                    break;
                case "Trimestral":
                    this.InitQuarterlyChartGastosCompras(fechaDesde, fechaHasta);
                    break;
                case "Semestral":
                    this.InitSemiannualChartGastosCompras(fechaDesde, fechaHasta);
                    break;
                case "Anual":
                    this.InitAnnualChartGastosCompras(fechaDesde, fechaHasta);
                    break;
            }
        }

        public void LoadInitSeriesGastosCompras(DateTime fechaInit, DateTime fechaFin) 
        {
            int intervalo = 1;

            switch (this.CBGranularidadGastosCompras.Text)
            {
                case "":
                    intervalo = 1;
                    break;
                case "Mensual":
                    intervalo = 1;
                    break;
                case "Trimestral":
                    intervalo = 3;
                    break;
                case "Senestral":
                    intervalo = 6;
                    break;
                case "Anual":
                    intervalo = 12;
                    break;
            }

            if (intervalo == 12)
            {
                for (DateTime i = fechaInit; i <= fechaFin; i = i.AddYears(1))
                {
                    foreach (Series serie in this.chart3.Series)
                    {
                        this.chart3.Series[serie.Name].Points.AddXY(
                        i.Date,
                        0
                        );
                    }
                }
            }
            else
            {
                for (DateTime i = fechaInit; i <= fechaFin; i = i.AddMonths(intervalo))
                {
                    foreach (Series serie in this.chart3.Series)
                    {
                        this.chart3.Series[serie.Name].Points.AddXY(
                        i.Date,
                        0
                        );
                    } 
                }
            }
        }

        public void LoadCBAñoGastosCompras()
        {
            for (int i = 2000; i <= DateTime.Now.Year; i++) 
            { 
                this.CBAnioDesdeGastoCompra.Items.Add(i);
                this.CBAnioHastaGastoCompra.Items.Add(i);
            }

            this.CBAnioDesdeGastoCompra.SelectedIndex = this.CBAnioDesdeGastoCompra.FindString("" + DateTime.Now.Year);
            this.CBAnioHastaGastoCompra.SelectedIndex = this.CBAnioHastaGastoCompra.FindString("" + DateTime.Now.Year);

            this.CBMesDesdeGastoCompra.SelectedIndex = DateTime.Now.Date.Month - 1;
            this.CBMesHastaGastoCompra.SelectedIndex = DateTime.Now.Date.Month - 1;
        }
    }
}
