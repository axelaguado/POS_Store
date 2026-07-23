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
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsFormsApp1.CapaDatos
{
    // La clase MiDbContext en el contexto de Entity Framework (EF) cumple una función clave como el intermediario entre la base de datos y tu aplicación. 
    public class MiDbContext : DbContext {

        //El constructor llama al constructor base (DbContext) y pasa un nombre de cadena de conexión ("MiDbContext").
        //Esto indica a Entity Framework qué cadena de conexión utilizar para conectarse a la base de datos.
        public MiDbContext() : base("name=MiDbContext")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        // Seccion Persona.   
        public DbSet<Persona> Personas { get; set; }

        public DbSet<PersonaFisica> PersonasFisicas { get; set; }

        public DbSet<PersonaJuridica> PersonasJuridicas { get; set; }

        // Seccion Roles. 
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Usuario> Usuarios { get; set; } 
         
        // Informacion Persona y Usuario. 
        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<Tipo_usuario> Tipo_Usuarios { get; set; } 

        // Proceso Compra.  
        public DbSet<Compra> Compras { get; set; } 
        
        public DbSet<Detalle_compra> Detalles_compra { get; set; }

        public DbSet<Estado_compra> Estados_compra { get; set; } 

        // Proceso Gasto
        public DbSet<Gasto> Gastos {  get; set; }

        public DbSet<Categoria_gasto> Categorias_gasto { get; set; } 

        // Proceso Venta. 
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria_producto> Categorias { get; set; }

        public DbSet<Detalle_venta> Detalle_Ventas { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        // Proceso Caja
        public DbSet<Caja> Cajas { get; set; }

        public DbSet<Tipo_movimiento> Tipos_movimiento { get; set; }

        public DbSet<Movimiento_caja> Movimientos_caja { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            // ----------------------------------------------------- 

            // Persona.
            // Definir entidad.
            var personaConfig = modelBuilder.Entity<Persona>();

            // Primary Key.
            personaConfig.HasKey(p => p.id_persona); 

            // Otros mapeos.
            personaConfig.ToTable("Persona");
             
            // ----------------------------------------------------- 

            // PersonaFisica
            // Definir entidad
            var fisicaConfig = modelBuilder.Entity<PersonaFisica>();

            // Primary Key.
            fisicaConfig.HasKey(f => f.id_persona);

            // Relaciones
            fisicaConfig.HasRequired(f => f.persona) // La persona_fisica tiene una persona.
                        .WithOptional(p => p.persona_fisica); // La persona debe tener una persona_fisica.

            // Configurar propiedades
            fisicaConfig.Property(f => f.id_persona).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            fisicaConfig.Property(f => f.dni_persona).IsRequired();
            fisicaConfig.Property(f => f.nombre_persona).HasMaxLength(100).IsRequired();
            fisicaConfig.Property(f => f.apellido_persona).HasMaxLength(100).IsRequired();
            fisicaConfig.Property(f => f.fecha_nacimiento).IsRequired();
            fisicaConfig.Property(f => f.sexo).IsRequired();

            // Otros mapeos
            fisicaConfig.ToTable("Persona_fisica");

            // -----------------------------------------------------

            // PersonaJuridica
            // Definir entidad
            var juridicaConfig = modelBuilder.Entity<PersonaJuridica>();

            //
            juridicaConfig.HasKey(f => f.id_persona);

            juridicaConfig.HasRequired(j => j.persona) // La persona_juridica tiene una persona.
                          .WithOptional(p => p.persona_juridica); // La persona debe tener una persona_juridica

            // Configurar propiedades
            juridicaConfig.Property(j => j.id_persona).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            juridicaConfig.Property(j => j.razon_social).HasMaxLength(100).IsRequired();
            juridicaConfig.Property(j => j.nombre_comercial).HasMaxLength(100).IsRequired();
            juridicaConfig.Property(p => p.cuit).IsRequired();

            // Otros mapeos
            juridicaConfig.ToTable("Persona_juridica");

            // -----------------------------------------------------

            // Direccion
            // Definir entidad
            var direccionConfig = modelBuilder.Entity<Direccion>();

            // Primary Key
            direccionConfig.HasKey(d => d.id_direccion);

            // Relacion con Persona. 
            direccionConfig.HasRequired(d => d.persona)
                           .WithMany(p => p.direcciones)
                           .HasForeignKey(d => d.id_persona) 
                           .WillCascadeOnDelete(false);

            // Configurar propiedades
            direccionConfig.Property(d => d.cod_postal).IsRequired();
            direccionConfig.Property(d => d.calle).IsRequired().HasMaxLength(100);
            direccionConfig.Property(d => d.altura).IsRequired();
            direccionConfig.Property(d => d.piso).IsOptional();
            direccionConfig.Property(d => d.depto).IsOptional();

            // Otros mapeos
            direccionConfig.ToTable("Direccion");

            // -----------------------------------------------------

            // Contacto
            // Definir entidad
            var contactoConfig = modelBuilder.Entity<Contacto>();

            // Primary Key
            contactoConfig.HasKey(c => c.id_contacto);

            // Relacion con Persona. 
            contactoConfig.HasRequired(c => c.persona)
                          .WithMany(p => p.contactos)
                          .HasForeignKey(c => c.id_persona) 
                          .WillCascadeOnDelete(false); 

            // Configurar propiedades
            contactoConfig.Property(c => c.telefono).IsRequired();
            contactoConfig.Property(c => c.email).IsRequired().HasMaxLength(100);
            contactoConfig.Property(c => c.sitio_web).HasMaxLength(100);

            // Otros mapeos
            contactoConfig.ToTable("Contacto");

            // -----------------------------------------------------

            // Cliente
            // Definir entidad
            var clienteConfig = modelBuilder.Entity<Cliente>();

            // Configurar clave primaria
            clienteConfig.HasKey(c => c.id_cliente);

            // Configurar relaciones
            clienteConfig.HasRequired(c => c.persona) // Cliente requiere una Persona.
                         .WithMany(p => p.clientes)
                         .HasForeignKey(c => c.id_persona);
                        
            // Otros mapeos
            clienteConfig.ToTable("Cliente");

            // ---------------------------------------

            // Empleado
            // Definir entidad
            var empleadoConfig = modelBuilder.Entity<Empleado>();

            // Configurar clave primaria
            empleadoConfig.HasKey(c => c.id_empleado);

            // Configurar relaciones
            empleadoConfig.HasRequired(e => e.persona)
                          .WithMany(p => p.empleados)
                          .HasForeignKey(e => e.id_persona);
             
            // Otros mapeos
            empleadoConfig.ToTable("Empleado");

            // ---------------------------------------
            // Proveedor
            // Definir entidad
            var proveedorConfig = modelBuilder.Entity<Proveedor>();

            // Primary Key
            proveedorConfig.HasKey(pr => pr.id_proveedor);

            // Confiuracion de relaciones.
            proveedorConfig.HasRequired(pr => pr.persona) // El proveedor reuqiere una persona 
                           .WithMany(p => p.proveedores)
                           .HasForeignKey(p => p.id_persona); 

            // Propiedades. 
            proveedorConfig.Property(pr => pr.estado_proveedor).IsRequired();

            // Otros mapeos.
            proveedorConfig.ToTable("Proveedor");

            // --------------------------------------------

            // Ususario
            // Definir entidad
            var usuarioConfig = modelBuilder.Entity<Usuario>();

            // Primary Key
            usuarioConfig.HasKey(u => u.id_usuario);

            // Configurar relaciones
            // Relacion entre usuario y tipo_usuario.
            usuarioConfig.HasRequired(u => u.tipo_usuario)
                         .WithMany(tp => tp.usuarios)
                         .HasForeignKey(u => u.tipo_perfil)
                         .WillCascadeOnDelete(false);

            usuarioConfig.HasRequired(u => u.empleado)
                         .WithMany(e => e.usuarios)
                         .HasForeignKey(u => u.id_empleado)
                         .WillCascadeOnDelete(false);

            // Configurar propiedades 
            usuarioConfig.Property(u => u.username).HasMaxLength(100).IsRequired();
            usuarioConfig.Property(u => u.contraseña).HasMaxLength(100).IsRequired();
            usuarioConfig.Property(u => u.tipo_perfil).IsRequired();
            usuarioConfig.Property(u => u.estado).IsRequired();
             
            // Otros mapeos
            usuarioConfig.ToTable("Usuario");

            // --------------------------------------------  

            // Tipo_Usuario
            // Definir entidad
            var tipoUsuarioConfig = modelBuilder.Entity<Tipo_usuario>();

            // Primary Key
            tipoUsuarioConfig.HasKey(t => t.id_tipo);

            // Configurar propiedades
            tipoUsuarioConfig.Property(t => t.descripcion_tipo).HasMaxLength(50).IsRequired();

            // Otros mapeos
            tipoUsuarioConfig.ToTable("Tipo_usuario"); 

            // ----------------------------------------------------- 
            
            // Compra
            // Definir entidad 
            var compraConfig = modelBuilder.Entity<Compra>();

            // Confiuracion PK.
            compraConfig.HasKey(c => c.id_compra);

            // Configuracion de relaciones.
            compraConfig.HasRequired(c => c.proveedor) // El pedido tiene un proveedor
                        .WithMany(p => p.compras) // El proveedor puede tener muchos pedidos
                        .HasForeignKey(c => c.id_proveedor)  // FK en Pedido
                        .WillCascadeOnDelete(false);

            compraConfig.HasRequired(c => c.estado) // El pedido tiene un proveedor
                        .WithMany(e => e.compras) // El proveedor puede tener muchos pedidos
                        .HasForeignKey(c => c.estado_compra)  // FK en Pedido
                        .WillCascadeOnDelete(false);

            // Configuracion de propeidades.
            compraConfig.Property(p => p.fecha_emision).IsRequired();
            compraConfig.Property(p => p.fecha_confirmacion).IsOptional();
            compraConfig.Property(p => p.monto_total).IsRequired().HasPrecision(10, 2);
            compraConfig.Property(p => p.estado_compra).IsRequired();

            // Otros mapeos.
            compraConfig.ToTable("Compra");

            // --------------------------------------------

            // Detalle_pedido
            // Definir entidad 
            var detalleConfig = modelBuilder.Entity<Detalle_compra>();

            // Configuracion PK.
            detalleConfig.HasKey(d => d.id_detalle);

            // Configuracion de relaciones. 
            detalleConfig.HasRequired(d => d.producto)
                         .WithMany(p => p.detalles_compra)
                         .HasForeignKey(d => d.id_producto)
                         .WillCascadeOnDelete(false);

            detalleConfig.HasRequired(d => d.compra)
                         .WithMany(c => c.detalles_compra)
                         .HasForeignKey(d => d.id_compra)
                         .WillCascadeOnDelete(false);

            // Configuracion de propeidades. 
            detalleConfig.Property(d => d.cantidad_producto).IsRequired();
            detalleConfig.Property(d => d.subtotal_producto).IsRequired().HasPrecision(10, 2);
            detalleConfig.Property(d => d.informacion_acerca).IsOptional().HasMaxLength(100);

            // Otros mapeos.
            detalleConfig.ToTable("Detalle_compra");

            // --------------------------------------------

            // Estado_compra 
            // Definir entidad
            var estadoCompraConfig = modelBuilder.Entity<Estado_compra>();

            // Configurar clave primaria
            estadoCompraConfig.HasKey(e => e.id_estado);

            // Configurar propiedades
            estadoCompraConfig.Property(e => e.descripcion_estado).HasMaxLength(30).IsRequired();

            // Otros mapeos
            estadoCompraConfig.ToTable("Estado_compra");

            // --------------------------------------------

            // Producto
            // Definir entidad
            var productoConfig = modelBuilder.Entity<Producto>();

            // Configurar clave primaria
            productoConfig.HasKey(pr => pr.id_producto);

            // Configurar relaciones
            productoConfig.HasRequired(pr => pr.categoria)
                          .WithMany(cp => cp.productos)
                          .HasForeignKey(pr => pr.categoria_producto);

            // Configurar propiedades
            productoConfig.Property(pr => pr.marca_producto).HasMaxLength(50).IsRequired();
            productoConfig.Property(pr => pr.nombre_producto).HasMaxLength(50).IsRequired();
            productoConfig.Property(pr => pr.descripcion_producto).HasMaxLength(500).IsRequired();
            productoConfig.Property(pr => pr.contenido_producto).HasMaxLength(500).IsRequired();
            productoConfig.Property(pr => pr.stock_producto).IsRequired();
            productoConfig.Property(pr => pr.stock_minimo).IsRequired(); 
            productoConfig.Property(pr => pr.precio_costo).IsRequired();
            productoConfig.Property(pr => pr.precio_venta).IsRequired(); 
            productoConfig.Property(pr => pr.sku_producto).IsRequired();
            productoConfig.Property(pr => pr.estado_producto).IsRequired();
             
            // Otros mapeos
            productoConfig.ToTable("Producto");

            // -------------------------------------------------------------- 

            // Categoria_Producto
            // Definir entidad
            var categoriaProductoConfig = modelBuilder.Entity<Categoria_producto>();

            // Configurar clave primaria
            categoriaProductoConfig.HasKey(cp => cp.id_categoria);

            // Configurar propiedades
            categoriaProductoConfig.Property(cp => cp.descripcion_categoria).HasMaxLength(50).IsRequired();
            categoriaProductoConfig.Property(cp => cp.estado_categoria).IsRequired();

            // Otros mapeos
            categoriaProductoConfig.ToTable("Categoria_producto");

            // ----------------------------------------------------------------------

            // Categoria gasto
            var categoriaGastoonfig = modelBuilder.Entity<Categoria_gasto>();

            // Canfiguracion clave primaria
            categoriaGastoonfig.HasKey(cg => cg.id_categoria);

            // Configuracion de propiedades
            categoriaGastoonfig.Property(cg => cg.descripcion_categoria).HasMaxLength(50).IsRequired();
            categoriaGastoonfig.Property(cg => cg.estado_categoria).IsRequired();

            // Otros mapeos
            categoriaGastoonfig.ToTable("Categoria_gasto");
            // ----------------------------------------------------------------------

            // Gasto
            var gastoConfig = modelBuilder.Entity<Gasto>();

            // Configurar clave primaria
            gastoConfig.HasKey(g => g.id_gasto);

            // Configurar relaciones
            gastoConfig.HasRequired(g => g.categoria)
                          .WithMany(cg => cg.gastos)
                          .HasForeignKey(g => g.categoria_gasto);

            // Definimos las propieades
            gastoConfig.Property(g => g.fecha_registro).IsRequired();
            gastoConfig.Property(g => g.periodo_gasto).IsRequired();
            gastoConfig.Property(g => g.descripcion_gasto).HasMaxLength(200).IsRequired();
            gastoConfig.Property(g => g.monto_gasto).HasPrecision(10, 2).IsRequired();
            gastoConfig.Property(g => g.categoria_gasto).IsRequired();
            gastoConfig.Property(g => g.estado_gasto).IsRequired();
             
            gastoConfig.ToTable("Gasto");

            // ----------------------------------------------------------------------

            // Tipo Movimiento
            // Definir Entidad
            var tipoMovimientoConfig = modelBuilder.Entity<Tipo_movimiento>();

            tipoMovimientoConfig.HasKey(tm => tm.id_tipo);

            tipoMovimientoConfig.Property(tm => tm.descripcion_tipo).HasMaxLength(100).IsRequired();
            tipoMovimientoConfig.Property(tm => tm.estado_tipo).IsRequired();

            tipoMovimientoConfig.ToTable("Tipo_movimiento");

            // ----------------------------------------------------------------------

            // Movimiento Caja
            // Definir Entidad
            var movimientoConfig = modelBuilder.Entity<Movimiento_caja>();

            // Definimos la clave primaria.
            movimientoConfig.HasKey(m => m.id_movimiento);

            // Definimos las relaciones.
            movimientoConfig.HasRequired(m => m.caja)
                         .WithMany(c => c.movimientos)
                         .HasForeignKey(m => m.id_caja)
                         .WillCascadeOnDelete(false);

            movimientoConfig.HasRequired(m => m.tipo_movimiento)
                         .WithMany(tm => tm.movimientos_caja)
                         .HasForeignKey(m => m.id_tipo)
                         .WillCascadeOnDelete(false);

            // Definimos las propiedades.
            movimientoConfig.Property(m => m.monto_movimiento).HasPrecision(10, 2).IsRequired();
            movimientoConfig.Property(m => m.descripcion_movimiento).HasMaxLength(100).IsRequired();
            movimientoConfig.Property(m => m.fecha_movimiento).IsRequired();
            movimientoConfig.Property(m => m.estado_movimiento).IsRequired();

            // Mapeamos la tabla.
            movimientoConfig.ToTable("Movimiento_caja");

            // ----------------------------------------------------------------------

            // Caja
            // Definir Entidad
            var cajaConfig = modelBuilder.Entity<Caja>();

            // Definimos la clave primaria.
            cajaConfig.HasKey(c => c.id_caja);

            // Definimos las relaciones.
            cajaConfig.HasRequired(c => c.usuario)
                      .WithMany(u => u.cajas)
                      .HasForeignKey(c => c.id_usuario)
                      .WillCascadeOnDelete(false);

            // Definimos las propiedas.
            cajaConfig.Property(c => c.fecha_apertura).IsRequired();
            cajaConfig.Property(c => c.fecha_cierre);
            cajaConfig.Property(c => c.saldo_inicial).HasPrecision(10, 2).IsRequired();
            cajaConfig.Property(c => c.saldo_cierre).HasPrecision(10, 2);
            cajaConfig.Property(c => c.estado_caja).IsRequired();

            // Mapeamos la tabla
            cajaConfig.ToTable("Caja");

            // ----------------------------------------------------------------------

            // Venta
            // Definir entidad
            var ventaConfig = modelBuilder.Entity<Venta>();

            // Configurar clave primaria
            ventaConfig.HasKey(v => v.id_venta);

            // Configurar relaciones
            ventaConfig.HasRequired(v => v.cliente)
                       .WithMany(c => c.compras)
                       .HasForeignKey(v => v.id_cliente);

            ventaConfig.HasRequired(v => v.caja)
                       .WithMany(c => c.ventas)
                       .HasForeignKey(v => v.id_caja);

            // Configurar propiedades
            ventaConfig.Property(v => v.fecha_venta).IsRequired();
            ventaConfig.Property(v => v.monto_venta).HasPrecision(10, 2).IsRequired();
            ventaConfig.Property(v => v.estado_venta).IsRequired();

            // Otros mapeos
            ventaConfig.ToTable("Venta");

            // -------------------------------------------------------

            // Detalle_Venta
            // Definir entidad
            var detalleVentaConfig = modelBuilder.Entity<Detalle_venta>();

            // Configurar clave primaria
            detalleVentaConfig.HasKey(dv => dv.id_detalle);

            // Configurar relaciones
            detalleVentaConfig.HasRequired(dv => dv.venta)
                              .WithMany(v => v.detalles)
                              .HasForeignKey(dv => dv.id_venta);
             
            detalleVentaConfig.HasRequired(dv => dv.producto)
                              .WithMany(pr => pr.detalles_venta)
                              .HasForeignKey(dv => dv.id_producto);

            // Configurar propiedades
            detalleVentaConfig.Property(dv => dv.cantidad_producto).IsRequired();
            detalleVentaConfig.Property(dv => dv.precio_costo).HasPrecision(10, 2).IsRequired();
            detalleVentaConfig.Property(dv => dv.precio_unitario).HasPrecision(10, 2).IsRequired();
            detalleVentaConfig.Property(dv => dv.subtotal).HasPrecision(10, 2);

            // Otros mapeos
            detalleVentaConfig.ToTable("Detalle_venta");

            // -------------------------------------------------------

            // Faltan Cobro y Metodo de pago.

            // -------------------------------------------------------
        }

    }
    
}

