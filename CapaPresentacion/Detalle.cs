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
        private Pedido pedido; 

        public Detalle(Pedido _pedido)
        { 
            this.pedido = _pedido;  
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
            string id = Convert.ToString(this.pedido.id_pedido);
            int cifras = id.Count();

            string nro = "#00000000";  

            this.LNroPedido.Text = nro.Insert(10 - cifras, id);  
            this.LRazonSocial.Text = this.pedido.proveedor.razon_social;
            this.LNomComer.Text = this.pedido.proveedor.nombre_comercial;
            this.LCuit.Text = Convert.ToString(this.pedido.proveedor.CUIT);
            this.LDireccion.Text = this.pedido.proveedor.direccion?.calle + " " + this.pedido.proveedor.direccion?.altura ;
            this.LCodPostal.Text = Convert.ToString(this.pedido.proveedor.cod_postal);
            this.LTelefono.Text = Convert.ToString(this.pedido.proveedor.telefono);
            this.LFechaPedido.Text = Convert.ToString(this.pedido.fecha_emision);
            this.LEstado.Text = this.GetEstado(this.pedido.estado); 
        } 

       public object cargarDGVDetalle(ICollection<Detalle_pedido> _lista)
       {
            var tabla = _lista.Select((detalle, index) => new
            { 
                 Marca = detalle.articulo.marca_articulo,
                 Nombre = detalle.articulo.nombre_articulo,
                 Descripcion = detalle.articulo.descripcion_articulo,
                 Contenido = detalle.articulo.contenido_articulo,
                 PrecioUnitario = detalle.articulo.precio_unitario,
                 Cantidad = detalle.cantidad,
                 Subtotal = (detalle.articulo.precio_unitario * detalle.cantidad)
             }).ToList(); // Convierte el resultado a una lista para que se pueda asignar al DataGridView  

            return tabla;
       }

        public void cargarBodyDetalle()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Columns.Clear();
            this.dataGridView1.Rows.Clear();

            this.dataGridView1.DataSource = cargarDGVDetalle(pedido.detalle_pedido); 

            this.LTotalPedido.Text = "Total: $" + Convert.ToString(this.pedido.monto_total);
        }

        public string GetEstado(int _estado) 
        {
            string estado = string.Empty;
             
            if (_estado == 1) 
            {
                estado = "Pendiente";
            }

            if (_estado == 2) 
            {
                estado = "Recibido";
            }

            return estado;
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            this.Close();   
        } 

        private void BGenPDF_Click(object sender, EventArgs e)
        {
            if (this.pedido == null)
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
            string id = Convert.ToString(this.pedido.id_pedido);
            int cifras = id.Count(); 
            string nro = "#00000000"; 
            //Estado.

            // Reemplazar los marcadores en el HTML con los datos del proveedor y del pedido
            Texto_Html = Texto_Html.Replace("@NumeroPedido", nro.Insert(10 - cifras, id));
            Texto_Html = Texto_Html.Replace("@FechaEmision", this.pedido.fecha_emision.ToString());
            Texto_Html = Texto_Html.Replace("@Estado", this.GetEstado(this.pedido.estado));
            // -----
            Texto_Html = Texto_Html.Replace("@RazonSocial", this.pedido.proveedor.razon_social);
            Texto_Html = Texto_Html.Replace("@NombreComercial", this.pedido.proveedor.nombre_comercial);
            Texto_Html = Texto_Html.Replace("@Cuit", this.pedido.proveedor.CUIT.ToString());
            // -----
            Texto_Html = Texto_Html.Replace("@Direccion", this.pedido.proveedor.direccion.calle + ", " + this.pedido.proveedor.direccion.altura);
            Texto_Html = Texto_Html.Replace("@CodigoPostal", this.pedido.proveedor.cod_postal.ToString());
            Texto_Html = Texto_Html.Replace("@Telefono", this.pedido.proveedor.telefono.ToString());

            // Construir las filas de la tabla con los productos comprados
            StringBuilder filas = new StringBuilder();

            foreach (var item in this.pedido.detalle_pedido)
            {
                filas.Append($@"
                    <tr>
                        <td>{item.articulo.marca_articulo}</td>
                        <td>{item.articulo.nombre_articulo}</td>
                        <td>{item.articulo.descripcion_articulo}</td>
                        <td>{item.articulo.contenido_articulo}</td>
                        <td>{"$" + item.articulo.precio_unitario}</td>
                        <td>{item.cantidad}</td>
                        <td>{"$" + item.articulo.precio_unitario * item.cantidad}</td>
                    </tr> 
                ");
            }

            Texto_Html = Texto_Html.Replace("@FilasProductos", filas.ToString());

            // Reemplazamos el Total.
            Texto_Html = Texto_Html.Replace("@Total", "$" + this.pedido.monto_total.ToString());

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
