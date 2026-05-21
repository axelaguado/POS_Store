namespace WindowsFormsApp1.CapaPresentacion
{
    partial class FGestionPedidos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.LProductos = new System.Windows.Forms.Label();
            this.LRegistrar = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 526);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.BTNBuscar);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(310, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 519);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(7, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 465);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel4.Controls.Add(this.LProductos);
            this.panel4.Location = new System.Drawing.Point(310, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(463, 33);
            this.panel4.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel5.Controls.Add(this.LRegistrar);
            this.panel5.Location = new System.Drawing.Point(7, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(297, 33);
            this.panel5.TabIndex = 1;
            // 
            // LProductos
            // 
            this.LProductos.AutoSize = true;
            this.LProductos.BackColor = System.Drawing.Color.DarkTurquoise;
            this.LProductos.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.LProductos.Location = new System.Drawing.Point(3, 9);
            this.LProductos.Name = "LProductos";
            this.LProductos.Size = new System.Drawing.Size(72, 18);
            this.LProductos.TabIndex = 0;
            this.LProductos.Text = "Productos";
            // 
            // LRegistrar
            // 
            this.LRegistrar.AutoSize = true;
            this.LRegistrar.Font = new System.Drawing.Font("Tahoma", 11.25F);
            this.LRegistrar.Location = new System.Drawing.Point(3, 9);
            this.LRegistrar.Name = "LRegistrar";
            this.LRegistrar.Size = new System.Drawing.Size(127, 18);
            this.LRegistrar.TabIndex = 0;
            this.LRegistrar.Text = "Registrar Producto";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 20);
            this.textBox1.TabIndex = 0;
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscar.FlatAppearance.BorderSize = 0;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.Location = new System.Drawing.Point(204, 48);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(75, 23);
            this.BTNBuscar.TabIndex = 1;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(454, 419);
            this.dataGridView1.TabIndex = 2;
            // 
            // FGestionPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(750, 500);
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FGestionPedidos";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label LRegistrar;
        private System.Windows.Forms.Label LProductos;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BTNBuscar;
    }
}