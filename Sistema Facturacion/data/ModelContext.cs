﻿using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.Configurations;
using Sistema_Facturacion.models.Categoria;
using Sistema_Facturacion.models.Clientes;
using Sistema_Facturacion.models.Cotizacion;
using Sistema_Facturacion.models.DetalleCotizacion;
using Sistema_Facturacion.models.DetalleFactura;
using Sistema_Facturacion.models.Factura;
using Sistema_Facturacion.models.MetodoPago;
using Sistema_Facturacion.models.Permiso;
using Sistema_Facturacion.models.Producto;
using Sistema_Facturacion.models.Rol;
using Sistema_Facturacion.models.RolesPermiso;
using Sistema_Facturacion.models.Sistema_Facturacion.Configurations;
using Sistema_Facturacion.models.Stock;
using Sistema_Facturacion.models.Usuarios;

namespace Sistema_Facturacion.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductoEntity> Productos { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }
        public DbSet<StockEntity> Stock { get; set; }
        public DbSet<CategoriaEntity> Categorias { get; set; }
        public DbSet<RolEntity> Roles { get; set; }
        public DbSet<PermisoEntity> Permisos { get; set; }
        public DbSet<RolesPermisosEntity> RolesPermisos { get; set; }
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<MetodoPagoEntity> MetodoPagos { get; set; }
        public DbSet<CotizacionEntity> Cotizaciones { get; set; }
        public DbSet<DetalleCotizacionEntity> DetalleCotizacion { get; set; }
        public DbSet<FacturaEntity> Facturas { get; set; }
        public DbSet<DetalleFacturaEntity> DetalleFactura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductoConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new StockConfig());
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new RolConfig());
            modelBuilder.ApplyConfiguration(new PermisoConfig());
            modelBuilder.ApplyConfiguration(new RolesPermisosConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new MetodoPagoConfig());
            modelBuilder.ApplyConfiguration(new CotizacionConfig());
            modelBuilder.ApplyConfiguration(new DetalleCotizacionConfig());
            modelBuilder.ApplyConfiguration(new FacturaConfig());
            modelBuilder.ApplyConfiguration(new DetalleFacturaConfig());
        }
    }
}
