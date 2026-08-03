namespace WindowsFormsApp1.CapaPresentacion
{
    partial class ConsultarPrecio
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
            this.LVPrecio = new System.Windows.Forms.Label();
            this.LVStock = new System.Windows.Forms.Label();
            this.LVProducto = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LStock = new System.Windows.Forms.Label();
            this.LProducto = new System.Windows.Forms.Label();
            this.BTNBuscar = new System.Windows.Forms.Button();
            this.TBCodigoProducto = new System.Windows.Forms.TextBox();
            this.BTNVolver = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.LVPrecio);
            this.panel1.Controls.Add(this.LVStock);
            this.panel1.Controls.Add(this.LVProducto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LStock);
            this.panel1.Controls.Add(this.LProducto);
            this.panel1.Controls.Add(this.BTNBuscar);
            this.panel1.Controls.Add(this.TBCodigoProducto);
            this.panel1.Controls.Add(this.BTNVolver);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 244);
            this.panel1.TabIndex = 0;
            // 
            // LVPrecio
            // 
            this.LVPrecio.AutoSize = true;
            this.LVPrecio.ForeColor = System.Drawing.SystemColors.Control;
            this.LVPrecio.Location = new System.Drawing.Point(172, 165);
            this.LVPrecio.Name = "LVPrecio";
            this.LVPrecio.Size = new System.Drawing.Size(10, 13);
            this.LVPrecio.TabIndex = 10;
            this.LVPrecio.Text = "-";
            // 
            // LVStock
            // 
            this.LVStock.AutoSize = true;
            this.LVStock.ForeColor = System.Drawing.SystemColors.Control;
            this.LVStock.Location = new System.Drawing.Point(172, 135);
            this.LVStock.Name = "LVStock";
            this.LVStock.Size = new System.Drawing.Size(10, 13);
            this.LVStock.TabIndex = 9;
            this.LVStock.Text = "-";
            // 
            // LVProducto
            // 
            this.LVProducto.AutoSize = true;
            this.LVProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.LVProducto.Location = new System.Drawing.Point(172, 105);
            this.LVProducto.Name = "LVProducto";
            this.LVProducto.Size = new System.Drawing.Size(10, 13);
            this.LVProducto.TabIndex = 8;
            this.LVProducto.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(67, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Precio:";
            // 
            // LStock
            // 
            this.LStock.AutoSize = true;
            this.LStock.ForeColor = System.Drawing.SystemColors.Control;
            this.LStock.Location = new System.Drawing.Point(67, 135);
            this.LStock.Name = "LStock";
            this.LStock.Size = new System.Drawing.Size(38, 13);
            this.LStock.TabIndex = 6;
            this.LStock.Text = "Stock:";
            // 
            // LProducto
            // 
            this.LProducto.AutoSize = true;
            this.LProducto.ForeColor = System.Drawing.SystemColors.Control;
            this.LProducto.Location = new System.Drawing.Point(67, 105);
            this.LProducto.Name = "LProducto";
            this.LProducto.Size = new System.Drawing.Size(53, 13);
            this.LProducto.TabIndex = 5;
            this.LProducto.Text = "Producto:";
            // 
            // BTNBuscar
            // 
            this.BTNBuscar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNBuscar.FlatAppearance.BorderSize = 0;
            this.BTNBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNBuscar.Location = new System.Drawing.Point(235, 63);
            this.BTNBuscar.Name = "BTNBuscar";
            this.BTNBuscar.Size = new System.Drawing.Size(70, 23);
            this.BTNBuscar.TabIndex = 4;
            this.BTNBuscar.Text = "Buscar";
            this.BTNBuscar.UseVisualStyleBackColor = false;
            this.BTNBuscar.Click += new System.EventHandler(this.BTNBuscar_Click);
            // 
            // TBCodigoProducto
            // 
            this.TBCodigoProducto.ForeColor = System.Drawing.Color.Gray;
            this.TBCodigoProducto.Location = new System.Drawing.Point(70, 65);
            this.TBCodigoProducto.Name = "TBCodigoProducto";
            this.TBCodigoProducto.Size = new System.Drawing.Size(160, 20);
            this.TBCodigoProducto.TabIndex = 3;
            this.TBCodigoProducto.Text = "Ingrese el codigo del producto ...";
            this.TBCodigoProducto.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TBCodigoProducto_MouseClick);
            this.TBCodigoProducto.Validating += new System.ComponentModel.CancelEventHandler(this.TBCodigoProducto_Validating);
            // 
            // BTNVolver
            // 
            this.BTNVolver.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNVolver.FlatAppearance.BorderSize = 0;
            this.BTNVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNVolver.Location = new System.Drawing.Point(150, 200);
            this.BTNVolver.Name = "BTNVolver";
            this.BTNVolver.Size = new System.Drawing.Size(75, 23);
            this.BTNVolver.TabIndex = 1;
            this.BTNVolver.Text = "Volver";
            this.BTNVolver.UseVisualStyleBackColor = false;
            this.BTNVolver.Click += new System.EventHandler(this.BTNVolver_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 36);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Consultar Producto";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ConsultarPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(398, 268);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultarPrecio";
            this.Text = "ConsultarPrecio";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNVolver;
        private System.Windows.Forms.Button BTNBuscar;
        private System.Windows.Forms.TextBox TBCodigoProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LStock;
        private System.Windows.Forms.Label LProducto;
        private System.Windows.Forms.Label LVPrecio;
        private System.Windows.Forms.Label LVStock;
        private System.Windows.Forms.Label LVProducto;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}