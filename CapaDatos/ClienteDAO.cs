using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class ClienteDAO
    {
        private readonly MiDbContext _context;

        public ClienteDAO(MiDbContext context)
        {
            _context = context;
        }

        public void Crear_cliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        } 
    }
}
