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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.PCategoria = new System.Windows.Forms.Panel();
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
            this.LCategoria = new System.Windows.Forms.Label();
            this.LProducto = new System.Windows.Forms.Label();
            this.BTAgregar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PCategoria.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BTNCalcularMargen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 571);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.LRegistrar);
            this.panel5.Location = new System.Drawing.Point(13, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(286, 33);
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
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.BTNBuscar);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(305, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 556);
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
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
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
            this.dataGridView1.Location = new System.Drawing.Point(7, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(450, 465);
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
            this.textBox1.Size = new System.Drawing.Size(221, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBBuscar_MouseClick);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscar.FlatAppearance.BorderSize = 0;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.Location = new System.Drawing.Point(234, 47);
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
            this.panel4.Size = new System.Drawing.Size(459, 33);
            this.panel4.TabIndex = 0;
            // 
            // LProductos
            // 
            this.LProductos.AutoSize = true;
            this.LProductos.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LProductos.Location = new System.Drawing.Point(3, 9);
            this.LProductos.Name = "LProductos";
            this.LProductos.Size = new System.Drawing.Size(72, 18);
            this.LProductos.TabIndex = 1;
            this.LProductos.Text = "Productos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTNReestablecer);
            this.panel2.Controls.Add(this.BTNActualizar);
            this.panel2.Controls.Add(this.PCategoria);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.BTNLimpiar);
            this.panel2.Controls.Add(this.LCategoria);
            this.panel2.Controls.Add(this.LProducto);
            this.panel2.Controls.Add(this.BTAgregar);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 556);
            this.panel2.TabIndex = 0;
            // 
            // BTNReestablecer
            // 
            this.BTNReestablecer.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNReestablecer.FlatAppearance.BorderSize = 0;
            this.BTNReestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNReestablecer.Location = new System.Drawing.Point(55, 467);
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
            this.BTNActualizar.Location = new System.Drawing.Point(160, 467);
            this.BTNActualizar.Name = "BTNActualizar";
            this.BTNActualizar.Size = new System.Drawing.Size(92, 23);
            this.BTNActualizar.TabIndex = 23;
            this.BTNActualizar.Text = "Actualizar";
            this.BTNActualizar.UseVisualStyleBackColor = false;
            this.BTNActualizar.Click += new System.EventHandler(this.BTNActualizar_Click);
            // 
            // PCategoria
            // 
            this.PCategoria.Controls.Add(this.LNuevaCategoria);
            this.PCategoria.Controls.Add(this.BTNInsertar);
            this.PCategoria.Controls.Add(this.TBCategoriaProducto);
            this.PCategoria.Location = new System.Drawing.Point(3, 52);
            this.PCategoria.Name = "PCategoria";
            this.PCategoria.Size = new System.Drawing.Size(280, 47);
            this.PCategoria.TabIndex = 3;
            // 
            // LNuevaCategoria
            // 
            this.LNuevaCategoria.AutoSize = true;
            this.LNuevaCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.LNuevaCategoria.Location = new System.Drawing.Point(12, 5);
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
            this.BTNInsertar.Location = new System.Drawing.Point(187, 19);
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
            this.TBCategoriaProducto.Location = new System.Drawing.Point(15, 21);
            this.TBCategoriaProducto.Name = "TBCategoriaProducto";
            this.TBCategoriaProducto.Size = new System.Drawing.Size(166, 20);
            this.TBCategoriaProducto.TabIndex = 0;
            this.TBCategoriaProducto.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBCategoriaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBCategoriaProducto_Validating);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BTNCalcularMargen);
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
            this.panel6.Location = new System.Drawing.Point(6, 118);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(277, 343);
            this.panel6.TabIndex = 2;
            // 
            // BTNCalcularMargen
            // 
            this.BTNCalcularMargen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNCalcularMargen.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNCalcularMargen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTNCalcularMargen.Image = global::WindowsFormsApp1.Properties.Resources.calculator;
            this.BTNCalcularMargen.Location = new System.Drawing.Point(85, 284);
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
            this.LNroCod.Location = new System.Drawing.Point(6, 321);
            this.LNroCod.Name = "LNroCod";
            this.LNroCod.Size = new System.Drawing.Size(43, 13);
            this.LNroCod.TabIndex = 24;
            this.LNroCod.Text = "Codigo:";
            // 
            // TBSkuProducto
            // 
            this.TBSkuProducto.Location = new System.Drawing.Point(107, 318);
            this.TBSkuProducto.Name = "TBSkuProducto";
            this.TBSkuProducto.Size = new System.Drawing.Size(116, 20);
            this.TBSkuProducto.TabIndex = 23;
            this.TBSkuProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBSkuProducto_Validating);
            // 
            // CBCategoriaProducto
            // 
            this.CBCategoriaProducto.FormattingEnabled = true;
            this.CBCategoriaProducto.Location = new System.Drawing.Point(107, 114);
            this.CBCategoriaProducto.Name = "CBCategoriaProducto";
            this.CBCategoriaProducto.Size = new System.Drawing.Size(116, 21);
            this.CBCategoriaProducto.TabIndex = 21;
            this.CBCategoriaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.CBCategoriaProducto_Validating);
            // 
            // LMargen
            // 
            this.LMargen.AutoSize = true;
            this.LMargen.ForeColor = System.Drawing.SystemColors.Control;
            this.LMargen.Location = new System.Drawing.Point(3, 287);
            this.LMargen.Name = "LMargen";
            this.LMargen.Size = new System.Drawing.Size(71, 13);
            this.LMargen.TabIndex = 20;
            this.LMargen.Text = "Precio Venta:";
            // 
            // LStockMinimo
            // 
            this.LStockMinimo.AutoSize = true;
            this.LStockMinimo.ForeColor = System.Drawing.SystemColors.Control;
            this.LStockMinimo.Location = new System.Drawing.Point(3, 219);
            this.LStockMinimo.Name = "LStockMinimo";
            this.LStockMinimo.Size = new System.Drawing.Size(74, 13);
            this.LStockMinimo.TabIndex = 19;
            this.LStockMinimo.Text = "Stock Minimo:";
            // 
            // LStock
            // 
            this.LStock.AutoSize = true;
            this.LStock.ForeColor = System.Drawing.SystemColors.Control;
            this.LStock.Location = new System.Drawing.Point(3, 185);
            this.LStock.Name = "LStock";
            this.LStock.Size = new System.Drawing.Size(38, 13);
            this.LStock.TabIndex = 18;
            this.LStock.Text = "Stock:";
            // 
            // LCateg
            // 
            this.LCateg.AutoSize = true;
            this.LCateg.ForeColor = System.Drawing.SystemColors.Control;
            this.LCateg.Location = new System.Drawing.Point(3, 117);
            this.LCateg.Name = "LCateg";
            this.LCateg.Size = new System.Drawing.Size(55, 13);
            this.LCateg.TabIndex = 17;
            this.LCateg.Text = "Categoria:";
            // 
            // TBPrecioVenta
            // 
            this.TBPrecioVenta.Location = new System.Drawing.Point(107, 284);
            this.TBPrecioVenta.Name = "TBPrecioVenta";
            this.TBPrecioVenta.Size = new System.Drawing.Size(116, 20);
            this.TBPrecioVenta.TabIndex = 16;
            // 
            // TBPrecioCosto
            // 
            this.TBPrecioCosto.Location = new System.Drawing.Point(107, 250);
            this.TBPrecioCosto.Name = "TBPrecioCosto";
            this.TBPrecioCosto.Size = new System.Drawing.Size(116, 20);
            this.TBPrecioCosto.TabIndex = 15;
            this.TBPrecioCosto.Validating += new System.ComponentModel.CancelEventHandler(this.TBPrecioCosto_Validating);
            // 
            // TBStockMinimo
            // 
            this.TBStockMinimo.Location = new System.Drawing.Point(107, 216);
            this.TBStockMinimo.Name = "TBStockMinimo";
            this.TBStockMinimo.Size = new System.Drawing.Size(116, 20);
            this.TBStockMinimo.TabIndex = 14;
            this.TBStockMinimo.Validating += new System.ComponentModel.CancelEventHandler(this.TBStockMinimo_Validating);
            // 
            // TBStockProducto
            // 
            this.TBStockProducto.Location = new System.Drawing.Point(107, 182);
            this.TBStockProducto.Name = "TBStockProducto";
            this.TBStockProducto.Size = new System.Drawing.Size(116, 20);
            this.TBStockProducto.TabIndex = 11;
            this.TBStockProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBStockProducto_Validating);
            // 
            // TBNombreProducto
            // 
            this.TBNombreProducto.Location = new System.Drawing.Point(107, 46);
            this.TBNombreProducto.Name = "TBNombreProducto";
            this.TBNombreProducto.Size = new System.Drawing.Size(116, 20);
            this.TBNombreProducto.TabIndex = 13;
            this.TBNombreProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBNombreProducto_Validating);
            // 
            // LNombreArticulo
            // 
            this.LNombreArticulo.AutoSize = true;
            this.LNombreArticulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LNombreArticulo.Location = new System.Drawing.Point(3, 49);
            this.LNombreArticulo.Name = "LNombreArticulo";
            this.LNombreArticulo.Size = new System.Drawing.Size(47, 13);
            this.LNombreArticulo.TabIndex = 12;
            this.LNombreArticulo.Text = "Nombre:";
            // 
            // TBContenidoProducto
            // 
            this.TBContenidoProducto.Location = new System.Drawing.Point(107, 148);
            this.TBContenidoProducto.Name = "TBContenidoProducto";
            this.TBContenidoProducto.Size = new System.Drawing.Size(116, 20);
            this.TBContenidoProducto.TabIndex = 8;
            this.TBContenidoProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBContenidoProducto_Validating);
            // 
            // LMarcaArticulo
            // 
            this.LMarcaArticulo.AutoSize = true;
            this.LMarcaArticulo.ForeColor = System.Drawing.SystemColors.Control;
            this.LMarcaArticulo.Location = new System.Drawing.Point(3, 15);
            this.LMarcaArticulo.Name = "LMarcaArticulo";
            this.LMarcaArticulo.Size = new System.Drawing.Size(40, 13);
            this.LMarcaArticulo.TabIndex = 0;
            this.LMarcaArticulo.Text = "Marca:";
            // 
            // LPrecio
            // 
            this.LPrecio.AutoSize = true;
            this.LPrecio.ForeColor = System.Drawing.SystemColors.Control;
            this.LPrecio.Location = new System.Drawing.Point(3, 253);
            this.LPrecio.Name = "LPrecio";
            this.LPrecio.Size = new System.Drawing.Size(70, 13);
            this.LPrecio.TabIndex = 3;
            this.LPrecio.Text = "Precio Costo:";
            // 
            // TBDescripcionProducto
            // 
            this.TBDescripcionProducto.Location = new System.Drawing.Point(107, 80);
            this.TBDescripcionProducto.Name = "TBDescripcionProducto";
            this.TBDescripcionProducto.Size = new System.Drawing.Size(116, 20);
            this.TBDescripcionProducto.TabIndex = 6;
            this.TBDescripcionProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBDescripcionProducto_Validating);
            // 
            // TBMarcaProducto
            // 
            this.TBMarcaProducto.Location = new System.Drawing.Point(107, 12);
            this.TBMarcaProducto.Name = "TBMarcaProducto";
            this.TBMarcaProducto.Size = new System.Drawing.Size(116, 20);
            this.TBMarcaProducto.TabIndex = 5;
            this.TBMarcaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBMarcaProducto_Validating);
            // 
            // LDescripcion
            // 
            this.LDescripcion.AutoSize = true;
            this.LDescripcion.ForeColor = System.Drawing.SystemColors.Control;
            this.LDescripcion.Location = new System.Drawing.Point(3, 83);
            this.LDescripcion.Name = "LDescripcion";
            this.LDescripcion.Size = new System.Drawing.Size(66, 13);
            this.LDescripcion.TabIndex = 2;
            this.LDescripcion.Text = "Descripcion:";
            // 
            // LContenido
            // 
            this.LContenido.AutoSize = true;
            this.LContenido.ForeColor = System.Drawing.SystemColors.Control;
            this.LContenido.Location = new System.Drawing.Point(3, 151);
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
            this.BTNLimpiar.Location = new System.Drawing.Point(67, 467);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BTNLimpiar.TabIndex = 22;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // LCategoria
            // 
            this.LCategoria.AutoSize = true;
            this.LCategoria.ForeColor = System.Drawing.SystemColors.Control;
            this.LCategoria.Location = new System.Drawing.Point(3, 36);
            this.LCategoria.Name = "LCategoria";
            this.LCategoria.Size = new System.Drawing.Size(52, 13);
            this.LCategoria.TabIndex = 1;
            this.LCategoria.Text = "Categoria";
            // 
            // LProducto
            // 
            this.LProducto.AutoSize = true;
            this.LProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.LProducto.Location = new System.Drawing.Point(3, 102);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(50, 13);
            this.LProducto.TabIndex = 0;
            this.LProducto.Text = "Producto";
            // 
            // BTAgregar
            // 
            this.BTAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTAgregar.AutoSize = true;
            this.BTAgregar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTAgregar.FlatAppearance.BorderSize = 0;
            this.BTAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregar.Location = new System.Drawing.Point(160, 467);
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
            // GestionProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(750, 500);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 586);
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
            this.PCategoria.ResumeLayout(false);
            this.PCategoria.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BTNCalcularMargen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
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
        private System.Windows.Forms.Label LCategoria;
        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Panel PCategoria;
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
    }
}