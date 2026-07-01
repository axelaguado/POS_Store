namespace WindowsFormsApp1.CapaPresentacion
{
    partial class GestionProductos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LRegistrar = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CContenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMargenPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecioV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LProductos = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTNReestablecer = new System.Windows.Forms.Button();
            this.BTNActualizar = new System.Windows.Forms.Button();
            this.LNuevaCategoria = new System.Windows.Forms.Label();
            this.BTNInsertar = new System.Windows.Forms.Button();
            this.TBCategoriaProducto = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BTNCalcularMargen = new System.Windows.Forms.PictureBox();
            this.LNroCod = new System.Windows.Forms.Label();
            this.TBSkuProducto = new System.Windows.Forms.TextBox();
            this.CBCategoriaProducto = new System.Windows.Forms.ComboBox();
            this.LMargen = new System.Windows.Forms.Label();
            this.LStockMinimo = new System.Windows.Forms.Label();
            this.LStock = new System.Windows.Forms.Label();
            this.LCateg = new System.Windows.Forms.Label();
            this.TBPrecioVenta = new System.Windows.Forms.TextBox();
            this.TBPrecioCosto = new System.Windows.Forms.TextBox();
            this.TBStockMinimo = new System.Windows.Forms.TextBox();
            this.TBStockProducto = new System.Windows.Forms.TextBox();
            this.TBNombreProducto = new System.Windows.Forms.TextBox();
            this.LNombreArticulo = new System.Windows.Forms.Label();
            this.TBContenidoProducto = new System.Windows.Forms.TextBox();
            this.LMarcaArticulo = new System.Windows.Forms.Label();
            this.LPrecio = new System.Windows.Forms.Label();
            this.TBDescripcionProducto = new System.Windows.Forms.TextBox();
            this.TBMarcaProducto = new System.Windows.Forms.TextBox();
            this.LDescripcion = new System.Windows.Forms.Label();
            this.LContenido = new System.Windows.Forms.Label();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.BTAgregar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LCategorias = new System.Windows.Forms.Label();
            this.DGVCategorias = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BTNCalcularMargen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategorias)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 571);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.LRegistrar);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(269, 33);
            this.panel5.TabIndex = 1;
            // 
            // LRegistrar
            // 
            this.LRegistrar.AutoSize = true;
            this.LRegistrar.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LRegistrar.Location = new System.Drawing.Point(3, 9);
            this.LRegistrar.Name = "LRegistrar";
            this.LRegistrar.Size = new System.Drawing.Size(127, 18);
            this.LRegistrar.TabIndex = 0;
            this.LRegistrar.Text = "Registrar Producto";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.BTNBuscar);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(278, 3);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 3);
            this.panel3.Size = new System.Drawing.Size(545, 496);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CMarca,
            this.CProducto,
            this.CCategoria,
            this.CContenido,
            this.CStock,
            this.CPrecioC,
            this.CMargenPrecioVenta,
            this.CPrecioV,
            this.CEstado});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(7, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(533, 411);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // CMarca
            // 
            this.CMarca.HeaderText = "Marca";
            this.CMarca.Name = "CMarca";
            this.CMarca.Width = 61;
            // 
            // CProducto
            // 
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            this.CProducto.Width = 74;
            // 
            // CCategoria
            // 
            this.CCategoria.HeaderText = "Categoria";
            this.CCategoria.Name = "CCategoria";
            this.CCategoria.Width = 76;
            // 
            // CContenido
            // 
            this.CContenido.HeaderText = "Contenido";
            this.CContenido.Name = "CContenido";
            this.CContenido.Width = 79;
            // 
            // CStock
            // 
            this.CStock.HeaderText = "Stock";
            this.CStock.Name = "CStock";
            this.CStock.Width = 59;
            // 
            // CPrecioC
            // 
            this.CPrecioC.HeaderText = "Precio Costo";
            this.CPrecioC.Name = "CPrecioC";
            this.CPrecioC.Width = 84;
            // 
            // CMargenPrecioVenta
            // 
            this.CMargenPrecioVenta.HeaderText = "Margen / Precio Venta";
            this.CMargenPrecioVenta.Name = "CMargenPrecioVenta";
            this.CMargenPrecioVenta.Width = 102;
            // 
            // CPrecioV
            // 
            this.CPrecioV.HeaderText = "Precio Venta";
            this.CPrecioV.Name = "CPrecioV";
            this.CPrecioV.Width = 85;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.Width = 45;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(314, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBBuscar_MouseClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscar.FlatAppearance.BorderSize = 0;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.Location = new System.Drawing.Point(327, 45);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(75, 23);
            this.BTNBuscar.TabIndex = 1;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Controls.Add(this.LProductos);
            this.panel4.Location = new System.Drawing.Point(1, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 33);
            this.panel4.TabIndex = 0;
            // 
            // LProductos
            // 
            this.LProductos.AutoSize = true;
            this.LProductos.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProductos.Location = new System.Drawing.Point(3, 9);
            this.LProductos.Name = "LProductos";
            this.LProductos.Size = new System.Drawing.Size(122, 18);
            this.LProductos.TabIndex = 1;
            this.LProductos.Text = "Listado Productos";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.DGVCategorias);
            this.panel2.Controls.Add(this.BTNInsertar);
            this.panel2.Controls.Add(this.LNuevaCategoria);
            this.panel2.Controls.Add(this.TBCategoriaProducto);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Location = new System.Drawing.Point(3, 337);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 162);
            this.panel2.TabIndex = 0;
            // 
            // BTNReestablecer
            // 
            this.BTNReestablecer.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNReestablecer.FlatAppearance.BorderSize = 0;
            this.BTNReestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNReestablecer.Location = new System.Drawing.Point(24, 248);
            this.BTNReestablecer.Name = "BTNReestablecer";
            this.BTNReestablecer.Size = new System.Drawing.Size(87, 23);
            this.BTNReestablecer.TabIndex = 24;
            this.BTNReestablecer.Text = "Reestablecer";
            this.BTNReestablecer.UseVisualStyleBackColor = false;
            this.BTNReestablecer.Click += new System.EventHandler(this.BTNReestablecer_Click);
            // 
            // BTNActualizar
            // 
            this.BTNActualizar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNActualizar.FlatAppearance.BorderSize = 0;
            this.BTNActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNActualizar.Location = new System.Drawing.Point(138, 248);
            this.BTNActualizar.Name = "BTNActualizar";
            this.BTNActualizar.Size = new System.Drawing.Size(92, 23);
            this.BTNActualizar.TabIndex = 23;
            this.BTNActualizar.Text = "Actualizar";
            this.BTNActualizar.UseVisualStyleBackColor = false;
            this.BTNActualizar.Click += new System.EventHandler(this.BTNActualizar_Click);
            // 
            // LNuevaCategoria
            // 
            this.LNuevaCategoria.AutoSize = true;
            this.LNuevaCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.LNuevaCategoria.Location = new System.Drawing.Point(3, 33);
            this.LNuevaCategoria.Name = "LNuevaCategoria";
            this.LNuevaCategoria.Size = new System.Drawing.Size(143, 13);
            this.LNuevaCategoria.TabIndex = 2;
            this.LNuevaCategoria.Text = "Inserte una nueva categoria:";
            // 
            // BTNInsertar
            // 
            this.BTNInsertar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNInsertar.FlatAppearance.BorderSize = 0;
            this.BTNInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNInsertar.Location = new System.Drawing.Point(178, 47);
            this.BTNInsertar.Name = "BTNInsertar";
            this.BTNInsertar.Size = new System.Drawing.Size(62, 23);
            this.BTNInsertar.TabIndex = 1;
            this.BTNInsertar.Text = "Insertar";
            this.BTNInsertar.UseVisualStyleBackColor = false;
            this.BTNInsertar.Click += new System.EventHandler(this.BTNInsertar_Click);
            // 
            // TBCategoriaProducto
            // 
            this.errorProvider1.SetIconAlignment(this.TBCategoriaProducto, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.errorProvider1.SetIconPadding(this.TBCategoriaProducto, 1);
            this.TBCategoriaProducto.Location = new System.Drawing.Point(6, 49);
            this.TBCategoriaProducto.Name = "TBCategoriaProducto";
            this.TBCategoriaProducto.Size = new System.Drawing.Size(166, 20);
            this.TBCategoriaProducto.TabIndex = 0;
            this.TBCategoriaProducto.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBCategoriaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBCategoriaProducto_Validating);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.BTAgregar);
            this.panel6.Controls.Add(this.BTNReestablecer);
            this.panel6.Controls.Add(this.BTNCalcularMargen);
            this.panel6.Controls.Add(this.BTNLimpiar);
            this.panel6.Controls.Add(this.BTNActualizar);
            this.panel6.Controls.Add(this.LNroCod);
            this.panel6.Controls.Add(this.TBSkuProducto);
            this.panel6.Controls.Add(this.CBCategoriaProducto);
            this.panel6.Controls.Add(this.LMargen);
            this.panel6.Controls.Add(this.LStockMinimo);
            this.panel6.Controls.Add(this.LStock);
            this.panel6.Controls.Add(this.LCateg);
            this.panel6.Controls.Add(this.TBPrecioVenta);
            this.panel6.Controls.Add(this.TBPrecioCosto);
            this.panel6.Controls.Add(this.TBStockMinimo);
            this.panel6.Controls.Add(this.TBStockProducto);
            this.panel6.Controls.Add(this.TBNombreProducto);
            this.panel6.Controls.Add(this.LNombreArticulo);
            this.panel6.Controls.Add(this.TBContenidoProducto);
            this.panel6.Controls.Add(this.LMarcaArticulo);
            this.panel6.Controls.Add(this.LPrecio);
            this.panel6.Controls.Add(this.TBDescripcionProducto);
            this.panel6.Controls.Add(this.TBMarcaProducto);
            this.panel6.Controls.Add(this.LDescripcion);
            this.panel6.Controls.Add(this.LContenido);
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.tableLayoutPanel1.SetRowSpan(this.panel6, 2);
            this.panel6.Size = new System.Drawing.Size(269, 328);
            this.panel6.TabIndex = 2;
            // 
            // BTNCalcularMargen
            // 
            this.BTNCalcularMargen.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNCalcularMargen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNCalcularMargen.Image = global::WindowsFormsApp1.Properties.Resources.calculator;
            this.BTNCalcularMargen.Location = new System.Drawing.Point(138, 170);
            this.BTNCalcularMargen.Name = "BTNCalcularMargen";
            this.BTNCalcularMargen.Size = new System.Drawing.Size(16, 20);
            this.BTNCalcularMargen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BTNCalcularMargen.TabIndex = 25;
            this.BTNCalcularMargen.TabStop = false;
            this.BTNCalcularMargen.Click += new System.EventHandler(this.BTNCalcularMargen_Click);
            this.BTNCalcularMargen.MouseEnter += new System.EventHandler(this.BTNCalcularMargen_MouseEnter);
            this.BTNCalcularMargen.MouseLeave += new System.EventHandler(this.BTNCalcularMargen_MouseLeave);
            // 
            // LNroCod
            // 
            this.LNroCod.AutoSize = true;
            this.LNroCod.ForeColor = System.Drawing.SystemColors.Control;
            this.LNroCod.Location = new System.Drawing.Point(3, 194);
            this.LNroCod.Name = "LNroCod";
            this.LNroCod.Size = new System.Drawing.Size(43, 13);
            this.LNroCod.TabIndex = 24;
            this.LNroCod.Text = "Codigo:";
            // 
            // TBSkuProducto
            // 
            this.TBSkuProducto.Location = new System.Drawing.Point(6, 211);
            this.TBSkuProducto.Name = "TBSkuProducto";
            this.TBSkuProducto.Size = new System.Drawing.Size(105, 20);
            this.TBSkuProducto.TabIndex = 23;
            this.TBSkuProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBSkuProducto_Validating);
            // 
            // CBCategoriaProducto
            // 
            this.CBCategoriaProducto.FormattingEnabled = true;
            this.CBCategoriaProducto.Location = new System.Drawing.Point(138, 210);
            this.CBCategoriaProducto.Name = "CBCategoriaProducto";
            this.CBCategoriaProducto.Size = new System.Drawing.Size(105, 21);
            this.CBCategoriaProducto.TabIndex = 21;
            this.CBCategoriaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.CBCategoriaProducto_Validating);
            // 
            // LMargen
            // 
            this.LMargen.AutoSize = true;
            this.LMargen.ForeColor = System.Drawing.SystemColors.Control;
            this.LMargen.Location = new System.Drawing.Point(135, 154);
            this.LMargen.Name = "LMargen";
            this.LMargen.Size = new System.Drawing.Size(71, 13);
            this.LMargen.TabIndex = 20;
            this.LMargen.Text = "Precio Venta:";
            // 
            // LStockMinimo
            // 
            this.LStockMinimo.AutoSize = true;
            this.LStockMinimo.ForeColor = System.Drawing.SystemColors.Control;
            this.LStockMinimo.Location = new System.Drawing.Point(135, 116);
            this.LStockMinimo.Name = "LStockMinimo";
            this.LStockMinimo.Size = new System.Drawing.Size(74, 13);
            this.LStockMinimo.TabIndex = 19;
            this.LStockMinimo.Text = "Stock Minimo:";
            // 
            // LStock
            // 
            this.LStock.AutoSize = true;
            this.LStock.ForeColor = System.Drawing.SystemColors.Control;
            this.LStock.Location = new System.Drawing.Point(3, 116);
            this.LStock.Name = "LStock";
            this.LStock.Size = new System.Drawing.Size(38, 13);
            this.LStock.TabIndex = 18;
            this.LStock.Text = "Stock:";
            // 
            // LCateg
            // 
            this.LCateg.AutoSize = true;
            this.LCateg.ForeColor = System.Drawing.SystemColors.Control;
            this.LCateg.Location = new System.Drawing.Point(138, 194);
            this.LCateg.Name = "LCateg";
            this.LCateg.Size = new System.Drawing.Size(55, 13);
            this.LCateg.TabIndex = 17;
            this.LCateg.Text = "Categoria:";
            // 
            // TBPrecioVenta
            // 
            this.TBPrecioVenta.Location = new System.Drawing.Point(157, 170);
            this.TBPrecioVenta.Name = "TBPrecioVenta";
            this.TBPrecioVenta.Size = new System.Drawing.Size(86, 20);
            this.TBPrecioVenta.TabIndex = 16;
            // 
            // TBPrecioCosto
            // 
            this.TBPrecioCosto.Location = new System.Drawing.Point(6, 170);
            this.TBPrecioCosto.Name = "TBPrecioCosto";
            this.TBPrecioCosto.Size = new System.Drawing.Size(105, 20);
            this.TBPrecioCosto.TabIndex = 15;
            this.TBPrecioCosto.Validating += new System.ComponentModel.CancelEventHandler(this.TBPrecioCosto_Validating);
            // 
            // TBStockMinimo
            // 
            this.TBStockMinimo.Location = new System.Drawing.Point(138, 130);
            this.TBStockMinimo.Name = "TBStockMinimo";
            this.TBStockMinimo.Size = new System.Drawing.Size(105, 20);
            this.TBStockMinimo.TabIndex = 14;
            this.TBStockMinimo.Validating += new System.ComponentModel.CancelEventHandler(this.TBStockMinimo_Validating);
            // 
            // TBStockProducto
            // 
            this.TBStockProducto.Location = new System.Drawing.Point(6, 130);
            this.TBStockProducto.Name = "TBStockProducto";
            this.TBStockProducto.Size = new System.Drawing.Size(105, 20);
            this.TBStockProducto.TabIndex = 11;
            this.TBStockProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBStockProducto_Validating);
            // 
            // TBNombreProducto
            // 
            this.TBNombreProducto.Location = new System.Drawing.Point(138, 50);
            this.TBNombreProducto.Name = "TBNombreProducto";
            this.TBNombreProducto.Size = new System.Drawing.Size(105, 20);
            this.TBNombreProducto.TabIndex = 13;
            this.TBNombreProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBNombreProducto_Validating);
            // 
            // LNombreArticulo
            // 
            this.LNombreArticulo.AutoSize = true;
            this.LNombreArticulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LNombreArticulo.Location = new System.Drawing.Point(135, 36);
            this.LNombreArticulo.Name = "LNombreArticulo";
            this.LNombreArticulo.Size = new System.Drawing.Size(47, 13);
            this.LNombreArticulo.TabIndex = 12;
            this.LNombreArticulo.Text = "Nombre:";
            // 
            // TBContenidoProducto
            // 
            this.TBContenidoProducto.Location = new System.Drawing.Point(138, 90);
            this.TBContenidoProducto.Name = "TBContenidoProducto";
            this.TBContenidoProducto.Size = new System.Drawing.Size(105, 20);
            this.TBContenidoProducto.TabIndex = 8;
            this.TBContenidoProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBContenidoProducto_Validating);
            // 
            // LMarcaArticulo
            // 
            this.LMarcaArticulo.AutoSize = true;
            this.LMarcaArticulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LMarcaArticulo.Location = new System.Drawing.Point(3, 36);
            this.LMarcaArticulo.Name = "LMarcaArticulo";
            this.LMarcaArticulo.Size = new System.Drawing.Size(40, 13);
            this.LMarcaArticulo.TabIndex = 0;
            this.LMarcaArticulo.Text = "Marca:";
            // 
            // LPrecio
            // 
            this.LPrecio.AutoSize = true;
            this.LPrecio.ForeColor = System.Drawing.SystemColors.Control;
            this.LPrecio.Location = new System.Drawing.Point(3, 154);
            this.LPrecio.Name = "LPrecio";
            this.LPrecio.Size = new System.Drawing.Size(70, 13);
            this.LPrecio.TabIndex = 3;
            this.LPrecio.Text = "Precio Costo:";
            // 
            // TBDescripcionProducto
            // 
            this.TBDescripcionProducto.Location = new System.Drawing.Point(6, 90);
            this.TBDescripcionProducto.Name = "TBDescripcionProducto";
            this.TBDescripcionProducto.Size = new System.Drawing.Size(105, 20);
            this.TBDescripcionProducto.TabIndex = 6;
            this.TBDescripcionProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBDescripcionProducto_Validating);
            // 
            // TBMarcaProducto
            // 
            this.TBMarcaProducto.Location = new System.Drawing.Point(6, 50);
            this.TBMarcaProducto.Name = "TBMarcaProducto";
            this.TBMarcaProducto.Size = new System.Drawing.Size(105, 20);
            this.TBMarcaProducto.TabIndex = 5;
            this.TBMarcaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBMarcaProducto_Validating);
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.ForeColor = System.Drawing.SystemColors.Control;
            this.LDescripcion.Location = new System.Drawing.Point(3, 73);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(66, 13);
            this.LDescripcion.TabIndex = 2;
            this.LDescripcion.Text = "Descripcion:";
            // 
            // LContenido
            // 
            this.LContenido.AutoSize = true;
            this.LContenido.ForeColor = System.Drawing.SystemColors.Control;
            this.LContenido.Location = new System.Drawing.Point(135, 73);
            this.LContenido.Name = "LContenido";
            this.LContenido.Size = new System.Drawing.Size(58, 13);
            this.LContenido.TabIndex = 1;
            this.LContenido.Text = "Contenido:";
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNLimpiar.FlatAppearance.BorderSize = 0;
            this.BTNLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLimpiar.Location = new System.Drawing.Point(36, 248);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BTNLimpiar.TabIndex = 22;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // BTAgregar
            // 
            this.BTAgregar.AutoSize = true;
            this.BTAgregar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTAgregar.FlatAppearance.BorderSize = 0;
            this.BTAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregar.Location = new System.Drawing.Point(138, 248);
            this.BTAgregar.Name = "BTAgregar";
            this.BTAgregar.Size = new System.Drawing.Size(92, 23);
            this.BTAgregar.TabIndex = 10;
            this.BTAgregar.Text = "Agregar";
            this.BTAgregar.UseVisualStyleBackColor = false;
            this.BTAgregar.Click += new System.EventHandler(this.Registrar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.tableLayoutPanel1);
            this.panel7.Location = new System.Drawing.Point(13, 11);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(832, 551);
            this.panel7.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 46);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(826, 502);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel8.Controls.Add(this.LCategorias);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(269, 30);
            this.panel8.TabIndex = 3;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCategorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCategorias.ColumnHeadersHeight = 21;
            this.DGVCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DGVCategorias.EnableHeadersVisualStyles = false;
            this.DGVCategorias.Location = new System.Drawing.Point(6, 81);
            this.DGVCategorias.Name = "DGVCategorias";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCategorias.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVCategorias.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVCategorias.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVCategorias.Size = new System.Drawing.Size(260, 78);
            this.DGVCategorias.TabIndex = 4;
            this.DGVCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVCategorias_CellContentClick);
            this.DGVCategorias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Categoria";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel9.Controls.Add(this.label1);
            this.panel9.Location = new System.Drawing.Point(13, 11);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(832, 33);
            this.panel9.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestion de Productos";
            // 
            // GestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 500);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(883, 586);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionProductos";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BTNCalcularMargen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCategorias)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LRegistrar;
        private System.Windows.Forms.Label LProductos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BTNBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label LNuevaCategoria;
        private System.Windows.Forms.Button BTNInsertar;
        private System.Windows.Forms.TextBox TBCategoriaProducto;
        private System.Windows.Forms.TextBox TBNombreProducto;
        private System.Windows.Forms.TextBox TBStockProducto;
        private System.Windows.Forms.Button BTAgregar;
        private System.Windows.Forms.TextBox TBContenidoProducto;
        private System.Windows.Forms.TextBox TBDescripcionProducto;
        private System.Windows.Forms.Label LPrecio;
        private System.Windows.Forms.Label LDescripcion;
        private System.Windows.Forms.Label LContenido;
        private System.Windows.Forms.Label LNombreArticulo;
        private System.Windows.Forms.Label LMarcaArticulo;
        private System.Windows.Forms.TextBox TBMarcaProducto;
        private System.Windows.Forms.Label LCateg;
        private System.Windows.Forms.TextBox TBPrecioVenta;
        private System.Windows.Forms.TextBox TBPrecioCosto;
        private System.Windows.Forms.TextBox TBStockMinimo;
        private System.Windows.Forms.Label LMargen;
        private System.Windows.Forms.Label LStockMinimo;
        private System.Windows.Forms.Label LStock;
        private System.Windows.Forms.ComboBox CBCategoriaProducto;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.Label LNroCod;
        private System.Windows.Forms.TextBox TBSkuProducto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox BTNCalcularMargen;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn CContenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMargenPrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecioV;
        private System.Windows.Forms.DataGridViewButtonColumn CEstado;
        private System.Windows.Forms.Button BTNReestablecer;
        private System.Windows.Forms.Button BTNActualizar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label LCategorias;
        private System.Windows.Forms.DataGridView DGVCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label1;
    }
}