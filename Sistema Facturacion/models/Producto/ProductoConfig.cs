using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_Facturacion.models.Producto
{
    public class ProductoConfig : IEntityTypeConfiguration<ProductoEnitity>
    {
        public void Configure(EntityTypeBuilder<ProductoEnitity> builder)
        {
            builder.ToTable("PRODUCTOS", "SISTEMAFACTURACION"); // Especifica el esquema aquí

            builder.Property(p => p.Id)
                   .HasColumnName("ID_PRODUCTO")
                   .IsRequired();

            builder.Property(p => p.Nombre)
                   .HasColumnName("NOMBRE_PRODUCTO")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.Precio)
                   .HasColumnName("PRECIO_PRODUCTO")
                   .HasColumnType("NUMBER(10, 2)")
                   .IsRequired();
        }
    }
}
