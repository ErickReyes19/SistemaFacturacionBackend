using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Facturacion.models.Permiso;

namespace Sistema_Facturacion.Configurations
{
    public class PermisoConfig : IEntityTypeConfiguration<PermisoEntity>
    {
        public void Configure(EntityTypeBuilder<PermisoEntity> builder)
        {
            builder.ToTable("PERMISOS", "SISTEMAFACTURACION");

            builder.HasKey(p => p.PermisoId); 

            builder.Property(p => p.PermisoId)
                   .HasColumnName("PERMISO_ID")
                   .IsRequired();

            builder.Property(p => p.Nombre)
                   .HasColumnName("NOMBRE")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();
        }
    }
}
