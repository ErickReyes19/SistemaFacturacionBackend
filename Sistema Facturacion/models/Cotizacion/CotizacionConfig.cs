namespace Sistema_Facturacion.models.Cotizacion
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CotizacionConfig : IEntityTypeConfiguration<CotizacionEntity>
    {
        public void Configure(EntityTypeBuilder<CotizacionEntity> builder)
        {
            builder.ToTable("COTIZACIONES", "SISTEMAFACTURACION");

            builder.HasKey(c => c.CotizacionId);

            builder.Property(c => c.CotizacionId)
                   .HasColumnName("COTIZACION_ID")
                   .IsRequired();

            builder.Property(c => c.ClienteId)
                   .HasColumnName("CLIENTE_ID")
                   .IsRequired();

            builder.Property(c => c.UsuarioId)
                   .HasColumnName("USUARIO_ID")
                   .IsRequired();

            builder.Property(c => c.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP")
                   .IsRequired();

            builder.Property(c => c.Validez)
                   .HasColumnName("VALIDEZ")
                   .IsRequired();

            builder.Property(c => c.Observacion)
                   .HasColumnName("OBSERVACION")
                   .HasMaxLength(255);

            builder.Property(c => c.Total)
                   .HasColumnName("TOTAL")
                   .IsRequired();

            builder.Property(c => c.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();
        }
    }
}
