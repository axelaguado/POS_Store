namespace WindowsFormsApp1.CapaPresentacion
{
    partial class MovimientoCaja
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BTNIngresar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LUsername = new System.Windows.Forms.Label();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.TBUsername = new System.Windows.Forms.TextBox();
            this.BTNCerrar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTNRegistrarMovimiento = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LTituloRegistrar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBMonto = new System.Windows.Forms.TextBox();
            this.TBDescripcion = new System.Windows.Forms.TextBox();
            this.CBTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LTituloTipos = new System.Windows.Forms.Label();
            this.DGVTipos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNAgregar = new System.Windows.Forms.Button();
            this.TBNuevoTipo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTipos)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.BTNCerrar);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 295);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel7.Controls.Add(this.BTNIngresar);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Controls.Add(this.LUsername);
            this.panel7.Controls.Add(this.TBPassword);
            this.panel7.Controls.Add(this.TBUsername);
            this.panel7.Location = new System.Drawing.Point(13, 50);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(447, 208);
            this.panel7.TabIndex = 9;
            // 
            // BTNIngresar
            // 
            this.BTNIngresar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNIngresar.FlatAppearance.BorderSize = 0;
            this.BTNIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNIngresar.Location = new System.Drawing.Point(195, 151);
            this.BTNIngresar.Name = "BTNIngresar";
            this.BTNIngresar.Size = new System.Drawing.Size(57, 21);
            this.BTNIngresar.TabIndex = 11;
            this.BTNIngresar.Text = "Ingresar";
            this.BTNIngresar.UseVisualStyleBackColor = false;
            this.BTNIngresar.Click += new System.EventHandler(this.BTNIngresar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Debe ingresar con un usuario autorizado.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(142, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contraseña:";
            // 
            // LUsername
            // 
            this.LUsername.AutoSize = true;
            this.LUsername.ForeColor = System.Drawing.SystemColors.Control;
            this.LUsername.Location = new System.Drawing.Point(142, 51);
            this.LUsername.Name = "LUsername";
            this.LUsername.Size = new System.Drawing.Size(46, 13);
            this.LUsername.TabIndex = 8;
            this.LUsername.Text = "Usuario:";
            // 
            // TBPassword
            // 
            this.TBPassword.Location = new System.Drawing.Point(145, 118);
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.PasswordChar = '*';
            this.TBPassword.Size = new System.Drawing.Size(157, 20);
            this.TBPassword.TabIndex = 7;
            this.TBPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TBPassword_Validating);
            // 
            // TBUsername
            // 
            this.TBUsername.Location = new System.Drawing.Point(145, 67);
            this.TBUsername.Name = "TBUsername";
            this.TBUsername.Size = new System.Drawing.Size(157, 20);
            this.TBUsername.TabIndex = 6;
            this.TBUsername.Validating += new System.ComponentModel.CancelEventHandler(this.TBUsername_Validating);
            // 
            // BTNCerrar
            // 
            this.BTNCerrar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNCerrar.FlatAppearance.BorderSize = 0;
            this.BTNCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNCerrar.Location = new System.Drawing.Point(209, 264);
            this.BTNCerrar.Name = "BTNCerrar";
            this.BTNCerrar.Size = new System.Drawing.Size(57, 21);
            this.BTNCerrar.TabIndex = 3;
            this.BTNCerrar.Text = "Cerrar";
            this.BTNCerrar.UseVisualStyleBackColor = false;
            this.BTNCerrar.Click += new System.EventHandler(this.BTNCerrar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 208);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BTNRegistrarMovimiento);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.TBMonto);
            this.panel4.Controls.Add(this.TBDescripcion);
            this.panel4.Controls.Add(this.CBTipoMovimiento);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.tableLayoutPanel1.SetRowSpan(this.panel4, 2);
            this.panel4.Size = new System.Drawing.Size(217, 202);
            this.panel4.TabIndex = 1;
            // 
            // BTNRegistrarMovimiento
            // 
            this.BTNRegistrarMovimiento.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNRegistrarMovimiento.FlatAppearance.BorderSize = 0;
            this.BTNRegistrarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNRegistrarMovimiento.Location = new System.Drawing.Point(80, 178);
            this.BTNRegistrarMovimiento.Name = "BTNRegistrarMovimiento";
            this.BTNRegistrarMovimiento.Size = new System.Drawing.Size(57, 21);
            this.BTNRegistrarMovimiento.TabIndex = 7;
            this.BTNRegistrarMovimiento.Text = "Registrar";
            this.BTNRegistrarMovimiento.UseVisualStyleBackColor = false;
            this.BTNRegistrarMovimiento.Click += new System.EventHandler(this.BTNRegistrarMovimiento_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.LTituloRegistrar);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(217, 26);
            this.panel5.TabIndex = 6;
            // 
            // LTituloRegistrar
            // 
            this.LTituloRegistrar.AutoSize = true;
            this.LTituloRegistrar.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTituloRegistrar.Location = new System.Drawing.Point(3, 7);
            this.LTituloRegistrar.Name = "LTituloRegistrar";
            this.LTituloRegistrar.Size = new System.Drawing.Size(112, 14);
            this.LTituloRegistrar.TabIndex = 8;
            this.LTituloRegistrar.Text = "Nuevo Movimiento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(27, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Monto ($):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(27, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Movimiento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(27, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion:";
            // 
            // TBMonto
            // 
            this.TBMonto.Location = new System.Drawing.Point(30, 140);
            this.TBMonto.Name = "TBMonto";
            this.TBMonto.Size = new System.Drawing.Size(157, 20);
            this.TBMonto.TabIndex = 2;
            this.TBMonto.TextChanged += new System.EventHandler(this.TB_TextChanged);
            this.TBMonto.Validating += new System.ComponentModel.CancelEventHandler(this.TBMonto_Validating);
            // 
            // TBDescripcion
            // 
            this.TBDescripcion.Location = new System.Drawing.Point(30, 95);
            this.TBDescripcion.Name = "TBDescripcion";
            this.TBDescripcion.Size = new System.Drawing.Size(157, 20);
            this.TBDescripcion.TabIndex = 1;
            this.TBDescripcion.Validating += new System.ComponentModel.CancelEventHandler(this.TBDescripcion_Validating);
            // 
            // CBTipoMovimiento
            // 
            this.CBTipoMovimiento.FormattingEnabled = true;
            this.CBTipoMovimiento.Location = new System.Drawing.Point(30, 50);
            this.CBTipoMovimiento.Name = "CBTipoMovimiento";
            this.CBTipoMovimiento.Size = new System.Drawing.Size(157, 21);
            this.CBTipoMovimiento.TabIndex = 0;
            this.CBTipoMovimiento.Validating += new System.ComponentModel.CancelEventHandler(this.CBTipoMovimiento_Validating);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.DGVTipos);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.BTNAgregar);
            this.panel3.Controls.Add(this.TBNuevoTipo);
            this.panel3.Location = new System.Drawing.Point(226, 3);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 2);
            this.panel3.Size = new System.Drawing.Size(217, 202);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel6.Controls.Add(this.LTituloTipos);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(217, 26);
            this.panel6.TabIndex = 7;
            // 
            // LTituloTipos
            // 
            this.LTituloTipos.AutoSize = true;
            this.LTituloTipos.Font = new System.Drawing.Font("Tahoma", 9F);
            this.LTituloTipos.Location = new System.Drawing.Point(3, 7);
            this.LTituloTipos.Name = "LTituloTipos";
            this.LTituloTipos.Size = new System.Drawing.Size(78, 14);
            this.LTituloTipos.TabIndex = 8;
            this.LTituloTipos.Text = "Movimientos:";
            // 
            // DGVTipos
            // 
            this.DGVTipos.AllowUserToAddRows = false;
            this.DGVTipos.AllowUserToDeleteRows = false;
            this.DGVTipos.AllowUserToResizeColumns = false;
            this.DGVTipos.AllowUserToResizeRows = false;
            this.DGVTipos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVTipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVTipos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVTipos.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.DGVTipos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVTipos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTipos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVTipos.ColumnHeadersHeight = 21;
            this.DGVTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVTipos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DGVTipos.EnableHeadersVisualStyles = false;
            this.DGVTipos.Location = new System.Drawing.Point(6, 79);
            this.DGVTipos.Name = "DGVTipos";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVTipos.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGVTipos.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.DGVTipos.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVTipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVTipos.Size = new System.Drawing.Size(208, 120);
            this.DGVTipos.TabIndex = 5;
            this.DGVTipos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVTipos_CellContentClick);
            this.DGVTipos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVTipos_CellFormatting);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese un tipo de movimiento:";
            // 
            // BTNAgregar
            // 
            this.BTNAgregar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAgregar.FlatAppearance.BorderSize = 0;
            this.BTNAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAgregar.Location = new System.Drawing.Point(160, 52);
            this.BTNAgregar.Name = "BTNAgregar";
            this.BTNAgregar.Size = new System.Drawing.Size(54, 21);
            this.BTNAgregar.TabIndex = 2;
            this.BTNAgregar.Text = "Agregar";
            this.BTNAgregar.UseVisualStyleBackColor = false;
            this.BTNAgregar.Click += new System.EventHandler(this.BTNAgregar_Click);
            // 
            // TBNuevoTipo
            // 
            this.TBNuevoTipo.Location = new System.Drawing.Point(6, 53);
            this.TBNuevoTipo.Name = "TBNuevoTipo";
            this.TBNuevoTipo.Size = new System.Drawing.Size(148, 20);
            this.TBNuevoTipo.TabIndex = 1;
            this.TBNuevoTipo.Validating += new System.ComponentModel.CancelEventHandler(this.TBNuevoTipo_Validating);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.LTitulo);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 33);
            this.panel2.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.Location = new System.Drawing.Point(3, 7);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(144, 18);
            this.LTitulo.TabIndex = 7;
            this.LTitulo.Text = "Movimientos de Caja";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // MovimientoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(500, 315);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MovimientoCaja";
            this.Text = "MovimientoCaja";
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVTipos)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BTNAgregar;
        private System.Windows.Forms.TextBox TBNuevoTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox TBMonto;
        private System.Windows.Forms.TextBox TBDescripcion;
        private System.Windows.Forms.ComboBox CBTipoMovimiento;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Label LTituloRegistrar;
        private System.Windows.Forms.Label LTituloTipos;
        private System.Windows.Forms.Button BTNCerrar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LUsername;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.TextBox TBUsername;
        private System.Windows.Forms.Button BTNIngresar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button BTNRegistrarMovimiento;
    }
}