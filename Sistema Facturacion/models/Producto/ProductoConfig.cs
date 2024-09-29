using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Facturacion.models.Producto;

namespace Sistema_Facturacion.Configurations
{
    public class ProductoConfig : IEntityTypeConfiguration<ProductoEntity>
    {
        public void Configure(EntityTypeBuilder<ProductoEntity> builder)
        {
            builder.ToTable("PRODUCTOS", "SISTEMAFACTURACION");

            builder.HasKey(p => p.ProductoId); 

            builder.Property(p => p.ProductoId)
                   .HasColumnName("PRODUCTO_ID")
                   .IsRequired();

            builder.Property(p => p.NombreProducto)
                   .HasColumnName("NOMBRE_PRODUCTO")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.PrecioProducto)
                   .HasColumnName("PRECIO_PRODUCTO")
                   .IsRequired(); 

            builder.Property(p => p.Descripcion)
                   .HasColumnName("DESCRIPCION")
                   .HasMaxLength(500); 

            builder.Property(p => p.FechaRegistro)
                   .HasColumnName("FECHA_REGISTRO")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP"); 

            builder.Property(p => p.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired(); 

            builder.Property(p => p.CategoriaId)
                   .HasColumnName("CATEGORIA_ID")
                   .IsRequired();

            builder.Property(p => p.Stock)
                   .HasColumnName("STOCK")
                   .IsRequired();
        }
    }
}
