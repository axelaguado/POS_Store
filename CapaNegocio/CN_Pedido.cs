using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.CapaDatos;
using WindowsFormsApp1.CapaEntidad;

namespace WindowsFormsApp1.CapaNegocio
{
    public class CN_Pedido
    {

        private Dictionary<string, string> validacion;

        public CN_Pedido()
        {
            this.validacion = new Dictionary<string, string>();
        }

        public void CrearPedido(Pedido _pedido)
        {
            using (var context = new MiDbContext()) 
            {
                // Ejecutamos si el pedido supera la validacion. 
                PedidoDAO pedidoDAO = new PedidoDAO(context);
                pedidoDAO.Crear_pedido(_pedido); // Retornar el ID del pedido.
            }     
        }

        public int CrearPedidoCompleto(Proveedor _proveedor, Pedido _pedido, List<Articulo> _items, List<Detalle_pedido> _detalles)
        {
            // Limpiamos el dictionary de validacion.
            this.validacion.Clear();

            // Algunas entidades que vamos a necesitar.   
            CN_DetallePedido nuevoDetalle = new CN_DetallePedido();
            CN_Articulo nuevoArticulo = new CN_Articulo();

            // Validamos toda la bullshit.    
            nuevoDetalle.ValidarDetalles(_detalles);
            nuevoArticulo.ValidarCarrito(_items);  

            this.unirDiccionarios(nuevoDetalle.GetErrors());
            this.unirDiccionarios(nuevoArticulo.GetErrors());

            if (this.validacion.Count() == 0)
            {
                // Hacemos el proceso de creacion.
                using (var context = new MiDbContext())
                {
                    // Algunas entidades que vamos a necesitar.     
                    PedidoDAO pedidoDAO = new PedidoDAO(context);
                    
                    if (_proveedor.id_proveedor > 0) 
                    { 
                        _pedido.id_proveedor = _proveedor.id_proveedor;
                    }
                    else 
                    {
                        _pedido.proveedor = _proveedor;
                    }
                     
                    pedidoDAO.Crear_pedido(_pedido);

                    ArticuloDAO articuloDAO = new ArticuloDAO(context);
                    List<Articulo> listaArticulos = articuloDAO.Crear_articulos(_items);

                    Detalle_pedidoDAO detalleDAO = new Detalle_pedidoDAO(context);
                    List<Detalle_pedido> listaDetalles = nuevoDetalle.crearDetallesPedido(_detalles, listaArticulos, _pedido);

                    detalleDAO.Crear_detalles(listaDetalles); 

                    // Para ver la salida por consola de la consulta que se realiza y demas
                    foreach (var entry in context.ChangeTracker.Entries())
                    {
                        System.Diagnostics.Debug.WriteLine(
                            entry.Entity.GetType().Name + " - " + entry.State
                        );
                    } 

                    return context.SaveChanges(); ;
                }
            }
            else
            {
                return 0;
            }

        }

        public Dictionary<string, string> ValidarPedido(Pedido _pedido) 
        {
            this.validacion.Clear();
             
            this.validarFecha(_pedido.fecha_emision); 
            this.validarMonto(_pedido.monto_total); 
            this.validarEstado(_pedido.estado);

            return validacion;
        }

        public void validarFecha(DateTime _fecha)
        {
            if (_fecha > DateTime.Now)
            {
                validacion.Add("Fecha_emision", "La fecha de emision del pedido no puede ser posterior a la fecha presente"); 
            } 
        }

        public void validarMonto(decimal _monto)
        { 
            if(_monto < 0) 
            {
                validacion.Add("Monto_total", "El campo Monto no puede ser menor a cero");
            }  
        }

        public void validarEstado(int _estado)
        {
            using (var context = new MiDbContext()) 
            {
                EstadoPedidoDAO estado_Pedido = new EstadoPedidoDAO(context);

                if (estado_Pedido.buscarEstado(_estado) == null)
                {
                    validacion.Add("Pedido", "Estado del pedido no permitido");
                }
            }     
        }

        public Dictionary<string, string> GetEttores()
        {
            return this.validacion;
        }

        public List<Pedido> PedidosPendientes()
        {
            using (var context = new MiDbContext())
            {
                PedidoDAO pendientes = new PedidoDAO(context);
                return pendientes.ReadPedidosPendientes();
            }
        }

        public List<Pedido> PedidosConfirmados()
        { 
                using (var context = new MiDbContext())
                {
                    PedidoDAO pendientes = new PedidoDAO(context);
                    return pendientes.ReadPedidosConfirmados();
                } 
        } 

        public void CancelarPedido(int id_pedido) 
        {
            using (var context = new MiDbContext()) 
            {
                PedidoDAO pedido = new PedidoDAO(context);
                pedido.update_StateInactive(id_pedido);
                context.SaveChanges();
            } 
        }

        public void ConfirmarPedido(int id_pedido)
        {
            using (var context = new MiDbContext()) 
            {
                PedidoDAO pedido = new PedidoDAO(context);
                pedido.update_StateConfirmado(id_pedido);
                context.SaveChanges();
            } 
        }

        public Pedido BuscarPedido(long id_pedido)
        {
            using (var context = new MiDbContext()) 
            {
                PedidoDAO pedido = new PedidoDAO(context);
                return pedido.buscarPedido(id_pedido);
            } 
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

        public Dictionary<string, string> GetErrors()
        {
            return this.validacion;
        }
    }
}
