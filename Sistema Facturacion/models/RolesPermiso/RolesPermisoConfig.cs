using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Sistema_Facturacion.models.RolesPermiso
{
    public class RolesPermisosConfig : IEntityTypeConfiguration<RolesPermisosEntity>
    {
        public void Configure(EntityTypeBuilder<RolesPermisosEntity> builder)
        {
            builder.ToTable("ROLES_PERMISOS", "SISTEMAFACTURACION");

            builder.HasKey(rp => rp.Id);

            builder.Property(rp => rp.Id)
                   .HasColumnName("ID")
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(rp => rp.RolId)
                   .HasColumnName("ROL_ID")
                   .IsRequired();

            builder.Property(rp => rp.PermisoId)
                   .HasColumnName("PERMISO_ID")
                   .IsRequired();

            builder.Property(rp => rp.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
