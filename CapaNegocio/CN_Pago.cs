using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Pago
    {
        public Dictionary<string, string> validacion;

        public CN_Pago() 
        { 
            this.validacion = new Dictionary<string, string>();
        }
 

        public void RegistrarPago(ICollection<Pago> _pagos, MiDbContext context) 
        {
            PagoDAO pago = new PagoDAO(context);

            foreach (Pago nuevoPago in _pagos) 
            { 
                pago.CrearPago(nuevoPago);

                if (nuevoPago.metodo != null) 
                { 
                    MetodoPagoDAO metodo = new MetodoPagoDAO(context);
                    metodo.Attach_metodo(nuevoPago.metodo);
                }
            }
        }

        public void SetConfirmationPay(ICollection<Pago> pagos) 
        { 
            foreach (Pago pago in pagos) 
            { 
                pago.fecha_pago = DateTime.Now;
                pago.estado_pago = true;
            }  
        }

        public Dictionary<string, string> ValidarPago(Pago _pago)
        { 
            this.validacion.Clear();

            this.ValidarVentaPago(_pago.venta);
            this.ValidarMetodoPago(_pago.metodo);
            this.ValidarImportePago(_pago.importe_pago);
            this.ValidarFechaPago(_pago.fecha_pago);

            return this.validacion;
        }

        public void ValidarVentaPago(Venta _venta) 
        { 
            if(_venta == null) 
            {
                this.validacion.Add("Venta", "El pago no cuenta con una venta asociada.");
            }
        }

        public void ValidarMetodoPago(Metodo_pago _metodo)
        {
            if (_metodo == null)
            {
                this.validacion.Add("Metodo_pago", "El pago no tiene un metodo asociado.");
            }
        }

        public void ValidarImportePago(decimal _importe)
        {
            if (_importe <= 0)
            {
                this.validacion.Add("Importe_pago", "El importe de pago debe ser mayor a cero.");
            }
            else if (decimal.Round(_importe, 2) != _importe)
            {
                this.validacion.Add("Importe_pago", "El importe de pago debe tener a lo sumo dos decimales.");
            }
        }

        public void ValidarFechaPago(DateTime _fecha)
        {
            if (_fecha == null)
            {
                this.validacion.Add("Fecha_pago", "El pago no tiene una fecha asociada.");
            }
        }

        public int ValidarPagos(ICollection<Pago> pagos)
        {
            if (pagos == null) 
            {
                return 0;
            }

            foreach(Pago pago in pagos) 
            {
                
                if (this.ValidarPago(pago).Count > 0) 
                {
                    return 0;
                }
            }

            return 1;
        }

        public Dictionary<string, string> GetErrors()
        { 
            return this.validacion;
        }

    }

}
