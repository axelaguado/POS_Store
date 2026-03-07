using System;
using System.Collections.Generic;
using System.Data.Entity;
using WindowsFormsApp1.CapaEntidad;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using System.Reflection.Emit;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.ModelConfiguration;
using System.Net.Http.Headers;

namespace WindowsFormsApp1.CapaDatos
{
    // La clase MiDbContext en el contexto de Entity Framework (EF) cumple una función clave como el intermediario entre la base de datos y tu aplicación. 
    public class MiDbContext : DbContext {

        //El constructor llama al constructor base (DbContext) y pasa un nombre de cadena de conexión ("MiDbContext").
        //Esto indica a Entity Framework qué cadena de conexión utilizar para conectarse a la base de datos.
        public MiDbContext() : base("name=MiDbContext"){ 
        
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<Detalle_venta> Detalle_Ventas { get; set; }

        public DbSet<Tipo_usuario> Tipo_Usuarios { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Detalle_pedido> Detalles_pedido { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Articulo> Articulos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Tipo_Usuario
            // Definir entidad
            var tipoUsuarioConfig = modelBuilder.Entity<Tipo_usuario>(); 

            // Configurar propiedades
            tipoUsuarioConfig.Property(t => t.descripcion_tipo).HasMaxLength(50).IsRequired();

            // Otros mapeos
            tipoUsuarioConfig.ToTable("Tipo_usuario");

            // --------------------------------------------------------------
            // Persona
            // Definir entidad
            var personaConfig = modelBuilder.Entity<Persona>();

            personaConfig.HasRequired(p => p.direccion) // La persona tiene una dirección
                         .WithMany(d => d.persona) // La dirección puede tener muchas personas
                         .HasForeignKey(p => p.id_direccion); // FK en Persona

            // Configurar propiedades
            personaConfig.Property(p => p.dni_persona).IsRequired();
            personaConfig.Property(p => p.nombre_persona).HasMaxLength(100).IsRequired();
            personaConfig.Property(p => p.apellido_persona).HasMaxLength(100).IsRequired();
            personaConfig.Property(p => p.fecha_nacimiento).IsRequired();
            personaConfig.Property(p => p.email).IsRequired(); 
            personaConfig.Property(p => p.telefono).IsRequired();
            personaConfig.Property(p => p.sexo).IsRequired();
            
            // Otros mapeos
            personaConfig.ToTable("Persona");

            // -----------------------------------------------------
            // Direccion
            // Definir entidad
            var direccionConfig = modelBuilder.Entity<Direccion>();
             

            // Configurar propiedades
            direccionConfig.Property( d => d.calle).IsRequired().HasMaxLength(100);
            direccionConfig.Property( d => d.altura).IsRequired();
            direccionConfig.Property( d => d.piso).IsOptional();
            direccionConfig.Property( d => d.depto).IsOptional();

            // Otros mapeos
            direccionConfig.ToTable("Direccion");

            // -----------------------------------------------------

            // Cliente
            // Definir entidad
            var clienteConfig = modelBuilder.Entity<Cliente>();

            // Configurar clave primaria
            clienteConfig.HasKey(c => c.id_cliente);

            // Configurar propiedades
            clienteConfig.Property(c => c.id_persona).IsRequired();

            // Configurar relaciones
            clienteConfig.HasRequired(c => c.persona)// Cliente requiere una Persona
                         .WithOptional(p => p.cliente);

            // Otros mapeos
            clienteConfig.ToTable("Cliente");

            // ---------------------------------------

            // Ususario
            // Definir entidad
            var usuarioConfig = modelBuilder.Entity<Usuario>();
             
            // Configurar propiedades
            usuarioConfig.Property(u => u.id_persona).IsRequired();
            usuarioConfig.Property( u => u.username).HasMaxLength(100).IsRequired();
            usuarioConfig.Property( u => u.contraseña).HasMaxLength(100).IsRequired();
            usuarioConfig.Property( u => u.tipo_perfil).IsRequired();
            usuarioConfig.Property(u => u.estado).IsRequired();

            // Configurar relaciones
            // Relacion entre usuario y tipo_usuario.
            usuarioConfig.HasRequired(u => u.tipo_usuario)
                         .WithMany(tp => tp.usuario)
                         .Map(m => m.MapKey("FK_usuario_tipo"));

            // Relacion entre usuario y persona.
            usuarioConfig.HasRequired(u => u.persona)
                         .WithOptional(p => p.usuario) 
                         .Map( m => m.MapKey("FK_usuario_persona"));

            // Falta la relacion con Venta.

            // Otros mapeos
            usuarioConfig.ToTable("Usuario");

            // --------------------------------------------

            var proveedorConfig = modelBuilder.Entity<Proveedor>();

            // Confiuracion PK.

            // Confiuracion de relaciones.
            proveedorConfig.HasRequired(p => p.direccion) // La persona tiene una dirección
                           .WithMany(d => d.proveedor) // La dirección puede tener muchas personas
                           .HasForeignKey(p => p.id_direccion); // FK en Proveedor

            // Configuracion de propeidades.
            proveedorConfig.Property(p => p.razon_social).IsOptional();
            proveedorConfig.Property(p => p.CUIT).IsOptional();
            proveedorConfig.Property(p => p.nombre_comercial).IsRequired();
            proveedorConfig.Property(p => p.cod_postal).IsRequired();
            proveedorConfig.Property(p => p.telefono).IsOptional();
            proveedorConfig.Property(p => p.email).IsOptional();
            proveedorConfig.Property(p => p.sitio_web).IsOptional();

            // Otros mapeos.
            proveedorConfig.ToTable("Proveedor");

            // --------------------------------------------

            var pedidoConfig = modelBuilder.Entity<Pedido>();

            // Confiuracion PK.
            pedidoConfig.HasKey(p => p.id_pedido);

            // Configuracion de relaciones.
            pedidoConfig.HasRequired(p => p.proveedor) // El pedido tiene un proveedor
                           .WithMany(p => p.pedido) // El proveedor puede tener muchos pedidos
                           .HasForeignKey(p => p.id_proveedor); // FK en Pedido

            // Configuracion de propeidades.
            pedidoConfig.Property(p => p.fecha_emision).IsRequired();
            pedidoConfig.Property(p => p.monto_total).IsRequired();
            pedidoConfig.Property(p => p.estado).IsRequired(); 

            // Otros mapeos.
            pedidoConfig.ToTable("Pedido");

            // --------------------------------------------

            var articuloConfig = modelBuilder.Entity<Articulo>();

            // Confiuracion PK.
            articuloConfig.HasKey(a => a.id_articulo);

            // Configuracion de propeidades.
            articuloConfig.Property(a => a.marca_articulo).IsOptional();
            articuloConfig.Property(a => a.nombre_articulo).IsOptional(); 
            articuloConfig.Property(a => a.descripcion_articulo).IsOptional();
            articuloConfig.Property(a => a.contenido_articulo).IsOptional();
            articuloConfig.Property(a => a.precio_unitario).IsRequired();

            // Otros mapeos.
            articuloConfig.ToTable("Articulo");

            // --------------------------------------------

            var detalleConfig = modelBuilder.Entity<Detalle_pedido>();

            // Configuracion PK.
            detalleConfig.HasKey(d => d.id_detalle);

            // Configuracion de relaciones. 
            detalleConfig.HasRequired(d => d.articulo)
                         .WithMany(a => a.detalle_pedido)
                         .HasForeignKey(d => d.id_articulo);

            detalleConfig.HasRequired(d => d.pedido)
                         .WithMany(p => p.detalle_pedido)
                         .HasForeignKey(d => d.id_pedido);

            // Configuracion de propeidades. 
            detalleConfig.Property(d => d.cantidad).IsRequired();

            // Otros mapeos.
            detalleConfig.ToTable("Detalle_pedido");

            // --------------------------------------------

            // Producto
            // Definir entidad
            var productoConfig = modelBuilder.Entity<Producto>();

            // Configurar clave primaria
            productoConfig.HasKey(pr => pr.id_producto);

            // Configurar propiedades
            productoConfig.Property(pr => pr.marca_producto).HasMaxLength(50).IsRequired();
            productoConfig.Property(pr => pr.modelo_producto).HasMaxLength(50).IsRequired();
            productoConfig.Property(pr => pr.descripcion_producto).HasMaxLength(500).IsRequired();
            productoConfig.Property(pr => pr.stock_producto).IsRequired();
            productoConfig.Property(pr => pr.stock_minimo).IsRequired();
            productoConfig.Property(pr => pr.precio_venta).IsRequired();
            productoConfig.Property(pr => pr.precio_costo).IsRequired();
            productoConfig.Property(pr => pr.imagen).IsRequired();
            productoConfig.Property(pr => pr.estado).IsRequired();

            // Configurar relaciones
            productoConfig.HasRequired(pr => pr.categoria)
                          .WithMany(cp => cp.productos)
                          .HasForeignKey(pr => pr.producto_categoria);
                          
            // Otros mapeos
            productoConfig.ToTable("Productos");

            // --------------------------------------------------------------

            // Categoria_Producto
            // Definir entidad
            var categoriaProductoConfig = modelBuilder.Entity<Categoria_producto>();

            // Configurar clave primaria
            categoriaProductoConfig.HasKey(cp => cp.id_categoria);

            // Configurar propiedades
            categoriaProductoConfig.Property(cp => cp.descripcion_categoria).HasMaxLength(50).IsRequired();


            // Otros mapeos
            categoriaProductoConfig.ToTable("Categorias_Productos");

            // ----------------------------------------------------------------------

            // Venta
            // Definir entidad
            var ventaConfig = modelBuilder.Entity<Venta>();

            // Configurar clave primaria
            ventaConfig.HasKey(v => v.id_venta);

            // Configurar propiedades
            ventaConfig.Property(v => v.fecha_venta).IsRequired();
            ventaConfig.Property(v => v.monto_venta).IsRequired();

            // Configurar relaciones
            ventaConfig.HasRequired(v => v.cliente)
                       .WithMany(c => c.compras)
                       .HasForeignKey(v => v.cliente_venta);

            /* 
             * ventaConfig.HasRequired(v => v.vendedor)
                       .WithMany(u => u.ventas)
                       .HasForeignKey(v => v.vendedor_venta);
            */

            // Otros mapeos
            ventaConfig.ToTable("Ventas");

            // -------------------------------------------------------

            // Detalle_Venta
            // Definir entidad
            var detalleVentaConfig = modelBuilder.Entity<Detalle_venta>();

            // Configurar clave primaria
            detalleVentaConfig.HasKey(dv => dv.id_detalle);

            // Configurar propiedades
            detalleVentaConfig.Property(dv => dv.cantidad_producto).IsRequired();
            detalleVentaConfig.Property(dv => dv.precio_unitario).IsRequired();
            detalleVentaConfig.Property(dv => dv.subtotal).IsRequired();

            // Configurar relaciones
            detalleVentaConfig.HasRequired(dv => dv.venta)
                              .WithMany(v => v.detalles)
                              .HasForeignKey(dv => dv.id_venta);

            detalleVentaConfig.HasRequired(dv => dv.producto)
                              .WithMany(pr => pr.ventas)
                              .HasForeignKey(dv => dv.id_producto);

            // Otros mapeos
            detalleVentaConfig.ToTable("Detalles_Ventas");
        }
    }
    
}

