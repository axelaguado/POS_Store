namespace WindowsFormsApp1.CapaPresentacion
{
    partial class GestionGastos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BTNActualizar = new System.Windows.Forms.Button();
            this.BTNReestablecer = new System.Windows.Forms.Button();
            this.BTNAgregarGasto = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LRegistrarGasto = new System.Windows.Forms.Label();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.LMonto = new System.Windows.Forms.Label();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.TBMonto = new System.Windows.Forms.TextBox();
            this.LDescipcion = new System.Windows.Forms.Label();
            this.CBCategorias = new System.Windows.Forms.ComboBox();
            this.LCategoria = new System.Windows.Forms.Label();
            this.LPeriodo = new System.Windows.Forms.Label();
            this.CBPeriodoAño = new System.Windows.Forms.ComboBox();
            this.CBPeriodoMes = new System.Windows.Forms.ComboBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DGVCategorias = new System.Windows.Forms.DataGridView();
            this.CCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNAgregarCategoria = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LCategorias = new System.Windows.Forms.Label();
            this.TBNuevaCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.BTNLimpiarFiltro = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CBHastaPeriodoAño = new System.Windows.Forms.ComboBox();
            this.CBHastaPeriodoMes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.LTotalPeriodoActual = new System.Windows.Forms.Label();
            this.LGastoPeriodoActual = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.LTotalFiltrado = new System.Windows.Forms.Label();
            this.LGastoPeriodoFiltrado = new System.Windows.Forms.Label();
            this.CBFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CBDesdePeriodoAño = new System.Windows.Forms.ComboBox();
            this.CBDesdePeriodoMes = new System.Windows.Forms.ComboBox();
            this.BTNFiltrar = new System.Windows.Forms.Button();
            this.DGVGastos = new System.Windows.Forms.DataGridView();
            this.CPeriodo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LGastos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LTItulo = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategorias)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGastos)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 476);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel8, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 430);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.BTNActualizar);
            this.panel7.Controls.Add(this.BTNReestablecer);
            this.panel7.Controls.Add(this.BTNAgregarGasto);
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.BTNLimpiar);
            this.panel7.Controls.Add(this.LMonto);
            this.panel7.Controls.Add(this.TBDescripcion);
            this.panel7.Controls.Add(this.TBMonto);
            this.panel7.Controls.Add(this.LDescipcion);
            this.panel7.Controls.Add(this.CBCategorias);
            this.panel7.Controls.Add(this.LCategoria);
            this.panel7.Controls.Add(this.LPeriodo);
            this.panel7.Controls.Add(this.CBPeriodoAño);
            this.panel7.Controls.Add(this.CBPeriodoMes);
            this.panel7.Location = new System.Drawing.Point(3, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(298, 209);
            this.panel7.TabIndex = 0;
            // 
            // BTNActualizar
            // 
            this.BTNActualizar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNActualizar.FlatAppearance.BorderSize = 0;
            this.BTNActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNActualizar.Location = new System.Drawing.Point(170, 183);
            this.BTNActualizar.Name = "BTNActualizar";
            this.BTNActualizar.Size = new System.Drawing.Size(67, 23);
            this.BTNActualizar.TabIndex = 12;
            this.BTNActualizar.Text = "Actualizar";
            this.BTNActualizar.UseVisualStyleBackColor = false;
            this.BTNActualizar.Click += new System.EventHandler(this.BTNActualizar_Click);
            // 
            // BTNReestablecer
            // 
            this.BTNReestablecer.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNReestablecer.FlatAppearance.BorderSize = 0;
            this.BTNReestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNReestablecer.Location = new System.Drawing.Point(82, 183);
            this.BTNReestablecer.Name = "BTNReestablecer";
            this.BTNReestablecer.Size = new System.Drawing.Size(82, 23);
            this.BTNReestablecer.TabIndex = 11;
            this.BTNReestablecer.Text = "Reestablecer";
            this.BTNReestablecer.UseVisualStyleBackColor = false;
            this.BTNReestablecer.Click += new System.EventHandler(this.BTNReestablecer_Click);
            // 
            // BTNAgregarGasto
            // 
            this.BTNAgregarGasto.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAgregarGasto.FlatAppearance.BorderSize = 0;
            this.BTNAgregarGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAgregarGasto.Location = new System.Drawing.Point(170, 183);
            this.BTNAgregarGasto.Name = "BTNAgregarGasto";
            this.BTNAgregarGasto.Size = new System.Drawing.Size(67, 23);
            this.BTNAgregarGasto.TabIndex = 10;
            this.BTNAgregarGasto.Text = "Agregar";
            this.BTNAgregarGasto.UseVisualStyleBackColor = false;
            this.BTNAgregarGasto.Click += new System.EventHandler(this.BTNAgregarGasto_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Controls.Add(this.LRegistrarGasto);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(298, 30);
            this.panel4.TabIndex = 1;
            // 
            // LRegistrarGasto
            // 
            this.LRegistrarGasto.AutoSize = true;
            this.LRegistrarGasto.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.LRegistrarGasto.Location = new System.Drawing.Point(3, 7);
            this.LRegistrarGasto.Name = "LRegistrarGasto";
            this.LRegistrarGasto.Size = new System.Drawing.Size(95, 16);
            this.LRegistrarGasto.TabIndex = 0;
            this.LRegistrarGasto.Text = "Registrar Gasto";
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNLimpiar.FlatAppearance.BorderSize = 0;
            this.BTNLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLimpiar.Location = new System.Drawing.Point(97, 183);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(67, 23);
            this.BTNLimpiar.TabIndex = 9;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // LMonto
            // 
            this.LMonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LMonto.AutoSize = true;
            this.LMonto.ForeColor = System.Drawing.SystemColors.Control;
            this.LMonto.Location = new System.Drawing.Point(6, 153);
            this.LMonto.Name = "LMonto";
            this.LMonto.Size = new System.Drawing.Size(55, 13);
            this.LMonto.TabIndex = 8;
            this.LMonto.Text = "Monto ($):";
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TBDescripcion.Location = new System.Drawing.Point(82, 115);
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(200, 20);
            this.TBDescripcion.TabIndex = 7;
            this.TBDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.TBDescripcion_Validating);
            // 
            // TBMonto
            // 
            this.TBMonto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TBMonto.Location = new System.Drawing.Point(82, 150);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.Size = new System.Drawing.Size(200, 20);
            this.TBMonto.TabIndex = 6;
            this.TBMonto.TextChanged += new System.EventHandler(this.TB_TextChanged);
            this.TBMonto.Validating += new System.ComponentModel.CancelEventHandler(this.TBMonto_Validating);
            // 
            // LDescipcion
            // 
            this.LDescipcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LDescipcion.AutoSize = true;
            this.LDescipcion.ForeColor = System.Drawing.SystemColors.Control;
            this.LDescipcion.Location = new System.Drawing.Point(5, 118);
            this.LDescipcion.Name = "LDescipcion";
            this.LDescipcion.Size = new System.Drawing.Size(66, 13);
            this.LDescipcion.TabIndex = 5;
            this.LDescipcion.Text = "Descripcion:";
            // 
            // CBCategorias
            // 
            this.CBCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CBCategorias.FormattingEnabled = true;
            this.CBCategorias.Location = new System.Drawing.Point(82, 80);
            this.CBCategorias.Name = "CBCategorias";
            this.CBCategorias.Size = new System.Drawing.Size(200, 21);
            this.CBCategorias.TabIndex = 4;
            this.CBCategorias.Validating += new System.ComponentModel.CancelEventHandler(this.CBCategorias_Validating);
            // 
            // LCategoria
            // 
            this.LCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LCategoria.AutoSize = true;
            this.LCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.LCategoria.Location = new System.Drawing.Point(6, 83);
            this.LCategoria.Name = "LCategoria";
            this.LCategoria.Size = new System.Drawing.Size(55, 13);
            this.LCategoria.TabIndex = 3;
            this.LCategoria.Text = "Categoria:";
            // 
            // LPeriodo
            // 
            this.LPeriodo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LPeriodo.AutoSize = true;
            this.LPeriodo.ForeColor = System.Drawing.SystemColors.Control;
            this.LPeriodo.Location = new System.Drawing.Point(6, 48);
            this.LPeriodo.Name = "LPeriodo";
            this.LPeriodo.Size = new System.Drawing.Size(46, 13);
            this.LPeriodo.TabIndex = 2;
            this.LPeriodo.Text = "Periodo:";
            // 
            // CBPeriodoAño
            // 
            this.CBPeriodoAño.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CBPeriodoAño.FormattingEnabled = true;
            this.CBPeriodoAño.Location = new System.Drawing.Point(185, 45);
            this.CBPeriodoAño.Name = "CBPeriodoAño";
            this.CBPeriodoAño.Size = new System.Drawing.Size(97, 21);
            this.CBPeriodoAño.TabIndex = 1;
            this.CBPeriodoAño.Validating += new System.ComponentModel.CancelEventHandler(this.CBPeriodoAño_Validating);
            // 
            // CBPeriodoMes
            // 
            this.CBPeriodoMes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CBPeriodoMes.FormattingEnabled = true;
            this.CBPeriodoMes.Location = new System.Drawing.Point(82, 45);
            this.CBPeriodoMes.Name = "CBPeriodoMes";
            this.CBPeriodoMes.Size = new System.Drawing.Size(97, 21);
            this.CBPeriodoMes.TabIndex = 0;
            this.CBPeriodoMes.Validating += new System.ComponentModel.CancelEventHandler(this.CBPeriodoMes_Validating);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.DGVCategorias);
            this.panel6.Controls.Add(this.BTNAgregarCategoria);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.TBNuevaCategoria);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Location = new System.Drawing.Point(3, 218);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(298, 209);
            this.panel6.TabIndex = 0;
            // 
            // DGVCategorias
            // 
            this.DGVCategorias.AllowUserToAddRows = false;
            this.DGVCategorias.AllowUserToDeleteRows = false;
            this.DGVCategorias.AllowUserToResizeColumns = false;
            this.DGVCategorias.AllowUserToResizeRows = false;
            this.DGVCategorias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCategorias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVCategorias.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.DGVCategorias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVCategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVCategorias.ColumnHeadersHeight = 21;
            this.DGVCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCategoria,
            this.CEstado});
            this.DGVCategorias.EnableHeadersVisualStyles = false;
            this.DGVCategorias.Location = new System.Drawing.Point(6, 79);
            this.DGVCategorias.Name = "DGVCategorias";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCategorias.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGVCategorias.RowHeadersVisible = false;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVCategorias.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCategorias.Size = new System.Drawing.Size(287, 127);
            this.DGVCategorias.TabIndex = 3;
            this.DGVCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCategorias_CellContentClick);
            this.DGVCategorias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // CCategoria
            // 
            this.CCategoria.HeaderText = "Categoria";
            this.CCategoria.Name = "CCategoria";
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            // 
            // BTNAgregarCategoria
            // 
            this.BTNAgregarCategoria.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAgregarCategoria.FlatAppearance.BorderSize = 0;
            this.BTNAgregarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAgregarCategoria.Location = new System.Drawing.Point(215, 51);
            this.BTNAgregarCategoria.Name = "BTNAgregarCategoria";
            this.BTNAgregarCategoria.Size = new System.Drawing.Size(67, 23);
            this.BTNAgregarCategoria.TabIndex = 2;
            this.BTNAgregarCategoria.Text = "Agregar";
            this.BTNAgregarCategoria.UseVisualStyleBackColor = false;
            this.BTNAgregarCategoria.Click += new System.EventHandler(this.BTNAgregarCategoria_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel3.Controls.Add(this.LCategorias);
            this.panel3.Location = new System.Drawing.Point(3, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 30);
            this.panel3.TabIndex = 0;
            // 
            // LCategorias
            // 
            this.LCategorias.AutoSize = true;
            this.LCategorias.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.LCategorias.Location = new System.Drawing.Point(3, 7);
            this.LCategorias.Name = "LCategorias";
            this.LCategorias.Size = new System.Drawing.Size(68, 16);
            this.LCategorias.TabIndex = 1;
            this.LCategorias.Text = "Categorias";
            // 
            // TBNuevaCategoria
            // 
            this.TBNuevaCategoria.Location = new System.Drawing.Point(6, 53);
            this.TBNuevaCategoria.Name = "TBNuevaCategoria";
            this.TBNuevaCategoria.Size = new System.Drawing.Size(203, 20);
            this.TBNuevaCategoria.TabIndex = 1;
            this.TBNuevaCategoria.Validating += new System.ComponentModel.CancelEventHandler(this.TBNuevaCategoria_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(5, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nueva Categoria:";
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.BTNLimpiarFiltro);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Controls.Add(this.CBHastaPeriodoAño);
            this.panel8.Controls.Add(this.CBHastaPeriodoMes);
            this.panel8.Controls.Add(this.tableLayoutPanel2);
            this.panel8.Controls.Add(this.CBFiltroCategoria);
            this.panel8.Controls.Add(this.label3);
            this.panel8.Controls.Add(this.label2);
            this.panel8.Controls.Add(this.CBDesdePeriodoAño);
            this.panel8.Controls.Add(this.CBDesdePeriodoMes);
            this.panel8.Controls.Add(this.BTNFiltrar);
            this.panel8.Controls.Add(this.DGVGastos);
            this.panel8.Controls.Add(this.panel5);
            this.panel8.Location = new System.Drawing.Point(307, 3);
            this.panel8.Name = "panel8";
            this.tableLayoutPanel1.SetRowSpan(this.panel8, 2);
            this.panel8.Size = new System.Drawing.Size(451, 424);
            this.panel8.TabIndex = 0;
            // 
            // BTNLimpiarFiltro
            // 
            this.BTNLimpiarFiltro.BackColor = System.Drawing.Color.Silver;
            this.BTNLimpiarFiltro.FlatAppearance.BorderSize = 0;
            this.BTNLimpiarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLimpiarFiltro.Location = new System.Drawing.Point(372, 86);
            this.BTNLimpiarFiltro.Name = "BTNLimpiarFiltro";
            this.BTNLimpiarFiltro.Size = new System.Drawing.Size(57, 23);
            this.BTNLimpiarFiltro.TabIndex = 16;
            this.BTNLimpiarFiltro.Text = "Limpiar";
            this.BTNLimpiarFiltro.UseVisualStyleBackColor = false;
            this.BTNLimpiarFiltro.Click += new System.EventHandler(this.BTNLimpiarFiltro_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(3, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Hasta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(3, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Desde:";
            // 
            // CBHastaPeriodoAño
            // 
            this.CBHastaPeriodoAño.FormattingEnabled = true;
            this.CBHastaPeriodoAño.Location = new System.Drawing.Point(121, 88);
            this.CBHastaPeriodoAño.Name = "CBHastaPeriodoAño";
            this.CBHastaPeriodoAño.Size = new System.Drawing.Size(65, 21);
            this.CBHastaPeriodoAño.TabIndex = 13;
            // 
            // CBHastaPeriodoMes
            // 
            this.CBHastaPeriodoMes.FormattingEnabled = true;
            this.CBHastaPeriodoMes.Location = new System.Drawing.Point(50, 88);
            this.CBHastaPeriodoMes.Name = "CBHastaPeriodoMes";
            this.CBHastaPeriodoMes.Size = new System.Drawing.Size(65, 21);
            this.CBHastaPeriodoMes.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel10, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 361);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(445, 60);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.Controls.Add(this.LTotalPeriodoActual);
            this.panel9.Controls.Add(this.LGastoPeriodoActual);
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(216, 54);
            this.panel9.TabIndex = 0;
            // 
            // LTotalPeriodoActual
            // 
            this.LTotalPeriodoActual.AutoSize = true;
            this.LTotalPeriodoActual.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalPeriodoActual.ForeColor = System.Drawing.SystemColors.Control;
            this.LTotalPeriodoActual.Location = new System.Drawing.Point(52, 30);
            this.LTotalPeriodoActual.Name = "LTotalPeriodoActual";
            this.LTotalPeriodoActual.Size = new System.Drawing.Size(38, 13);
            this.LTotalPeriodoActual.TabIndex = 2;
            this.LTotalPeriodoActual.Text = "$ - - -";
            // 
            // LGastoPeriodoActual
            // 
            this.LGastoPeriodoActual.AutoSize = true;
            this.LGastoPeriodoActual.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGastoPeriodoActual.ForeColor = System.Drawing.SystemColors.Control;
            this.LGastoPeriodoActual.Location = new System.Drawing.Point(3, 5);
            this.LGastoPeriodoActual.Name = "LGastoPeriodoActual";
            this.LGastoPeriodoActual.Size = new System.Drawing.Size(157, 13);
            this.LGastoPeriodoActual.TabIndex = 1;
            this.LGastoPeriodoActual.Text = "Gasto total periodo actual:";
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.Controls.Add(this.LTotalFiltrado);
            this.panel10.Controls.Add(this.LGastoPeriodoFiltrado);
            this.panel10.Location = new System.Drawing.Point(225, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(217, 54);
            this.panel10.TabIndex = 1;
            // 
            // LTotalFiltrado
            // 
            this.LTotalFiltrado.AutoSize = true;
            this.LTotalFiltrado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotalFiltrado.ForeColor = System.Drawing.SystemColors.Control;
            this.LTotalFiltrado.Location = new System.Drawing.Point(52, 30);
            this.LTotalFiltrado.Name = "LTotalFiltrado";
            this.LTotalFiltrado.Size = new System.Drawing.Size(38, 13);
            this.LTotalFiltrado.TabIndex = 2;
            this.LTotalFiltrado.Text = "$ - - -";
            // 
            // LGastoPeriodoFiltrado
            // 
            this.LGastoPeriodoFiltrado.AutoSize = true;
            this.LGastoPeriodoFiltrado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LGastoPeriodoFiltrado.ForeColor = System.Drawing.SystemColors.Control;
            this.LGastoPeriodoFiltrado.Location = new System.Drawing.Point(3, 5);
            this.LGastoPeriodoFiltrado.Name = "LGastoPeriodoFiltrado";
            this.LGastoPeriodoFiltrado.Size = new System.Drawing.Size(163, 13);
            this.LGastoPeriodoFiltrado.TabIndex = 0;
            this.LGastoPeriodoFiltrado.Text = "Gasto total periodo filtrado:";
            // 
            // CBFiltroCategoria
            // 
            this.CBFiltroCategoria.FormattingEnabled = true;
            this.CBFiltroCategoria.Location = new System.Drawing.Point(220, 56);
            this.CBFiltroCategoria.Name = "CBFiltroCategoria";
            this.CBFiltroCategoria.Size = new System.Drawing.Size(124, 21);
            this.CBFiltroCategoria.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(217, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Categoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(50, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Periodo:";
            // 
            // CBDesdePeriodoAño
            // 
            this.CBDesdePeriodoAño.FormattingEnabled = true;
            this.CBDesdePeriodoAño.Location = new System.Drawing.Point(121, 56);
            this.CBDesdePeriodoAño.Name = "CBDesdePeriodoAño";
            this.CBDesdePeriodoAño.Size = new System.Drawing.Size(65, 21);
            this.CBDesdePeriodoAño.TabIndex = 7;
            // 
            // CBDesdePeriodoMes
            // 
            this.CBDesdePeriodoMes.FormattingEnabled = true;
            this.CBDesdePeriodoMes.Location = new System.Drawing.Point(50, 56);
            this.CBDesdePeriodoMes.Name = "CBDesdePeriodoMes";
            this.CBDesdePeriodoMes.Size = new System.Drawing.Size(65, 21);
            this.CBDesdePeriodoMes.TabIndex = 6;
            // 
            // BTNFiltrar
            // 
            this.BTNFiltrar.BackColor = System.Drawing.Color.Silver;
            this.BTNFiltrar.FlatAppearance.BorderSize = 0;
            this.BTNFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNFiltrar.Location = new System.Drawing.Point(372, 54);
            this.BTNFiltrar.Name = "BTNFiltrar";
            this.BTNFiltrar.Size = new System.Drawing.Size(57, 23);
            this.BTNFiltrar.TabIndex = 5;
            this.BTNFiltrar.Text = "Filtrar";
            this.BTNFiltrar.UseVisualStyleBackColor = false;
            this.BTNFiltrar.Click += new System.EventHandler(this.BTNFiltrar_Click);
            // 
            // DGVGastos
            // 
            this.DGVGastos.AllowUserToAddRows = false;
            this.DGVGastos.AllowUserToDeleteRows = false;
            this.DGVGastos.AllowUserToResizeColumns = false;
            this.DGVGastos.AllowUserToResizeRows = false;
            this.DGVGastos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVGastos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVGastos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVGastos.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.DGVGastos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVGastos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGVGastos.ColumnHeadersHeight = 21;
            this.DGVGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CPeriodo,
            this.dataGridViewTextBoxColumn1,
            this.CDescripcion,
            this.CMonto,
            this.dataGridViewTextBoxColumn2});
            this.DGVGastos.EnableHeadersVisualStyles = false;
            this.DGVGastos.Location = new System.Drawing.Point(6, 115);
            this.DGVGastos.Name = "DGVGastos";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVGastos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGVGastos.RowHeadersVisible = false;
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVGastos.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGVGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVGastos.Size = new System.Drawing.Size(445, 243);
            this.DGVGastos.TabIndex = 4;
            this.DGVGastos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.DGVGastos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // CPeriodo
            // 
            this.CPeriodo.HeaderText = "Periodo";
            this.CPeriodo.Name = "CPeriodo";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // CDescripcion
            // 
            this.CDescripcion.HeaderText = "Descripcion";
            this.CDescripcion.Name = "CDescripcion";
            // 
            // CMonto
            // 
            this.CMonto.HeaderText = "Monto";
            this.CMonto.Name = "CMonto";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.LGastos);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(451, 30);
            this.panel5.TabIndex = 0;
            // 
            // LGastos
            // 
            this.LGastos.AutoSize = true;
            this.LGastos.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.LGastos.Location = new System.Drawing.Point(3, 7);
            this.LGastos.Name = "LGastos";
            this.LGastos.Size = new System.Drawing.Size(93, 16);
            this.LGastos.TabIndex = 2;
            this.LGastos.Text = "Lista de Gastos";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.LTItulo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 33);
            this.panel2.TabIndex = 0;
            // 
            // LTItulo
            // 
            this.LTItulo.AutoSize = true;
            this.LTItulo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTItulo.Location = new System.Drawing.Point(3, 8);
            this.LTItulo.Name = "LTItulo";
            this.LTItulo.Size = new System.Drawing.Size(106, 18);
            this.LTItulo.TabIndex = 0;
            this.LTItulo.Text = "Gestion Gastos";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GestionGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(776, 476);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionGastos";
            this.Text = "GestionGastos";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategorias)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVGastos)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LTItulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LRegistrarGasto;
        private System.Windows.Forms.Label LGastos;
        private System.Windows.Forms.Label LCategorias;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView DGVCategorias;
        private System.Windows.Forms.Button BTNAgregarCategoria;
        private System.Windows.Forms.TextBox TBNuevaCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label LPeriodo;
        private System.Windows.Forms.ComboBox CBPeriodoAño;
        private System.Windows.Forms.ComboBox CBPeriodoMes;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.TextBox TBMonto;
        private System.Windows.Forms.Label LDescipcion;
        private System.Windows.Forms.ComboBox CBCategorias;
        private System.Windows.Forms.Label LCategoria;
        private System.Windows.Forms.Button BTNAgregarGasto;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.Label LMonto;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button BTNFiltrar;
        private System.Windows.Forms.DataGridView DGVGastos;
        private System.Windows.Forms.ComboBox CBFiltroCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBDesdePeriodoAño;
        private System.Windows.Forms.ComboBox CBDesdePeriodoMes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label LGastoPeriodoActual;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label LGastoPeriodoFiltrado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CBHastaPeriodoAño;
        private System.Windows.Forms.ComboBox CBHastaPeriodoMes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPeriodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button BTNActualizar;
        private System.Windows.Forms.Button BTNReestablecer;
        private System.Windows.Forms.Button BTNLimpiarFiltro;
        private System.Windows.Forms.Label LTotalPeriodoActual;
        private System.Windows.Forms.Label LTotalFiltrado;
    }
}