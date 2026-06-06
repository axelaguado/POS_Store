namespace WindowsFormsApp1.CapaPresentacion
{
    partial class GestionCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.DGVPedidosConfirmados = new System.Windows.Forms.DataGridView();
            this.CNumeroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProveedorPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMontoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDetalle = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.LPedidosConfirmados = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVPedidosPendientes = new System.Windows.Forms.DataGridView();
            this.CNroPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDetalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CRecibir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CCancelar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPedidosConfirmados)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPedidosPendientes)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 483);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.TBBuscar);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(13, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 468);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 388);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.DGVPedidosConfirmados);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Location = new System.Drawing.Point(421, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(412, 382);
            this.panel5.TabIndex = 4;
            // 
            // DGVPedidosConfirmados
            // 
            this.DGVPedidosConfirmados.AllowUserToAddRows = false;
            this.DGVPedidosConfirmados.AllowUserToDeleteRows = false;
            this.DGVPedidosConfirmados.AllowUserToResizeColumns = false;
            this.DGVPedidosConfirmados.AllowUserToResizeRows = false;
            this.DGVPedidosConfirmados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVPedidosConfirmados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVPedidosConfirmados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVPedidosConfirmados.BackgroundColor = System.Drawing.Color.LightGreen;
            this.DGVPedidosConfirmados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPedidosConfirmados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.LimeGreen;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPedidosConfirmados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.DGVPedidosConfirmados.ColumnHeadersHeight = 30;
            this.DGVPedidosConfirmados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPedidosConfirmados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNumeroPedido,
            this.CProveedorPedido,
            this.CMontoPedido,
            this.CDetalle});
            this.DGVPedidosConfirmados.EnableHeadersVisualStyles = false;
            this.DGVPedidosConfirmados.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DGVPedidosConfirmados.Location = new System.Drawing.Point(5, 46);
            this.DGVPedidosConfirmados.Name = "DGVPedidosConfirmados";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPedidosConfirmados.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DGVPedidosConfirmados.RowHeadersVisible = false;
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVPedidosConfirmados.RowsDefaultCellStyle = dataGridViewCellStyle21;
            this.DGVPedidosConfirmados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPedidosConfirmados.Size = new System.Drawing.Size(404, 333);
            this.DGVPedidosConfirmados.TabIndex = 3;
            this.DGVPedidosConfirmados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPedidosPendientesConfirmados_CellContentClick);
            // 
            // CNumeroPedido
            // 
            this.CNumeroPedido.HeaderText = "Nro. Compra";
            this.CNumeroPedido.Name = "CNumeroPedido";
            this.CNumeroPedido.Width = 83;
            // 
            // CProveedorPedido
            // 
            this.CProveedorPedido.HeaderText = "Proveedor";
            this.CProveedorPedido.Name = "CProveedorPedido";
            this.CProveedorPedido.Width = 80;
            // 
            // CMontoPedido
            // 
            this.CMontoPedido.HeaderText = "Monto";
            this.CMontoPedido.Name = "CMontoPedido";
            this.CMontoPedido.Width = 61;
            // 
            // CDetalle
            // 
            this.CDetalle.HeaderText = "Detalles";
            this.CDetalle.Name = "CDetalle";
            this.CDetalle.Width = 50;
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.LimeGreen;
            this.panel7.Controls.Add(this.LPedidosConfirmados);
            this.panel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel7.Location = new System.Drawing.Point(5, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(404, 33);
            this.panel7.TabIndex = 1;
            // 
            // LPedidosConfirmados
            // 
            this.LPedidosConfirmados.AutoSize = true;
            this.LPedidosConfirmados.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.LPedidosConfirmados.Location = new System.Drawing.Point(3, 11);
            this.LPedidosConfirmados.Name = "LPedidosConfirmados";
            this.LPedidosConfirmados.Size = new System.Drawing.Size(112, 13);
            this.LPedidosConfirmados.TabIndex = 1;
            this.LPedidosConfirmados.Text = "Compras Confirmadas";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.DGVPedidosPendientes);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(412, 382);
            this.panel4.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.Gold;
            this.panel6.Controls.Add(this.label2);
            this.panel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel6.Location = new System.Drawing.Point(3, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(404, 33);
            this.panel6.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Compras Pendientes";
            // 
            // DGVPedidosPendientes
            // 
            this.DGVPedidosPendientes.AllowUserToAddRows = false;
            this.DGVPedidosPendientes.AllowUserToDeleteRows = false;
            this.DGVPedidosPendientes.AllowUserToResizeColumns = false;
            this.DGVPedidosPendientes.AllowUserToResizeRows = false;
            this.DGVPedidosPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVPedidosPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVPedidosPendientes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVPedidosPendientes.BackgroundColor = System.Drawing.Color.Khaki;
            this.DGVPedidosPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPedidosPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPedidosPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.DGVPedidosPendientes.ColumnHeadersHeight = 30;
            this.DGVPedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVPedidosPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CNroPedido,
            this.CProveedor,
            this.CMonto,
            this.CDetalles,
            this.CRecibir,
            this.CCancelar});
            this.DGVPedidosPendientes.EnableHeadersVisualStyles = false;
            this.DGVPedidosPendientes.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DGVPedidosPendientes.Location = new System.Drawing.Point(3, 46);
            this.DGVPedidosPendientes.Name = "DGVPedidosPendientes";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVPedidosPendientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DGVPedidosPendientes.RowHeadersVisible = false;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVPedidosPendientes.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.DGVPedidosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPedidosPendientes.Size = new System.Drawing.Size(404, 333);
            this.DGVPedidosPendientes.TabIndex = 2;
            this.DGVPedidosPendientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPedidosPendientesConfirmados_CellContentClick);
            // 
            // CNroPedido
            // 
            this.CNroPedido.HeaderText = "Nro. Compra";
            this.CNroPedido.Name = "CNroPedido";
            this.CNroPedido.Width = 83;
            // 
            // CProveedor
            // 
            this.CProveedor.HeaderText = "Proveedor";
            this.CProveedor.Name = "CProveedor";
            this.CProveedor.Width = 80;
            // 
            // CMonto
            // 
            this.CMonto.HeaderText = "Monto";
            this.CMonto.Name = "CMonto";
            this.CMonto.Width = 61;
            // 
            // CDetalles
            // 
            this.CDetalles.HeaderText = "Detalles";
            this.CDetalles.Name = "CDetalles";
            this.CDetalles.Width = 69;
            // 
            // CRecibir
            // 
            this.CRecibir.HeaderText = "Recibir";
            this.CRecibir.Name = "CRecibir";
            this.CRecibir.Width = 45;
            // 
            // CCancelar
            // 
            this.CCancelar.HeaderText = "Cancelar";
            this.CCancelar.Name = "CCancelar";
            this.CCancelar.Width = 54;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(276, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(13, 48);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(257, 20);
            this.TBBuscar.TabIndex = 6;
            this.TBBuscar.Text = "Buscar por proveedor o por numero de compra ...";
            this.TBBuscar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBBuscar_MouseClick);
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(729, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "+ Nueva Compra";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel3.Controls.Add(this.LTitulo);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 33);
            this.panel3.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.LTitulo.Location = new System.Drawing.Point(4, 7);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(140, 18);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Gestion de Compras";
            // 
            // GestionCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 450);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(900, 507);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionCompras";
            this.Text = "GestionCompras";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPedidosConfirmados)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPedidosPendientes)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVPedidosPendientes;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView DGVPedidosConfirmados;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label LPedidosConfirmados;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNroPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMonto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDetalles;
        private System.Windows.Forms.DataGridViewButtonColumn CRecibir;
        private System.Windows.Forms.DataGridViewButtonColumn CCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNumeroPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProveedorPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMontoPedido;
        private System.Windows.Forms.DataGridViewButtonColumn CDetalle;
    }
}