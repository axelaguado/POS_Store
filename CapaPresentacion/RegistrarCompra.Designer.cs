namespace WindowsFormsApp1.CapaPresentacion
{
    partial class RegistrarCompra
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
            this.DGVCompra = new System.Windows.Forms.DataGridView();
            this.dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CInformacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTRegistrarCompra = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LTotal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTNBuscarCuit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TBProveedorCuit = new System.Windows.Forms.TextBox();
            this.BTLimpiar = new System.Windows.Forms.Button();
            this.BTAgregarProducto = new System.Windows.Forms.Button();
            this.TBProductoInformacion = new System.Windows.Forms.TextBox();
            this.TBProductoPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBProductoCantidad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BTNBuscarSku = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TBProductoSku = new System.Windows.Forms.TextBox();
            this.CBProducto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CBProveedor = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components); 
            ((System.ComponentModel.ISupportInitialize)(this.DGVCompra)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVCompra
            // 
            DGVCompra.AllowUserToAddRows = false;
            DGVCompra.AllowUserToDeleteRows = false;
            DGVCompra.AllowUserToResizeColumns = false;
            DGVCompra.AllowUserToResizeRows = false;
            DGVCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            DGVCompra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            DGVCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            DGVCompra.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            DGVCompra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            DGVCompra.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            DGVCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DGVCompra.ColumnHeadersHeight = 30;
            DGVCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            DGVCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProducto,
            this.CCantida,
            this.CInformacion,
            this.CPrecio,
            this.CBorrar});
            DGVCompra.EnableHeadersVisualStyles = false;
            DGVCompra.GridColor = System.Drawing.SystemColors.ActiveBorder;
            DGVCompra.Location = new System.Drawing.Point(6, 3);
            DGVCompra.Name = "DGVCompra";
            DGVCompra.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            DGVCompra.RowsDefaultCellStyle = dataGridViewCellStyle6;
            DGVCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DGVCompra.Size = new System.Drawing.Size(747, 234);
            DGVCompra.TabIndex = 8;
            DGVCompra.DataSourceChanged += new System.EventHandler(this.DGVCompra_DataSourceChanged);
            DGVCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPedido_CellContentClick);
            // 
            // CProducto
            // 
            this.CProducto.HeaderText = "Producto";
            this.CProducto.Name = "CProducto";
            // 
            // CCantida
            // 
            this.CCantida.HeaderText = "Cantidad";
            this.CCantida.Name = "CCantida";
            // 
            // CInformacion
            // 
            this.CInformacion.HeaderText = "Informacion";
            this.CInformacion.Name = "CInformacion";
            // 
            // CPrecio
            // 
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            // 
            // CBorrar
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.CBorrar.DefaultCellStyle = dataGridViewCellStyle5;
            this.CBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBorrar.HeaderText = "Eliminar";
            this.CBorrar.Name = "CBorrar";
            this.CBorrar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.BTRegistrarCompra);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 521);
            this.panel1.TabIndex = 0;
            // 
            // BTRegistrarCompra
            // 
            this.BTRegistrarCompra.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BTRegistrarCompra.AutoSize = true;
            this.BTRegistrarCompra.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTRegistrarCompra.FlatAppearance.BorderSize = 0;
            this.BTRegistrarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTRegistrarCompra.Location = new System.Drawing.Point(335, 479);
            this.BTRegistrarCompra.Name = "BTRegistrarCompra";
            this.BTRegistrarCompra.Size = new System.Drawing.Size(94, 26);
            this.BTRegistrarCompra.TabIndex = 6;
            this.BTRegistrarCompra.Text = "Finalizar Compra";
            this.BTRegistrarCompra.UseVisualStyleBackColor = false;
            this.BTRegistrarCompra.Click += new System.EventHandler(this.BTRegistrarCompra_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.LTitulo);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 33);
            this.panel2.TabIndex = 1;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.LTitulo.Location = new System.Drawing.Point(2, 7);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(126, 18);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Registrar Compra ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(759, 430);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(DGVCompra);
            this.panel3.Location = new System.Drawing.Point(3, 153);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(753, 274);
            this.panel3.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel5.Controls.Add(this.LTotal);
            this.panel5.Location = new System.Drawing.Point(618, 243);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(135, 27);
            this.panel5.TabIndex = 9;
            // 
            // LTotal
            // 
            this.LTotal.AutoSize = true;
            this.LTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTotal.Location = new System.Drawing.Point(4, 7);
            this.LTotal.Name = "LTotal";
            this.LTotal.Size = new System.Drawing.Size(51, 13);
            this.LTotal.TabIndex = 0;
            this.LTotal.Text = "Total: $";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.BTNBuscarCuit);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.TBProveedorCuit);
            this.panel4.Controls.Add(this.BTLimpiar);
            this.panel4.Controls.Add(this.BTAgregarProducto);
            this.panel4.Controls.Add(this.TBProductoInformacion);
            this.panel4.Controls.Add(this.TBProductoPrecio);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.TBProductoCantidad);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.BTNBuscarSku);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.TBProductoSku);
            this.panel4.Controls.Add(this.CBProducto);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.CBProveedor);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(753, 144);
            this.panel4.TabIndex = 1;
            // 
            // BTNBuscarCuit
            // 
            this.BTNBuscarCuit.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscarCuit.FlatAppearance.BorderSize = 0;
            this.BTNBuscarCuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscarCuit.Image = global::WindowsFormsApp1.Properties.Resources.lupa;
            this.BTNBuscarCuit.Location = new System.Drawing.Point(135, 67);
            this.BTNBuscarCuit.Name = "BTNBuscarCuit";
            this.BTNBuscarCuit.Size = new System.Drawing.Size(28, 23);
            this.BTNBuscarCuit.TabIndex = 20;
            this.BTNBuscarCuit.UseVisualStyleBackColor = false;
            this.BTNBuscarCuit.Click += new System.EventHandler(this.BTNBuscarCuit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cuit:";
            // 
            // TBProveedorCuit
            // 
            this.TBProveedorCuit.Location = new System.Drawing.Point(6, 69);
            this.TBProveedorCuit.Name = "TBProveedorCuit";
            this.TBProveedorCuit.Size = new System.Drawing.Size(123, 20);
            this.TBProveedorCuit.TabIndex = 18;
            this.TBProveedorCuit.Validating += new System.ComponentModel.CancelEventHandler(this.TBProveedorCuit_Validating);
            // 
            // BTLimpiar
            // 
            this.BTLimpiar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTLimpiar.FlatAppearance.BorderSize = 0;
            this.BTLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTLimpiar.Location = new System.Drawing.Point(618, 45);
            this.BTLimpiar.Name = "BTLimpiar";
            this.BTLimpiar.Size = new System.Drawing.Size(99, 23);
            this.BTLimpiar.TabIndex = 9;
            this.BTLimpiar.Text = "Limpiar";
            this.BTLimpiar.UseVisualStyleBackColor = false;
            this.BTLimpiar.Click += new System.EventHandler(this.BTLimpiar_Click);
            // 
            // BTAgregarProducto
            // 
            this.BTAgregarProducto.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTAgregarProducto.FlatAppearance.BorderSize = 0;
            this.BTAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTAgregarProducto.Location = new System.Drawing.Point(618, 95);
            this.BTAgregarProducto.Name = "BTAgregarProducto";
            this.BTAgregarProducto.Size = new System.Drawing.Size(99, 23);
            this.BTAgregarProducto.TabIndex = 17;
            this.BTAgregarProducto.Text = "Agregar Producto";
            this.BTAgregarProducto.UseVisualStyleBackColor = false;
            this.BTAgregarProducto.Click += new System.EventHandler(this.BTAgregarProducto_Click);
            // 
            // TBProductoInformacion
            // 
            this.TBProductoInformacion.Location = new System.Drawing.Point(452, 115);
            this.TBProductoInformacion.Name = "TBProductoInformacion";
            this.TBProductoInformacion.Size = new System.Drawing.Size(123, 20);
            this.TBProductoInformacion.TabIndex = 16;
            this.TBProductoInformacion.Validating += new System.ComponentModel.CancelEventHandler(this.TBProductoInformacion_Validating);
            // 
            // TBProductoPrecio
            // 
            this.TBProductoPrecio.Location = new System.Drawing.Point(452, 70);
            this.TBProductoPrecio.Name = "TBProductoPrecio";
            this.TBProductoPrecio.Size = new System.Drawing.Size(123, 20);
            this.TBProductoPrecio.TabIndex = 15;
            this.TBProductoPrecio.TextChanged += new System.EventHandler(this.TB_TextChanged);
            this.TBProductoPrecio.Validating += new System.ComponentModel.CancelEventHandler(this.TBProductoPrecio_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(449, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Informacion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(247, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cantidad (unidades):";
            // 
            // TBProductoCantidad
            // 
            this.TBProductoCantidad.Location = new System.Drawing.Point(250, 115);
            this.TBProductoCantidad.Name = "TBProductoCantidad";
            this.TBProductoCantidad.Size = new System.Drawing.Size(123, 20);
            this.TBProductoCantidad.TabIndex = 12;
            this.TBProductoCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.TBProductoCantidad_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(449, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Precio:";
            // 
            // BTNBuscarSku
            // 
            this.BTNBuscarSku.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscarSku.FlatAppearance.BorderSize = 0;
            this.BTNBuscarSku.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscarSku.Image = global::WindowsFormsApp1.Properties.Resources.lupa;
            this.BTNBuscarSku.Location = new System.Drawing.Point(379, 68);
            this.BTNBuscarSku.Name = "BTNBuscarSku";
            this.BTNBuscarSku.Size = new System.Drawing.Size(28, 23);
            this.BTNBuscarSku.TabIndex = 8;
            this.BTNBuscarSku.UseVisualStyleBackColor = false;
            this.BTNBuscarSku.Click += new System.EventHandler(this.BTNBuscarSku_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(247, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sku:";
            // 
            // TBProductoSku
            // 
            this.TBProductoSku.Location = new System.Drawing.Point(250, 70);
            this.TBProductoSku.Name = "TBProductoSku";
            this.TBProductoSku.Size = new System.Drawing.Size(123, 20);
            this.TBProductoSku.TabIndex = 5;
            this.TBProductoSku.Validating += new System.ComponentModel.CancelEventHandler(this.TBProductoSku_Validating);
            // 
            // CBProducto
            // 
            this.CBProducto.FormattingEnabled = true;
            this.CBProducto.Location = new System.Drawing.Point(250, 23);
            this.CBProducto.Name = "CBProducto";
            this.CBProducto.Size = new System.Drawing.Size(325, 21);
            this.CBProducto.TabIndex = 3;
            this.CBProducto.SelectedIndexChanged += new System.EventHandler(this.CBProducto_SelectedIndexChanged);
            this.CBProducto.TextChanged += new System.EventHandler(this.CBProdoucto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(247, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proveedor:";
            // 
            // CBProveedor
            // 
            this.CBProveedor.FormattingEnabled = true;
            this.CBProveedor.Location = new System.Drawing.Point(6, 23);
            this.CBProveedor.Name = "CBProveedor";
            this.CBProveedor.Size = new System.Drawing.Size(208, 21);
            this.CBProveedor.TabIndex = 0;
            this.CBProveedor.SelectedIndexChanged += new System.EventHandler(this.CBProveedor_SelectedIndexChanged);
            this.CBProveedor.TextChanged += new System.EventHandler(this.CBProveedor_TextChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegistrarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 500);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrarPedido";
            this.Text = "RegistrarPedido";
            ((System.ComponentModel.ISupportInitialize)(DGVCompra)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox CBProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBProductoSku;
        private System.Windows.Forms.ComboBox CBProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTNBuscarSku;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBProductoCantidad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBProductoInformacion;
        private System.Windows.Forms.TextBox TBProductoPrecio;
        private System.Windows.Forms.Button BTAgregarProducto;
        private System.Windows.Forms.Button BTLimpiar;
        private System.Windows.Forms.Button BTRegistrarCompra;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LTotal;
        private System.Windows.Forms.Button BTNBuscarCuit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBProveedorCuit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView DGVCompra;
        private System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6;
        private System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5;
        private System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4; 
        private System.Windows.Forms.DataGridViewTextBoxColumn CProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CInformacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
        private System.Windows.Forms.DataGridViewButtonColumn CBorrar;
    }
}