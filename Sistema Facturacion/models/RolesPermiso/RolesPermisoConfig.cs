using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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

      
        builder.HasOne(rp => rp.Rol) // Navegación hacia Rol
               .WithMany(r => r.RolesPermisos) // Navegación inversa hacia RolesPermisos
               .HasForeignKey(rp => rp.RolId)
               .OnDelete(DeleteBehavior.Cascade);

       
        builder.HasOne(rp => rp.Permiso) // Navegación hacia Permiso
               .WithMany(p => p.RolesPermisos) // Navegación inversa hacia RolesPermisos
               .HasForeignKey(rp => rp.PermisoId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
