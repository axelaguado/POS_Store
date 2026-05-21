using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection.Emit;
using WindowsFormsApp1.CapaEntidad;


namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Principal : Form
    {
        private Session session;

        public Principal(Session datosSession)
        {
            this.session = datosSession;
            InitializeComponent();
            cargarPBienvenida();
        }

        // Permiteel despalzamiento del formulario por la pantalla.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam);

        private void PHeaderPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void cargarPBienvenida()
        {
            BBienvenida.Text = "Bienvenido, " + this.session.nombre + " " + this.session.apellido + "   ▼";

            if (this.session.tipo_perfil.Equals("Empleado"))
            {
                BGestionEmpleados.Enabled = false;
            }
        }

        private void BMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PBRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            PBRestaurar.Visible = false;
            PBMaximizar.Visible = true;

            // Atencion con este if porque estoy tratando de forma estatica y no dinamica.
            // Este comportamiento se llama "pattern matching" (coincidencia de patrones).
            if (this.PContenidos.Controls[0] is IConfigForm formHijo)
            {
                formHijo.MantenerPanelesPrincipales();
            }
        }

        private void PBMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            PBMaximizar.Visible = false;
            PBRestaurar.Visible = true;

            // Atencion con este if porque estoy tratando de forma estatica y no dinamica. 
            if (this.PContenidos.Controls.Count > 0)
            {
                // Este comportamiento se llama "pattern matching" (coincidencia de patrones).
                if (this.PContenidos.Controls[0] is IConfigForm formHijo)
                {
                    formHijo.CentrarPanelesPrincipales();
                }
            }
        }

        private void PBCerrarPrincipal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public string GetSessionTypeUser()
        {
            return this.session.tipo_perfil;
        }

        public void AbrirFormHijo(object formHijo)
        {
            if (this.PContenidos.Controls.Count > 0)
            {
                this.PContenidos.Controls.RemoveAt(0);
            }

            // Esto es útil cuando no sabes con certeza si el objeto que estás recibiendo es un Form,
            // y quieres hacer una conversión segura sin que se lance una excepción si la conversión falla.
            Form fh = formHijo as Form;

            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            // fh.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.PContenidos.Controls.Add(fh);
            fh.Show();
        }

        private void BGestionEmpleados_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new Listado(this));
            BGestionEmpleados.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        private void BTGestionPedidos_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new GestionPedido(this));
            BTGestionPedidos.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        private void BGestionClientes_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new GestionClientes(this));
            BGestionClientes.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        private void BGestionProductos_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new GestionProductos(this));
            BGestionProductos.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        
    }
 }
