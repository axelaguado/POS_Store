namespace WindowsFormsApp1.CapaPresentacion
{
    partial class GestionUsuario
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
            this.PTCrearUsuario = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.PFormularioCrearUsuario = new System.Windows.Forms.Panel();
            this.BRegistrarUsuario = new System.Windows.Forms.Button();
            this.BRestaurar = new System.Windows.Forms.Button();
            this.PInfoContacto = new System.Windows.Forms.Panel();
            this.LInfoContacto = new System.Windows.Forms.Label();
            this.COMBOBDepto = new System.Windows.Forms.ComboBox();
            this.COMBOBPiso = new System.Windows.Forms.ComboBox();
            this.TBCalle = new System.Windows.Forms.TextBox();
            this.LEmail = new System.Windows.Forms.Label();
            this.TBTelefono = new System.Windows.Forms.TextBox();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LDireccion = new System.Windows.Forms.Label();
            this.TBAltura = new System.Windows.Forms.TextBox();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.LAltura = new System.Windows.Forms.Label();
            this.CBDepartamento = new System.Windows.Forms.CheckBox();
            this.LCalle = new System.Windows.Forms.Label();
            this.LPiso = new System.Windows.Forms.Label();
            this.LDepto = new System.Windows.Forms.Label();
            this.PDatosCuenta = new System.Windows.Forms.Panel();
            this.TBGURepetir = new System.Windows.Forms.TextBox();
            this.LRepetirContraseña = new System.Windows.Forms.Label();
            this.LDatosCuenta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.COMBOBTipoUsuario = new System.Windows.Forms.ComboBox();
            this.LGUContraseña = new System.Windows.Forms.Label();
            this.TBGUContraseña = new System.Windows.Forms.TextBox();
            this.LGCUsuario = new System.Windows.Forms.Label();
            this.TBGUUsername = new System.Windows.Forms.TextBox();
            this.PDatosPersonales = new System.Windows.Forms.Panel();
            this.LDatosPersonales = new System.Windows.Forms.Label();
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
            this.PCrearUsuario = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PTCrearUsuario.SuspendLayout();
            this.PFormularioCrearUsuario.SuspendLayout();
            this.PInfoContacto.SuspendLayout();
            this.PDatosCuenta.SuspendLayout();
            this.PDatosPersonales.SuspendLayout();
            this.PCrearUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // PTCrearUsuario
            // 
            this.PTCrearUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PTCrearUsuario.BackColor = System.Drawing.Color.DarkTurquoise;
            this.PTCrearUsuario.Controls.Add(this.LTitulo);
            this.PTCrearUsuario.Location = new System.Drawing.Point(0, 0);
            this.PTCrearUsuario.Name = "PTCrearUsuario";
            this.PTCrearUsuario.Size = new System.Drawing.Size(882, 36);
            this.PTCrearUsuario.TabIndex = 7;
            // 
            // LTitulo
            // 
            this.LTitulo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LTitulo.Location = new System.Drawing.Point(10, 10);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(101, 18);
            this.LTitulo.TabIndex = 0;
            this.LTitulo.Text = "Crear Usuario ";
            this.LTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PFormularioCrearUsuario
            // 
            this.PFormularioCrearUsuario.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.PFormularioCrearUsuario.Controls.Add(this.BRegistrarUsuario);
            this.PFormularioCrearUsuario.Controls.Add(this.BRestaurar);
            this.PFormularioCrearUsuario.Controls.Add(this.PInfoContacto);
            this.PFormularioCrearUsuario.Controls.Add(this.PDatosCuenta);
            this.PFormularioCrearUsuario.Controls.Add(this.PDatosPersonales);
            this.PFormularioCrearUsuario.Location = new System.Drawing.Point(3, 42);
            this.PFormularioCrearUsuario.Name = "PFormularioCrearUsuario";
            this.PFormularioCrearUsuario.Size = new System.Drawing.Size(827, 465);
            this.PFormularioCrearUsuario.TabIndex = 42;
            // 
            // BRegistrarUsuario
            // 
            this.BRegistrarUsuario.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BRegistrarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRegistrarUsuario.FlatAppearance.BorderSize = 0;
            this.BRegistrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRegistrarUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BRegistrarUsuario.Location = new System.Drawing.Point(459, 388);
            this.BRegistrarUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.BRegistrarUsuario.Name = "BRegistrarUsuario";
            this.BRegistrarUsuario.Size = new System.Drawing.Size(124, 32);
            this.BRegistrarUsuario.TabIndex = 43;
            this.BRegistrarUsuario.Text = "Registrar Usuario";
            this.BRegistrarUsuario.UseVisualStyleBackColor = false;
            this.BRegistrarUsuario.Click += new System.EventHandler(this.BRegistrarUsuario_Click);
            // 
            // BRestaurar
            // 
            this.BRestaurar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BRestaurar.FlatAppearance.BorderSize = 0;
            this.BRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BRestaurar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BRestaurar.Location = new System.Drawing.Point(303, 388);
            this.BRestaurar.Margin = new System.Windows.Forms.Padding(0);
            this.BRestaurar.Name = "BRestaurar";
            this.BRestaurar.Size = new System.Drawing.Size(124, 32);
            this.BRestaurar.TabIndex = 42;
            this.BRestaurar.Text = "Restaurar Formulario";
            this.BRestaurar.UseVisualStyleBackColor = false;
            this.BRestaurar.Click += new System.EventHandler(this.BRestaurar_Click);
            // 
            // PInfoContacto
            // 
            this.PInfoContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PInfoContacto.Controls.Add(this.LInfoContacto);
            this.PInfoContacto.Controls.Add(this.COMBOBDepto);
            this.PInfoContacto.Controls.Add(this.COMBOBPiso);
            this.PInfoContacto.Controls.Add(this.TBCalle);
            this.PInfoContacto.Controls.Add(this.LEmail);
            this.PInfoContacto.Controls.Add(this.TBTelefono);
            this.PInfoContacto.Controls.Add(this.LTelefono);
            this.PInfoContacto.Controls.Add(this.LDireccion);
            this.PInfoContacto.Controls.Add(this.TBAltura);
            this.PInfoContacto.Controls.Add(this.TBEmail);
            this.PInfoContacto.Controls.Add(this.LAltura);
            this.PInfoContacto.Controls.Add(this.CBDepartamento);
            this.PInfoContacto.Controls.Add(this.LCalle);
            this.PInfoContacto.Controls.Add(this.LPiso);
            this.PInfoContacto.Controls.Add(this.LDepto);
            this.PInfoContacto.Location = new System.Drawing.Point(539, 8);
            this.PInfoContacto.Name = "PInfoContacto";
            this.PInfoContacto.Size = new System.Drawing.Size(274, 352);
            this.PInfoContacto.TabIndex = 37;
            // 
            // LInfoContacto
            // 
            this.LInfoContacto.AutoSize = true;
            this.LInfoContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.LInfoContacto.Location = new System.Drawing.Point(15, 4);
            this.LInfoContacto.Name = "LInfoContacto";
            this.LInfoContacto.Size = new System.Drawing.Size(171, 18);
            this.LInfoContacto.TabIndex = 38;
            this.LInfoContacto.Text = "Informacion de Contacto";
            // 
            // COMBOBDepto
            // 
            this.COMBOBDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMBOBDepto.Enabled = false;
            this.COMBOBDepto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.COMBOBDepto.FormattingEnabled = true;
            this.COMBOBDepto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.COMBOBDepto.IntegralHeight = false;
            this.COMBOBDepto.Location = new System.Drawing.Point(203, 311);
            this.COMBOBDepto.Name = "COMBOBDepto";
            this.COMBOBDepto.Size = new System.Drawing.Size(40, 21);
            this.COMBOBDepto.TabIndex = 36;
            this.COMBOBDepto.Validating += new System.ComponentModel.CancelEventHandler(this.COMBOBDepto_Validating);
            // 
            // COMBOBPiso
            // 
            this.COMBOBPiso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMBOBPiso.Enabled = false;
            this.COMBOBPiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.COMBOBPiso.FormattingEnabled = true;
            this.COMBOBPiso.IntegralHeight = false;
            this.COMBOBPiso.ItemHeight = 13;
            this.COMBOBPiso.Location = new System.Drawing.Point(71, 311);
            this.COMBOBPiso.Name = "COMBOBPiso";
            this.COMBOBPiso.Size = new System.Drawing.Size(40, 21);
            this.COMBOBPiso.TabIndex = 35;
             
            this.COMBOBPiso.Validating += new System.ComponentModel.CancelEventHandler(this.COMBOBPiso_Validating);
            // 
            // TBCalle
            // 
            this.TBCalle.Location = new System.Drawing.Point(103, 169);
            this.TBCalle.Name = "TBCalle";
            this.TBCalle.Size = new System.Drawing.Size(119, 20);
            this.TBCalle.TabIndex = 33;
            this.TBCalle.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBCalle.Validating += new System.ComponentModel.CancelEventHandler(this.TBCalle_Validating);
            // 
            // LEmail
            // 
            this.LEmail.AutoSize = true;
            this.LEmail.Location = new System.Drawing.Point(15, 52);
            this.LEmail.Name = "LEmail";
            this.LEmail.Size = new System.Drawing.Size(35, 13);
            this.LEmail.TabIndex = 4;
            this.LEmail.Text = "Email:";
            // 
            // TBTelefono
            // 
            this.TBTelefono.Location = new System.Drawing.Point(103, 95);
            this.TBTelefono.Name = "TBTelefono";
            this.TBTelefono.Size = new System.Drawing.Size(119, 20);
            this.TBTelefono.TabIndex = 34;
            this.TBTelefono.Validating += new System.ComponentModel.CancelEventHandler(this.TBTelefono_Validating);
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Location = new System.Drawing.Point(15, 98);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(52, 13);
            this.LTelefono.TabIndex = 5;
            this.LTelefono.Text = "Telefono:";
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Location = new System.Drawing.Point(15, 134);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(55, 13);
            this.LDireccion.TabIndex = 8;
            this.LDireccion.Text = "Direccion:";
            // 
            // TBAltura
            // 
            this.TBAltura.Location = new System.Drawing.Point(103, 215);
            this.TBAltura.Name = "TBAltura";
            this.TBAltura.Size = new System.Drawing.Size(119, 20);
            this.TBAltura.TabIndex = 32;
            this.TBAltura.Validating += new System.ComponentModel.CancelEventHandler(this.TBAltura_Validating);
            // 
            // TBEmail
            // 
            this.TBEmail.Location = new System.Drawing.Point(103, 49);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(119, 20);
            this.TBEmail.TabIndex = 18;
            this.TBEmail.Validating += new System.ComponentModel.CancelEventHandler(this.TBEmail_Validating);
            // 
            // LAltura
            // 
            this.LAltura.AutoSize = true;
            this.LAltura.Location = new System.Drawing.Point(15, 218);
            this.LAltura.Name = "LAltura";
            this.LAltura.Size = new System.Drawing.Size(37, 13);
            this.LAltura.TabIndex = 31;
            this.LAltura.Text = "Altura:";
            // 
            // CBDepartamento
            // 
            this.CBDepartamento.AutoSize = true;
            this.CBDepartamento.Location = new System.Drawing.Point(18, 265);
            this.CBDepartamento.Name = "CBDepartamento";
            this.CBDepartamento.Size = new System.Drawing.Size(93, 17);
            this.CBDepartamento.TabIndex = 25;
            this.CBDepartamento.Text = "Departamento";
            this.CBDepartamento.UseVisualStyleBackColor = true;
            this.CBDepartamento.CheckedChanged += new System.EventHandler(this.CBDepartamento_CheckedChanged);
            // 
            // LCalle
            // 
            this.LCalle.AutoSize = true;
            this.LCalle.Location = new System.Drawing.Point(15, 172);
            this.LCalle.Name = "LCalle";
            this.LCalle.Size = new System.Drawing.Size(33, 13);
            this.LCalle.TabIndex = 30;
            this.LCalle.Text = "Calle:";
            // 
            // LPiso
            // 
            this.LPiso.AutoSize = true;
            this.LPiso.Location = new System.Drawing.Point(20, 319);
            this.LPiso.Name = "LPiso";
            this.LPiso.Size = new System.Drawing.Size(30, 13);
            this.LPiso.TabIndex = 26;
            this.LPiso.Text = "Piso:";
            // 
            // LDepto
            // 
            this.LDepto.AutoSize = true;
            this.LDepto.Location = new System.Drawing.Point(147, 319);
            this.LDepto.Name = "LDepto";
            this.LDepto.Size = new System.Drawing.Size(39, 13);
            this.LDepto.TabIndex = 27;
            this.LDepto.Text = "Depto:";
            // 
            // PDatosCuenta
            // 
            this.PDatosCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PDatosCuenta.Controls.Add(this.TBGURepetir);
            this.PDatosCuenta.Controls.Add(this.LRepetirContraseña);
            this.PDatosCuenta.Controls.Add(this.LDatosCuenta);
            this.PDatosCuenta.Controls.Add(this.label1);
            this.PDatosCuenta.Controls.Add(this.COMBOBTipoUsuario);
            this.PDatosCuenta.Controls.Add(this.LGUContraseña);
            this.PDatosCuenta.Controls.Add(this.TBGUContraseña);
            this.PDatosCuenta.Controls.Add(this.LGCUsuario);
            this.PDatosCuenta.Controls.Add(this.TBGUUsername);
            this.PDatosCuenta.Location = new System.Drawing.Point(10, 197);
            this.PDatosCuenta.Name = "PDatosCuenta";
            this.PDatosCuenta.Size = new System.Drawing.Size(523, 163);
            this.PDatosCuenta.TabIndex = 36;
            // 
            // TBGURepetir
            // 
            this.TBGURepetir.Location = new System.Drawing.Point(382, 95);
            this.TBGURepetir.Name = "TBGURepetir";
            this.TBGURepetir.PasswordChar = '*';
            this.TBGURepetir.Size = new System.Drawing.Size(123, 20);
            this.TBGURepetir.TabIndex = 39;
            this.TBGURepetir.Validating += new System.ComponentModel.CancelEventHandler(this.TBGURepetir_Validating);
            // 
            // LRepetirContraseña
            // 
            this.LRepetirContraseña.AutoSize = true;
            this.LRepetirContraseña.Location = new System.Drawing.Point(265, 98);
            this.LRepetirContraseña.Name = "LRepetirContraseña";
            this.LRepetirContraseña.Size = new System.Drawing.Size(101, 13);
            this.LRepetirContraseña.TabIndex = 38;
            this.LRepetirContraseña.Text = "Repetir Contraseña:";
            // 
            // LDatosCuenta
            // 
            this.LDatosCuenta.AutoSize = true;
            this.LDatosCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.LDatosCuenta.Location = new System.Drawing.Point(15, 9);
            this.LDatosCuenta.Name = "LDatosCuenta";
            this.LDatosCuenta.Size = new System.Drawing.Size(134, 18);
            this.LDatosCuenta.TabIndex = 37;
            this.LDatosCuenta.Text = "Datos de la Cuenta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tipo de Usuario:";
            // 
            // COMBOBTipoUsuario
            // 
            this.COMBOBTipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMBOBTipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.COMBOBTipoUsuario.FormattingEnabled = true;
            this.COMBOBTipoUsuario.Items.AddRange(new object[] {
            "Administrador",
            "Gerente",
            "Empleado"});
            this.COMBOBTipoUsuario.Location = new System.Drawing.Point(116, 95);
            this.COMBOBTipoUsuario.Name = "COMBOBTipoUsuario";
            this.COMBOBTipoUsuario.Size = new System.Drawing.Size(123, 21);
            this.COMBOBTipoUsuario.TabIndex = 35;
            this.COMBOBTipoUsuario.Validating += new System.ComponentModel.CancelEventHandler(this.COMBOBTipoUsuario_Validating);
            // 
            // LGUContraseña
            // 
            this.LGUContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LGUContraseña.AutoSize = true;
            this.LGUContraseña.Location = new System.Drawing.Point(265, 49);
            this.LGUContraseña.Name = "LGUContraseña";
            this.LGUContraseña.Size = new System.Drawing.Size(64, 13);
            this.LGUContraseña.TabIndex = 11;
            this.LGUContraseña.Text = "Contraseña:";
            // 
            // TBGUContraseña
            // 
            this.TBGUContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TBGUContraseña.Location = new System.Drawing.Point(382, 46);
            this.TBGUContraseña.Name = "TBGUContraseña";
            this.TBGUContraseña.PasswordChar = '*';
            this.TBGUContraseña.Size = new System.Drawing.Size(123, 20);
            this.TBGUContraseña.TabIndex = 21;
            this.TBGUContraseña.Validating += new System.ComponentModel.CancelEventHandler(this.TBGUContraseña_Validating);
            // 
            // LGCUsuario
            // 
            this.LGCUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LGCUsuario.AutoSize = true;
            this.LGCUsuario.Location = new System.Drawing.Point(19, 49);
            this.LGCUsuario.Name = "LGCUsuario";
            this.LGCUsuario.Size = new System.Drawing.Size(46, 13);
            this.LGCUsuario.TabIndex = 10;
            this.LGCUsuario.Text = "Usuario:";
            // 
            // TBGUUsername
            // 
            this.TBGUUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TBGUUsername.Location = new System.Drawing.Point(116, 46);
            this.TBGUUsername.Name = "TBGUUsername";
            this.TBGUUsername.Size = new System.Drawing.Size(123, 20);
            this.TBGUUsername.TabIndex = 19;
            this.TBGUUsername.Validating += new System.ComponentModel.CancelEventHandler(this.TBGUUsuario_Validating);
            // 
            // PDatosPersonales
            // 
            this.PDatosPersonales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PDatosPersonales.Controls.Add(this.LDatosPersonales);
            this.PDatosPersonales.Controls.Add(this.TBApellido);
            this.PDatosPersonales.Controls.Add(this.LFechaNac);
            this.PDatosPersonales.Controls.Add(this.LApellido);
            this.PDatosPersonales.Controls.Add(this.RBHombre);
            this.PDatosPersonales.Controls.Add(this.LNombre);
            this.PDatosPersonales.Controls.Add(this.RBMujer);
            this.PDatosPersonales.Controls.Add(this.LSexo);
            this.PDatosPersonales.Controls.Add(this.DTPFechaNacimiento);
            this.PDatosPersonales.Controls.Add(this.LDni);
            this.PDatosPersonales.Controls.Add(this.TBDni);
            this.PDatosPersonales.Controls.Add(this.TBNombre);
            this.PDatosPersonales.Location = new System.Drawing.Point(10, 8);
            this.PDatosPersonales.Name = "PDatosPersonales";
            this.PDatosPersonales.Size = new System.Drawing.Size(523, 183);
            this.PDatosPersonales.TabIndex = 39;
            // 
            // LDatosPersonales
            // 
            this.LDatosPersonales.AutoSize = true;
            this.LDatosPersonales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.LDatosPersonales.Location = new System.Drawing.Point(15, 4);
            this.LDatosPersonales.Name = "LDatosPersonales";
            this.LDatosPersonales.Size = new System.Drawing.Size(127, 18);
            this.LDatosPersonales.TabIndex = 25;
            this.LDatosPersonales.Text = "Datos Personales";
            // 
            // TBApellido
            // 
            this.TBApellido.Location = new System.Drawing.Point(111, 145);
            this.TBApellido.Name = "TBApellido";
            this.TBApellido.Size = new System.Drawing.Size(123, 20);
            this.TBApellido.TabIndex = 14;
            this.TBApellido.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBApellido.Validating += new System.ComponentModel.CancelEventHandler(this.TBApellido_Validating);
            // 
            // LFechaNac
            // 
            this.LFechaNac.AutoSize = true;
            this.LFechaNac.Location = new System.Drawing.Point(379, 49);
            this.LFechaNac.Name = "LFechaNac";
            this.LFechaNac.Size = new System.Drawing.Size(94, 13);
            this.LFechaNac.TabIndex = 3;
            this.LFechaNac.Text = "Fecha nacimiento:";
            // 
            // LApellido
            // 
            this.LApellido.AutoSize = true;
            this.LApellido.Location = new System.Drawing.Point(15, 148);
            this.LApellido.Name = "LApellido";
            this.LApellido.Size = new System.Drawing.Size(47, 13);
            this.LApellido.TabIndex = 2;
            this.LApellido.Text = "Apellido:";
            // 
            // RBHombre
            // 
            this.RBHombre.AutoSize = true;
            this.RBHombre.Checked = true;
            this.RBHombre.Location = new System.Drawing.Point(274, 74);
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
            this.LNombre.Location = new System.Drawing.Point(15, 98);
            this.LNombre.Name = "LNombre";
            this.LNombre.Size = new System.Drawing.Size(47, 13);
            this.LNombre.TabIndex = 1;
            this.LNombre.Text = "Nombre:";
            // 
            // RBMujer
            // 
            this.RBMujer.AutoSize = true;
            this.RBMujer.Location = new System.Drawing.Point(274, 107);
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
            this.LSexo.Location = new System.Drawing.Point(271, 49);
            this.LSexo.Name = "LSexo";
            this.LSexo.Size = new System.Drawing.Size(34, 13);
            this.LSexo.TabIndex = 6;
            this.LSexo.Text = "Sexo:";
            // 
            // DTPFechaNacimiento
            // 
            this.DTPFechaNacimiento.Checked = false;
            this.DTPFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaNacimiento.Location = new System.Drawing.Point(382, 74);
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
            this.LDni.Location = new System.Drawing.Point(15, 49);
            this.LDni.Name = "LDni";
            this.LDni.Size = new System.Drawing.Size(26, 13);
            this.LDni.TabIndex = 0;
            this.LDni.Text = "Dni:";
            // 
            // TBDni
            // 
            this.TBDni.Location = new System.Drawing.Point(111, 46);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(123, 20);
            this.TBDni.TabIndex = 13;
            this.TBDni.Validating += new System.ComponentModel.CancelEventHandler(this.TBDni_Validating);
            // 
            // TBNombre
            // 
            this.TBNombre.Location = new System.Drawing.Point(111, 95);
            this.TBNombre.Name = "TBNombre";
            this.TBNombre.Size = new System.Drawing.Size(123, 20);
            this.TBNombre.TabIndex = 15;
            this.TBNombre.TextChanged += new System.EventHandler(this.TBNombre_TextChanged);
            this.TBNombre.Validating += new System.ComponentModel.CancelEventHandler(this.TBNombre_Validating);
            // 
            // PCrearUsuario
            // 
            this.PCrearUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCrearUsuario.AutoScroll = true;
            this.PCrearUsuario.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PCrearUsuario.Controls.Add(this.PFormularioCrearUsuario);
            this.PCrearUsuario.Controls.Add(this.PTCrearUsuario);
            this.PCrearUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.PCrearUsuario.Location = new System.Drawing.Point(10, 10);
            this.PCrearUsuario.MinimumSize = new System.Drawing.Size(447, 531);
            this.PCrearUsuario.Name = "PCrearUsuario";
            this.PCrearUsuario.Size = new System.Drawing.Size(882, 531);
            this.PCrearUsuario.TabIndex = 7;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // GestionUsuario
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(3, 3);
            this.AutoScrollMinSize = new System.Drawing.Size(910, 560);
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(875, 553);
            this.Controls.Add(this.PCrearUsuario);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GestionUsuario";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.Text = "Gestionar Usuarios";
            this.PTCrearUsuario.ResumeLayout(false);
            this.PFormularioCrearUsuario.ResumeLayout(false);
            this.PInfoContacto.ResumeLayout(false);
            this.PInfoContacto.PerformLayout();
            this.PDatosCuenta.ResumeLayout(false);
            this.PDatosCuenta.PerformLayout();
            this.PDatosPersonales.ResumeLayout(false);
            this.PDatosPersonales.PerformLayout();
            this.PCrearUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Panel PTCrearUsuario;
        private System.Windows.Forms.Label LInfoContacto;
        private System.Windows.Forms.Label LEmail;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.Label LAltura;
        private System.Windows.Forms.Label LCalle;
        private System.Windows.Forms.Label LPiso;
        private System.Windows.Forms.Label LDepto;
        private System.Windows.Forms.Label LDatosCuenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LGCUsuario;
        private System.Windows.Forms.Panel PDatosPersonales;
        private System.Windows.Forms.Label LDatosPersonales;
        private System.Windows.Forms.Label LFechaNac;
        private System.Windows.Forms.Label LApellido;
        private System.Windows.Forms.Label LNombre;
        private System.Windows.Forms.Label LSexo;
        private System.Windows.Forms.Label LDni;
        public System.Windows.Forms.ErrorProvider errorProvider1;
        protected System.Windows.Forms.TextBox TBTelefono;
        protected System.Windows.Forms.TextBox TBEmail;
        protected System.Windows.Forms.TextBox TBApellido;
        protected System.Windows.Forms.RadioButton RBHombre;
        protected System.Windows.Forms.RadioButton RBMujer;
        protected System.Windows.Forms.DateTimePicker DTPFechaNacimiento;
        protected System.Windows.Forms.TextBox TBDni;
        protected System.Windows.Forms.TextBox TBNombre;
        protected System.Windows.Forms.Button BRegistrarUsuario;
        protected System.Windows.Forms.Button BRestaurar;
        protected System.Windows.Forms.ComboBox COMBOBDepto;
        protected System.Windows.Forms.ComboBox COMBOBPiso;
        protected System.Windows.Forms.TextBox TBCalle;
        protected System.Windows.Forms.TextBox TBAltura;
        protected System.Windows.Forms.CheckBox CBDepartamento;
        protected System.Windows.Forms.ComboBox COMBOBTipoUsuario;
        protected System.Windows.Forms.TextBox TBGUUsername;
        protected System.Windows.Forms.Label LTitulo;
        protected System.Windows.Forms.Panel PInfoContacto;
        protected System.Windows.Forms.Panel PDatosCuenta;
        protected System.Windows.Forms.Label LRepetirContraseña;
        protected System.Windows.Forms.Label LGUContraseña;
        protected System.Windows.Forms.Panel PFormularioCrearUsuario;
        protected System.Windows.Forms.Panel PCrearUsuario;
        protected System.Windows.Forms.TextBox TBGUContraseña;
        protected System.Windows.Forms.TextBox TBGURepetir;
    }
}