using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Caja
    {
        public Dictionary<string, string> validacion;

        public CN_Caja()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public int CrearCaja(Caja _caja) 
        {
            if(this.ValidarCaja(_caja).Count == 0) 
            {
                using (var context = new MiDbContext()) {

                    CajaDAO caja = new CajaDAO(context);
                    UsuarioDAO usuario = new UsuarioDAO(context);
                    usuario.Attach(_caja.usuario);
                    caja.CrearCaja(_caja);
                    
                    return context.SaveChanges();
                }  
            } 

            return 0;
        }

        public int UpdateCaja(Caja _caja)
        {
            if (this.ValidarCaja(_caja).Count == 0)
            {
                using (var context = new MiDbContext())
                {

                    CajaDAO caja = new CajaDAO(context);
                    UsuarioDAO usuario = new UsuarioDAO(context);
                    usuario.Attach(_caja.usuario);

                    caja.update_caja(_caja);

                    return context.SaveChanges();
                }
            }

            return 0;
        }

        public int UpdateCajaStateOff(Caja _caja)
        {
            if (this.ValidarCaja(_caja).Count == 0)
            {
                using (var context = new MiDbContext())
                {
                    CajaDAO caja = new CajaDAO(context);

                    _caja.estado_caja = false;

                    caja.update_caja(_caja);

                    return context.SaveChanges();
                }
            }

            return 0;
        }

        public Caja ObtenerCaja(int id_caja)
        {
            using (var context = new MiDbContext())
            {
                CajaDAO caja = new CajaDAO(context);
                return caja.GetCaja(id_caja);
            }
        }

        public void AttachCaja(Caja _caja) 
        {
            using (var context = new MiDbContext())
            {
                CajaDAO caja = new CajaDAO(context);
                caja.Attach_caja(_caja);
            }
        }

        public Dictionary<string, string> ValidarCaja(Caja _caja)
        {
            this.validacion.Clear();

            this.ValidarUsuario(_caja.usuario);
            this.ValidarFechaApertura(_caja.fecha_apertura);
            this.ValidarFechaCierra(_caja.fecha_cierre, _caja.fecha_apertura);
            this.ValidarSaldoInicial(_caja.saldo_inicial);
            this.ValidarSaldoCierre(_caja.saldo_cierre);

            return this.validacion;
        }

        public Caja GetActiveCaja(int id_user) 
        {
            using (var context = new MiDbContext()) 
            {
                CajaDAO caja = new CajaDAO(context);

                return caja.GetCajaActiva(id_user);
            }

        }
         
        public void ValidarUsuario(Usuario _user)
        {
            if(_user == null) 
            {
                this.validacion.Add("Usuario", "Se debe identificar el usuario responsable.");
            }
        }

        public void ValidarFechaApertura(DateTime fecha_apertura)
        {
            if (fecha_apertura == null)
            {
                this.validacion.Add("Fecha Apertura", "Se debe indicar la fecha y hora de apertura de la caja.");
            }
        }

        public void ValidarFechaCierra(DateTime? fecha_cierre, DateTime fecha_apertura)
        {
            if (fecha_cierre != null)
            {
                if (fecha_cierre < fecha_apertura) 
                {
                    this.validacion.Add("Fecha Cierre", "El cierre debe ser posterior a la apertura de la caja");
                }
            }
        }

        public void ValidarSaldoInicial(decimal saldo_incial)
        {
            if (saldo_incial < 0)
            {
                this.validacion.Add("TBSaldoInicial", "El campo Saldo Inicial debe ser mayor o igual a cero.");
            }
            else if (decimal.Round(saldo_incial, 2) != saldo_incial)
            {
                this.validacion.Add("TBSaldoInicial", "El campo Saldo Inicial solo acepta valores con hasta dos decimales");
            }
        }

        public void ValidarSaldoCierre(decimal saldo_cierre)
        {
            if (saldo_cierre > 0) 
            {                   
                if (decimal.Round(saldo_cierre, 2) != saldo_cierre)
                {
                    this.validacion.Add("Saldo Cierre", "El campo Saldo Cierre solo acepta valores con hasta dos decimales");
                }
            }   
            
        }

        // Manejo de errores. 
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

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }
    }
}
