using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Facturacion.models.Usuarios;

namespace Sistema_Facturacion.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<UsuarioEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioEntity> builder)
        {
            builder.ToTable("USUARIOS", "SISTEMAFACTURACION");

            builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.UsuarioId)
                   .HasColumnName("USUARIO_ID")
                   .IsRequired();

            builder.Property(u => u.Nombre)
                   .HasColumnName("NOMBRE")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Correo)
                   .HasColumnName("CORREO")
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode();

            builder.Property(u => u.Contrasena)
                   .HasColumnName("CONTRASENA")
                   .IsRequired()
                   .HasMaxLength(255); // Longitud máxima segura

            builder.Property(u => u.RolId)
                   .HasColumnName("ROL_ID")
                   .IsRequired();

            builder.Property(u => u.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(u => u.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();

            
            builder.HasOne(u => u.Rol) 
                   .WithMany(r => r.Usuarios) 
                   .HasForeignKey(u => u.RolId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
