namespace WindowsFormsApp1.CapaPresentacion
{
    partial class GestionProveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNReestablecer = new System.Windows.Forms.Button();
            this.BTNActualizar = new System.Windows.Forms.Button();
            this.BTNRegistrarProveedor = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TBRazonSocial = new System.Windows.Forms.TextBox();
            this.CBDepto = new System.Windows.Forms.ComboBox();
            this.LDepto = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LGestionCompras = new System.Windows.Forms.Label();
            this.LDepartamento = new System.Windows.Forms.Label();
            this.LPiso = new System.Windows.Forms.Label();
            this.CBPiso = new System.Windows.Forms.ComboBox();
            this.TBCodPostal = new System.Windows.Forms.TextBox();
            this.TBSitioWeb = new System.Windows.Forms.TextBox();
            this.CHKBDepto = new System.Windows.Forms.CheckBox();
            this.LCUIT = new System.Windows.Forms.Label();
            this.LRazonSocial = new System.Windows.Forms.Label();
            this.LSitioWeb = new System.Windows.Forms.Label();
            this.TBAltura = new System.Windows.Forms.TextBox();
            this.LAltura = new System.Windows.Forms.Label();
            this.LNombreComercial = new System.Windows.Forms.Label();
            this.TBCalle = new System.Windows.Forms.TextBox();
            this.TBNombreComercial = new System.Windows.Forms.TextBox();
            this.LCalle = new System.Windows.Forms.Label();
            this.TBCuit = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LCodPostal = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TBBuscar = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCuit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTelefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CSitioWeb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCodPostal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAltura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.BTNReestablecer);
            this.panel1.Controls.Add(this.BTNActualizar);
            this.panel1.Controls.Add(this.BTNRegistrarProveedor);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.BTNLimpiar);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 575);
            this.panel1.TabIndex = 0;
            // 
            // BTNReestablecer
            // 
            this.BTNReestablecer.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNReestablecer.FlatAppearance.BorderSize = 0;
            this.BTNReestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNReestablecer.Location = new System.Drawing.Point(84, 512);
            this.BTNReestablecer.Name = "BTNReestablecer";
            this.BTNReestablecer.Size = new System.Drawing.Size(84, 23);
            this.BTNReestablecer.TabIndex = 23;
            this.BTNReestablecer.Text = "Reestablecer";
            this.BTNReestablecer.UseVisualStyleBackColor = false;
            this.BTNReestablecer.Click += new System.EventHandler(this.BTNReestablecer_Click);
            // 
            // BTNActualizar
            // 
            this.BTNActualizar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNActualizar.FlatAppearance.BorderSize = 0;
            this.BTNActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNActualizar.Location = new System.Drawing.Point(184, 512);
            this.BTNActualizar.Name = "BTNActualizar";
            this.BTNActualizar.Size = new System.Drawing.Size(75, 23);
            this.BTNActualizar.TabIndex = 22;
            this.BTNActualizar.Text = "Actualizar";
            this.BTNActualizar.UseVisualStyleBackColor = false;
            this.BTNActualizar.Click += new System.EventHandler(this.BTNActualizar_Click);
            // 
            // BTNRegistrarProveedor
            // 
            this.BTNRegistrarProveedor.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNRegistrarProveedor.FlatAppearance.BorderSize = 0;
            this.BTNRegistrarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNRegistrarProveedor.Location = new System.Drawing.Point(184, 512);
            this.BTNRegistrarProveedor.Name = "BTNRegistrarProveedor";
            this.BTNRegistrarProveedor.Size = new System.Drawing.Size(75, 23);
            this.BTNRegistrarProveedor.TabIndex = 21;
            this.BTNRegistrarProveedor.Text = "Registrar";
            this.BTNRegistrarProveedor.UseVisualStyleBackColor = false;
            this.BTNRegistrarProveedor.Click += new System.EventHandler(this.BTRegistrarProveedor_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(347, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(435, 33);
            this.panel5.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proveedores";
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNLimpiar.FlatAppearance.BorderSize = 0;
            this.BTNLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLimpiar.Location = new System.Drawing.Point(93, 512);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BTNLimpiar.TabIndex = 20;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TBRazonSocial);
            this.panel4.Controls.Add(this.CBDepto);
            this.panel4.Controls.Add(this.LDepto);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.LDepartamento);
            this.panel4.Controls.Add(this.LPiso);
            this.panel4.Controls.Add(this.CBPiso);
            this.panel4.Controls.Add(this.TBCodPostal);
            this.panel4.Controls.Add(this.TBSitioWeb);
            this.panel4.Controls.Add(this.CHKBDepto);
            this.panel4.Controls.Add(this.LCUIT);
            this.panel4.Controls.Add(this.LRazonSocial);
            this.panel4.Controls.Add(this.LSitioWeb);
            this.panel4.Controls.Add(this.TBAltura);
            this.panel4.Controls.Add(this.LAltura);
            this.panel4.Controls.Add(this.LNombreComercial);
            this.panel4.Controls.Add(this.TBCalle);
            this.panel4.Controls.Add(this.TBNombreComercial);
            this.panel4.Controls.Add(this.LCalle);
            this.panel4.Controls.Add(this.TBCuit);
            this.panel4.Controls.Add(this.LTelefono);
            this.panel4.Controls.Add(this.TBTelefono);
            this.panel4.Controls.Add(this.LCodPostal);
            this.panel4.Controls.Add(this.TBEmail);
            this.panel4.Controls.Add(this.LEmail);
            this.panel4.Location = new System.Drawing.Point(13, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(328, 486);
            this.panel4.TabIndex = 4;
            // 
            // TBRazonSocial
            // 
            this.TBRazonSocial.Location = new System.Drawing.Point(108, 48);
            this.TBRazonSocial.Name = "TBRazonSocial";
            this.TBRazonSocial.Size = new System.Drawing.Size(108, 20);
            this.TBRazonSocial.TabIndex = 20;
            this.TBRazonSocial.Validating += new System.ComponentModel.CancelEventHandler(this.CBRazonSocial_Validating);
            // 
            // CBDepto
            // 
            this.CBDepto.FormattingEnabled = true;
            this.CBDepto.ItemHeight = 13;
            this.CBDepto.Location = new System.Drawing.Point(171, 455);
            this.CBDepto.Name = "CBDepto";
            this.CBDepto.Size = new System.Drawing.Size(45, 21);
            this.CBDepto.TabIndex = 12;
            this.CBDepto.Validating += new System.ComponentModel.CancelEventHandler(this.CBDepto_Validating);
            // 
            // LDepto
            // 
            this.LDepto.AutoSize = true;
            this.LDepto.ForeColor = System.Drawing.SystemColors.Control;
            this.LDepto.Location = new System.Drawing.Point(105, 458);
            this.LDepto.Name = "LDepto";
            this.LDepto.Size = new System.Drawing.Size(39, 13);
            this.LDepto.TabIndex = 14;
            this.LDepto.Text = "Depto:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel3.Controls.Add(this.LGestionCompras);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 33);
            this.panel3.TabIndex = 3;
            // 
            // LGestionCompras
            // 
            this.LGestionCompras.AutoSize = true;
            this.LGestionCompras.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.LGestionCompras.Location = new System.Drawing.Point(3, 8);
            this.LGestionCompras.Name = "LGestionCompras";
            this.LGestionCompras.Size = new System.Drawing.Size(136, 18);
            this.LGestionCompras.TabIndex = 0;
            this.LGestionCompras.Text = "Registrar Proveedor";
            // 
            // LDepartamento
            // 
            this.LDepartamento.AutoSize = true;
            this.LDepartamento.ForeColor = System.Drawing.SystemColors.Control;
            this.LDepartamento.Location = new System.Drawing.Point(25, 402);
            this.LDepartamento.Name = "LDepartamento";
            this.LDepartamento.Size = new System.Drawing.Size(77, 13);
            this.LDepartamento.TabIndex = 19;
            this.LDepartamento.Text = "Departamento:";
            // 
            // LPiso
            // 
            this.LPiso.AutoSize = true;
            this.LPiso.ForeColor = System.Drawing.SystemColors.Control;
            this.LPiso.Location = new System.Drawing.Point(105, 422);
            this.LPiso.Name = "LPiso";
            this.LPiso.Size = new System.Drawing.Size(30, 13);
            this.LPiso.TabIndex = 13;
            this.LPiso.Text = "Piso:";
            // 
            // CBPiso
            // 
            this.CBPiso.FormattingEnabled = true;
            this.CBPiso.ItemHeight = 13;
            this.CBPiso.Location = new System.Drawing.Point(171, 419);
            this.CBPiso.Name = "CBPiso";
            this.CBPiso.Size = new System.Drawing.Size(45, 21);
            this.CBPiso.TabIndex = 11;
            this.CBPiso.Validating += new System.ComponentModel.CancelEventHandler(this.CBPiso_Validating);
            // 
            // TBCodPostal
            // 
            this.TBCodPostal.Location = new System.Drawing.Point(108, 286);
            this.TBCodPostal.Name = "TBCodPostal";
            this.TBCodPostal.Size = new System.Drawing.Size(108, 20);
            this.TBCodPostal.TabIndex = 16;
            this.TBCodPostal.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodPostal_Validating);
            // 
            // TBSitioWeb
            // 
            this.TBSitioWeb.Location = new System.Drawing.Point(108, 239);
            this.TBSitioWeb.Name = "TBSitioWeb";
            this.TBSitioWeb.Size = new System.Drawing.Size(108, 20);
            this.TBSitioWeb.TabIndex = 17;
            this.TBSitioWeb.Validating += new System.ComponentModel.CancelEventHandler(this.TBSitioWeb_Validating);
            // 
            // CHKBDepto
            // 
            this.CHKBDepto.AutoSize = true;
            this.CHKBDepto.ForeColor = System.Drawing.SystemColors.Control;
            this.CHKBDepto.Location = new System.Drawing.Point(10, 401);
            this.CHKBDepto.Name = "CHKBDepto";
            this.CHKBDepto.Size = new System.Drawing.Size(29, 17);
            this.CHKBDepto.TabIndex = 10;
            this.CHKBDepto.Text = " ";
            this.CHKBDepto.UseVisualStyleBackColor = true;
            this.CHKBDepto.CheckedChanged += new System.EventHandler(this.CHKBDepto_CheckedChanged);
            // 
            // LCUIT
            // 
            this.LCUIT.AutoSize = true;
            this.LCUIT.ForeColor = System.Drawing.SystemColors.Control;
            this.LCUIT.Location = new System.Drawing.Point(9, 123);
            this.LCUIT.Name = "LCUIT";
            this.LCUIT.Size = new System.Drawing.Size(35, 13);
            this.LCUIT.TabIndex = 18;
            this.LCUIT.Text = "CUIT:";
            // 
            // LRazonSocial
            // 
            this.LRazonSocial.AutoSize = true;
            this.LRazonSocial.ForeColor = System.Drawing.SystemColors.Control;
            this.LRazonSocial.Location = new System.Drawing.Point(7, 51);
            this.LRazonSocial.Name = "LRazonSocial";
            this.LRazonSocial.Size = new System.Drawing.Size(71, 13);
            this.LRazonSocial.TabIndex = 0;
            this.LRazonSocial.Text = "Razon social:";
            // 
            // LSitioWeb
            // 
            this.LSitioWeb.AutoSize = true;
            this.LSitioWeb.ForeColor = System.Drawing.SystemColors.Control;
            this.LSitioWeb.Location = new System.Drawing.Point(9, 242);
            this.LSitioWeb.Name = "LSitioWeb";
            this.LSitioWeb.Size = new System.Drawing.Size(53, 13);
            this.LSitioWeb.TabIndex = 15;
            this.LSitioWeb.Text = "Sitio web:";
            // 
            // TBAltura
            // 
            this.TBAltura.Location = new System.Drawing.Point(108, 358);
            this.TBAltura.Name = "TBAltura";
            this.TBAltura.Size = new System.Drawing.Size(108, 20);
            this.TBAltura.TabIndex = 9;
            this.TBAltura.Validating += new System.ComponentModel.CancelEventHandler(this.TBAltura_Validating);
            // 
            // LAltura
            // 
            this.LAltura.AutoSize = true;
            this.LAltura.ForeColor = System.Drawing.SystemColors.Control;
            this.LAltura.Location = new System.Drawing.Point(9, 361);
            this.LAltura.Name = "LAltura";
            this.LAltura.Size = new System.Drawing.Size(37, 13);
            this.LAltura.TabIndex = 7;
            this.LAltura.Text = "Altura:";
            // 
            // LNombreComercial
            // 
            this.LNombreComercial.AutoSize = true;
            this.LNombreComercial.ForeColor = System.Drawing.SystemColors.Control;
            this.LNombreComercial.Location = new System.Drawing.Point(7, 87);
            this.LNombreComercial.Name = "LNombreComercial";
            this.LNombreComercial.Size = new System.Drawing.Size(95, 13);
            this.LNombreComercial.TabIndex = 2;
            this.LNombreComercial.Text = "Nombre comercial:";
            // 
            // TBCalle
            // 
            this.TBCalle.Location = new System.Drawing.Point(108, 322);
            this.TBCalle.Name = "TBCalle";
            this.TBCalle.Size = new System.Drawing.Size(108, 20);
            this.TBCalle.TabIndex = 3;
            this.TBCalle.Validating += new System.ComponentModel.CancelEventHandler(this.TBCalle_Validating);
            // 
            // TBNombreComercial
            // 
            this.TBNombreComercial.Location = new System.Drawing.Point(108, 84);
            this.TBNombreComercial.Name = "TBNombreComercial";
            this.TBNombreComercial.Size = new System.Drawing.Size(108, 20);
            this.TBNombreComercial.TabIndex = 3;
            this.TBNombreComercial.Validating += new System.ComponentModel.CancelEventHandler(this.TBNombreComercial_Validating);
            // 
            // LCalle
            // 
            this.LCalle.AutoSize = true;
            this.LCalle.ForeColor = System.Drawing.SystemColors.Control;
            this.LCalle.Location = new System.Drawing.Point(9, 325);
            this.LCalle.Name = "LCalle";
            this.LCalle.Size = new System.Drawing.Size(33, 13);
            this.LCalle.TabIndex = 6;
            this.LCalle.Text = "Calle:";
            // 
            // TBCuit
            // 
            this.TBCuit.Location = new System.Drawing.Point(108, 120);
            this.TBCuit.Name = "TBCuit";
            this.TBCuit.Size = new System.Drawing.Size(108, 20);
            this.TBCuit.TabIndex = 8;
            this.TBCuit.Validating += new System.ComponentModel.CancelEventHandler(this.TBCuit_Validating);
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.ForeColor = System.Drawing.SystemColors.Control;
            this.LTelefono.Location = new System.Drawing.Point(7, 170);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(52, 13);
            this.LTelefono.TabIndex = 5;
            this.LTelefono.Text = "Telefono:";
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(108, 167);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(108, 20);
            this.TBTelefono.TabIndex = 1;
            this.TBTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.TBTelefono_Validating);
            // 
            // LCodPostal
            // 
            this.LCodPostal.AutoSize = true;
            this.LCodPostal.ForeColor = System.Drawing.SystemColors.Control;
            this.LCodPostal.Location = new System.Drawing.Point(9, 289);
            this.LCodPostal.Name = "LCodPostal";
            this.LCodPostal.Size = new System.Drawing.Size(75, 13);
            this.LCodPostal.TabIndex = 4;
            this.LCodPostal.Text = "Codigo Postal:";
            // 
            // TBEmail
            // 
            this.TBEmail.Location = new System.Drawing.Point(108, 203);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(108, 20);
            this.TBEmail.TabIndex = 2;
            this.TBEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TBEmail_Validating);
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.ForeColor = System.Drawing.SystemColors.Control;
            this.LEmail.Location = new System.Drawing.Point(9, 206);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(35, 13);
            this.LEmail.TabIndex = 7;
            this.LEmail.Text = "Email:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.TBBuscar);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.BTNBuscar);
            this.panel2.Location = new System.Drawing.Point(347, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 552);
            this.panel2.TabIndex = 3;
            // 
            // TBBuscar
            // 
            this.TBBuscar.Location = new System.Drawing.Point(6, 48);
            this.TBBuscar.Name = "TBBuscar";
            this.TBBuscar.Size = new System.Drawing.Size(208, 20);
            this.TBBuscar.TabIndex = 2;
            this.TBBuscar.Text = "Buscar por nombre o cuit ...";
            this.TBBuscar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBBuscar_MouseClick);
            this.TBBuscar.TextChanged += new System.EventHandler(this.TBBuscar_TextChanged);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkTurquoise;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CProveedor,
            this.CCuit,
            this.CTelefono,
            this.CEmail,
            this.CSitioWeb,
            this.CCodPostal,
            this.CCalle,
            this.CAltura,
            this.CEstado});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(6, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(426, 466);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // CProveedor
            // 
            this.CProveedor.HeaderText = "Proveedor";
            this.CProveedor.Name = "CProveedor";
            this.CProveedor.Width = 80;
            // 
            // CCuit
            // 
            this.CCuit.HeaderText = "Cuit";
            this.CCuit.Name = "CCuit";
            this.CCuit.Width = 49;
            // 
            // CTelefono
            // 
            this.CTelefono.HeaderText = "Telefono";
            this.CTelefono.Name = "CTelefono";
            this.CTelefono.Width = 73;
            // 
            // CEmail
            // 
            this.CEmail.HeaderText = "Email";
            this.CEmail.Name = "CEmail";
            this.CEmail.Width = 56;
            // 
            // CSitioWeb
            // 
            this.CSitioWeb.HeaderText = "SitioWeb";
            this.CSitioWeb.Name = "CSitioWeb";
            this.CSitioWeb.Width = 74;
            // 
            // CCodPostal
            // 
            this.CCodPostal.HeaderText = "CodPostal";
            this.CCodPostal.Name = "CCodPostal";
            this.CCodPostal.Width = 79;
            // 
            // CCalle
            // 
            this.CCalle.HeaderText = "Calle";
            this.CCalle.Name = "CCalle";
            this.CCalle.Width = 54;
            // 
            // CAltura
            // 
            this.CAltura.HeaderText = "Altura";
            this.CAltura.Name = "CAltura";
            this.CAltura.Width = 58;
            // 
            // CEstado
            // 
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.Width = 64;
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscar.FlatAppearance.BorderSize = 0;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.Location = new System.Drawing.Point(220, 48);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(64, 23);
            this.BTNBuscar.TabIndex = 1;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GestionProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(800, 600);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(821, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionProveedor";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TBBuscar;
        private System.Windows.Forms.Button BTNBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LGestionCompras;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox CBDepto;
        private System.Windows.Forms.Label LDepto;
        private System.Windows.Forms.Label LDepartamento;
        private System.Windows.Forms.Label LPiso;
        private System.Windows.Forms.ComboBox CBPiso;
        private System.Windows.Forms.TextBox TBCodPostal;
        private System.Windows.Forms.TextBox TBSitioWeb;
        private System.Windows.Forms.CheckBox CHKBDepto;
        private System.Windows.Forms.Label LCUIT;
        private System.Windows.Forms.Label LRazonSocial;
        private System.Windows.Forms.Label LSitioWeb;
        private System.Windows.Forms.TextBox TBAltura;
        private System.Windows.Forms.Label LAltura;
        private System.Windows.Forms.Label LNombreComercial;
        private System.Windows.Forms.TextBox TBCalle;
        private System.Windows.Forms.TextBox TBNombreComercial;
        private System.Windows.Forms.Label LCalle;
        private System.Windows.Forms.TextBox TBCuit;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.TextBox TBTelefono;
        private System.Windows.Forms.Label LCodPostal;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button BTNRegistrarProveedor;
        private System.Windows.Forms.Button BTNLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn CProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCuit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTelefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn CSitioWeb;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCodPostal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn CAltura;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.Button BTNReestablecer;
        private System.Windows.Forms.Button BTNActualizar;
        private System.Windows.Forms.TextBox TBRazonSocial;
    }
}