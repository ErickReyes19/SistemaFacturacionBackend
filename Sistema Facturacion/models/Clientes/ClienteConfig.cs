namespace Sistema_Facturacion.models
{
    using global::Sistema_Facturacion.models.Clientes;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace Sistema_Facturacion.Configurations
    {
        public class ClienteConfig : IEntityTypeConfiguration<ClienteEntity>
        {
            public void Configure(EntityTypeBuilder<ClienteEntity> builder)
            {
                builder.ToTable("CLIENTES", "SISTEMAFACTURACION");

                builder.HasKey(c => c.ClienteId);

                builder.Property(c => c.ClienteId)
                       .HasColumnName("CLIENTE_ID")
                       .IsRequired();

                builder.Property(c => c.Nombre)
                       .HasColumnName("NOMBRE")
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(c => c.Apellido)
                       .HasColumnName("APELLIDO")
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(c => c.Correo)
                       .HasColumnName("CORREO")
                       .IsRequired()
                       .HasMaxLength(100)
                       .IsUnicode();

                builder.Property(c => c.Telefono)
                       .HasColumnName("TELEFONO")
                       .HasMaxLength(15);

                builder.Property(c => c.Direccion)
                       .HasColumnName("DIRECCION")
                       .HasMaxLength(255);

                builder.Property(c => c.Activo)
                       .HasColumnName("ACTIVO")
                       .IsRequired();

                builder.Property(c => c.Identidad)
                       .HasColumnName("IDENTIDAD")
                       .IsRequired();

                builder.Property(c => c.FechaRegistro)
                       .HasColumnName("FECHAREGISTRO")
                       .HasDefaultValueSql("CURRENT_TIMESTAMP");
            }
        }
    }

}
