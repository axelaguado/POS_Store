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
using System.Net;

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
                                            estado = p.estado_proveedor,
                                        }).ToList();
        }

        public Proveedor Get_proveedor(int id_proveedor)
        {
            return _context.Proveedores.Include(p => p.persona)
                                        .Include(p => p.persona.persona_juridica)
                                        .Include(p => p.persona.contactos) 
                                        .Include(p => p.persona.direcciones)
                                        .FirstOrDefault(p => p.id_proveedor == id_proveedor);
        }

        public async Task<List<ProveedorDTO>> Get_proveedores(CancellationToken token, long cuit)
        {    
            return await _context.Proveedores.Where(p => (p.persona.persona_juridica.cuit.ToString().StartsWith(cuit.ToString())))  
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
                                            estado = p.estado_proveedor,
                                        }).ToListAsync(token); 
        }

        public async Task<List<ProveedorDTO>> Get_proveedores(CancellationToken token, string razon_social)
        {
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
                                            estado = p.estado_proveedor,
                                        }).ToListAsync(token);  
        }

        public Proveedor update_proveedor(Proveedor datos_modificados)
        {
            Proveedor proveedor_modificar = _context.Proveedores.FirstOrDefault(pr => pr.id_proveedor == datos_modificados.id_proveedor);

            if (proveedor_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(proveedor_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return proveedor_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }
    }
}
