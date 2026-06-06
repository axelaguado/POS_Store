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
using System.Reflection.Emit;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using System.Drawing.Printing;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text;       // Paquete para trabajar con pdf y se descarga tambien el xml worker para que pueda interpretar html.
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.util;
using iTextSharp.tool.xml.html;

namespace WindowsFormsApp1.CapaPresentacion
{
    public partial class Detalle : Form
    { 
        private Compra compra; 

        public Detalle(Compra _compra)
        { 
            this.compra = _compra;  
            InitializeComponent();
            this.cargarHeaderDetalle();   
            this.cargarBodyDetalle();   
        } 

        // Permite el despalzamiento del formulario por la pantalla.
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int IParam); 

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void cargarHeaderDetalle()
        {
            string id = Convert.ToString(this.compra.id_compra);
            int cifras = id.Count();

            string nro = "#00000000";   

            this.LNroPedido.Text = nro.Insert(10 - cifras, id);  
            this.LRazonSocial.Text = this.compra.proveedor.persona.persona_juridica.razon_social;
            this.LNomComer.Text = this.compra.proveedor.persona.persona_juridica.nombre_comercial;
            this.LCuit.Text = Convert.ToString(this.compra.proveedor.persona.persona_juridica.cuit);
            this.LDireccion.Text = (this.compra.proveedor.persona.direcciones.FirstOrDefault().calle + " " + this.compra.proveedor.persona.direcciones.FirstOrDefault().altura);
            this.LCodPostal.Text = Convert.ToString(this.compra.proveedor.persona.direcciones.FirstOrDefault().cod_postal);
            this.LTelefono.Text = Convert.ToString(this.compra.proveedor.persona.contactos.FirstOrDefault().telefono);
            this.LFechaPedido.Text = "Fecha Emision: " + this.compra.fecha_emision.ToShortDateString();
            this.LFechaConfirmacion.Text = "Fecha Confirmacion: " + (this.compra.fecha_confirmacion == null? "---" : this.compra.fecha_confirmacion.Value.ToShortDateString()); 
            this.LEstado.Text = this.compra.estado.descripcion_estado; 
        } 

       public object cargarDGVDetalle(ICollection<Detalle_compra> _lista)
       { 
            var tabla = _lista.Select((detalle, index) => new
            {
                Marca = detalle.producto.marca_producto,
                Producto = detalle.producto.nombre_producto + " (" + detalle.producto.contenido_producto + ") - " + detalle.producto.descripcion_producto, 
                Cantidad = detalle.cantidad_producto,
                Informacion = detalle.informacion_acerca,
                Subtotal = detalle.subtotal_producto,
            }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
       }

        public void cargarBodyDetalle()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            this.dataGridView1.DataSource = cargarDGVDetalle(compra.detalles_compra); 

            this.LTotalPedido.Text = "Total: $" + Convert.ToString(this.compra.monto_total);
        }
         
        private void BCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        } 

        private void BGenPDF_Click(object sender, EventArgs e)
        {
            if (this.compra == null)
            {
                MessageBox.Show("Hemos tenido un problema, no se pudo descargar el pdf.", "Atencion.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Cargar la plantilla HTML del PDF desde los recursos.
            // En este caso lo cargamos como string aunque tambien podria tratarse como binario.  

            // Path.Combine: Une las partes de la ruta(BaseDirectory, Plantillas, Factura.html) utilizando el separador de directorios correcto del sistema operativo(por ejemplo, \ en Windows o / en Linux / macOS
            // AppDomain.CurrentDomain.BaseDirectory: Obtiene la ruta base del directorio donde se ejecuta la aplicación, útil para encontrar archivos de configuración o plantillas adjuntas.
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plantilla", "Solicitud_pedido.html");

            if (!File.Exists(ruta))
            {
                MessageBox.Show("Plantilla no encontrada: " + ruta);
                return;
            }

            string Texto_Html = File.ReadAllText(ruta);

            // Manemos los datos.   
            //Nro. Pedido. 
            string id = Convert.ToString(this.compra.id_compra);
            int cifras = id.Count(); 
            string nro = "#00000000"; 
            //Estado.

            // Reemplazar los marcadores en el HTML con los datos del proveedor y del pedido
            Texto_Html = Texto_Html.Replace("@NumeroCompra", nro.Insert(10 - cifras, id));
            Texto_Html = Texto_Html.Replace("@FechaEmision", this.compra.fecha_emision.ToShortDateString());
            Texto_Html = Texto_Html.Replace("@FechaConfirmacion", this.compra.fecha_confirmacion == null? "---" : this.compra.fecha_confirmacion.Value.ToShortDateString());
            Texto_Html = Texto_Html.Replace("@Estado", this.compra.estado.descripcion_estado);
            // -----
            Texto_Html = Texto_Html.Replace("@RazonSocial", this.compra.proveedor.persona.persona_juridica.razon_social);
            Texto_Html = Texto_Html.Replace("@NombreComercial", this.compra.proveedor.persona.persona_juridica.nombre_comercial);
            Texto_Html = Texto_Html.Replace("@Cuit", this.compra.proveedor.persona.persona_juridica.cuit.ToString());
            // -----
            Texto_Html = Texto_Html.Replace("@Direccion", this.compra.proveedor.persona.direcciones.FirstOrDefault()?.calle + " " + this.compra.proveedor.persona.direcciones.FirstOrDefault()?.altura); 
            Texto_Html = Texto_Html.Replace("@CodigoPostal", this.compra.proveedor.persona.direcciones.FirstOrDefault()?.cod_postal.ToString());
            Texto_Html = Texto_Html.Replace("@Telefono", this.compra.proveedor.persona.contactos.FirstOrDefault()?.telefono.ToString());

            // Construir las filas de la tabla con los productos comprados
            StringBuilder filas = new StringBuilder();

            foreach (var item in this.compra.detalles_compra)
            {
                filas.Append($@"
                    <tr>
                        <td>{item.producto.marca_producto}</td>
                        <td>{item.producto.nombre_producto + " (" + item.producto.contenido_producto + ") - " + item.producto.descripcion_producto}</td> 
                        <td>{item.cantidad_producto}</td>
                        <td>{item.informacion_acerca}</td>
                        <td>{"$" + item.subtotal_producto}</td>
                    </tr> 
                ");
            }

            Texto_Html = Texto_Html.Replace("@FilasProductos", filas.ToString());

            // Reemplazamos el Total.
            Texto_Html = Texto_Html.Replace("@Total", "$" + this.compra.monto_total.ToString());

            // Mostrar un cuadro de diálogo para seleccionar la ubicación donde guardar el PDF
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Solicitud_pedido{0}.pdf", nro.Insert(10 - cifras, id) + DateTime.Today.ToString("ddMMyyyy"));
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

                    MessageBox.Show("El detalle del pedido se guardo correctamente.");
                }
            } 
        }    
    }
}
