using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_TipoMovimiento
    {
        public Dictionary<string, string> validacion;

        public CN_TipoMovimiento()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public int RegistrarTipo(Tipo_movimiento _nuevo)
        {

            if (this.ValidarTipo(_nuevo).Count == 0) 
            { 
                using (var _context = new MiDbContext())
                {
                    TipoMovimientoDAO tipoDAO = new TipoMovimientoDAO(_context);
                    _nuevo.estado_tipo = true;
                
                    tipoDAO.CrearTipo(_nuevo);

                    return _context.SaveChanges();
                } 
            }

            return 0;

        }

        public int EliminarTipo(Tipo_movimiento _actualizar)
        {
            using (var _context = new MiDbContext())
            {
                TipoMovimientoDAO tipoDAO = new TipoMovimientoDAO(_context);
                _actualizar.estado_tipo = false;

                tipoDAO.update_tipo(_actualizar);

                return _context.SaveChanges();
            }
        }

        public void AttachTipo(Tipo_movimiento _tipo) 
        {
            using ( var _context = new MiDbContext()) 
            {
                TipoMovimientoDAO tipo = new TipoMovimientoDAO(_context);
                tipo.Attach_tipo(_tipo);
            }
        }

        public Dictionary<string, string> ValidarTipo(Tipo_movimiento tipo)
        {
            this.validacion.Clear();

            if (string.IsNullOrEmpty(tipo.descripcion_tipo))
            {
                this.validacion.Add("Tipo Movimiento", "El atributo descripcion no puede estar vacio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(tipo.descripcion_tipo, @"^[a-zA-Z\s]+$"))
            {
                this.validacion.Add("Tipo Movimiento", "El atributo descripcion solo puede contener letras y espacios.");
            }
            else if (this.ObtenerTipo(tipo.descripcion_tipo) != null)
            {
                this.validacion.Add("Tipo Movimiento", "El tipo de movimiento ya existe.");
            }

            return this.validacion;
        }

        public Tipo_movimiento ObtenerTipo(string _categoria)
        {
            using (var _context = new MiDbContext())
            {
                TipoMovimientoDAO tipoDAO = new TipoMovimientoDAO(_context);
                return tipoDAO.GetTipo(_categoria);
            }
        }

        public Tipo_movimiento ObtenerTipo(int id_tipo)
        {
            using (var _context = new MiDbContext())
            {
                TipoMovimientoDAO tipoDAO = new TipoMovimientoDAO(_context);
                return tipoDAO.GetTipo(id_tipo);
            }
        }

        public List<Tipo_movimiento> ObtenerTipos() 
        {
            using (var _context = new MiDbContext())
            {
                TipoMovimientoDAO tipoDAO = new TipoMovimientoDAO(_context);
                return tipoDAO.GetAllTipos();
            }
        }

        public int UpdateTipo(Tipo_movimiento modificar)
        {
            using (var _context = new MiDbContext())
            {
                TipoMovimientoDAO tipoDAO = new TipoMovimientoDAO(_context);
                tipoDAO.update_tipo(modificar);
                return _context.SaveChanges();
            }
        }

    }
}
