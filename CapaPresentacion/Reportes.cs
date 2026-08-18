using System;
using System.Collections.Generic;
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

        public Reportes(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.cts = new CancellationTokenSource();
            this.InitDailyChart(DateTime.Now, DateTime.Now);
            this.LoadInit();
        }

        public void InitDailyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorDia(desde, hasta);

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

        public void InitWeeklyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorSemana(desde, hasta);

            // Definimos la serie.
            string serie = "Ventas Semanales";

            this.SetUpChart1(serie, ventas);

            // Definimos la cantidad de periodos acumulados que se muestra

            this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
            this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddDays(7);

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

        public void InitMonthlyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorMes(desde, hasta);

            // Definimos la serie.
            string serie = "Ventas Mensuales";

            this.SetUpChart1(serie, ventas);

            this.PEmpleadoPeriodoDesde = ventas.Last().fecha_acumulada;
            this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoDesde.AddMonths(1);

            // DateTime fechaFin = ventas.Last().fecha_acumulada;
            DateTime fechaFin = this.PEmpleadoPeriodoDesde;
            DateTime fechaInit = fechaFin.AddMonths(-6);

            this.chart1.ChartAreas[0].AxisX.Minimum = fechaInit.ToOADate();
            this.chart1.ChartAreas[0].AxisX.Maximum = fechaFin.ToOADate();

            this.chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/yy";

            this.chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;
            this.chart1.ChartAreas[0].AxisX.Interval = 1;
        }

        public void InitQuarterlyChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorTrimestre(desde, hasta);

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

        public void InitSemiannualChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorSemestre(desde, hasta);

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

        public void InitAnnualChart(DateTime desde, DateTime hasta)
        {
            // Traemos los datos que necesitamos.
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaDTO> ventas = venta.VentasPorAño(desde, hasta);

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

        private async void BTNFiltrar_Click(object sender, EventArgs e)
        {
            CN_Venta venta = new CN_Venta();
            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            // Si son iguales ambas fecha significa que no se requiere la utilizacion del filtro
            DateTime desde = this.DTPFiltroDesde.Value;
            DateTime hasta = this.DTPFiltroHasta.Value;

            bool load_date = desde < hasta;
            bool load_granularidad = this.CBGranularidad.SelectedIndex > -1;

            // Verificamos que se cumplan las condiciones neesarias para el filtrado. --> Falta mayor analisis y definir el retorno
            if (!load_date && !load_granularidad)
            {
                return;
            }

            try
            {
                // Tambien debemos cargar el DGV con los datos que representan al ultimo elemento del Chart
                // Invocamos el metodo encargado de los datos.
                switch (this.CBGranularidad.Text)
                {
                    case "Diario":
                        this.InitDailyChart(desde, hasta);
                        this.LoadPeriodo(this.PEmpleadoPeriodoDesde);
                        this.LoadTableEmpleado(await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Semanal":
                        this.InitWeeklyChart(desde, hasta);
                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Mensual":
                        this.InitMonthlyChart(desde, hasta);
                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Trimestral":
                        this.InitQuarterlyChart(desde, hasta);
                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Semestral":
                        this.InitSemiannualChart(desde, hasta);
                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Anual":
                        this.InitAnnualChart(desde, hasta);
                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;
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
        }

        // ----- Manejo de la seccion DGV con respecto de Ventas por: -----
        public void LoadInit()
        {
            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventas = venta.VentasDiarioEmpleado(DateTime.Now, DateTime.Now);

            // this.PEmpleadoPeriodoDesde = ventas.Last().periodo;
            this.LoadPeriodo(this.PEmpleadoPeriodoDesde); 

            this.LoadTableEmpleado(ventas.Where(v => v.periodo == this.PEmpleadoPeriodoDesde).ToList());
        }

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
            this.LVTotalTickets.Text = lista.Sum(l => l.cantidad_ventas).ToString();
            this.LVMontoPromedioTicket.Text = "$" + decimal.Round((lista.Sum(l => l.monto_total) / lista.Sum(l => l.cantidad_ventas)), 2);
        }

        // ----- Eventos botones Chart -----
        private void BTNAdelante_Click(object sender, EventArgs e)
        {
            DateTime fechaFin = DateTime.FromOADate(this.chart1.ChartAreas[0].AxisX.Maximum);
            DateTime fechaInit = DateTime.FromOADate(this.chart1.ChartAreas[0].AxisX.Minimum);

            if (this.CBGranularidad.SelectedIndex < 0 && this.chart1.ChartAreas[0].AxisX.Maximum <= DateTime.Now.Date.ToOADate())
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
            if (this.PEmpleadoPeriodoDesde == null) return;

            if (this.PEmpleadoPeriodoHasta == null || this.PEmpleadoPeriodoHasta > DateTime.Now) return;

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventas = new List<ReporteVentaEmpleadoDTO>();

            try
            {
                if (this.CBGranularidad.SelectedIndex < 0)
                {
                    this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(1);
                    this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(1);

                    this.LoadPeriodo(this.PEmpleadoPeriodoDesde);
                    this.LoadTableEmpleado(await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                }

                // Probablemente la porcion de codigo a estandarizar va ser el manejo mediante el switch. -- Principalmente el PEmpleadoPeriodoDesde y PEmpleadoPeriodoHasta.
                // La carga incial ya funciona falta reveer la asignaciones de fecha aca porque PEmpladoHasta ya viene cargado, cosa que antes no ocurria.
                switch (this.CBGranularidad.Text)
                {
                    case "Diario":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(1);

                        this.LoadPeriodo(this.PEmpleadoPeriodoDesde);
                        this.LoadTableEmpleado(await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Semanal":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(7);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(7);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Mensual":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddMonths(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddMonths(1);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Trimestral":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddMonths(3);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddMonths(3);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Semestral":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddMonths(6);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddMonths(6);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Anual":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddYears(1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddYears(1);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;
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
            if (this.PEmpleadoPeriodoDesde == null) return;

            this.cts.Cancel();
            this.cts = new CancellationTokenSource();

            CN_Venta venta = new CN_Venta();
            List<ReporteVentaEmpleadoDTO> ventas = new List<ReporteVentaEmpleadoDTO>();

            try
            {
                if (this.CBGranularidad.SelectedIndex < 0)
                {
                    this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(-1);
                    this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(-1);

                    this.LoadPeriodo(this.PEmpleadoPeriodoDesde);
                    this.LoadTableEmpleado(await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                }

                // Probablemente la porcion de codigo a estandarizar va ser el manejo mediante el switch. -- Principalmente el PEmpleadoPeriodoDesde y PEmpleadoPeriodoHasta.
                // La carga incial ya funciona falta reveer la asignaciones de fecha aca porque PEmpladoHasta ya viene cargado, cosa que antes no ocurria.
                switch (this.CBGranularidad.Text)
                {
                    case "Diario":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(-1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(-1);

                        this.LoadPeriodo(this.PEmpleadoPeriodoDesde);
                        this.LoadTableEmpleado(await venta.VentasPeriodoDiarioEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Semanal":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddDays(-7);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddDays(-7);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoSemanalEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Mensual":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddMonths(-1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddMonths(-1);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoMensualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Trimestral":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddMonths(-3);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddMonths(-3);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoTrimestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Semestral":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddMonths(-6);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddMonths(-6);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoSemestralEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;

                    case "Anual":
                        this.PEmpleadoPeriodoDesde = this.PEmpleadoPeriodoDesde.AddYears(-1);
                        this.PEmpleadoPeriodoHasta = this.PEmpleadoPeriodoHasta.AddYears(-1);

                        this.LoadPeriodoDesdeHasta(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta.AddMilliseconds(-1));
                        this.LoadTableEmpleado(await venta.VentasPeriodoAnualEmpleadoAsync(this.PEmpleadoPeriodoDesde, this.PEmpleadoPeriodoHasta, this.cts.Token));
                        break;
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

        public void LoadPeriodo(DateTime periodo)
        {
            this.LPeriodo.Visible = true;
            this.LPeriodoDesdeHasta.Visible = false;
            this.LPeriodo.Text = periodo.ToShortDateString();
        }

        public void LoadPeriodoDesdeHasta(DateTime desde, DateTime hasta)
        {
            this.LPeriodoDesdeHasta.Visible = true;
            this.LPeriodo.Visible = false;
            this.LPeriodoDesdeHasta.Text = desde.ToShortDateString() + " - " + hasta.ToShortDateString();
        }
    }
}
