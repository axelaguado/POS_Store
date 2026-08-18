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
using Org.BouncyCastle.Crypto.Engines;


namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Principal : Form
    {
        private Session session;
        
        public Principal(Session datosSession)
        {
            this.session = datosSession;
            InitializeComponent();
            this.cargarPBienvenida();
            this.SetUpTimer();
            this.SetUpAvailableMenuEmpleado();
            this.SetUpAvailableMenuGerente();
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

        public string GetUsernameSession() 
        { 
            return this.session.username;
        }
         
        // Seria lo correcto?
        public int GetIdSession()
        {
            return this.session.id_user;
        }

        public string GetTipoPerfilSession()
        {
            return this.session.tipo_perfil;
        }

        // Eventos y configuraciones del reloj
        public void SetUpTimer()
        {
            // Seteamos el horario incial en la aplicacion.
            this.LoadReloj();

            // Seteamos el timer
            this.timer1.Interval = 500; // 100ms segundos para poder tener el reloj lo mas sincronizado posible
            this.timer1.Start();
        }

        //Evento que se diespara cuando se cumple el tiempo de intevalo establecido en el timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.LoadReloj();
        }

        public void LoadReloj() 
        {
            bool state = this.LReloj.Visible;
            this.LReloj.Text = "" + DateTime.Now.ToShortTimeString();
            this.LReloj.Visible = !state;
        }

        // ---------------

        public void cargarPBienvenida()
        {
            this.BBienvenida.Text = "Bienvenido, " + this.session.nombre + " " + this.session.apellido;
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
            if (this.PContenidos.Controls.Count > 0 && this.PContenidos.Controls[0] is IConfigForm formHijo)
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

        public Rectangle GetAreaPContenido()
        {
            Rectangle area = this.PContenidos.RectangleToScreen(this.PContenidos.ClientRectangle);
            return area;
        }

        private void BGestionUsuarios_Click(object sender, EventArgs e)
        {
            if (!this.Autorizado()) return;

            if (!this.AutorizadoGerente()) return;

            this.AbrirFormHijo(new Listado(this));
            this.LightOff(sender);
            BGestionUsuarios.BackColor = System.Drawing.Color.DarkTurquoise;
        }
        private void BGestionClientes_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new GestionClientes(this));
            this.LightOff(sender);
            BGestionClientes.BackColor = System.Drawing.Color.DarkTurquoise;
        }
        private void BGestionProveedor_Click(object sender, EventArgs e)
        {
            if (!this.Autorizado()) return;

            this.AbrirFormHijo(new GestionProveedor(this));
            this.LightOff(sender);
            BGestionProveedor.BackColor = System.Drawing.Color.DarkTurquoise;
        }
        private void BGestionProductos_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new GestionProductos(this));
            this.LightOff(sender);
            BGestionProductos.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        private void BTGestionCompras_Click(object sender, EventArgs e)
        {
            if (!this.Autorizado()) return;

            this.AbrirFormHijo(new GestionCompras(this));
            this.LightOff(sender);
            BTGestionCompras.BackColor = System.Drawing.Color.DarkTurquoise;
        } 
        private void BTGastos_Click(object sender, EventArgs e)
        {
            if (!this.Autorizado()) return;

            this.AbrirFormHijo(new GestionGastos(this));
            this.LightOff(sender);
            BTGastos.BackColor = System.Drawing.Color.DarkTurquoise;
        }
        
        private void BVentas_Click(object sender, EventArgs e)
        {
            this.AbrirFormHijo(new GestionVentas(this));
            this.LightOff(sender);
            BVentas.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        private void BReportes_Click(object sender, EventArgs e)
        {
            if (!this.Autorizado()) return;

            this.AbrirFormHijo(new Reportes(this));
            this.LightOff(sender);
            this.BReportes.BackColor = System.Drawing.Color.DarkTurquoise;
        }

        public bool Autorizado() 
        {
            if ((this.GetTipoPerfilSession() == "Administrador") || this.GetTipoPerfilSession() == ("Gerente"))
            {
                return true;
            }

            if (this.GetTipoPerfilSession() == "Empleado") 
            { 
                return false;
            }

            return false;
        }

        public bool AutorizadoGerente()
        {
            if ((this.GetTipoPerfilSession() == "Administrador"))
            {
                return true;
            }

            if ((this.GetTipoPerfilSession() == "Gerente"))
            {
                return false;
            }

            return false;
        }

        public void SetUpAvailableMenuEmpleado() 
        {
            List<Control> available = new List<Control>
            {
                this.BGestionClientes,
                this.BGestionProductos,
                this.BVentas,
                this.BCerrarSession
            };

            Control.ControlCollection controles = this.PMenu.Controls;

            // 2. Modificas o seteas propiedades en lote usando un bucle
            foreach (Control ctrl in controles)
            {
                if (!this.Autorizado() && !available.Contains(ctrl)) 
                { 
                    ctrl.ForeColor = Color.Gray; // Ejemplo: Desactivar todos
                }
            }

            // Faltaria Reportes, BackUp y Cerrar
        }

        public void SetUpAvailableMenuGerente()
        {
            List<Control> notAvailable = new List<Control>
            {
                this.BGestionUsuarios,
                this.BBackUp
            };

            Control.ControlCollection controles = this.PMenu.Controls;

            // 2. Modificas o seteas propiedades en lote usando un bucle
            foreach (Control ctrl in controles)
            {
                if (!this.AutorizadoGerente() && notAvailable.Contains(ctrl))
                {
                    ctrl.ForeColor = Color.Gray; // Ejemplo: Desactivar todos
                }
            }

            // Faltaria Reportes, BackUp y Cerrar
        }

        public void LightOff(object sender) 
        { 
            Button boton = sender as Button;

            foreach(Control control in this.PMenu.Controls)
            {
                if (control is Button) 
                { 
                    if(control.Name != boton.Name) 
                    {
                        control.BackColor = System.Drawing.Color.DarkSlateGray;
                    }          
                }
            }
        
        }  
    }
 }
