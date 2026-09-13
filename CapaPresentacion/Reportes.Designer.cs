namespace WindowsFormsApp1.CapaPresentacion
{
    partial class Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LReportes = new System.Windows.Forms.Label();
            this.BTNVentas = new System.Windows.Forms.Button();
            this.TLPVentas = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTNAtras = new System.Windows.Forms.Button();
            this.BTNAdelante = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LVTotalTickets = new System.Windows.Forms.Label();
            this.LVMontoPromedioTicket = new System.Windows.Forms.Label();
            this.LMontoPromedioTicket = new System.Windows.Forms.Label();
            this.LTotalTickets = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.DGVVentas = new System.Windows.Forms.DataGridView();
            this.CPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEmpleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTickets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMontoPromedio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMontoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LPeriodoDesdeHasta = new System.Windows.Forms.Label();
            this.LPeriodo = new System.Windows.Forms.Label();
            this.BTNAdelantePVentaPor = new System.Windows.Forms.Button();
            this.BTNAtrasPVentaPor = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BTNVentasPorEmpleado = new System.Windows.Forms.Button();
            this.BTNVentasPorProducto = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.BTNFiltrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CBGranularidad = new System.Windows.Forms.ComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.DTPFiltroHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.DTPFiltroDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.TLPVentas.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TLPVentas);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 425);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.LReportes);
            this.panel3.Controls.Add(this.BTNVentas);
            this.panel3.Location = new System.Drawing.Point(7, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 46);
            this.panel3.TabIndex = 0;
            // 
            // LReportes
            // 
            this.LReportes.AutoSize = true;
            this.LReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LReportes.ForeColor = System.Drawing.SystemColors.Control;
            this.LReportes.Location = new System.Drawing.Point(7, 0);
            this.LReportes.Name = "LReportes";
            this.LReportes.Size = new System.Drawing.Size(75, 16);
            this.LReportes.TabIndex = 1;
            this.LReportes.Text = "Reportes:";
            // 
            // BTNVentas
            // 
            this.BTNVentas.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNVentas.FlatAppearance.BorderSize = 0;
            this.BTNVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNVentas.Location = new System.Drawing.Point(7, 19);
            this.BTNVentas.Name = "BTNVentas";
            this.BTNVentas.Size = new System.Drawing.Size(75, 23);
            this.BTNVentas.TabIndex = 0;
            this.BTNVentas.Text = "Ventas";
            this.BTNVentas.UseVisualStyleBackColor = false;
            // 
            // TLPVentas
            // 
            this.TLPVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TLPVentas.ColumnCount = 2;
            this.TLPVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPVentas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLPVentas.Controls.Add(this.panel4, 0, 1);
            this.TLPVentas.Controls.Add(this.panel8, 1, 3);
            this.TLPVentas.Controls.Add(this.panel7, 1, 1);
            this.TLPVentas.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.TLPVentas.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.TLPVentas.Location = new System.Drawing.Point(7, 91);
            this.TLPVentas.Name = "TLPVentas";
            this.TLPVentas.RowCount = 4;
            this.TLPVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.TLPVentas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TLPVentas.Size = new System.Drawing.Size(760, 325);
            this.TLPVentas.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.Controls.Add(this.BTNAtras);
            this.panel4.Controls.Add(this.BTNAdelante);
            this.panel4.Controls.Add(this.chart1);
            this.panel4.Location = new System.Drawing.Point(3, 84);
            this.panel4.Name = "panel4";
            this.TLPVentas.SetRowSpan(this.panel4, 3);
            this.panel4.Size = new System.Drawing.Size(374, 238);
            this.panel4.TabIndex = 1;
            // 
            // BTNAtras
            // 
            this.BTNAtras.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BTNAtras.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAtras.FlatAppearance.BorderSize = 0;
            this.BTNAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAtras.Location = new System.Drawing.Point(3, 110);
            this.BTNAtras.Name = "BTNAtras";
            this.BTNAtras.Size = new System.Drawing.Size(16, 23);
            this.BTNAtras.TabIndex = 1;
            this.BTNAtras.Text = "<<";
            this.BTNAtras.UseVisualStyleBackColor = false;
            this.BTNAtras.Click += new System.EventHandler(this.BTNAtras_Click);
            // 
            // BTNAdelante
            // 
            this.BTNAdelante.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BTNAdelante.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAdelante.FlatAppearance.BorderSize = 0;
            this.BTNAdelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAdelante.Location = new System.Drawing.Point(355, 110);
            this.BTNAdelante.Name = "BTNAdelante";
            this.BTNAdelante.Size = new System.Drawing.Size(16, 23);
            this.BTNAdelante.TabIndex = 2;
            this.BTNAdelante.Text = ">>";
            this.BTNAdelante.UseVisualStyleBackColor = false;
            this.BTNAdelante.Click += new System.EventHandler(this.BTNAdelante_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Teal;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(22, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            this.chart1.Size = new System.Drawing.Size(330, 238);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Teal;
            this.panel8.Controls.Add(this.LVTotalTickets);
            this.panel8.Controls.Add(this.LVMontoPromedioTicket);
            this.panel8.Controls.Add(this.LMontoPromedioTicket);
            this.panel8.Controls.Add(this.LTotalTickets);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Location = new System.Drawing.Point(383, 246);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(374, 76);
            this.panel8.TabIndex = 5;
            // 
            // LVTotalTickets
            // 
            this.LVTotalTickets.AutoSize = true;
            this.LVTotalTickets.ForeColor = System.Drawing.SystemColors.Control;
            this.LVTotalTickets.Location = new System.Drawing.Point(156, 27);
            this.LVTotalTickets.Name = "LVTotalTickets";
            this.LVTotalTickets.Size = new System.Drawing.Size(10, 13);
            this.LVTotalTickets.TabIndex = 7;
            this.LVTotalTickets.Text = "-";
            // 
            // LVMontoPromedioTicket
            // 
            this.LVMontoPromedioTicket.AutoSize = true;
            this.LVMontoPromedioTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.LVMontoPromedioTicket.Location = new System.Drawing.Point(156, 50);
            this.LVMontoPromedioTicket.Name = "LVMontoPromedioTicket";
            this.LVMontoPromedioTicket.Size = new System.Drawing.Size(10, 13);
            this.LVMontoPromedioTicket.TabIndex = 6;
            this.LVMontoPromedioTicket.Text = "-";
            // 
            // LMontoPromedioTicket
            // 
            this.LMontoPromedioTicket.AutoSize = true;
            this.LMontoPromedioTicket.ForeColor = System.Drawing.SystemColors.Control;
            this.LMontoPromedioTicket.Location = new System.Drawing.Point(3, 50);
            this.LMontoPromedioTicket.Name = "LMontoPromedioTicket";
            this.LMontoPromedioTicket.Size = new System.Drawing.Size(133, 13);
            this.LMontoPromedioTicket.TabIndex = 5;
            this.LMontoPromedioTicket.Text = "Monto promedio por ticket:";
            // 
            // LTotalTickets
            // 
            this.LTotalTickets.AutoSize = true;
            this.LTotalTickets.ForeColor = System.Drawing.SystemColors.Control;
            this.LTotalTickets.Location = new System.Drawing.Point(3, 27);
            this.LTotalTickets.Name = "LTotalTickets";
            this.LTotalTickets.Size = new System.Drawing.Size(87, 13);
            this.LTotalTickets.TabIndex = 4;
            this.LTotalTickets.Text = "Total de Tickets:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tickets:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.DGVVentas);
            this.panel7.Location = new System.Drawing.Point(383, 84);
            this.panel7.Name = "panel7";
            this.TLPVentas.SetRowSpan(this.panel7, 2);
            this.panel7.Size = new System.Drawing.Size(374, 156);
            this.panel7.TabIndex = 4;
            // 
            // DGVVentas
            // 
            this.DGVVentas.AllowUserToAddRows = false;
            this.DGVVentas.AllowUserToDeleteRows = false;
            this.DGVVentas.AllowUserToResizeColumns = false;
            this.DGVVentas.AllowUserToResizeRows = false;
            this.DGVVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVVentas.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.DGVVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVVentas.ColumnHeadersHeight = 21;
            this.DGVVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CPeriodo,
            this.CEmpleado,
            this.CTickets,
            this.CMontoPromedio,
            this.CMontoTotal});
            this.DGVVentas.EnableHeadersVisualStyles = false;
            this.DGVVentas.Location = new System.Drawing.Point(3, 0);
            this.DGVVentas.Name = "DGVVentas";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVVentas.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVVentas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVVentas.Size = new System.Drawing.Size(368, 153);
            this.DGVVentas.TabIndex = 5;
            // 
            // CPeriodo
            // 
            this.CPeriodo.HeaderText = "Periodo";
            this.CPeriodo.Name = "CPeriodo";
            // 
            // CEmpleado
            // 
            this.CEmpleado.HeaderText = "Empleado";
            this.CEmpleado.Name = "CEmpleado";
            // 
            // CTickets
            // 
            this.CTickets.HeaderText = "Tickets";
            this.CTickets.Name = "CTickets";
            // 
            // CMontoPromedio
            // 
            this.CMontoPromedio.HeaderText = "MontoPromedio";
            this.CMontoPromedio.Name = "CMontoPromedio";
            // 
            // CMontoTotal
            // 
            this.CMontoTotal.HeaderText = "MontoTotal";
            this.CMontoTotal.Name = "CMontoTotal";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(383, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(374, 75);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.LPeriodoDesdeHasta);
            this.panel5.Controls.Add(this.LPeriodo);
            this.panel5.Controls.Add(this.BTNAdelantePVentaPor);
            this.panel5.Controls.Add(this.BTNAtrasPVentaPor);
            this.panel5.Location = new System.Drawing.Point(3, 40);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(368, 32);
            this.panel5.TabIndex = 4;
            // 
            // LPeriodoDesdeHasta
            // 
            this.LPeriodoDesdeHasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LPeriodoDesdeHasta.AutoSize = true;
            this.LPeriodoDesdeHasta.ForeColor = System.Drawing.SystemColors.Control;
            this.LPeriodoDesdeHasta.Location = new System.Drawing.Point(123, 8);
            this.LPeriodoDesdeHasta.Name = "LPeriodoDesdeHasta";
            this.LPeriodoDesdeHasta.Size = new System.Drawing.Size(132, 13);
            this.LPeriodoDesdeHasta.TabIndex = 6;
            this.LPeriodoDesdeHasta.Text = "00/00/0000 - 00/00/0000";
            // 
            // LPeriodo
            // 
            this.LPeriodo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LPeriodo.AutoSize = true;
            this.LPeriodo.ForeColor = System.Drawing.SystemColors.Control;
            this.LPeriodo.Location = new System.Drawing.Point(163, 8);
            this.LPeriodo.Name = "LPeriodo";
            this.LPeriodo.Size = new System.Drawing.Size(65, 13);
            this.LPeriodo.TabIndex = 5;
            this.LPeriodo.Text = "00/00/0000";
            // 
            // BTNAdelantePVentaPor
            // 
            this.BTNAdelantePVentaPor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNAdelantePVentaPor.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAdelantePVentaPor.FlatAppearance.BorderSize = 0;
            this.BTNAdelantePVentaPor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAdelantePVentaPor.Location = new System.Drawing.Point(352, 3);
            this.BTNAdelantePVentaPor.Name = "BTNAdelantePVentaPor";
            this.BTNAdelantePVentaPor.Size = new System.Drawing.Size(16, 23);
            this.BTNAdelantePVentaPor.TabIndex = 4;
            this.BTNAdelantePVentaPor.Text = ">>";
            this.BTNAdelantePVentaPor.UseVisualStyleBackColor = false;
            this.BTNAdelantePVentaPor.Click += new System.EventHandler(this.BTNAdelantePVentaPor_Click);
            // 
            // BTNAtrasPVentaPor
            // 
            this.BTNAtrasPVentaPor.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAtrasPVentaPor.FlatAppearance.BorderSize = 0;
            this.BTNAtrasPVentaPor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAtrasPVentaPor.Location = new System.Drawing.Point(0, 3);
            this.BTNAtrasPVentaPor.Name = "BTNAtrasPVentaPor";
            this.BTNAtrasPVentaPor.Size = new System.Drawing.Size(16, 23);
            this.BTNAtrasPVentaPor.TabIndex = 2;
            this.BTNAtrasPVentaPor.Text = "<<";
            this.BTNAtrasPVentaPor.UseVisualStyleBackColor = false;
            this.BTNAtrasPVentaPor.Click += new System.EventHandler(this.BTNAtrasPVentaPor_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.flowLayoutPanel1);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(368, 31);
            this.panel6.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BTNVentasPorEmpleado);
            this.flowLayoutPanel1.Controls.Add(this.BTNVentasPorProducto);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(89, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 27);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // BTNVentasPorEmpleado
            // 
            this.BTNVentasPorEmpleado.BackColor = System.Drawing.Color.LightGray;
            this.BTNVentasPorEmpleado.FlatAppearance.BorderSize = 0;
            this.BTNVentasPorEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNVentasPorEmpleado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNVentasPorEmpleado.Location = new System.Drawing.Point(3, 3);
            this.BTNVentasPorEmpleado.Name = "BTNVentasPorEmpleado";
            this.BTNVentasPorEmpleado.Size = new System.Drawing.Size(75, 23);
            this.BTNVentasPorEmpleado.TabIndex = 3;
            this.BTNVentasPorEmpleado.Text = "Empleado";
            this.BTNVentasPorEmpleado.UseVisualStyleBackColor = false;
            this.BTNVentasPorEmpleado.Click += new System.EventHandler(this.BTNVentasPorEmpleado_Click);
            // 
            // BTNVentasPorProducto
            // 
            this.BTNVentasPorProducto.BackColor = System.Drawing.Color.LightGray;
            this.BTNVentasPorProducto.FlatAppearance.BorderSize = 0;
            this.BTNVentasPorProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNVentasPorProducto.Location = new System.Drawing.Point(84, 3);
            this.BTNVentasPorProducto.Name = "BTNVentasPorProducto";
            this.BTNVentasPorProducto.Size = new System.Drawing.Size(75, 23);
            this.BTNVentasPorProducto.TabIndex = 4;
            this.BTNVentasPorProducto.Text = "Producto";
            this.BTNVentasPorProducto.UseVisualStyleBackColor = false;
            this.BTNVentasPorProducto.Click += new System.EventHandler(this.BTNVentasPorProducto_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(165, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Categoria";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(-3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ventas por:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel10, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(374, 75);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.BTNFiltrar);
            this.panel10.Controls.Add(this.label1);
            this.panel10.Controls.Add(this.CBGranularidad);
            this.panel10.Location = new System.Drawing.Point(190, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(181, 69);
            this.panel10.TabIndex = 1;
            // 
            // BTNFiltrar
            // 
            this.BTNFiltrar.BackColor = System.Drawing.Color.Gray;
            this.BTNFiltrar.FlatAppearance.BorderSize = 0;
            this.BTNFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNFiltrar.ForeColor = System.Drawing.SystemColors.Control;
            this.BTNFiltrar.Location = new System.Drawing.Point(70, 44);
            this.BTNFiltrar.Name = "BTNFiltrar";
            this.BTNFiltrar.Size = new System.Drawing.Size(52, 20);
            this.BTNFiltrar.TabIndex = 7;
            this.BTNFiltrar.Text = "Filtrar";
            this.BTNFiltrar.UseVisualStyleBackColor = false;
            this.BTNFiltrar.Click += new System.EventHandler(this.BTNFiltrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Acumular por:";
            // 
            // CBGranularidad
            // 
            this.CBGranularidad.FormattingEnabled = true;
            this.CBGranularidad.Items.AddRange(new object[] {
            "Diario",
            "Semanal",
            "Mensual",
            "Trimestral",
            "Semestral",
            "Anual"});
            this.CBGranularidad.Location = new System.Drawing.Point(6, 19);
            this.CBGranularidad.Name = "CBGranularidad";
            this.CBGranularidad.Size = new System.Drawing.Size(116, 21);
            this.CBGranularidad.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.DTPFiltroHasta);
            this.panel9.Controls.Add(this.label2);
            this.panel9.Controls.Add(this.DTPFiltroDesde);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(181, 69);
            this.panel9.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(3, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Monto de Ventas:";
            // 
            // DTPFiltroHasta
            // 
            this.DTPFiltroHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFiltroHasta.Location = new System.Drawing.Point(51, 44);
            this.DTPFiltroHasta.Name = "DTPFiltroHasta";
            this.DTPFiltroHasta.Size = new System.Drawing.Size(108, 20);
            this.DTPFiltroHasta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(4, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Desde:";
            // 
            // DTPFiltroDesde
            // 
            this.DTPFiltroDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFiltroDesde.Location = new System.Drawing.Point(51, 17);
            this.DTPFiltroDesde.Name = "DTPFiltroDesde";
            this.DTPFiltroDesde.Size = new System.Drawing.Size(108, 20);
            this.DTPFiltroDesde.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(4, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hasta:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.LTitulo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 33);
            this.panel2.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.Location = new System.Drawing.Point(3, 7);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(71, 19);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Reportes";
            // 
            // Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reportes";
            this.Text = "Reportes";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.TLPVentas.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVVentas)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel TLPVentas;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LReportes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBGranularidad;
        private System.Windows.Forms.DateTimePicker DTPFiltroHasta;
        private System.Windows.Forms.DateTimePicker DTPFiltroDesde;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button BTNVentasPorProducto;
        private System.Windows.Forms.Button BTNVentasPorEmpleado;
        private System.Windows.Forms.Label LMontoPromedioTicket;
        private System.Windows.Forms.Label LTotalTickets;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView DGVVentas;
        private System.Windows.Forms.Label LVTotalTickets;
        private System.Windows.Forms.Label LVMontoPromedioTicket;
        private System.Windows.Forms.Button BTNFiltrar;
        private System.Windows.Forms.Button BTNVentas;
        private System.Windows.Forms.Button BTNAdelante;
        private System.Windows.Forms.Button BTNAtras;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BTNAtrasPVentaPor;
        private System.Windows.Forms.Button BTNAdelantePVentaPor;
        private System.Windows.Forms.Label LPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMontoPromedio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMontoTotal;
        private System.Windows.Forms.Label LPeriodoDesdeHasta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}