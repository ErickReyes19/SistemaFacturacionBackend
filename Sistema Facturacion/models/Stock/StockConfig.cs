namespace Sistema_Facturacion.models
{
    using global::Sistema_Facturacion.models.Stock;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace Sistema_Facturacion.Configurations
    {
        public class StockConfig : IEntityTypeConfiguration<StockEntity>
        {
            public void Configure(EntityTypeBuilder<StockEntity> builder)
            {
                builder.ToTable("STOCK", "SISTEMAFACTURACION");

                builder.HasKey(c => c.StockId);

                builder.Property(c => c.StockId)
                       .HasColumnName("STOCK_ID")
                       .IsRequired();

                builder.Property(c => c.ProductoId)
                       .HasColumnName("PRODUCTO_ID")
                       .IsRequired()
                       .HasMaxLength(100);

                builder.Property(c => c.Cantidad)
                       .HasColumnName("CANTIDAD")
                       .IsRequired();

                builder.Property(c => c.FechaRegistro)
                       .HasColumnName("FECHA_REGISTRO")
                       .HasDefaultValueSql("CURRENT_TIMESTAMP");
            }
        }
    }

}
