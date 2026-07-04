using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Gasto
    {
        public Dictionary<string, string> validacion;

        public CN_Gasto() 
        { 
            this.validacion = new Dictionary<string, string>();
        }

        public int RegistrarGasto(Gasto nuevo) 
        {
            this.validacion.Clear();

            this.ValidarGasto(nuevo);

            if(this.validacion.Count == 0) 
            { 
                using (var _context = new MiDbContext()) 
                {
                    GastoDAO gastoaDAO = new GastoDAO(_context);
                    nuevo.fecha_registro = DateTime.Now;
                    nuevo.estado_gasto = true;
                    gastoaDAO.CrearGasto(nuevo);
                    return _context.SaveChanges();
                }
            }

            return 0;
        }

        public int UpdateGasto(Gasto gastoActualizar) 
        {
            this.validacion.Clear();

            this.ValidarGasto(gastoActualizar);

            if (this.validacion.Count == 0)
            {
                using (var _context = new MiDbContext())
                {
                    GastoDAO gastoaDAO = new GastoDAO(_context);
                    gastoaDAO.update_gasto(gastoActualizar);
                    return _context.SaveChanges();
                }
            }

            return 0;
        }
         
        public decimal MontoAcumuladoActivos(List<Gasto> gastos)
        {
            if (gastos == null)
            {
                return 0;
            }

            return gastos.
                        Where(g => g.estado_gasto == true).
                        Sum(g => g.monto_gasto);
        }

        public Gasto GetGasto(int id_gasto)
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.buscarId(id_gasto);
            }
        }

        public List<Gasto> AllGastos() 
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.get_AllGastos();
            }
        }

        // Implementacion de filtrado de gastos

        public List<Gasto> GetGastoFiltro(DateTime periodo) 
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.get_GastosFilter(periodo);
            }
        }

        public List<Gasto> GetGastoFiltro(int id_categoria)
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.get_GastosFilter(id_categoria);
            }
        }

        public List<Gasto> GetGastoFiltro(DateTime periodo_desde, DateTime periodo_hasta)
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.get_GastosFilter(periodo_desde, periodo_hasta);
            }
        }

        public List<Gasto> GetGastoFiltro(DateTime periodo_desde, DateTime periodo_hasta, int id_categoria)
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.get_GastosFilter(periodo_desde, periodo_hasta, id_categoria);
            }
        }

        public List<Gasto> GetGastoFiltro(DateTime periodo_desde, int id_categoria)
        {
            using (var _context = new MiDbContext())
            {
                GastoDAO gastoDAO = new GastoDAO(_context);
                return gastoDAO.get_GastosFilter(periodo_desde, id_categoria);
            }
        }

        public Dictionary<string, string> ValidarGasto(Gasto _gasto) 
        {
            this.validacion.Clear();

            this.ValidarPeriodo(_gasto.periodo_gasto);
            this.ValidarIdCategoria(_gasto.categoria_gasto);
            this.ValidarDescripcion(_gasto.descripcion_gasto);
            this.ValidarMonto(_gasto.monto_gasto);

            return this.validacion;

        }

        public void ValidarPeriodo(DateTime _periodo)
        {
            this.ValidarPeriordoMes(_periodo.Month);
            this.ValidarPeriordoAño(_periodo.Year);
        }

        public void ValidarPeriordoMes(int periodoMes)
        {
            if (periodoMes < 1 && periodoMes > 12)
            {
                this.validacion.Add("CBPeriodoMes", "Debe seleccionar un mes para el periodo."); 
            } 
        }

        public void ValidarPeriordoAño(int periodo)
        {
            int añoActual = DateTime.Now.Year;

            if (añoActual < (añoActual - 5) && añoActual > (añoActual + 5))
            {
                this.validacion.Add("CBPeriodoAño", "Debe seleccionar un mes para el periodo."); 
            }
        }

        public void ValidarCategoria(Categoria_gasto categoria)
        {
            if (categoria == null)
            {
                this.validacion.Add("Categoria", "No se encuentra iniciada la categoria");
            }
        }

        public void ValidarIdCategoria(int categoria_gasto)
        {
            if (categoria_gasto < 1)
            {
                this.validacion.Add("Categoria", "Categoria no valida");
            }
        }

        public void ValidarDescripcion(string descripcion)
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                this.validacion.Add("TBDescripcion", "El campo Descripcion es obligatorio.");
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(descripcion, @"^[a-zA-Z0-9\s\-,.]+$"))
            {
                this.validacion.Add("TBDescripcion", "El campo Descripcion solo puede caracteres alfabeticos, numericos, espacios y guiones.");
            } 
            else if (descripcion.Length >= 200)
            {
                this.validacion.Add("TBDescripcion", "La descirpcion supera el limite maximo de caracteres (100).");
            }
        }

        public void ValidarMonto(decimal monto_gasto)
        {
            if (monto_gasto <= 0)
            {
                this.validacion.Add("TBMonto", "El campo Monto debe ser mayor a cero.");
            }
            else if (!(decimal.Round(monto_gasto, 2) == monto_gasto))
            {
                this.validacion.Add("TBMonto", "El campo Monto debe ser un valor numerico con hasta dos decimales.");
            }
        }

        public Dictionary<string, string> GetErrores() 
        {
            return this.validacion;
        }

    }
}
