namespace WindowsFormsApp1.CapaPresentacion
{
    partial class AperturaCaja
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNVolver = new System.Windows.Forms.Button();
            this.BTNAbrirCaja = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LTitulo = new System.Windows.Forms.Label();
            this.FechaApertura = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.Label();
            this.LUsuario = new System.Windows.Forms.Label();
            this.TBSaldoInicial = new System.Windows.Forms.TextBox();
            this.LSaldoInicial = new System.Windows.Forms.Label();
            this.LFechaApertura = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.BTNVolver);
            this.panel1.Controls.Add(this.BTNAbrirCaja);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.FechaApertura);
            this.panel1.Controls.Add(this.Usuario);
            this.panel1.Controls.Add(this.LUsuario);
            this.panel1.Controls.Add(this.TBSaldoInicial);
            this.panel1.Controls.Add(this.LSaldoInicial);
            this.panel1.Controls.Add(this.LFechaApertura);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 301);
            this.panel1.TabIndex = 0;
            // 
            // BTNVolver
            // 
            this.BTNVolver.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNVolver.FlatAppearance.BorderSize = 0;
            this.BTNVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNVolver.Location = new System.Drawing.Point(60, 249);
            this.BTNVolver.Name = "BTNVolver";
            this.BTNVolver.Size = new System.Drawing.Size(75, 23);
            this.BTNVolver.TabIndex = 10;
            this.BTNVolver.Text = "<< Volver";
            this.BTNVolver.UseVisualStyleBackColor = false;
            this.BTNVolver.Click += new System.EventHandler(this.BTNVolver_Click);
            // 
            // BTNAbrirCaja
            // 
            this.BTNAbrirCaja.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNAbrirCaja.FlatAppearance.BorderSize = 0;
            this.BTNAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNAbrirCaja.Location = new System.Drawing.Point(195, 249);
            this.BTNAbrirCaja.Name = "BTNAbrirCaja";
            this.BTNAbrirCaja.Size = new System.Drawing.Size(75, 23);
            this.BTNAbrirCaja.TabIndex = 9;
            this.BTNAbrirCaja.Text = "Abrir Caja";
            this.BTNAbrirCaja.UseVisualStyleBackColor = false;
            this.BTNAbrirCaja.Click += new System.EventHandler(this.BTNAbrirCaja_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.LTitulo);
            this.panel2.ForeColor = System.Drawing.SystemColors.Control;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 33);
            this.panel2.TabIndex = 0;
            // 
            // LTitulo
            // 
            this.LTitulo.AutoSize = true;
            this.LTitulo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LTitulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LTitulo.Location = new System.Drawing.Point(3, 7);
            this.LTitulo.Name = "LTitulo";
            this.LTitulo.Size = new System.Drawing.Size(119, 18);
            this.LTitulo.TabIndex = 1;
            this.LTitulo.Text = "Apertura de Caja";
            // 
            // FechaApertura
            // 
            this.FechaApertura.AutoSize = true;
            this.FechaApertura.ForeColor = System.Drawing.SystemColors.Control;
            this.FechaApertura.Location = new System.Drawing.Point(109, 129);
            this.FechaApertura.Name = "FechaApertura";
            this.FechaApertura.Size = new System.Drawing.Size(110, 13);
            this.FechaApertura.TabIndex = 8;
            this.FechaApertura.Text = "10/11/1999 15:09:22";
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.ForeColor = System.Drawing.SystemColors.Control;
            this.Usuario.Location = new System.Drawing.Point(109, 71);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(105, 13);
            this.Usuario.TabIndex = 7;
            this.Usuario.Text = "Aguado, Axel Tomas";
            // 
            // LUsuario
            // 
            this.LUsuario.AutoSize = true;
            this.LUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.LUsuario.Location = new System.Drawing.Point(109, 49);
            this.LUsuario.Name = "LUsuario";
            this.LUsuario.Size = new System.Drawing.Size(46, 13);
            this.LUsuario.TabIndex = 6;
            this.LUsuario.Text = "Usuario:";
            // 
            // TBSaldoInicial
            // 
            this.TBSaldoInicial.Location = new System.Drawing.Point(112, 188);
            this.TBSaldoInicial.Name = "TBSaldoInicial";
            this.TBSaldoInicial.Size = new System.Drawing.Size(100, 20);
            this.TBSaldoInicial.TabIndex = 5;
            this.TBSaldoInicial.TextChanged += new System.EventHandler(this.TB_TextChanged);
            this.TBSaldoInicial.Validating += new System.ComponentModel.CancelEventHandler(this.TBSaldoInicial_Validating);
            // 
            // LSaldoInicial
            // 
            this.LSaldoInicial.AutoSize = true;
            this.LSaldoInicial.ForeColor = System.Drawing.SystemColors.Control;
            this.LSaldoInicial.Location = new System.Drawing.Point(109, 163);
            this.LSaldoInicial.Name = "LSaldoInicial";
            this.LSaldoInicial.Size = new System.Drawing.Size(82, 13);
            this.LSaldoInicial.TabIndex = 3;
            this.LSaldoInicial.Text = "Saldo Inicial ($):";
            // 
            // LFechaApertura
            // 
            this.LFechaApertura.AutoSize = true;
            this.LFechaApertura.ForeColor = System.Drawing.SystemColors.Control;
            this.LFechaApertura.Location = new System.Drawing.Point(109, 107);
            this.LFechaApertura.Name = "LFechaApertura";
            this.LFechaApertura.Size = new System.Drawing.Size(83, 13);
            this.LFechaApertura.TabIndex = 1;
            this.LFechaApertura.Text = "Fecha Apertura:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(354, 327);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AperturaCaja";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LSaldoInicial;
        private System.Windows.Forms.Label LFechaApertura;
        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.TextBox TBSaldoInicial;
        private System.Windows.Forms.Button BTNAbrirCaja;
        private System.Windows.Forms.Label FechaApertura;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Button BTNVolver;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}