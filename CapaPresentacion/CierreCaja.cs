using iTextSharp.text.pdf;
using iTextSharp.text;
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
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class CierreCaja : Form
    {
        public Caja cajaCierre;
        public bool load_ErrorProvider;

        public CierreCaja(Caja _cajaCierre)
        {
            InitializeComponent();
            this.cajaCierre = _cajaCierre;
        }

        private void BTNVolver_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        public void LoadInitValues()
        { 
            // Informacion General.
            this.Usuario.Text = this.cajaCierre.usuario.username;
            this.FechaApertura.Text = this.cajaCierre.fecha_apertura.ToString();

            // Movimientos.
            this.Ingresos.Text = string.Empty;
            this.Egresos.Text = string.Empty;

            // Necesito un metodo para calcular movimientos.

            // Ventas.
            this.CantVentas.Text = string.Empty;
            this.CantProductos.Text = string.Empty;
            this.MontoTotal.Text = string.Empty;

            // Necesito un metodo para calcular ventas.

            // Cobros.
            this.Efectivo.Text = string.Empty;
            this.Otros.Text = string.Empty;

            // Necesito un metodo para calcular cobros.

            // Saldo.
            this.SaldoInicial.Text = string.Empty;
            this.SaldoEsperado.Text = string.Empty;

            this.Diferencia.Text = string.Empty;

            // Necesito un metodo para calcular saldo. 
        }


        private void BTNDescargar_Click(object sender, EventArgs e)
        {
            this.GetResumenCierre();
        }

        private void BTNCerrarCaja_Click(object sender, EventArgs e)
        {
            this.load_ErrorProvider = false;

            if (this.ValidateChildren())
            {
                if (this.load_ErrorProvider)
                {
                    return;
                }
            }

            decimal.TryParse(this.TBSaldoCierre.Text, out decimal saldo_cierre);

            CN_Caja caja = new CN_Caja();

            this.cajaCierre.fecha_cierre = DateTime.Now; // Probamos luego con una fecha < a fecha apertura.
            this.cajaCierre.saldo_cierre = saldo_cierre;

            try
            {
                int confirmacion = caja.UpdateCajaStateOff(this.cajaCierre);

                if (confirmacion == 1)
                {
                    MessageBox.Show("Cierre de caja exitoso.", "Cierre.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    // Mensaje de error
                    this.mostrarErrores(caja.GetErrors());
                    MessageBox.Show("Ha ocurrido un error, no se pudo realizar el cierre de caja.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error de validación: " + ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityErrors in ex.EntityValidationErrors)
                {
                    foreach (var error in entityErrors.ValidationErrors)
                    {
                        MessageBox.Show(
                            "Propiedad: " + error.PropertyName +
                            "\nError: " + error.ErrorMessage);
                    }
                }
            }
        }

        // Falta modificar alguna que otra cosita como ser la modularizacion del metodo.
        public void GetResumenCierre()
        {

            if (this.cajaCierre == null)
            {
                MessageBox.Show("Hemos tenido un problema, no se pudo descargar el pdf.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Cargar la plantilla HTML del PDF desde los recursos.
            // En este caso lo cargamos como string aunque tambien podria tratarse como binario.  

            // Path.Combine: Une las partes de la ruta(BaseDirectory, Plantillas, Factura.html) utilizando el separador de directorios correcto del sistema operativo(por ejemplo, \ en Windows o / en Linux / macOS
            // AppDomain.CurrentDomain.BaseDirectory: Obtiene la ruta base del directorio donde se ejecuta la aplicación, útil para encontrar archivos de configuración o plantillas adjuntas.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plantilla", "Resumen_cerrados.html");

            if (!File.Exists(ruta))
            {
                MessageBox.Show("Plantilla no encontrada: " + ruta);
                return;
            }

            string Texto_Html = File.ReadAllText(ruta);

            // Manemos los datos.   
            // Nro. de Caja. 

            string id = "1000";
            int cifras = id.Count();

            string modelo = "#000000000000";

            string valor = modelo.Insert(modelo.Count() - cifras, id);
            valor = valor.Remove(modelo.Count());

            // Reemplazar los marcadores en el HTML con los datos de la caja y del usuario.

            // -----
            // Informacion General.
            Texto_Html = Texto_Html.Replace("{{usuario}}", this.Usuario.Text);
            Texto_Html = Texto_Html.Replace("{{fecha_apertura}}", this.FechaApertura.Text);
            Texto_Html = Texto_Html.Replace("{{fecha_cierre}}", " - - - ");

            // -----
            // Movimientos
            Texto_Html = Texto_Html.Replace("{{ingresos}}", this.Ingresos.Text);
            Texto_Html = Texto_Html.Replace("{{egresos}}", this.Egresos.Text);

            // -----
            // Ventas
            Texto_Html = Texto_Html.Replace("{{cantidad_ventas}}", this.CantVentas.Text);
            Texto_Html = Texto_Html.Replace("{{cantidad_productos}}", this.CantProductos.Text);
            Texto_Html = Texto_Html.Replace("{{ventas_total}}", this.MontoTotal.Text);

            // -----
            // Cobros  
            Texto_Html = Texto_Html.Replace("{{efectivo}}", this.Efectivo.Text);
            Texto_Html = Texto_Html.Replace("{{otros}}", this.Otros.Text);

            // -----
            // Saldo
            Texto_Html = Texto_Html.Replace("{{saldo_inicial}}", this.SaldoInicial.Text);
            Texto_Html = Texto_Html.Replace("{{saldo_esperado}}", this.SaldoEsperado.Text);
            Texto_Html = Texto_Html.Replace("{{saldo_cierre}}", this.FechaApertura.Text);
            Texto_Html = Texto_Html.Replace("{{diferencia}}", this.Diferencia.Text);
             
            // Cargamos la Fecha de emision del documento.
            Texto_Html = Texto_Html.Replace("{{fecha_emision}}", "17/07/2026 14:00:00");

            // Mostrar un cuadro de diálogo para seleccionar la ubicación donde guardar el PDF
            SaveFileDialog savefile = new SaveFileDialog();

            savefile.FileName = string.Format("Resumen_cierre{0}.pdf", valor + DateTime.Today.ToString("ddMMyyyy"));
            savefile.Filter = "Pdf Files | *.pdf";

            // Si el usuario confirma la descarga
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                // Flujo de creacion del archivo.
                /*
                    1. Se crea archivo físico vacío
                    2. Se crea estructura PDF en memoria
                    3. Se conecta estructura con archivo
                    4. Se abre el documento
                    5. Se lee el HTML
                    6. Se traduce HTML → objetos PDF
                    7. Se escriben esos objetos en el archivo
                    8. Se cierra el documento
                    9. Se libera el archivo
                */

                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);

                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);

                    pdfDoc.Open();

                    // Leer el HTML y agregarlo al documento PDF
                    using (StringReader sr = new StringReader(Texto_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    // Cerrar el documento y el stream
                    pdfDoc.Close();

                    MessageBox.Show("El Resumen de caja se descargo correctamente.", "Descargado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        } 

        private void TBSaldoCierre_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBSaldoCierre.Text))
            {
                this.errorProvider1.SetError(this.TBSaldoCierre, "El campo Saldo Cierre es obligatorio");
                this.load_ErrorProvider = true;
            }
            else if (!decimal.TryParse(this.TBSaldoCierre.Text, out decimal monto_gasto))
            {
                this.errorProvider1.SetError(this.TBSaldoCierre, "El campo Saldo Cierre debe ser un valor numerico");
                this.load_ErrorProvider = true;
            }
            else if (monto_gasto <= 0)
            {
                this.errorProvider1.SetError(this.TBSaldoCierre, "El campo Saldo Cierre debe ser mayor a cero.");
                this.load_ErrorProvider = true;
            }
            else if (!(decimal.Round(monto_gasto, 2) == monto_gasto))
            {
                this.errorProvider1.SetError(this.TBSaldoCierre, "El campo Saldo Cierre debe ser un valor numerico con hasta dos decimales.");
                this.load_ErrorProvider = true;
            }
            else
            {
                this.errorProvider1.SetError(this.TBSaldoCierre, "");
            }
        }

        private void TB_TextChanged(object sender, EventArgs e)
        {
            // Convierte el objeto sender en un TextBox.
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            if (!string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.Contains("."))
                {
                    string modificado = textBox.Text.Replace(".", ",");
                    textBox.Text = modificado;

                    // Mover el cursor al final del texto.
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }

        public void mostrarErrores(Dictionary<string, string> validacion)
        {
            if (validacion != null)
            {
                foreach (var error in validacion)
                {
                    MessageBox.Show("" + error.Key + ": " + error.Value);

                    // Control[] controlesEncontrados = this.Controls.Find(error.Key, true); // 'true' busca en controles hijos también 
                    // errorProvider1.SetError(controlesEncontrados[0], error.Value);
                }
            }
        }
    }
}

