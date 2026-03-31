using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using System.Runtime.Remoting.Contexts;
using WindowsFormsApp1.DTO;
using System.Threading;
using iTextSharp.tool.xml.css;

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

        public async Task<List<ProveedorDTO>> listar_Proveedores(string razon_social, CancellationToken token)
        {
            /*
            return await _context.Proveedores.Include(p => p.persona)
                                        .Include(p => p.persona.persona_juridica)
                                        .Include(p => p.persona.contactos)
                                        .Include(p => p.persona.direcciones)
                                        .Where(p => (p.persona.persona_juridica.razon_social.Contains(razon_social))) 
                                        .OrderBy(p => p.persona.persona_juridica.razon_social)
                                        .ToListAsync(token);
            */
             
            return await _context.Proveedores.Where(p => (p.persona.persona_juridica.razon_social.Contains(razon_social))) 
                                        .OrderBy(p => p.persona.persona_juridica.razon_social)
                                        .Select(p => new ProveedorDTO
                                        {
                                            id_proveedor = p.id_proveedor,
                                            razon_social = p.persona.persona_juridica.razon_social,
                                            nombre_comercial = p.persona.persona_juridica.nombre_comercial,
                                            cuit = p.persona.persona_juridica.cuit,
                                            telefono = p.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                            email = p.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                            sitio_web = p.persona.contactos.Select(c => c.sitio_web).FirstOrDefault(),
                                            cod_postal = p.persona.direcciones.Select(d => d.cod_postal).FirstOrDefault(),
                                            calle = p.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                            altura = p.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                            piso = p.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                            depto = p.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                     }).ToListAsync(token);

        
        }
    }
}
