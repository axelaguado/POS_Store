using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaPresentacion;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_MovimientoCaja
    {
        public Dictionary<string, string> validacion;

        public CN_MovimientoCaja()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public int RegistrarMovimiento(Movimiento_caja _movimiento)
        {
            if (this.ValidarMovimiento(_movimiento).Count == 0) 
            {
                using (var context = new MiDbContext()) 
                {
                    MovimientoCajaDAO movimiento = new MovimientoCajaDAO(context);
                    _movimiento.estado_movimiento = true;

                    // Realizamos el seguimiento de la caja y del tipo existentes -- Como la Caja esta trayendo todo os chiches vamos a simplificarla
                    CajaDAO caja = new CajaDAO(context);
                    caja.Attach_caja(_movimiento.caja);

                    TipoMovimientoDAO tipo = new TipoMovimientoDAO(context);
                    tipo.Attach_tipo(_movimiento.tipo_movimiento);

                    movimiento.AddMoviento(_movimiento);
                     
                    return context.SaveChanges();
                }
            }

            return 0;
        }

        public Dictionary<string, string> ValidarMovimiento(Movimiento_caja _movimiento)
        {
            this.validacion.Clear();

            // Validamos los campos y las entidades necesarias
            this.ValidarTipoMovimiento(_movimiento.tipo_movimiento);
            this.ValidarCajaMovimiento(_movimiento.caja);
            this.ValidarMontoMovimiento(_movimiento.monto_movimiento);
            this.ValidarDescripcionMovimiento(_movimiento.descripcion_movimiento);
            this.ValidarFechaMovimiento(_movimiento.fecha_movimiento);

            return this.validacion;
        }

        public void ValidarTipoMovimiento(Tipo_movimiento _tipo)
        {
            if (_tipo == null)
            {
                this.validacion.Add("Tipo_movimiento", "Es necesario asociar un tipo de movimiento al movimiento."); //this.validacion.Add("", "")
            }
        }

        public void ValidarCajaMovimiento(Caja _caja)
        {
            // Podriamos tambien hacer algunas comprobaciones extras , como por ejemplo: si existe en la BD dicha caja y si dicha caja se encuentra abierta ..

            if (_caja == null)
            {
                this.validacion.Add("Caja", "Es necesario asociar una caja a la venta."); //this.validacion.Add("", "")
            }
        }

        public void ValidarMontoMovimiento(decimal _importe)
        {
            if (_importe <= 0)
            {
                this.validacion.Add("Monto_movimiento", "El importe final de la venta debe ser mayor a cero.");
            }
            else if (decimal.Round(_importe, 2) != _importe)
            {
                this.validacion.Add("Monto_venta", "El importe final de la venta debe tener a lo sumo dos decimales.");
            }
        }

        public void ValidarDescripcionMovimiento(string _descripcion)
        {
            if (string.IsNullOrEmpty(_descripcion))
            {
                this.validacion.Add("Descripcion_movimiento", "Es obligatorio ingresar una descripcion del movimiento."); //this.validacion.Add("", "")
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(_descripcion, @"^[a-zA-Z\s,.-]+$"))
            {
                this.validacion.Add("Descripcion_movimiento", "El atributo solo puede contener letras, espacios y caracteres especiales (-.,).");
            }
            else if (_descripcion.Length > 100)
            {
                this.validacion.Add("Descripcion_movimiento", "El atributo supera el limite de caracteres permitidos (100).");
            }
        }


        public void ValidarFechaMovimiento(DateTime _fecha)
        {
            if (_fecha == null)
            {
                this.validacion.Add("Fecha_movimineto", "Es necesario asociar una fecha valida al movimiento."); //this.validacion.Add("", "")
            }
        }
         
        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }

        public Dictionary<string, string> unirDiccionarios(Dictionary<string, string> _diccionario)
        {
            if (_diccionario != null)
            {
                foreach (var error in _diccionario)
                {
                    validacion[error.Key] = error.Value; // Agrega o actualiza
                }
            }

            return validacion;
        }

    }
}
