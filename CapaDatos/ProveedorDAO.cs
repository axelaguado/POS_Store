using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using System.Runtime.Remoting.Contexts;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.CapaDatos
{
    public class ProveedorDAO
    {
        private readonly MiDbContext _context;

        public ProveedorDAO(MiDbContext context) 
        { 
            this._context = context;    
        } 

        public void Crear_proveedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
        }

        public List<ProveedorDTO> Get_proveedores() 
        {
            return _context.Proveedores.Select(p => new ProveedorDTO
                                                    {
                                                         id_proveedor = p.id_proveedor,
                                                         razon_social = p.persona.persona_juridica.razon_social
                                                    })
                                        .ToList();
        }

        public Proveedor Get_proveedor(long id_proveedor)
        {
            return _context.Proveedores.Include(p => p.persona)
                                        .Include(p => p.persona.persona_juridica)
                                        .Include(p => p.persona.contactos) 
                                        .Include(p => p.persona.direcciones)
                                        .FirstOrDefault(p => p.id_proveedor == id_proveedor);
        }
    }
}
