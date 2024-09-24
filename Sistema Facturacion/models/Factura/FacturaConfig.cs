using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_Facturacion.models.Factura
{
    public class FacturaConfig : IEntityTypeConfiguration<FacturaEntity>
    {
        public void Configure(EntityTypeBuilder<FacturaEntity> builder)
        {
            builder.ToTable("FACTURAS", "SISTEMAFACTURACION");

            builder.HasKey(f => f.FacturaId);

            builder.Property(f => f.FacturaId)
                   .HasColumnName("FACTURA_ID")
                   .IsRequired();

            builder.Property(f => f.ClienteId)
                   .HasColumnName("CLIENTE_ID")
                   .IsRequired();

            builder.Property(f => f.Total)
                   .HasColumnName("TOTAL")
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(f => f.Estado)
                   .HasColumnName("ESTADO")
                   .HasMaxLength(50);

            builder.Property(f => f.Notas)
                   .HasColumnName("NOTAS")
                   .HasMaxLength(255);

            builder.Property(f => f.MontoPagado)
                   .HasColumnName("MONTO_PAGADO")
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(f => f.Cambio)
                   .HasColumnName("CAMBIO")
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(f => f.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(f => f.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();

            builder.Property(f => f.IdMetodoPago)
                   .HasColumnName("ID_METODO_PAGO")
                   .IsRequired();

            builder.Property(f => f.UsuarioId)
                   .HasColumnName("USUARIO_ID")
                   .IsRequired();
        }
    }
}
