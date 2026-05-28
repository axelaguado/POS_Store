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
            this.PListado = new System.Windows.Forms.Panel();
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
            this.DGVLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVLista.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.DGVLista.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVLista.EnableHeadersVisualStyles = false;
            this.DGVLista.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.DGVLista.Location = new System.Drawing.Point(23, 135);
            this.DGVLista.Name = "DGVLista";
            this.DGVLista.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.DGVLista.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLista.Size = new System.Drawing.Size(753, 475);
            this.DGVLista.TabIndex = 4;
            this.DGVLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVLista_CellClick);
            this.DGVLista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
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
    }
}