namespace WindowsFormsApp1.CapaPresentacion
{
    partial class Detalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Detalle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BCerrar = new System.Windows.Forms.PictureBox();
            this.LNroPedido = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LEstado = new System.Windows.Forms.Label();
            this.LFechaPedido = new System.Windows.Forms.Label();
            this.LCodPostal = new System.Windows.Forms.Label();
            this.LDireccion = new System.Windows.Forms.Label();
            this.LTelefono = new System.Windows.Forms.Label();
            this.LCuit = new System.Windows.Forms.Label();
            this.LNomComer = new System.Windows.Forms.Label();
            this.LRazonSocial = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LTotalPedido = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CContenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BTNDescargar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCerrar)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BCerrar);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 32);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.header_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Detalle Pedido";
            // 
            // BCerrar
            // 
            this.BCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BCerrar.Image")));
            this.BCerrar.Location = new System.Drawing.Point(443, 4);
            this.BCerrar.Name = "BCerrar";
            this.BCerrar.Size = new System.Drawing.Size(27, 23);
            this.BCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BCerrar.TabIndex = 5;
            this.BCerrar.TabStop = false;
            this.BCerrar.Click += new System.EventHandler(this.BCerrar_Click);
            // 
            // LNroPedido
            // 
            this.LNroPedido.AutoSize = true;
            this.LNroPedido.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNroPedido.Location = new System.Drawing.Point(3, 9);
            this.LNroPedido.Name = "LNroPedido";
            this.LNroPedido.Size = new System.Drawing.Size(80, 17);
            this.LNroPedido.TabIndex = 6;
            this.LNroPedido.Text = "#00000001";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.LNroPedido);
            this.panel2.Controls.Add(this.LEstado);
            this.panel2.Controls.Add(this.LFechaPedido);
            this.panel2.Controls.Add(this.LCodPostal);
            this.panel2.Controls.Add(this.LDireccion);
            this.panel2.Controls.Add(this.LTelefono);
            this.panel2.Controls.Add(this.LCuit);
            this.panel2.Controls.Add(this.LNomComer);
            this.panel2.Controls.Add(this.LRazonSocial);
            this.panel2.Location = new System.Drawing.Point(6, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 138);
            this.panel2.TabIndex = 1;
            // 
            // LEstado
            // 
            this.LEstado.AutoSize = true;
            this.LEstado.Location = new System.Drawing.Point(3, 26);
            this.LEstado.Name = "LEstado";
            this.LEstado.Size = new System.Drawing.Size(40, 13);
            this.LEstado.TabIndex = 7;
            this.LEstado.Text = "Estado";
            // 
            // LFechaPedido
            // 
            this.LFechaPedido.AutoSize = true;
            this.LFechaPedido.Location = new System.Drawing.Point(3, 116);
            this.LFechaPedido.Name = "LFechaPedido";
            this.LFechaPedido.Size = new System.Drawing.Size(74, 13);
            this.LFechaPedido.TabIndex = 6;
            this.LFechaPedido.Text = "Fecha Emsion";
            // 
            // LCodPostal
            // 
            this.LCodPostal.AutoSize = true;
            this.LCodPostal.Location = new System.Drawing.Point(191, 78);
            this.LCodPostal.Name = "LCodPostal";
            this.LCodPostal.Size = new System.Drawing.Size(72, 13);
            this.LCodPostal.TabIndex = 5;
            this.LCodPostal.Text = "Codigo Postal";
            // 
            // LDireccion
            // 
            this.LDireccion.AutoSize = true;
            this.LDireccion.Location = new System.Drawing.Point(191, 65);
            this.LDireccion.Name = "LDireccion";
            this.LDireccion.Size = new System.Drawing.Size(52, 13);
            this.LDireccion.TabIndex = 4;
            this.LDireccion.Text = "Direccion";
            // 
            // LTelefono
            // 
            this.LTelefono.AutoSize = true;
            this.LTelefono.Location = new System.Drawing.Point(191, 91);
            this.LTelefono.Name = "LTelefono";
            this.LTelefono.Size = new System.Drawing.Size(49, 13);
            this.LTelefono.TabIndex = 3;
            this.LTelefono.Text = "Telefono";
            // 
            // LCuit
            // 
            this.LCuit.AutoSize = true;
            this.LCuit.Location = new System.Drawing.Point(191, 52);
            this.LCuit.Name = "LCuit";
            this.LCuit.Size = new System.Drawing.Size(25, 13);
            this.LCuit.TabIndex = 2;
            this.LCuit.Text = "Cuit";
            // 
            // LNomComer
            // 
            this.LNomComer.AutoSize = true;
            this.LNomComer.Location = new System.Drawing.Point(191, 39);
            this.LNomComer.Name = "LNomComer";
            this.LNomComer.Size = new System.Drawing.Size(93, 13);
            this.LNomComer.TabIndex = 1;
            this.LNomComer.Text = "Nombre Comercial";
            // 
            // LRazonSocial
            // 
            this.LRazonSocial.AutoSize = true;
            this.LRazonSocial.Location = new System.Drawing.Point(191, 26);
            this.LRazonSocial.Name = "LRazonSocial";
            this.LRazonSocial.Size = new System.Drawing.Size(67, 13);
            this.LRazonSocial.TabIndex = 0;
            this.LRazonSocial.Text = "RazonSocial";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.LTotalPedido);
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel3.Location = new System.Drawing.Point(6, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(456, 249);
            this.panel3.TabIndex = 2;
            // 
            // LTotalPedido
            // 
            this.LTotalPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LTotalPedido.AutoSize = true;
            this.LTotalPedido.Location = new System.Drawing.Point(311, 229);
            this.LTotalPedido.Name = "LTotalPedido";
            this.LTotalPedido.Size = new System.Drawing.Size(31, 13);
            this.LTotalPedido.TabIndex = 8;
            this.LTotalPedido.Text = "Total";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CMarca,
            this.CNombre,
            this.CDescripcion,
            this.CContenido,
            this.CPrecio,
            this.CCantidad});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(6, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(436, 214);
            this.dataGridView1.TabIndex = 0;
            // 
            // CMarca
            // 
            this.CMarca.HeaderText = "Marca";
            this.CMarca.Name = "CMarca";
            this.CMarca.Width = 62;
            // 
            // CNombre
            // 
            this.CNombre.HeaderText = "Articulo";
            this.CNombre.Name = "CNombre";
            this.CNombre.Width = 67;
            // 
            // CDescripcion
            // 
            this.CDescripcion.HeaderText = "Descripcion";
            this.CDescripcion.Name = "CDescripcion";
            this.CDescripcion.Width = 88;
            // 
            // CContenido
            // 
            this.CContenido.HeaderText = "Contenido";
            this.CContenido.Name = "CContenido";
            this.CContenido.Width = 80;
            // 
            // CPrecio
            // 
            this.CPrecio.HeaderText = "Precio";
            this.CPrecio.Name = "CPrecio";
            this.CPrecio.Width = 62;
            // 
            // CCantidad
            // 
            this.CCantidad.HeaderText = "Cantidad";
            this.CCantidad.Name = "CCantidad";
            this.CCantidad.Width = 74;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.BTNDescargar);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(1, 31);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(473, 442);
            this.panel4.TabIndex = 3;
            // 
            // BTNDescargar
            // 
            this.BTNDescargar.AutoSize = true;
            this.BTNDescargar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNDescargar.FlatAppearance.BorderSize = 0;
            this.BTNDescargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNDescargar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNDescargar.Location = new System.Drawing.Point(177, 407);
            this.BTNDescargar.Name = "BTNDescargar";
            this.BTNDescargar.Size = new System.Drawing.Size(92, 25);
            this.BTNDescargar.TabIndex = 3;
            this.BTNDescargar.Text = "Descargar PDF";
            this.BTNDescargar.UseVisualStyleBackColor = false;
            this.BTNDescargar.Click += new System.EventHandler(this.BGenPDF_Click);
            // 
            // Detalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(475, 475);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Detalle";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCerrar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox BCerrar;
        private System.Windows.Forms.Label LNroPedido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LDireccion;
        private System.Windows.Forms.Label LTelefono;
        private System.Windows.Forms.Label LCuit;
        private System.Windows.Forms.Label LNomComer;
        private System.Windows.Forms.Label LRazonSocial;
        private System.Windows.Forms.Label LCodPostal;
        private System.Windows.Forms.Label LEstado;
        private System.Windows.Forms.Label LFechaPedido;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CContenido;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCantidad;
        private System.Windows.Forms.Label LTotalPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button BTNDescargar;
    }
}