using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 
using System.Drawing.Drawing2D;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        
        //Añadimos bordes al formulario.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Definir el color y el grosor del borde
            Color borderColor = Color.Black;
            int borderWidth = 2;

            // Dibujar el borde en los cuatro lados
            using (Pen pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
        }

        private void BMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Permiteel despalzamiento del formulario por la pantalla.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); 
        }

        private void BIniciar_Click(object sender, EventArgs e)
        {
             
            if  (this.ValidateChildren() && this.ValidarCampos())
            {
                try 
                {
                    var username = TBUsername.Text;
                    var contraseña = TBContraseña.Text;

                    CN_Usuario usuario = new CN_Usuario();
                    usuario.loginUsuario(username, contraseña);

                    Principal principal = new Principal();
                    principal.Show();
                    
                    this.Hide();
                }
                catch (UnauthorizedAccessException na) 
                { 
                    MessageBox.Show("Error: " + na.Message, "Datos no validos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
                   // MessageBox.Show($"Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
            }
            else
            {
                MessageBox.Show("Ha surgido un error, verifique los datos ingresados.");
            }
              
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            TBUsername.Select(); 
        }

        
        private void TBUsername_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(TBUsername.Text)) 
            {
                errorProvider1.SetError(TBUsername, "Debe completar el campo Usuario.");   
            }
            else 
            {
                errorProvider1.SetError(TBUsername, "");
            }
        }

        private void TBContraseña_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TBContraseña.Text))
            {
                errorProvider1.SetError(TBContraseña, "Debe completar el campo Contraseña."); 
            }
            else
            {
                errorProvider1.SetError(TBContraseña, "");
            }
        }
         

        private bool ValidarCampos()
        {
            bool esValido = true;

            if (string.IsNullOrEmpty(TBUsername.Text))
            {
                errorProvider1.SetError(TBUsername, "Debe completar el campo Usuario.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(TBUsername, "");
            }

            if (string.IsNullOrEmpty(TBContraseña.Text))
            {
                errorProvider1.SetError(TBContraseña, "Debe completar el campo Contraseña.");
                esValido = false;
            }
            else
            {
                errorProvider1.SetError(TBContraseña, "");
            }

            return esValido;
        }
    }
}
