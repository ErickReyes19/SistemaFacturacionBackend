using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Facturacion.models.Rol;

namespace Sistema_Facturacion.Configurations
{
    public class RolConfig : IEntityTypeConfiguration<RolEntity>
    {
        public void Configure(EntityTypeBuilder<RolEntity> builder)
        {
            builder.ToTable("ROLES", "SISTEMAFACTURACION");
            
            builder.HasKey(r => r.RolId);

            builder.Property(r => r.RolId)
                   .HasColumnName("ROL_ID")
                   .IsRequired();

            builder.Property(r => r.Nombre)
                   .HasColumnName("NOMBRE")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(r => r.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();
        }
    }
}
