using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_Facturacion.models.DetalleCotizacion
{
    public class DetalleCotizacionConfig : IEntityTypeConfiguration<DetalleCotizacionEntity>
    {
        public void Configure(EntityTypeBuilder<DetalleCotizacionEntity> builder)
        {
            builder.ToTable("DETALLE_COTIZACION", "SISTEMAFACTURACION");

            builder.HasKey(dc => dc.DetalleCotizacionId);

            builder.Property(dc => dc.DetalleCotizacionId)
                   .HasColumnName("DETALLE_COTIZACION_ID")
                   .IsRequired();

            builder.Property(dc => dc.CotizacionId)
                   .HasColumnName("COTIZACION_ID")
                   .IsRequired();

            builder.Property(dc => dc.ProductoId)
                   .HasColumnName("PRODUCTO_ID")
                   .IsRequired();

            builder.Property(dc => dc.Cantidad)
                   .HasColumnName("CANTIDAD")
                   .IsRequired();

            builder.Property(dc => dc.Precio)
                   .HasColumnName("PRECIO")
                   .IsRequired();

            builder.Property(dc => dc.Subtotal)
                   .HasColumnName("SUBTOTAL")
                   .IsRequired();
        }
    }
}
