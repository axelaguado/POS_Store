namespace WindowsFormsApp1.CapaPresentacion
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.PHeaderPrincipal = new System.Windows.Forms.Panel();
            this.BBienvenida = new System.Windows.Forms.Button();
            this.PBMaximizar = new System.Windows.Forms.PictureBox();
            this.PBMinimizar = new System.Windows.Forms.PictureBox();
            this.PBRestaurar = new System.Windows.Forms.PictureBox();
            this.PBCerrarPrincipal = new System.Windows.Forms.PictureBox();
            this.PMenu = new System.Windows.Forms.Panel();
            this.BTGastos = new System.Windows.Forms.Button();
            this.BTGestionPedidos = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCerrarPrincipal = new System.Windows.Forms.Button();
            this.BBackUp = new System.Windows.Forms.Button();
            this.BReportes = new System.Windows.Forms.Button();
            this.BVentas = new System.Windows.Forms.Button();
            this.BGestionProductos = new System.Windows.Forms.Button();
            this.BGestionClientes = new System.Windows.Forms.Button();
            this.BGestionEmpleados = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PContenidos = new System.Windows.Forms.Panel();
            this.PHeaderPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBCerrarPrincipal)).BeginInit();
            this.PMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PHeaderPrincipal
            // 
            this.PHeaderPrincipal.BackColor = System.Drawing.Color.DarkTurquoise;
            this.PHeaderPrincipal.Controls.Add(this.BBienvenida);
            this.PHeaderPrincipal.Controls.Add(this.PBMaximizar);
            this.PHeaderPrincipal.Controls.Add(this.PBMinimizar);
            this.PHeaderPrincipal.Controls.Add(this.PBRestaurar);
            this.PHeaderPrincipal.Controls.Add(this.PBCerrarPrincipal);
            this.PHeaderPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.PHeaderPrincipal.Location = new System.Drawing.Point(0, 0);
            this.PHeaderPrincipal.Name = "PHeaderPrincipal";
            this.PHeaderPrincipal.Size = new System.Drawing.Size(900, 32);
            this.PHeaderPrincipal.TabIndex = 0;
            this.PHeaderPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PHeaderPrincipal_MouseDown);
            // 
            // BBienvenida
            // 
            this.BBienvenida.AutoSize = true;
            this.BBienvenida.FlatAppearance.BorderSize = 0;
            this.BBienvenida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBienvenida.Location = new System.Drawing.Point(3, 4);
            this.BBienvenida.Name = "BBienvenida";
            this.BBienvenida.Size = new System.Drawing.Size(83, 23);
            this.BBienvenida.TabIndex = 5;
            this.BBienvenida.Text = "button1";
            this.BBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BBienvenida.UseVisualStyleBackColor = true;
            // 
            // PBMaximizar
            // 
            this.PBMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("PBMaximizar.Image")));
            this.PBMaximizar.Location = new System.Drawing.Point(851, 4);
            this.PBMaximizar.Name = "PBMaximizar";
            this.PBMaximizar.Size = new System.Drawing.Size(20, 24);
            this.PBMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBMaximizar.TabIndex = 4;
            this.PBMaximizar.TabStop = false;
            this.PBMaximizar.Click += new System.EventHandler(this.PBMaximizar_Click);
            // 
            // PBMinimizar
            // 
            this.PBMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("PBMinimizar.Image")));
            this.PBMinimizar.Location = new System.Drawing.Point(832, 12);
            this.PBMinimizar.Name = "PBMinimizar";
            this.PBMinimizar.Size = new System.Drawing.Size(13, 24);
            this.PBMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBMinimizar.TabIndex = 4;
            this.PBMinimizar.TabStop = false;
            this.PBMinimizar.Click += new System.EventHandler(this.BMinimizar_Click);
            // 
            // PBRestaurar
            // 
            this.PBRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("PBRestaurar.Image")));
            this.PBRestaurar.Location = new System.Drawing.Point(851, 4);
            this.PBRestaurar.Name = "PBRestaurar";
            this.PBRestaurar.Size = new System.Drawing.Size(20, 24);
            this.PBRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBRestaurar.TabIndex = 2;
            this.PBRestaurar.TabStop = false;
            this.PBRestaurar.Visible = false;
            this.PBRestaurar.Click += new System.EventHandler(this.PBRestaurar_Click);
            // 
            // PBCerrarPrincipal
            // 
            this.PBCerrarPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PBCerrarPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PBCerrarPrincipal.Image = ((System.Drawing.Image)(resources.GetObject("PBCerrarPrincipal.Image")));
            this.PBCerrarPrincipal.Location = new System.Drawing.Point(877, 3);
            this.PBCerrarPrincipal.Name = "PBCerrarPrincipal";
            this.PBCerrarPrincipal.Size = new System.Drawing.Size(20, 24);
            this.PBCerrarPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBCerrarPrincipal.TabIndex = 1;
            this.PBCerrarPrincipal.TabStop = false;
            this.PBCerrarPrincipal.Click += new System.EventHandler(this.PBCerrarPrincipal_Click);
            // 
            // PMenu
            // 
            this.PMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.PMenu.Controls.Add(this.BTGastos);
            this.PMenu.Controls.Add(this.BTGestionPedidos);
            this.PMenu.Controls.Add(this.panel9);
            this.PMenu.Controls.Add(this.panel2);
            this.PMenu.Controls.Add(this.panel3);
            this.PMenu.Controls.Add(this.panel4);
            this.PMenu.Controls.Add(this.panel5);
            this.PMenu.Controls.Add(this.panel6);
            this.PMenu.Controls.Add(this.panel7);
            this.PMenu.Controls.Add(this.panel8);
            this.PMenu.Controls.Add(this.panel1);
            this.PMenu.Controls.Add(this.BCerrarPrincipal);
            this.PMenu.Controls.Add(this.BBackUp);
            this.PMenu.Controls.Add(this.BReportes);
            this.PMenu.Controls.Add(this.BVentas);
            this.PMenu.Controls.Add(this.BGestionProductos);
            this.PMenu.Controls.Add(this.BGestionClientes);
            this.PMenu.Controls.Add(this.BGestionEmpleados);
            this.PMenu.Controls.Add(this.pictureBox1);
            this.PMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PMenu.Location = new System.Drawing.Point(0, 32);
            this.PMenu.Margin = new System.Windows.Forms.Padding(5);
            this.PMenu.Name = "PMenu";
            this.PMenu.Size = new System.Drawing.Size(208, 536);
            this.PMenu.TabIndex = 1;
            // 
            // BTGastos
            // 
            this.BTGastos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTGastos.FlatAppearance.BorderSize = 0;
            this.BTGastos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BTGastos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGastos.ForeColor = System.Drawing.SystemColors.Control;
            this.BTGastos.Location = new System.Drawing.Point(12, 283);
            this.BTGastos.Name = "BTGastos";
            this.BTGastos.Size = new System.Drawing.Size(196, 32);
            this.BTGastos.TabIndex = 12;
            this.BTGastos.Text = "Gastos";
            this.BTGastos.UseVisualStyleBackColor = true;
            // 
            // BTGestionPedidos
            // 
            this.BTGestionPedidos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTGestionPedidos.FlatAppearance.BorderSize = 0;
            this.BTGestionPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BTGestionPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTGestionPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTGestionPedidos.ForeColor = System.Drawing.SystemColors.Control;
            this.BTGestionPedidos.Location = new System.Drawing.Point(12, 233);
            this.BTGestionPedidos.Name = "BTGestionPedidos";
            this.BTGestionPedidos.Size = new System.Drawing.Size(196, 32);
            this.BTGestionPedidos.TabIndex = 11;
            this.BTGestionPedidos.Text = "Gestion de Pedidos ";
            this.BTGestionPedidos.UseVisualStyleBackColor = true;
            this.BTGestionPedidos.Click += new System.EventHandler(this.BTGestionPedidos_Click);
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel9.Location = new System.Drawing.Point(0, 332);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(12, 32);
            this.panel9.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Location = new System.Drawing.Point(0, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(12, 32);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel3.Location = new System.Drawing.Point(0, 492);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(12, 32);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Location = new System.Drawing.Point(0, 434);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(12, 32);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Location = new System.Drawing.Point(0, 380);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(12, 32);
            this.panel5.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel6.Location = new System.Drawing.Point(0, 233);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(12, 32);
            this.panel6.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel7.Location = new System.Drawing.Point(0, 186);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(12, 32);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel8.Location = new System.Drawing.Point(0, 140);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(12, 32);
            this.panel8.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Location = new System.Drawing.Point(0, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(12, 32);
            this.panel1.TabIndex = 0;
            // 
            // BCerrarPrincipal
            // 
            this.BCerrarPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BCerrarPrincipal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrarPrincipal.FlatAppearance.BorderSize = 0;
            this.BCerrarPrincipal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BCerrarPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCerrarPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCerrarPrincipal.ForeColor = System.Drawing.SystemColors.Control;
            this.BCerrarPrincipal.Location = new System.Drawing.Point(12, 492);
            this.BCerrarPrincipal.Name = "BCerrarPrincipal";
            this.BCerrarPrincipal.Size = new System.Drawing.Size(196, 32);
            this.BCerrarPrincipal.TabIndex = 8;
            this.BCerrarPrincipal.Text = "Cerrar";
            this.BCerrarPrincipal.UseVisualStyleBackColor = true;
            // 
            // BBackUp
            // 
            this.BBackUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BBackUp.FlatAppearance.BorderSize = 0;
            this.BBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBackUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBackUp.ForeColor = System.Drawing.SystemColors.Control;
            this.BBackUp.Location = new System.Drawing.Point(12, 434);
            this.BBackUp.Name = "BBackUp";
            this.BBackUp.Size = new System.Drawing.Size(196, 32);
            this.BBackUp.TabIndex = 7;
            this.BBackUp.Text = "Back Up";
            this.BBackUp.UseVisualStyleBackColor = true;
            // 
            // BReportes
            // 
            this.BReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BReportes.FlatAppearance.BorderSize = 0;
            this.BReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BReportes.ForeColor = System.Drawing.SystemColors.Control;
            this.BReportes.Location = new System.Drawing.Point(12, 380);
            this.BReportes.Name = "BReportes";
            this.BReportes.Size = new System.Drawing.Size(196, 32);
            this.BReportes.TabIndex = 6;
            this.BReportes.Text = "Reportes";
            this.BReportes.UseVisualStyleBackColor = true;
            // 
            // BVentas
            // 
            this.BVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BVentas.FlatAppearance.BorderSize = 0;
            this.BVentas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BVentas.ForeColor = System.Drawing.SystemColors.Control;
            this.BVentas.Location = new System.Drawing.Point(12, 332);
            this.BVentas.Name = "BVentas";
            this.BVentas.Size = new System.Drawing.Size(196, 32);
            this.BVentas.TabIndex = 5;
            this.BVentas.Text = "Ventas";
            this.BVentas.UseVisualStyleBackColor = true;
            // 
            // BGestionProductos
            // 
            this.BGestionProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGestionProductos.FlatAppearance.BorderSize = 0;
            this.BGestionProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BGestionProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGestionProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGestionProductos.ForeColor = System.Drawing.SystemColors.Control;
            this.BGestionProductos.Location = new System.Drawing.Point(12, 186);
            this.BGestionProductos.Name = "BGestionProductos";
            this.BGestionProductos.Size = new System.Drawing.Size(196, 32);
            this.BGestionProductos.TabIndex = 4;
            this.BGestionProductos.Text = "Gestion de Productos";
            this.BGestionProductos.UseVisualStyleBackColor = true;
            // 
            // BGestionClientes
            // 
            this.BGestionClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGestionClientes.FlatAppearance.BorderSize = 0;
            this.BGestionClientes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BGestionClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGestionClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGestionClientes.ForeColor = System.Drawing.SystemColors.Control;
            this.BGestionClientes.Location = new System.Drawing.Point(12, 140);
            this.BGestionClientes.Name = "BGestionClientes";
            this.BGestionClientes.Size = new System.Drawing.Size(196, 32);
            this.BGestionClientes.TabIndex = 3;
            this.BGestionClientes.Text = "Gestion de Clientes";
            this.BGestionClientes.UseVisualStyleBackColor = true;
            // 
            // BGestionEmpleados
            // 
            this.BGestionEmpleados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGestionEmpleados.FlatAppearance.BorderSize = 0;
            this.BGestionEmpleados.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise;
            this.BGestionEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGestionEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGestionEmpleados.ForeColor = System.Drawing.SystemColors.Control;
            this.BGestionEmpleados.Location = new System.Drawing.Point(12, 92);
            this.BGestionEmpleados.Name = "BGestionEmpleados";
            this.BGestionEmpleados.Size = new System.Drawing.Size(196, 32);
            this.BGestionEmpleados.TabIndex = 2;
            this.BGestionEmpleados.Text = "Gestion de Empleados";
            this.BGestionEmpleados.UseVisualStyleBackColor = true;
            this.BGestionEmpleados.Click += new System.EventHandler(this.BGestionEmpleados_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // PContenidos
            // 
            this.PContenidos.BackColor = System.Drawing.Color.White;
            this.PContenidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PContenidos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PContenidos.Location = new System.Drawing.Point(208, 32);
            this.PContenidos.Name = "PContenidos";
            this.PContenidos.Size = new System.Drawing.Size(692, 536);
            this.PContenidos.TabIndex = 0;
             
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(900, 568);
            this.Controls.Add(this.PContenidos);
            this.Controls.Add(this.PMenu);
            this.Controls.Add(this.PHeaderPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Principal";
            this.PHeaderPrincipal.ResumeLayout(false);
            this.PHeaderPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBCerrarPrincipal)).EndInit();
            this.PMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PHeaderPrincipal;
        private System.Windows.Forms.Panel PMenu;
        private System.Windows.Forms.Panel PContenidos;
        private System.Windows.Forms.PictureBox PBMaximizar;
        private System.Windows.Forms.PictureBox PBRestaurar;
        private System.Windows.Forms.PictureBox PBCerrarPrincipal;
        private System.Windows.Forms.PictureBox PBMinimizar;
        private System.Windows.Forms.Button BCerrarPrincipal;
        private System.Windows.Forms.Button BBackUp;
        private System.Windows.Forms.Button BReportes;
        private System.Windows.Forms.Button BVentas;
        private System.Windows.Forms.Button BGestionProductos;
        private System.Windows.Forms.Button BGestionClientes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button BGestionEmpleados;
        private System.Windows.Forms.Button BBienvenida;
        private System.Windows.Forms.Button BTGastos;
        private System.Windows.Forms.Button BTGestionPedidos;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel2;
    }
}