namespace WindowsFormsApp1.CapaPresentacion
{
    partial class EdicionUsuario
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
            this.TBNuevaContraseña = new System.Windows.Forms.TextBox();
            this.LNuevaContraseña = new System.Windows.Forms.Label();
            this.BTNRestablecer = new System.Windows.Forms.Button();
            this.BTNActualizar = new System.Windows.Forms.Button();
            this.TBEUContraseña = new System.Windows.Forms.TextBox();
            this.TBEURepetir = new System.Windows.Forms.TextBox();
            this.PTCrearUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.PInfoContacto.SuspendLayout();
            this.PDatosCuenta.SuspendLayout();
            this.PFormularioCrearUsuario.SuspendLayout();
            this.PCrearUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // BRegistrarUsuario
            // 
            this.BRegistrarUsuario.FlatAppearance.BorderSize = 0;
            this.BRegistrarUsuario.Location = new System.Drawing.Point(464, 388);
            this.BRegistrarUsuario.Text = "Actualizar";
            this.BRegistrarUsuario.Click += new System.EventHandler(this.BActualizarUsuario_Click);
            // 
            // BRestaurar
            // 
            this.BRestaurar.FlatAppearance.BorderSize = 0;
            this.BRestaurar.Text = "Restablecer";
            this.BRestaurar.Click += new System.EventHandler(this.BTNRestablecer_Click);
            // 
            // LTitulo
            // 
            this.LTitulo.Text = "Editar Usuario ";
            // 
            // PInfoContacto
            // 
            this.PInfoContacto.Size = new System.Drawing.Size(274, 365);
            // 
            // PDatosCuenta
            // 
            this.PDatosCuenta.Controls.Add(this.TBEURepetir);
            this.PDatosCuenta.Controls.Add(this.TBEUContraseña);
            this.PDatosCuenta.Controls.Add(this.LNuevaContraseña);
            this.PDatosCuenta.Controls.Add(this.TBNuevaContraseña);
            this.PDatosCuenta.Size = new System.Drawing.Size(523, 176);
            this.PDatosCuenta.Controls.SetChildIndex(this.TBGUContraseña, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.TBGURepetir, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.TBGUUsername, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.LGUContraseña, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.COMBOBTipoUsuario, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.LRepetirContraseña, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.TBNuevaContraseña, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.LNuevaContraseña, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.TBEUContraseña, 0);
            this.PDatosCuenta.Controls.SetChildIndex(this.TBEURepetir, 0);
            // 
            // LRepetirContraseña
            // 
            this.LRepetirContraseña.Location = new System.Drawing.Point(265, 147);
            // 
            // LGUContraseña
            // 
            this.LGUContraseña.Size = new System.Drawing.Size(97, 13);
            this.LGUContraseña.Text = "Contraseña Actual:";
            // 
            // PFormularioCrearUsuario
            // 
            this.PFormularioCrearUsuario.Controls.Add(this.BTNActualizar);
            this.PFormularioCrearUsuario.Controls.Add(this.BTNRestablecer);
            this.PFormularioCrearUsuario.Controls.SetChildIndex(this.PDatosCuenta, 0);
            this.PFormularioCrearUsuario.Controls.SetChildIndex(this.PInfoContacto, 0);
            this.PFormularioCrearUsuario.Controls.SetChildIndex(this.BRestaurar, 0);
            this.PFormularioCrearUsuario.Controls.SetChildIndex(this.BRegistrarUsuario, 0);
            this.PFormularioCrearUsuario.Controls.SetChildIndex(this.BTNRestablecer, 0);
            this.PFormularioCrearUsuario.Controls.SetChildIndex(this.BTNActualizar, 0);
            // 
            // TBGUContraseña
            // 
            this.TBGUContraseña.Visible = false;
            // 
            // TBGURepetir
            // 
            this.TBGURepetir.Visible = false;
            // 
            // TBNuevaContraseña
            // 
            this.TBNuevaContraseña.Location = new System.Drawing.Point(382, 95);
            this.TBNuevaContraseña.Name = "TBNuevaContraseña";
            this.TBNuevaContraseña.PasswordChar = '*';
            this.TBNuevaContraseña.Size = new System.Drawing.Size(123, 20);
            this.TBNuevaContraseña.TabIndex = 40;
            this.TBNuevaContraseña.Validating += new System.ComponentModel.CancelEventHandler(this.TBGUNuevaContraseña_Validating);
            // 
            // LNuevaContraseña
            // 
            this.LNuevaContraseña.AutoSize = true;
            this.LNuevaContraseña.Location = new System.Drawing.Point(265, 98);
            this.LNuevaContraseña.Name = "LNuevaContraseña";
            this.LNuevaContraseña.Size = new System.Drawing.Size(99, 13);
            this.LNuevaContraseña.TabIndex = 41;
            this.LNuevaContraseña.Text = "Nueva Contraseña:";
            // 
            // BTNRestablecer
            // 
            this.BTNRestablecer.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNRestablecer.FlatAppearance.BorderSize = 0;
            this.BTNRestablecer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNRestablecer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNRestablecer.Location = new System.Drawing.Point(303, 388);
            this.BTNRestablecer.Name = "BTNRestablecer";
            this.BTNRestablecer.Size = new System.Drawing.Size(124, 32);
            this.BTNRestablecer.TabIndex = 44;
            this.BTNRestablecer.Text = "Restablecer Datos";
            this.BTNRestablecer.UseVisualStyleBackColor = false;
            this.BTNRestablecer.Click += new System.EventHandler(this.BTNRestablecer_Click);
            // 
            // BTNActualizar
            // 
            this.BTNActualizar.BackColor = System.Drawing.Color.DarkTurquoise;
            this.BTNActualizar.FlatAppearance.BorderSize = 0;
            this.BTNActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTNActualizar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BTNActualizar.Location = new System.Drawing.Point(464, 388);
            this.BTNActualizar.Name = "BTNActualizar";
            this.BTNActualizar.Size = new System.Drawing.Size(124, 32);
            this.BTNActualizar.TabIndex = 45;
            this.BTNActualizar.Text = "Actualizar Datos";
            this.BTNActualizar.UseVisualStyleBackColor = false;
            this.BTNActualizar.Click += new System.EventHandler(this.BActualizarUsuario_Click);
            // 
            // TBEUContraseña
            // 
            this.TBEUContraseña.Location = new System.Drawing.Point(382, 46);
            this.TBEUContraseña.Name = "TBEUContraseña";
            this.TBEUContraseña.Size = new System.Drawing.Size(123, 20);
            this.TBEUContraseña.TabIndex = 42;
            this.TBEUContraseña.Validating += new System.ComponentModel.CancelEventHandler(this.TBGUContraseña_Validating);
            // 
            // TBEURepetir
            // 
            this.TBEURepetir.Location = new System.Drawing.Point(382, 140);
            this.TBEURepetir.Name = "TBEURepetir";
            this.TBEURepetir.Size = new System.Drawing.Size(123, 20);
            this.TBEURepetir.TabIndex = 43;
            this.TBEURepetir.Validating += new System.ComponentModel.CancelEventHandler(this.TBGURepetir_Validating);
            // 
            // EdicionUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 552);
            this.Name = "EdicionUsuario";
            this.Text = "EdicionUsuario";
            this.PTCrearUsuario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.PInfoContacto.ResumeLayout(false);
            this.PInfoContacto.PerformLayout();
            this.PDatosCuenta.ResumeLayout(false);
            this.PDatosCuenta.PerformLayout();
            this.PFormularioCrearUsuario.ResumeLayout(false);
            this.PCrearUsuario.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LNuevaContraseña;
        private System.Windows.Forms.TextBox TBNuevaContraseña;
        private System.Windows.Forms.Button BTNActualizar;
        private System.Windows.Forms.Button BTNRestablecer;
        private System.Windows.Forms.TextBox TBEUContraseña;
        private System.Windows.Forms.TextBox TBEURepetir;
    }
}