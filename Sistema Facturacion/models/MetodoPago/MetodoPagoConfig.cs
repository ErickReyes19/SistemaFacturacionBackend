namespace Sistema_Facturacion.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema_Facturacion.models.MetodoPago;

    public class MetodoPagoConfig : IEntityTypeConfiguration<MetodoPagoEntity>
    {
        public void Configure(EntityTypeBuilder<MetodoPagoEntity> builder)
        {
            builder.ToTable("METODOS_PAGO", "SISTEMAFACTURACION");

            builder.HasKey(m => m.MetodoPagoId);

            builder.Property(m => m.MetodoPagoId)
                   .HasColumnName("METODO_PAGO_ID")
                   .IsRequired();

            builder.Property(m => m.Nombre)
                   .HasColumnName("NOMBRE")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(m => m.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();

            builder.Property(m => m.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
