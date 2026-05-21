namespace WindowsFormsApp1.CapaPresentacion
{
    partial class Calculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNLimpiar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.BTNPVCalcular = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBPVPrecio = new System.Windows.Forms.TextBox();
            this.TBMargen = new System.Windows.Forms.TextBox();
            this.LCPrecio = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LResultadoMargen = new System.Windows.Forms.Label();
            this.BTNMCalcular = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBPrecioVenta = new System.Windows.Forms.TextBox();
            this.TBPCMargen = new System.Windows.Forms.TextBox();
            this.LCMargen = new System.Windows.Forms.Label();
            this.PTitulo = new System.Windows.Forms.Panel();
            this.PBCerrarPrincipal = new System.Windows.Forms.PictureBox();
            this.LCalculadora = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBCerrarPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.BTNLimpiar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PTitulo);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 353);
            this.panel1.TabIndex = 0;
            // 
            // BTNLimpiar
            // 
            this.BTNLimpiar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNLimpiar.FlatAppearance.BorderSize = 0;
            this.BTNLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNLimpiar.Location = new System.Drawing.Point(146, 312);
            this.BTNLimpiar.Name = "BTNLimpiar";
            this.BTNLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BTNLimpiar.TabIndex = 3;
            this.BTNLimpiar.Text = "Limpiar";
            this.BTNLimpiar.UseVisualStyleBackColor = false;
            this.BTNLimpiar.Click += new System.EventHandler(this.BTNLimpiar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.BTNPVCalcular);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TBPVPrecio);
            this.panel3.Controls.Add(this.TBMargen);
            this.panel3.Controls.Add(this.LCPrecio);
            this.panel3.Location = new System.Drawing.Point(188, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 267);
            this.panel3.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Precio de Venta = ";
            // 
            // BTNPVCalcular
            // 
            this.BTNPVCalcular.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNPVCalcular.FlatAppearance.BorderSize = 0;
            this.BTNPVCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNPVCalcular.Location = new System.Drawing.Point(55, 156);
            this.BTNPVCalcular.Name = "BTNPVCalcular";
            this.BTNPVCalcular.Size = new System.Drawing.Size(75, 23);
            this.BTNPVCalcular.TabIndex = 6;
            this.BTNPVCalcular.Text = "Calcular";
            this.BTNPVCalcular.UseVisualStyleBackColor = false;
            this.BTNPVCalcular.Click += new System.EventHandler(this.BTNPVCalcular_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Margen sobre Precio Venta (%):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio Costo:";
            // 
            // TBPVPrecio
            // 
            this.TBPVPrecio.Location = new System.Drawing.Point(41, 52);
            this.TBPVPrecio.Name = "TBPVPrecio";
            this.TBPVPrecio.Size = new System.Drawing.Size(100, 20);
            this.TBPVPrecio.TabIndex = 3;
            this.TBPVPrecio.TextChanged += new System.EventHandler(this.TB_TextChanged);
            // 
            // TBMargen
            // 
            this.TBMargen.Location = new System.Drawing.Point(41, 108);
            this.TBMargen.Name = "TBMargen";
            this.TBMargen.Size = new System.Drawing.Size(100, 20);
            this.TBMargen.TabIndex = 2;
            this.TBMargen.TextChanged += new System.EventHandler(this.TB_TextChanged);
            // 
            // LCPrecio
            // 
            this.LCPrecio.AutoSize = true;
            this.LCPrecio.Location = new System.Drawing.Point(3, 4);
            this.LCPrecio.Name = "LCPrecio";
            this.LCPrecio.Size = new System.Drawing.Size(127, 13);
            this.LCPrecio.TabIndex = 0;
            this.LCPrecio.Text = "Calcular Precio de Venta:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.LResultadoMargen);
            this.panel2.Controls.Add(this.BTNMCalcular);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TBPrecioVenta);
            this.panel2.Controls.Add(this.TBPCMargen);
            this.panel2.Controls.Add(this.LCMargen);
            this.panel2.Location = new System.Drawing.Point(3, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(181, 267);
            this.panel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "precio de venta";
            // 
            // LResultadoMargen
            // 
            this.LResultadoMargen.AutoSize = true;
            this.LResultadoMargen.Location = new System.Drawing.Point(6, 216);
            this.LResultadoMargen.Name = "LResultadoMargen";
            this.LResultadoMargen.Size = new System.Drawing.Size(75, 13);
            this.LResultadoMargen.TabIndex = 8;
            this.LResultadoMargen.Text = "Margen sobre ";
            // 
            // BTNMCalcular
            // 
            this.BTNMCalcular.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNMCalcular.FlatAppearance.BorderSize = 0;
            this.BTNMCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNMCalcular.Location = new System.Drawing.Point(51, 156);
            this.BTNMCalcular.Name = "BTNMCalcular";
            this.BTNMCalcular.Size = new System.Drawing.Size(75, 23);
            this.BTNMCalcular.TabIndex = 7;
            this.BTNMCalcular.Text = "Calcular";
            this.BTNMCalcular.UseVisualStyleBackColor = false;
            this.BTNMCalcular.Click += new System.EventHandler(this.BTNMCalcular_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Precio Venta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Precio Costo:";
            // 
            // TBPrecioVenta
            // 
            this.TBPrecioVenta.Location = new System.Drawing.Point(39, 108);
            this.TBPrecioVenta.Name = "TBPrecioVenta";
            this.TBPrecioVenta.Size = new System.Drawing.Size(100, 20);
            this.TBPrecioVenta.TabIndex = 2;
            this.TBPrecioVenta.TextChanged += new System.EventHandler(this.TB_TextChanged);
            // 
            // TBPCMargen
            // 
            this.TBPCMargen.Location = new System.Drawing.Point(39, 52);
            this.TBPCMargen.Name = "TBPCMargen";
            this.TBPCMargen.Size = new System.Drawing.Size(100, 20);
            this.TBPCMargen.TabIndex = 1;
            this.TBPCMargen.TextChanged += new System.EventHandler(this.TB_TextChanged);
            // 
            // LCMargen
            // 
            this.LCMargen.AutoSize = true;
            this.LCMargen.Location = new System.Drawing.Point(3, 4);
            this.LCMargen.Name = "LCMargen";
            this.LCMargen.Size = new System.Drawing.Size(87, 13);
            this.LCMargen.TabIndex = 0;
            this.LCMargen.Text = "Calcular Margen:";
            // 
            // PTitulo
            // 
            this.PTitulo.BackColor = System.Drawing.Color.DarkTurquoise;
            this.PTitulo.Controls.Add(this.PBCerrarPrincipal);
            this.PTitulo.Controls.Add(this.LCalculadora);
            this.PTitulo.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.PTitulo.Location = new System.Drawing.Point(0, 0);
            this.PTitulo.Name = "PTitulo";
            this.PTitulo.Size = new System.Drawing.Size(372, 33);
            this.PTitulo.TabIndex = 0;
            this.PTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PHeaderPrincipal_MouseDown);
            // 
            // PBCerrarPrincipal
            // 
            this.PBCerrarPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBCerrarPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBCerrarPrincipal.Image = ((System.Drawing.Image)(resources.GetObject("PBCerrarPrincipal.Image")));
            this.PBCerrarPrincipal.Location = new System.Drawing.Point(349, 3);
            this.PBCerrarPrincipal.Name = "PBCerrarPrincipal";
            this.PBCerrarPrincipal.Size = new System.Drawing.Size(20, 24);
            this.PBCerrarPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBCerrarPrincipal.TabIndex = 2;
            this.PBCerrarPrincipal.TabStop = false;
            this.PBCerrarPrincipal.Click += new System.EventHandler(this.PBCerrarPrincipal_Click);
            // 
            // LCalculadora
            // 
            this.LCalculadora.AutoSize = true;
            this.LCalculadora.Location = new System.Drawing.Point(3, 6);
            this.LCalculadora.Name = "LCalculadora";
            this.LCalculadora.Size = new System.Drawing.Size(81, 18);
            this.LCalculadora.TabIndex = 0;
            this.LCalculadora.Text = "Calculadora";
            // 
            // Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(374, 359);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Calculadora";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Calculadora";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PTitulo.ResumeLayout(false);
            this.PTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBCerrarPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LCMargen;
        private System.Windows.Forms.Panel PTitulo;
        private System.Windows.Forms.Label LCalculadora;
        private System.Windows.Forms.Label LCPrecio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBPVPrecio;
        private System.Windows.Forms.TextBox TBMargen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBPrecioVenta;
        private System.Windows.Forms.TextBox TBPCMargen;
        private System.Windows.Forms.PictureBox PBCerrarPrincipal;
        private System.Windows.Forms.Button BTNPVCalcular;
        private System.Windows.Forms.Button BTNMCalcular;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LResultadoMargen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BTNLimpiar;
    }
}