using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;
using WindowsFormsApp1.CapaNegocio;
using WindowsFormsApp1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading;
using System.Xml;

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

        public Cliente GetClienteFisico(int identificacion) 
        { 
            return _context.Clientes.Include(cl => cl.persona)
                                    .Include(cl => cl.persona.persona_fisica)
                                    .Include(cl => cl.persona.direcciones)
                                    .Include(cl => cl.persona.contactos)
                                    .FirstOrDefault(cl => cl.persona.persona_fisica.dni_persona == identificacion); 
                                     
        }

        public Cliente GetClienteJuridico(long identificacion)
        {
            return _context.Clientes.Include(cl => cl.persona)
                                    .Include(cl => cl.persona.persona_juridica)
                                    .Include(cl => cl.persona.direcciones)
                                    .Include(cl => cl.persona.contactos)
                                    .FirstOrDefault(cl => cl.persona.persona_juridica.cuit == identificacion);
                                    
        }

        public List<ClienteDTO> Get_Clientes()
        {
            return  _context.Clientes.OrderBy(p => p.id_persona)
                                        .Select(cl => new ClienteDTO
                                        {
                                            identificacion = cl.persona.persona_fisica != null? cl.persona.persona_fisica.dni_persona : cl.persona.persona_juridica.cuit,
                                            cliente = cl.persona.persona_fisica != null ? (cl.persona.persona_fisica.apellido_persona + ", " + cl.persona.persona_fisica.nombre_persona) : cl.persona.persona_juridica.razon_social,
                                            telefono = cl.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                            email = cl.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                            codPostal = cl.persona.direcciones.Select(c => c.cod_postal).FirstOrDefault(),
                                            calle = cl.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                            altura = cl.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                            piso = cl.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                            depto = cl.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                            estado = cl.estado_cliente
                                         }).ToList();
        }

        public async Task<List<ClienteDTO>> Get_ClientesIdentificacion(CancellationToken token, long identificacion)
        { 
            return await _context.Clientes.Where(cl => ((cl.persona.persona_fisica != null) && (cl.persona.persona_fisica.dni_persona.ToString().StartsWith(identificacion.ToString()))) || ((cl.persona.persona_juridica != null) && (cl.persona.persona_juridica.cuit.ToString().StartsWith(identificacion.ToString()))))
                                          .OrderBy(cl => cl.id_cliente)
                                          .Select(cl => new ClienteDTO
                                          {
                                                identificacion = cl.persona.persona_fisica != null ? cl.persona.persona_fisica.dni_persona : cl.persona.persona_juridica.cuit,
                                                cliente = cl.persona.persona_fisica != null ? (cl.persona.persona_fisica.apellido_persona + ", " + cl.persona.persona_fisica.nombre_persona) : cl.persona.persona_juridica.razon_social,
                                                telefono = cl.persona.contactos.Select(c => c.telefono).FirstOrDefault(),
                                                email = cl.persona.contactos.Select(c => c.email).FirstOrDefault(),
                                                codPostal = cl.persona.direcciones.Select(c => c.cod_postal).FirstOrDefault(),
                                                calle = cl.persona.direcciones.Select(d => d.calle).FirstOrDefault(),
                                                altura = cl.persona.direcciones.Select(d => d.altura).FirstOrDefault(),
                                                piso = cl.persona.direcciones.Select(d => d.piso).FirstOrDefault(),
                                                depto = cl.persona.direcciones.Select(d => d.depto).FirstOrDefault(),
                                                estado = cl.estado_cliente
                                          }).ToListAsync(token);   
        }
         
        // -- UPDATE --
        public Cliente update_cliente(Cliente datos_modificados)
        {
            Cliente cliente_modificar = _context.Clientes.FirstOrDefault(cl => cl.id_cliente == datos_modificados.id_cliente);

            if (cliente_modificar != null)
            {
                // Entry: Proporciona acceso a la información sobre el estado de la entidad (usuario_modificar) en el contexto de EF.
                // Esto incluye su estado (por ejemplo, Unchanged, Modified, Deleted, etc.) y sus valores actuales y originales.
                // CurrentValues --> propiedad de entry que devuelve los valores actuales.
                // SetValues: este metodo nos permite asignar/modificar valores al entry.  
                _context.Entry(cliente_modificar).CurrentValues.SetValues(datos_modificados);
            }

            return cliente_modificar; // si entro en el if tiene los datos actualizados, caso contrario no se encontro el usuario a modificar. 
        }
    }
}
 