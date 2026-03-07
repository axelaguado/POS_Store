namespace WindowsFormsApp1.CapaPresentacion
{
    partial class Listado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PListado = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.LGenero = new System.Windows.Forms.Label();
            this.COMBOBTipoUsuario = new System.Windows.Forms.ComboBox();
            this.COMBOBGenero = new System.Windows.Forms.ComboBox();
            this.LTipoUsuario = new System.Windows.Forms.Label();
            this.BTNFiltrar = new System.Windows.Forms.Button();
            this.DGVLista = new System.Windows.Forms.DataGridView();
            this.CDni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CApellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTipoUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEditar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CBorrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BTBuscar = new System.Windows.Forms.Button();
            this.BTNuevo = new System.Windows.Forms.Button();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.PListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLista)).BeginInit();
            this.SuspendLayout();
            // 
            // PListado
            // 
            this.PListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PListado.AutoScroll = true;
            this.PListado.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PListado.Controls.Add(this.dataGridView1);
            this.PListado.Controls.Add(this.LGenero);
            this.PListado.Controls.Add(this.COMBOBTipoUsuario);
            this.PListado.Controls.Add(this.COMBOBGenero);
            this.PListado.Controls.Add(this.LTipoUsuario);
            this.PListado.Controls.Add(this.BTNFiltrar);
            this.PListado.Controls.Add(this.DGVLista);
            this.PListado.Controls.Add(this.BTBuscar);
            this.PListado.Controls.Add(this.BTNuevo);
            this.PListado.Controls.Add(this.TBBuscar);
            this.PListado.Location = new System.Drawing.Point(12, 12);
            this.PListado.Name = "PListado";
            this.PListado.Size = new System.Drawing.Size(798, 626);
            this.PListado.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.RosyBrown;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewButtonColumn1,
            this.dataGridViewButtonColumn2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(23, 383);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(752, 225);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLista_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Dni";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 76;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Usuario";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 74;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Tipo de Usuario";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 118;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Telefono";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 79;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Email";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 63;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Direccion";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 83;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Piso";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 55;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Departamento";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 110;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "Editar";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Width = 44;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "Borrar";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Width = 46;
            // 
            // LGenero
            // 
            this.LGenero.AutoSize = true;
            this.LGenero.ForeColor = System.Drawing.SystemColors.Control;
            this.LGenero.Location = new System.Drawing.Point(278, 58);
            this.LGenero.Name = "LGenero";
            this.LGenero.Size = new System.Drawing.Size(45, 13);
            this.LGenero.TabIndex = 10;
            this.LGenero.Text = "Genero:";
            // 
            // COMBOBTipoUsuario
            // 
            this.COMBOBTipoUsuario.FormattingEnabled = true;
            this.COMBOBTipoUsuario.Items.AddRange(new object[] {
            "Administrador",
            "Gerente",
            "Empleado\t "});
            this.COMBOBTipoUsuario.Location = new System.Drawing.Point(367, 22);
            this.COMBOBTipoUsuario.Name = "COMBOBTipoUsuario";
            this.COMBOBTipoUsuario.Size = new System.Drawing.Size(83, 21);
            this.COMBOBTipoUsuario.TabIndex = 6;
            this.COMBOBTipoUsuario.Text = "Seleccionar";
            // 
            // COMBOBGenero
            // 
            this.COMBOBGenero.FormattingEnabled = true;
            this.COMBOBGenero.Items.AddRange(new object[] {
            "Hombre",
            "Mujer"});
            this.COMBOBGenero.Location = new System.Drawing.Point(367, 55);
            this.COMBOBGenero.Name = "COMBOBGenero";
            this.COMBOBGenero.Size = new System.Drawing.Size(83, 21);
            this.COMBOBGenero.TabIndex = 11;
            this.COMBOBGenero.Text = "Seleccionar";
            // 
            // LTipoUsuario
            // 
            this.LTipoUsuario.AutoSize = true;
            this.LTipoUsuario.ForeColor = System.Drawing.Color.White;
            this.LTipoUsuario.Location = new System.Drawing.Point(278, 25);
            this.LTipoUsuario.Name = "LTipoUsuario";
            this.LTipoUsuario.Size = new System.Drawing.Size(83, 13);
            this.LTipoUsuario.TabIndex = 7;
            this.LTipoUsuario.Text = "Tipo de usuario:";
            // 
            // BTNFiltrar
            // 
            this.BTNFiltrar.BackColor = System.Drawing.Color.Silver;
            this.BTNFiltrar.FlatAppearance.BorderSize = 0;
            this.BTNFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNFiltrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNFiltrar.Location = new System.Drawing.Point(386, 93);
            this.BTNFiltrar.Name = "BTNFiltrar";
            this.BTNFiltrar.Size = new System.Drawing.Size(46, 24);
            this.BTNFiltrar.TabIndex = 5;
            this.BTNFiltrar.Text = "Filtrar";
            this.BTNFiltrar.UseVisualStyleBackColor = false;
            this.BTNFiltrar.Click += new System.EventHandler(this.BTNFiltrar_Click);
            // 
            // DGVLista
            // 
            this.DGVLista.AllowUserToAddRows = false;
            this.DGVLista.AllowUserToDeleteRows = false;
            this.DGVLista.AllowUserToResizeColumns = false;
            this.DGVLista.AllowUserToResizeRows = false;
            this.DGVLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVLista.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.DGVLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVLista.ColumnHeadersHeight = 30;
            this.DGVLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CDni,
            this.CNombre,
            this.CApellido,
            this.CUser,
            this.CTipoUser,
            this.CTelefono,
            this.CEmail,
            this.CDireccion,
            this.CPiso,
            this.CDepto,
            this.CEditar,
            this.CBorrar});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVLista.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVLista.EnableHeadersVisualStyles = false;
            this.DGVLista.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DGVLista.Location = new System.Drawing.Point(23, 135);
            this.DGVLista.Name = "DGVLista";
            this.DGVLista.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVLista.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGVLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLista.Size = new System.Drawing.Size(753, 225);
            this.DGVLista.TabIndex = 4;
            this.DGVLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLista_CellClick);
            // 
            // CDni
            // 
            this.CDni.HeaderText = "Dni";
            this.CDni.Name = "CDni";
            this.CDni.Width = 50;
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Nombre";
            this.CNombre.Name = "CNombre";
            this.CNombre.Width = 76;
            // 
            // CApellido
            // 
            this.CApellido.HeaderText = "Apellido";
            this.CApellido.Name = "CApellido";
            this.CApellido.Width = 75;
            // 
            // CUser
            // 
            this.CUser.HeaderText = "Usuario";
            this.CUser.Name = "CUser";
            this.CUser.Width = 74;
            // 
            // CTipoUser
            // 
            this.CTipoUser.HeaderText = "Tipo de Usuario";
            this.CTipoUser.Name = "CTipoUser";
            this.CTipoUser.Width = 118;
            // 
            // CTelefono
            // 
            this.CTelefono.HeaderText = "Telefono";
            this.CTelefono.Name = "CTelefono";
            this.CTelefono.Width = 79;
            // 
            // CEmail
            // 
            this.CEmail.HeaderText = "Email";
            this.CEmail.Name = "CEmail";
            this.CEmail.Width = 63;
            // 
            // CDireccion
            // 
            this.CDireccion.HeaderText = "Direccion";
            this.CDireccion.Name = "CDireccion";
            this.CDireccion.Width = 83;
            // 
            // CPiso
            // 
            this.CPiso.HeaderText = "Piso";
            this.CPiso.Name = "CPiso";
            this.CPiso.Width = 55;
            // 
            // CDepto
            // 
            this.CDepto.HeaderText = "Departamento";
            this.CDepto.Name = "CDepto";
            this.CDepto.Width = 110;
            // 
            // CEditar
            // 
            this.CEditar.HeaderText = "Editar";
            this.CEditar.Name = "CEditar";
            this.CEditar.Width = 44;
            // 
            // CBorrar
            // 
            this.CBorrar.HeaderText = "Borrar";
            this.CBorrar.Name = "CBorrar";
            this.CBorrar.Width = 46;
            // 
            // BTBuscar
            // 
            this.BTBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTBuscar.FlatAppearance.BorderSize = 0;
            this.BTBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTBuscar.Location = new System.Drawing.Point(181, 22);
            this.BTBuscar.Name = "BTBuscar";
            this.BTBuscar.Size = new System.Drawing.Size(75, 23);
            this.BTBuscar.TabIndex = 3;
            this.BTBuscar.Text = "Buscar";
            this.BTBuscar.UseVisualStyleBackColor = false;
            // 
            // BTNuevo
            // 
            this.BTNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTNuevo.BackColor = System.Drawing.Color.LimeGreen;
            this.BTNuevo.FlatAppearance.BorderSize = 0;
            this.BTNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNuevo.Location = new System.Drawing.Point(689, 93);
            this.BTNuevo.Name = "BTNuevo";
            this.BTNuevo.Size = new System.Drawing.Size(86, 24);
            this.BTNuevo.TabIndex = 2;
            this.BTNuevo.Text = "+  Nuevo";
            this.BTNuevo.UseVisualStyleBackColor = false;
            this.BTNuevo.Click += new System.EventHandler(this.BTNuevo_Click);
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(22, 24);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(153, 20);
            this.TBBuscar.TabIndex = 0;
            this.TBBuscar.Text = " Buscar por dni o nombre ...";
            this.TBBuscar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBBuscar_MouseClick);
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(849, 450);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.PListado);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Listado";
            this.Text = "Listado";
            this.PListado.ResumeLayout(false);
            this.PListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PListado;
        private System.Windows.Forms.Button BTBuscar;
        private System.Windows.Forms.Button BTNuevo;
        private System.Windows.Forms.DataGridView DGVLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDni;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CApellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTipoUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDepto;
        private System.Windows.Forms.DataGridViewButtonColumn CEditar;
        private System.Windows.Forms.DataGridViewButtonColumn CBorrar;
        private System.Windows.Forms.Button BTNFiltrar;
        private System.Windows.Forms.Label LTipoUsuario;
        private System.Windows.Forms.ComboBox COMBOBTipoUsuario;
        private System.Windows.Forms.ComboBox COMBOBGenero;
        private System.Windows.Forms.Label LGenero;
        protected System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
    }
}