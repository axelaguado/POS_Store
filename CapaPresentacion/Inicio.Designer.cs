namespace WindowsFormsApp1.CapaPresentacion
{
    partial class Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inicio));
            this.PHeaderInicio = new System.Windows.Forms.Panel();
            this.BCerrar = new System.Windows.Forms.PictureBox();
            this.BMinimizar = new System.Windows.Forms.PictureBox();
            this.LIniciarSesion = new System.Windows.Forms.Label();
            this.PBUsers = new System.Windows.Forms.PictureBox();
            this.TBContraseña = new System.Windows.Forms.TextBox();
            this.TBUsername = new System.Windows.Forms.TextBox();
            this.LUsuario = new System.Windows.Forms.Label();
            this.LContraseña = new System.Windows.Forms.Label();
            this.LBienvenida = new System.Windows.Forms.Label();
            this.BIniciar = new System.Windows.Forms.Button();
            this.PBLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PHeaderInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // PHeaderInicio
            // 
            this.PHeaderInicio.BackColor = System.Drawing.Color.DarkTurquoise;
            this.PHeaderInicio.Controls.Add(this.BCerrar);
            this.PHeaderInicio.Controls.Add(this.BMinimizar);
            this.PHeaderInicio.Controls.Add(this.LIniciarSesion);
            this.PHeaderInicio.Controls.Add(this.PBUsers);
            this.PHeaderInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeaderInicio.Location = new System.Drawing.Point(2, 2);
            this.PHeaderInicio.Name = "PHeaderInicio";
            this.PHeaderInicio.Padding = new System.Windows.Forms.Padding(2);
            this.PHeaderInicio.Size = new System.Drawing.Size(296, 30);
            this.PHeaderInicio.TabIndex = 0;
            this.PHeaderInicio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // BCerrar
            // 
            this.BCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.Location = new System.Drawing.Point(262, 3);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(27, 25);
            this.BCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BCerrar.TabIndex = 4;
            this.BCerrar.TabStop = false;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // BMinimizar
            // 
            this.BMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("BMinimizar.Image")));
            this.BMinimizar.Location = new System.Drawing.Point(241, 12);
            this.BMinimizar.Name = "BMinimizar";
            this.BMinimizar.Size = new System.Drawing.Size(13, 16);
            this.BMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BMinimizar.TabIndex = 3;
            this.BMinimizar.TabStop = false;
            this.BMinimizar.Click += new System.EventHandler(this.BMinimizar_Click);
            // 
            // LIniciarSesion
            // 
            this.LIniciarSesion.AutoSize = true;
            this.LIniciarSesion.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LIniciarSesion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LIniciarSesion.Location = new System.Drawing.Point(35, 11);
            this.LIniciarSesion.Name = "LIniciarSesion";
            this.LIniciarSesion.Size = new System.Drawing.Size(71, 14);
            this.LIniciarSesion.TabIndex = 2;
            this.LIniciarSesion.Text = "Iniciar Sesion";
            // 
            // PBUsers
            // 
            this.PBUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.PBUsers.Image = ((System.Drawing.Image)(resources.GetObject("PBUsers.Image")));
            this.PBUsers.Location = new System.Drawing.Point(2, 2);
            this.PBUsers.Name = "PBUsers";
            this.PBUsers.Size = new System.Drawing.Size(27, 26);
            this.PBUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBUsers.TabIndex = 1;
            this.PBUsers.TabStop = false;
            // 
            // TBContraseña
            // 
            this.TBContraseña.BackColor = System.Drawing.Color.DarkSlateGray;
            this.TBContraseña.ForeColor = System.Drawing.SystemColors.Control;
            this.TBContraseña.Location = new System.Drawing.Point(69, 240);
            this.TBContraseña.Name = "TBContraseña";
            this.TBContraseña.PasswordChar = '*';
            this.TBContraseña.Size = new System.Drawing.Size(162, 20);
            this.TBContraseña.TabIndex = 1; 
            // 
            // TBUsername
            // 
            this.TBUsername.BackColor = System.Drawing.Color.DarkSlateGray;
            this.TBUsername.ForeColor = System.Drawing.SystemColors.Control;
            this.TBUsername.Location = new System.Drawing.Point(69, 184);
            this.TBUsername.Name = "TBUsername";
            this.TBUsername.Size = new System.Drawing.Size(162, 20);
            this.TBUsername.TabIndex = 2; 
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.LUsuario.Location = new System.Drawing.Point(68, 170);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(47, 13);
            this.LUsuario.TabIndex = 3;
            this.LUsuario.Text = "Usuario:";
            // 
            // LContraseña
            // 
            this.LContraseña.AutoSize = true;
            this.LContraseña.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LContraseña.ForeColor = System.Drawing.SystemColors.Control;
            this.LContraseña.Location = new System.Drawing.Point(68, 226);
            this.LContraseña.Name = "LContraseña";
            this.LContraseña.Size = new System.Drawing.Size(67, 13);
            this.LContraseña.TabIndex = 4;
            this.LContraseña.Text = "Contraseña:";
            // 
            // LBienvenida
            // 
            this.LBienvenida.AutoSize = true;
            this.LBienvenida.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBienvenida.ForeColor = System.Drawing.SystemColors.Control;
            this.LBienvenida.Location = new System.Drawing.Point(77, 109);
            this.LBienvenida.Name = "LBienvenida";
            this.LBienvenida.Size = new System.Drawing.Size(147, 16);
            this.LBienvenida.TabIndex = 7;
            this.LBienvenida.Text = "Te damos la bienvenida!";
            // 
            // BIniciar
            // 
            this.BIniciar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BIniciar.FlatAppearance.BorderSize = 0;
            this.BIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIniciar.Location = new System.Drawing.Point(99, 285);
            this.BIniciar.Margin = new System.Windows.Forms.Padding(0);
            this.BIniciar.Name = "BIniciar";
            this.BIniciar.Size = new System.Drawing.Size(100, 32);
            this.BIniciar.TabIndex = 8;
            this.BIniciar.Text = "Iniciar";
            this.BIniciar.UseVisualStyleBackColor = false;
            this.BIniciar.Click += new System.EventHandler(this.BIniciar_Click);
            // 
            // PBLogo
            // 
            this.PBLogo.Image = ((System.Drawing.Image)(resources.GetObject("PBLogo.Image")));
            this.PBLogo.Location = new System.Drawing.Point(99, 54);
            this.PBLogo.Name = "PBLogo";
            this.PBLogo.Size = new System.Drawing.Size(110, 50);
            this.PBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBLogo.TabIndex = 5;
            this.PBLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Location = new System.Drawing.Point(131, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(300, 360);
            this.Controls.Add(this.BIniciar);
            this.Controls.Add(this.LBienvenida);
            this.Controls.Add(this.PBLogo);
            this.Controls.Add(this.LContraseña);
            this.Controls.Add(this.LUsuario);
            this.Controls.Add(this.TBUsername);
            this.Controls.Add(this.TBContraseña);
            this.Controls.Add(this.PHeaderInicio);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inicio";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Iniciar Sesion";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.PHeaderInicio.ResumeLayout(false);
            this.PHeaderInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PHeaderInicio;
        private System.Windows.Forms.PictureBox PBUsers;
        private System.Windows.Forms.Label LIniciarSesion;
        private System.Windows.Forms.PictureBox BCerrar;
        private System.Windows.Forms.PictureBox BMinimizar;
        private System.Windows.Forms.TextBox TBContraseña;
        private System.Windows.Forms.TextBox TBUsername;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Label LBienvenida;
        private System.Windows.Forms.Button BIniciar;
        private System.Windows.Forms.PictureBox PBLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}