using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class BackUp : Form
    {
        public Principal principal; 

        public BackUp(Principal _principal)
        {
            InitializeComponent();
            this.principal = _principal;
            this.LoadInit();
        }

        public void LoadInit() 
        { 
            CN_BackUp backUp = new CN_BackUp();

            string db_active = backUp.ObtenerBDActiva();

            this.CBBackUpBD.Items.Add("" + db_active);
            this.CBRestoreBD.Items.Add("" + db_active);

            this.CBBackUpBD.SelectedIndex = 0;
            this.CBRestoreBD.SelectedIndex = 0;

            this.CBBackUpBD.Enabled = false;
            this.CBRestoreBD.Enabled = false;
        }

        private void BTNGenerarCopiaSeguridad_Click(object sender, EventArgs e)
        {
            try
            {
                CN_BackUp cn_backup = new CN_BackUp();
                string save_ruta = cn_backup.BackUp();

                this.TBBackUpPathDestino.Text = save_ruta;
                MessageBox.Show("La copia de seguridad se guardo correctamente, podes encontrarla en: " + save_ruta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void BTNExaminarRestore_Click(object sender, EventArgs e)
        {
            CN_BackUp cn_BackUp = new CN_BackUp();  

            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog()) 
                {
                    ofd.Filter = "Archivos de respaldo (*.bak)|*.bak";
                    ofd.InitialDirectory = cn_BackUp.ObtenerCarpetaRestore();

                    if (ofd.ShowDialog() == DialogResult.OK) 
                    { 
                        this.TBArchivoRespaldo.Text = ofd.FileName;
                    } 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTNRestoreBD_Click(object sender, EventArgs e)
        {
            CN_BackUp cn_backup = new CN_BackUp();
            string backup_selected = this.TBArchivoRespaldo.Text;

            try
            {
                if (!string.IsNullOrEmpty(backup_selected)) 
                { 
                    cn_backup.Restore(backup_selected);

                    MessageBox.Show("La copia de seguridad fue restaurada con exito.", "Copia Restaurada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error, la copia de seguridad no pudo restaurarse. " + ex.Message);
            }
        }
    }
}
