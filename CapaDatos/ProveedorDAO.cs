using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaDatos
{
    public class ProveedorDAO
    {
        public int Crear_proveedor(Proveedor proveedor)
        {
            using (var context = new MiDbContext())
            {
                context.Proveedores.Add(proveedor);
                context.SaveChanges();
                return proveedor.id_proveedor;
            }
        }

        public Proveedor buscar_Razon(string _razonSocial)  
        {
            using (var context = new MiDbContext())
            {
                return context.Proveedores.FirstOrDefault(p => p.razon_social == _razonSocial);

            }
        }

        public Proveedor buscar_Proveedor(long _cuit)
        {
            

            using (var context = new MiDbContext())
            {
                return context.Proveedores.FirstOrDefault(p => p.CUIT == _cuit);

            }
        }

        public Proveedor buscar_Telefono(long _telefono)
        {
            using (var context = new MiDbContext())
            {    
                return context.Proveedores.FirstOrDefault(p => p.telefono == _telefono); 
            }
        }

        public Proveedor buscar_Email(string _email)
        {
            using (var context = new MiDbContext())
            {
                return context.Proveedores.FirstOrDefault(p => p.email.Equals(_email));
            }
        }

        public Proveedor buscar_NombreComercial(string _nombre)
        {
            using (var context = new MiDbContext())
            {
                return context.Proveedores.FirstOrDefault(p => p.nombre_comercial.Equals(_nombre));
            }
        }

    }
}
