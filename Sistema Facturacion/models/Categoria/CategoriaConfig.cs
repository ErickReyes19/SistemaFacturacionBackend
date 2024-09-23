using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Facturacion.models.Categoria;

namespace Sistema_Facturacion.Configurations
{
    public class CategoriaConfig : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {
            builder.ToTable("CATEGORIAS", "SISTEMAFACTURACION");

            builder.HasKey(c => c.CategoriaId);

            builder.Property(c => c.CategoriaId)
                   .HasColumnName("CATEGORIA_ID")
                   .IsRequired();

            builder.Property(c => c.Nombre)
                   .HasColumnName("NOMBRE")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Descripcion)
                   .HasColumnName("DESCRIPCION")
                   .HasMaxLength(255);

            builder.Property(c => c.FechaCreacion)
                   .HasColumnName("FECHA_CREACION")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.Activo)
                   .HasColumnName("ACTIVO")
                   .IsRequired();
        }
    }
}
