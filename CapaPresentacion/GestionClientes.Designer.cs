namespace WindowsFormsApp1.CapaPresentacion
{
    partial class GestionClientes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CIdentificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCodPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.BTNRegistrar = new System.Windows.Forms.Button();
            this.BTNActualizar = new System.Windows.Forms.Button();
            this.PDatosPFisica = new System.Windows.Forms.Panel();
            this.TBApellido = new System.Windows.Forms.TextBox();
            this.LFechaNac = new System.Windows.Forms.Label();
            this.LApellido = new System.Windows.Forms.Label();
            this.RBHombre = new System.Windows.Forms.RadioButton();
            this.LNombre = new System.Windows.Forms.Label();
            this.RBMujer = new System.Windows.Forms.RadioButton();
            this.LSexo = new System.Windows.Forms.Label();
            this.DTPFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.LDni = new System.Windows.Forms.Label();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.TBNombre = new System.Windows.Forms.TextBox();
            this.LPJuridica = new System.Windows.Forms.Label();
            this.LPFisica = new System.Windows.Forms.Label();
            this.PDatosPJuridica = new System.Windows.Forms.Panel();
            this.TBRazonSocial = new System.Windows.Forms.TextBox();
            this.LCUIT = new System.Windows.Forms.Label();
            this.TBCuit = new System.Windows.Forms.TextBox();
            this.TBNombreComercial = new System.Windows.Forms.TextBox();
            this.LNombreComercial = new System.Windows.Forms.Label();
            this.LRazonSocial = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TBSitioWeb = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LSitioWeb = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LDepartamento = new System.Windows.Forms.Label();
            this.LCodPostal = new System.Windows.Forms.Label();
            this.TBCodPostal = new System.Windows.Forms.TextBox();
            this.CHKBDepto = new System.Windows.Forms.CheckBox();
            this.LCalle = new System.Windows.Forms.Label();
            this.TBCalle = new System.Windows.Forms.TextBox();
            this.CBDepto = new System.Windows.Forms.ComboBox();
            this.LDepto = new System.Windows.Forms.Label();
            this.LAltura = new System.Windows.Forms.Label();
            this.LPiso = new System.Windows.Forms.Label();
            this.TBAltura = new System.Windows.Forms.TextBox();
            this.CBPiso = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.PDatosPFisica.SuspendLayout();
            this.PDatosPJuridica.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 510);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(381, 17);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(383, 33);
            this.panel4.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clientes";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(16, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(361, 33);
            this.panel5.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Registrar Cliente";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.BTNBuscar);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Controls.Add(this.TBBuscar);
            this.panel3.Location = new System.Drawing.Point(381, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(383, 490);
            this.panel3.TabIndex = 1;
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscar.FlatAppearance.BorderSize = 0;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTNBuscar.Location = new System.Drawing.Point(195, 47);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(54, 23);
            this.BTNBuscar.TabIndex = 2;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIdentificacion,
            this.CCliente,
            this.CTelefono,
            this.CEmail,
            this.CCodPostal,
            this.CCalle,
            this.CAltura,
            this.CPiso,
            this.CDepto});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(6, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(374, 402);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // CIdentificacion
            // 
            this.CIdentificacion.HeaderText = "Identificacion";
            this.CIdentificacion.Name = "CIdentificacion";
            this.CIdentificacion.ReadOnly = true;
            this.CIdentificacion.Width = 103;
            // 
            // CCliente
            // 
            this.CCliente.HeaderText = "Cliente";
            this.CCliente.Name = "CCliente";
            this.CCliente.ReadOnly = true;
            this.CCliente.Width = 69;
            // 
            // CTelefono
            // 
            this.CTelefono.HeaderText = "Telefono";
            this.CTelefono.Name = "CTelefono";
            this.CTelefono.ReadOnly = true;
            this.CTelefono.Width = 79;
            // 
            // CEmail
            // 
            this.CEmail.HeaderText = "Email";
            this.CEmail.Name = "CEmail";
            this.CEmail.ReadOnly = true;
            this.CEmail.Width = 63;
            // 
            // CCodPostal
            // 
            this.CCodPostal.HeaderText = "CodPostal";
            this.CCodPostal.Name = "CCodPostal";
            this.CCodPostal.ReadOnly = true;
            this.CCodPostal.Width = 87;
            // 
            // CCalle
            // 
            this.CCalle.HeaderText = "Calle";
            this.CCalle.Name = "CCalle";
            this.CCalle.ReadOnly = true;
            this.CCalle.Width = 59;
            // 
            // CAltura
            // 
            this.CAltura.HeaderText = "Altura";
            this.CAltura.Name = "CAltura";
            this.CAltura.ReadOnly = true;
            this.CAltura.Width = 62;
            // 
            // CPiso
            // 
            this.CPiso.HeaderText = "Piso";
            this.CPiso.Name = "CPiso";
            this.CPiso.ReadOnly = true;
            this.CPiso.Width = 55;
            // 
            // CDepto
            // 
            this.CDepto.HeaderText = "Depto";
            this.CDepto.Name = "CDepto";
            this.CDepto.ReadOnly = true;
            this.CDepto.Width = 64;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(6, 49);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(183, 20);
            this.TBBuscar.TabIndex = 1;
            this.TBBuscar.Text = "Buscar por identificacion ...";
            this.TBBuscar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBBuscar_MouseClick);
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BTNLimpiar);
            this.panel2.Controls.Add(this.BTNRegistrar);
            this.panel2.Controls.Add(this.BTNActualizar);
            this.panel2.Controls.Add(this.PDatosPFisica);
            this.panel2.Controls.Add(this.LPJuridica);
            this.panel2.Controls.Add(this.LPFisica);
            this.panel2.Controls.Add(this.PDatosPJuridica);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Location = new System.Drawing.Point(16, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(361, 490);
            this.panel2.TabIndex = 0;
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNLimpiar.FlatAppearance.BorderSize = 0;
            this.BTNLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNLimpiar.Location = new System.Drawing.Point(95, 451);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BTNLimpiar.TabIndex = 45;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // BTNRegistrar
            // 
            this.BTNRegistrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.BTNRegistrar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNRegistrar.FlatAppearance.BorderSize = 0;
            this.BTNRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNRegistrar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNRegistrar.Location = new System.Drawing.Point(193, 451);
            this.BTNRegistrar.Name = "BTNRegistrar";
            this.BTNRegistrar.Size = new System.Drawing.Size(75, 22);
            this.BTNRegistrar.TabIndex = 43;
            this.BTNRegistrar.Text = "Registrar";
            this.BTNRegistrar.UseVisualStyleBackColor = false;
            this.BTNRegistrar.Click += new System.EventHandler(this.Registrar_Click);
            // 
            // BTNActualizar
            // 
            this.BTNActualizar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNActualizar.FlatAppearance.BorderSize = 0;
            this.BTNActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNActualizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNActualizar.Location = new System.Drawing.Point(193, 451);
            this.BTNActualizar.Name = "BTNActualizar";
            this.BTNActualizar.Size = new System.Drawing.Size(75, 22);
            this.BTNActualizar.TabIndex = 44;
            this.BTNActualizar.Text = "Actualizar";
            this.BTNActualizar.UseVisualStyleBackColor = false;
            this.BTNActualizar.Click += new System.EventHandler(this.BTNActualizar_Click);
            // 
            // PDatosPFisica
            // 
            this.PDatosPFisica.Controls.Add(this.TBApellido);
            this.PDatosPFisica.Controls.Add(this.LFechaNac);
            this.PDatosPFisica.Controls.Add(this.LApellido);
            this.PDatosPFisica.Controls.Add(this.RBHombre);
            this.PDatosPFisica.Controls.Add(this.LNombre);
            this.PDatosPFisica.Controls.Add(this.RBMujer);
            this.PDatosPFisica.Controls.Add(this.LSexo);
            this.PDatosPFisica.Controls.Add(this.DTPFechaNacimiento);
            this.PDatosPFisica.Controls.Add(this.LDni);
            this.PDatosPFisica.Controls.Add(this.TBDni);
            this.PDatosPFisica.Controls.Add(this.TBNombre);
            this.PDatosPFisica.Location = new System.Drawing.Point(3, 65);
            this.PDatosPFisica.Name = "PDatosPFisica";
            this.PDatosPFisica.Size = new System.Drawing.Size(356, 130);
            this.PDatosPFisica.TabIndex = 40;
            // 
            // TBApellido
            // 
            this.TBApellido.Location = new System.Drawing.Point(103, 100);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(112, 20);
            this.TBApellido.TabIndex = 14;
            this.TBApellido.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBApellido.Validating += new System.ComponentModel.CancelEventHandler(this.TBApellido_Validating);
            // 
            // LFechaNac
            // 
            this.LFechaNac.AutoSize = true;
            this.LFechaNac.Location = new System.Drawing.Point(231, 20);
            this.LFechaNac.Name = "LFechaNac";
            this.LFechaNac.Size = new System.Drawing.Size(94, 13);
            this.LFechaNac.TabIndex = 3;
            this.LFechaNac.Text = "Fecha nacimiento:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(3, 105);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(47, 13);
            this.LApellido.TabIndex = 2;
            this.LApellido.Text = "Apellido:";
            // 
            // RBHombre
            // 
            this.RBHombre.AutoSize = true;
            this.RBHombre.Checked = true;
            this.RBHombre.Location = new System.Drawing.Point(234, 100);
            this.RBHombre.Name = "RBHombre";
            this.RBHombre.Size = new System.Drawing.Size(62, 17);
            this.RBHombre.TabIndex = 24;
            this.RBHombre.TabStop = true;
            this.RBHombre.Text = "Hombre";
            this.RBHombre.UseVisualStyleBackColor = true;
            // 
            // LNombre
            // 
            this.LNombre.AutoSize = true;
            this.LNombre.Location = new System.Drawing.Point(3, 64);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(47, 13);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // RBMujer
            // 
            this.RBMujer.AutoSize = true;
            this.RBMujer.Location = new System.Drawing.Point(302, 101);
            this.RBMujer.Name = "RBMujer";
            this.RBMujer.Size = new System.Drawing.Size(51, 17);
            this.RBMujer.TabIndex = 23;
            this.RBMujer.TabStop = true;
            this.RBMujer.Text = "Mujer";
            this.RBMujer.UseVisualStyleBackColor = true;
            // 
            // LSexo
            // 
            this.LSexo.AutoSize = true;
            this.LSexo.Location = new System.Drawing.Point(231, 83);
            this.LSexo.Name = "LSexo";
            this.LSexo.Size = new System.Drawing.Size(34, 13);
            this.LSexo.TabIndex = 6;
            this.LSexo.Text = "Sexo:";
            // 
            // DTPFechaNacimiento
            // 
            this.DTPFechaNacimiento.Checked = false;
            this.DTPFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaNacimiento.Location = new System.Drawing.Point(234, 45);
            this.DTPFechaNacimiento.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.DTPFechaNacimiento.MinDate = new System.DateTime(1924, 1, 1, 0, 0, 0, 0);
            this.DTPFechaNacimiento.Name = "DTPFechaNacimiento";
            this.DTPFechaNacimiento.Size = new System.Drawing.Size(115, 20);
            this.DTPFechaNacimiento.TabIndex = 22;
            this.DTPFechaNacimiento.Value = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.DTPFechaNacimiento.Validating += new System.ComponentModel.CancelEventHandler(this.DTPFechaNacimiento_Validating);
            // 
            // LDni
            // 
            this.LDni.AutoSize = true;
            this.LDni.Location = new System.Drawing.Point(3, 23);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(26, 13);
            this.LDni.TabIndex = 0;
            this.LDni.Text = "Dni:";
            // 
            // TBDni
            // 
            this.TBDni.Location = new System.Drawing.Point(103, 20);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(112, 20);
            this.TBDni.TabIndex = 13;
            this.TBDni.Validating += new System.ComponentModel.CancelEventHandler(this.TBDni_Validating);
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(103, 60);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(112, 20);
            this.TBNombre.TabIndex = 15;
            this.TBNombre.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBNombre.Validating += new System.ComponentModel.CancelEventHandler(this.TBNombre_Validating);
            // 
            // LPJuridica
            // 
            this.LPJuridica.AutoSize = true;
            this.LPJuridica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LPJuridica.ForeColor = System.Drawing.Color.Gray;
            this.LPJuridica.Location = new System.Drawing.Point(85, 49);
            this.LPJuridica.Name = "LPJuridica";
            this.LPJuridica.Size = new System.Drawing.Size(85, 13);
            this.LPJuridica.TabIndex = 42;
            this.LPJuridica.Text = "Persona Juridica";
            this.LPJuridica.Click += new System.EventHandler(this.LPJuridica_Click);
            // 
            // LPFisica
            // 
            this.LPFisica.AutoSize = true;
            this.LPFisica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LPFisica.Location = new System.Drawing.Point(3, 49);
            this.LPFisica.Name = "LPFisica";
            this.LPFisica.Size = new System.Drawing.Size(76, 13);
            this.LPFisica.TabIndex = 41;
            this.LPFisica.Text = "Persona Fisica";
            this.LPFisica.Click += new System.EventHandler(this.LPFisica_Click);
            // 
            // PDatosPJuridica
            // 
            this.PDatosPJuridica.Controls.Add(this.TBRazonSocial);
            this.PDatosPJuridica.Controls.Add(this.LCUIT);
            this.PDatosPJuridica.Controls.Add(this.TBCuit);
            this.PDatosPJuridica.Controls.Add(this.TBNombreComercial);
            this.PDatosPJuridica.Controls.Add(this.LNombreComercial);
            this.PDatosPJuridica.Controls.Add(this.LRazonSocial);
            this.PDatosPJuridica.Location = new System.Drawing.Point(3, 65);
            this.PDatosPJuridica.Name = "PDatosPJuridica";
            this.PDatosPJuridica.Size = new System.Drawing.Size(356, 130);
            this.PDatosPJuridica.TabIndex = 7;
            // 
            // TBRazonSocial
            // 
            this.TBRazonSocial.Location = new System.Drawing.Point(103, 20);
            this.TBRazonSocial.Name = "TBRazonSocial";
            this.TBRazonSocial.Size = new System.Drawing.Size(112, 20);
            this.TBRazonSocial.TabIndex = 19;
            this.TBRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.CBRazonSocial_Validating);
            // 
            // LCUIT
            // 
            this.LCUIT.AutoSize = true;
            this.LCUIT.ForeColor = System.Drawing.SystemColors.Control;
            this.LCUIT.Location = new System.Drawing.Point(6, 105);
            this.LCUIT.Name = "LCUIT";
            this.LCUIT.Size = new System.Drawing.Size(35, 13);
            this.LCUIT.TabIndex = 18;
            this.LCUIT.Text = "CUIT:";
            // 
            // TBCuit
            // 
            this.TBCuit.Location = new System.Drawing.Point(104, 100);
            this.TBCuit.Name = "TBCuit";
            this.TBCuit.Size = new System.Drawing.Size(112, 20);
            this.TBCuit.TabIndex = 8;
            this.TBCuit.Validating += new System.ComponentModel.CancelEventHandler(this.TBCuit_Validating);
            // 
            // TBNombreComercial
            // 
            this.TBNombreComercial.Location = new System.Drawing.Point(103, 60);
            this.TBNombreComercial.Name = "TBNombreComercial";
            this.TBNombreComercial.Size = new System.Drawing.Size(112, 20);
            this.TBNombreComercial.TabIndex = 3;
            this.TBNombreComercial.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBNombreComercial.Validating += new System.ComponentModel.CancelEventHandler(this.TBNombreComercial_Validating);
            // 
            // LNombreComercial
            // 
            this.LNombreComercial.AutoSize = true;
            this.LNombreComercial.ForeColor = System.Drawing.SystemColors.Control;
            this.LNombreComercial.Location = new System.Drawing.Point(4, 64);
            this.LNombreComercial.Name = "LNombreComercial";
            this.LNombreComercial.Size = new System.Drawing.Size(95, 13);
            this.LNombreComercial.TabIndex = 2;
            this.LNombreComercial.Text = "Nombre comercial:";
            // 
            // LRazonSocial
            // 
            this.LRazonSocial.AutoSize = true;
            this.LRazonSocial.ForeColor = System.Drawing.SystemColors.Control;
            this.LRazonSocial.Location = new System.Drawing.Point(5, 23);
            this.LRazonSocial.Name = "LRazonSocial";
            this.LRazonSocial.Size = new System.Drawing.Size(71, 13);
            this.LRazonSocial.TabIndex = 0;
            this.LRazonSocial.Text = "Razon social:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.LTelefono);
            this.panel6.Controls.Add(this.TBSitioWeb);
            this.panel6.Controls.Add(this.LEmail);
            this.panel6.Controls.Add(this.TBEmail);
            this.panel6.Controls.Add(this.LSitioWeb);
            this.panel6.Controls.Add(this.TBTelefono);
            this.panel6.Location = new System.Drawing.Point(3, 326);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(356, 118);
            this.panel6.TabIndex = 3;
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.ForeColor = System.Drawing.SystemColors.Control;
            this.LTelefono.Location = new System.Drawing.Point(8, 11);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(52, 13);
            this.LTelefono.TabIndex = 5;
            this.LTelefono.Text = "Telefono:";
            // 
            // TBSitioWeb
            // 
            this.TBSitioWeb.Location = new System.Drawing.Point(103, 87);
            this.TBSitioWeb.Name = "TBSitioWeb";
            this.TBSitioWeb.Size = new System.Drawing.Size(112, 20);
            this.TBSitioWeb.TabIndex = 17;
            this.TBSitioWeb.Validating += new System.ComponentModel.CancelEventHandler(this.TBSitioWeb_Validating);
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.ForeColor = System.Drawing.SystemColors.Control;
            this.LEmail.Location = new System.Drawing.Point(8, 50);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(35, 13);
            this.LEmail.TabIndex = 7;
            this.LEmail.Text = "Email:";
            // 
            // TBEmail
            // 
            this.TBEmail.Location = new System.Drawing.Point(103, 47);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(112, 20);
            this.TBEmail.TabIndex = 2;
            this.TBEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TBEmail_Validating);
            // 
            // LSitioWeb
            // 
            this.LSitioWeb.AutoSize = true;
            this.LSitioWeb.ForeColor = System.Drawing.SystemColors.Control;
            this.LSitioWeb.Location = new System.Drawing.Point(7, 90);
            this.LSitioWeb.Name = "LSitioWeb";
            this.LSitioWeb.Size = new System.Drawing.Size(53, 13);
            this.LSitioWeb.TabIndex = 15;
            this.LSitioWeb.Text = "Sitio web:";
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(103, 8);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(112, 20);
            this.TBTelefono.TabIndex = 1;
            this.TBTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.TBTelefono_Validating);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.LDepartamento);
            this.panel8.Controls.Add(this.LCodPostal);
            this.panel8.Controls.Add(this.TBCodPostal);
            this.panel8.Controls.Add(this.CHKBDepto);
            this.panel8.Controls.Add(this.LCalle);
            this.panel8.Controls.Add(this.TBCalle);
            this.panel8.Controls.Add(this.CBDepto);
            this.panel8.Controls.Add(this.LDepto);
            this.panel8.Controls.Add(this.LAltura);
            this.panel8.Controls.Add(this.LPiso);
            this.panel8.Controls.Add(this.TBAltura);
            this.panel8.Controls.Add(this.CBPiso);
            this.panel8.Location = new System.Drawing.Point(3, 201);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(356, 119);
            this.panel8.TabIndex = 2;
            // 
            // LDepartamento
            // 
            this.LDepartamento.AutoSize = true;
            this.LDepartamento.ForeColor = System.Drawing.SystemColors.Control;
            this.LDepartamento.Location = new System.Drawing.Point(252, 12);
            this.LDepartamento.Name = "LDepartamento";
            this.LDepartamento.Size = new System.Drawing.Size(74, 13);
            this.LDepartamento.TabIndex = 19;
            this.LDepartamento.Text = "Departamento";
            // 
            // LCodPostal
            // 
            this.LCodPostal.AutoSize = true;
            this.LCodPostal.ForeColor = System.Drawing.SystemColors.Control;
            this.LCodPostal.Location = new System.Drawing.Point(4, 12);
            this.LCodPostal.Name = "LCodPostal";
            this.LCodPostal.Size = new System.Drawing.Size(75, 13);
            this.LCodPostal.TabIndex = 4;
            this.LCodPostal.Text = "Codigo Postal:";
            // 
            // TBCodPostal
            // 
            this.TBCodPostal.Location = new System.Drawing.Point(103, 9);
            this.TBCodPostal.Name = "TBCodPostal";
            this.TBCodPostal.Size = new System.Drawing.Size(112, 20);
            this.TBCodPostal.TabIndex = 16;
            this.TBCodPostal.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodPostal_Validating);
            // 
            // CHKBDepto
            // 
            this.CHKBDepto.AutoSize = true;
            this.CHKBDepto.ForeColor = System.Drawing.SystemColors.Control;
            this.CHKBDepto.Location = new System.Drawing.Point(235, 11);
            this.CHKBDepto.Name = "CHKBDepto";
            this.CHKBDepto.Size = new System.Drawing.Size(29, 17);
            this.CHKBDepto.TabIndex = 10;
            this.CHKBDepto.Text = " ";
            this.CHKBDepto.UseVisualStyleBackColor = true;
            this.CHKBDepto.CheckedChanged += new System.EventHandler(this.CBDepartamento_CheckedChanged);
            // 
            // LCalle
            // 
            this.LCalle.AutoSize = true;
            this.LCalle.ForeColor = System.Drawing.SystemColors.Control;
            this.LCalle.Location = new System.Drawing.Point(6, 52);
            this.LCalle.Name = "LCalle";
            this.LCalle.Size = new System.Drawing.Size(33, 13);
            this.LCalle.TabIndex = 6;
            this.LCalle.Text = "Calle:";
            // 
            // TBCalle
            // 
            this.TBCalle.Location = new System.Drawing.Point(103, 49);
            this.TBCalle.Name = "TBCalle";
            this.TBCalle.Size = new System.Drawing.Size(112, 20);
            this.TBCalle.TabIndex = 3;
            this.TBCalle.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBCalle.Validating += new System.ComponentModel.CancelEventHandler(this.TBCalle_Validating);
            // 
            // CBDepto
            // 
            this.CBDepto.FormattingEnabled = true;
            this.CBDepto.ItemHeight = 13;
            this.CBDepto.Location = new System.Drawing.Point(297, 88);
            this.CBDepto.Name = "CBDepto";
            this.CBDepto.Size = new System.Drawing.Size(38, 21);
            this.CBDepto.TabIndex = 12;
            this.CBDepto.Validating += new System.ComponentModel.CancelEventHandler(this.CBDepto_Validating);
            // 
            // LDepto
            // 
            this.LDepto.AutoSize = true;
            this.LDepto.ForeColor = System.Drawing.SystemColors.Control;
            this.LDepto.Location = new System.Drawing.Point(252, 92);
            this.LDepto.Name = "LDepto";
            this.LDepto.Size = new System.Drawing.Size(39, 13);
            this.LDepto.TabIndex = 14;
            this.LDepto.Text = "Depto:";
            // 
            // LAltura
            // 
            this.LAltura.AutoSize = true;
            this.LAltura.ForeColor = System.Drawing.SystemColors.Control;
            this.LAltura.Location = new System.Drawing.Point(6, 92);
            this.LAltura.Name = "LAltura";
            this.LAltura.Size = new System.Drawing.Size(37, 13);
            this.LAltura.TabIndex = 7;
            this.LAltura.Text = "Altura:";
            // 
            // LPiso
            // 
            this.LPiso.AutoSize = true;
            this.LPiso.ForeColor = System.Drawing.SystemColors.Control;
            this.LPiso.Location = new System.Drawing.Point(252, 52);
            this.LPiso.Name = "LPiso";
            this.LPiso.Size = new System.Drawing.Size(30, 13);
            this.LPiso.TabIndex = 13;
            this.LPiso.Text = "Piso:";
            // 
            // TBAltura
            // 
            this.TBAltura.Location = new System.Drawing.Point(103, 89);
            this.TBAltura.Name = "TBAltura";
            this.TBAltura.Size = new System.Drawing.Size(112, 20);
            this.TBAltura.TabIndex = 9;
            this.TBAltura.Validating += new System.ComponentModel.CancelEventHandler(this.TBAltura_Validating);
            // 
            // CBPiso
            // 
            this.CBPiso.FormattingEnabled = true;
            this.CBPiso.ItemHeight = 13;
            this.CBPiso.Location = new System.Drawing.Point(297, 49);
            this.CBPiso.Name = "CBPiso";
            this.CBPiso.Size = new System.Drawing.Size(38, 21);
            this.CBPiso.TabIndex = 11;
            this.CBPiso.Validating += new System.ComponentModel.CancelEventHandler(this.CBPiso_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GestionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(750, 500);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 534);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionClientes";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PDatosPFisica.ResumeLayout(false);
            this.PDatosPFisica.PerformLayout();
            this.PDatosPJuridica.ResumeLayout(false);
            this.PDatosPJuridica.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel PDatosPJuridica;
        private System.Windows.Forms.Label LCUIT;
        private System.Windows.Forms.TextBox TBSitioWeb;
        private System.Windows.Forms.Label LSitioWeb;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.TextBox TBCuit;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBNombreComercial;
        private System.Windows.Forms.Label LNombreComercial;
        private System.Windows.Forms.Label LRazonSocial;
        private System.Windows.Forms.Label LDepartamento;
        private System.Windows.Forms.Label LCodPostal;
        private System.Windows.Forms.TextBox TBCodPostal;
        private System.Windows.Forms.CheckBox CHKBDepto;
        private System.Windows.Forms.Label LCalle;
        private System.Windows.Forms.TextBox TBCalle;
        private System.Windows.Forms.ComboBox CBDepto;
        private System.Windows.Forms.Label LDepto;
        private System.Windows.Forms.Label LAltura;
        private System.Windows.Forms.Label LPiso;
        private System.Windows.Forms.TextBox TBAltura;
        private System.Windows.Forms.ComboBox CBPiso;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel PDatosPFisica;
        protected System.Windows.Forms.TextBox TBApellido;
        private System.Windows.Forms.Label LFechaNac;
        private System.Windows.Forms.Label LApellido;
        protected System.Windows.Forms.RadioButton RBHombre;
        private System.Windows.Forms.Label LNombre;
        protected System.Windows.Forms.RadioButton RBMujer;
        private System.Windows.Forms.Label LSexo;
        protected System.Windows.Forms.DateTimePicker DTPFechaNacimiento;
        private System.Windows.Forms.Label LDni;
        protected System.Windows.Forms.TextBox TBDni;
        protected System.Windows.Forms.TextBox TBNombre;
        private System.Windows.Forms.Label LPJuridica;
        private System.Windows.Forms.Label LPFisica;
        private System.Windows.Forms.Button BTNRegistrar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox TBRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIdentificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAltura;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDepto;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.Button BTNActualizar;
        private System.Windows.Forms.Button BTNBuscar;
        private System.Windows.Forms.TextBox TBBuscar;
    }
}