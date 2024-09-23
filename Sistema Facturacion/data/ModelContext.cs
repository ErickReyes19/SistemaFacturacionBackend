using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.models.Clientes;
using Sistema_Facturacion.models.Producto;
using Sistema_Facturacion.models.Producto.Sistema_Facturacion.Configurations;

namespace Sistema_Facturacion.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductoEnitity> Productos { get; set; }
        public DbSet<ClienteEntity> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductoConfig());

            modelBuilder.ApplyConfiguration(new ClienteConfig());
        }
    }
}
