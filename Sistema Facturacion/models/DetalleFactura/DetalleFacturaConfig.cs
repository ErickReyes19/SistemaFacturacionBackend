using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_Facturacion.models.DetalleFactura
{
    public class DetalleFacturaConfig : IEntityTypeConfiguration<DetalleFacturaEntity>
    {
        public void Configure(EntityTypeBuilder<DetalleFacturaEntity> builder)
        {
            builder.ToTable("DETALLE_FACTURA", "SISTEMAFACTURACION");

            builder.HasKey(d => d.DetalleFacturaId);

            builder.Property(d => d.DetalleFacturaId)
                   .HasColumnName("DETALLE_FACTURA_ID")
                   .IsRequired();

            builder.Property(d => d.Subtotal)
                   .HasColumnName("SUBTOTAL")
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.PrecioUnitario)
                   .HasColumnName("PRECIO_UNITARIO")
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(d => d.Cantidad)
                   .HasColumnName("CANTIDAD")
                   .IsRequired();

            builder.Property(d => d.ProductoId)
                   .HasColumnName("PRODUCTO_ID")
                   .IsRequired();

            builder.Property(d => d.FacturaId)
                   .HasColumnName("FACTURA_ID")
                   .IsRequired();
        }
    }
}
