using Sistema_Facturacion.models.Categoria;

namespace Sistema_Facturacion.models.Producto
{
    public class ProductoDto
    {
        public string ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioProducto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }
        public string CategoriaId { get; set; } // Agregado
        public string CategoriaNombre { get; set; }
        public int Stock { get; set; }

        public static ProductoDto FromEntity(ProductoEntity entity)
        {
            return new ProductoDto
            {
                ProductoId = entity.ProductoId,
                NombreProducto = entity.NombreProducto,
                PrecioProducto = entity.PrecioProducto,
                Descripcion = entity.Descripcion,
                FechaRegistro = entity.FechaRegistro,
                Activo = entity.Activo == 1,
                CategoriaId = entity.Categoria?.CategoriaId, // Agregado
                CategoriaNombre = entity.Categoria?.Nombre,
                Stock = entity.Stock
            };
        }

        public static ProductoEntity ToEntity(ProductoDto dto)
        {
            return new ProductoEntity
            {
                ProductoId = dto.ProductoId,
                NombreProducto = dto.NombreProducto,
                PrecioProducto = dto.PrecioProducto,
                Descripcion = dto.Descripcion,
                FechaRegistro = dto.FechaRegistro,
                Activo = dto.Activo ? 1 : 0,
                CategoriaId = dto.CategoriaId, // Cambiado para usar CategoriaId
                Stock = dto.Stock
            };
        }
    }

    public class CategoriaDto
    {
        public string CategoriaId { get; set; }
        public string Nombre { get; set; }

        public static CategoriaDto FromEntity(CategoriaEntity entity)
        {
            return new CategoriaDto
            {
                CategoriaId = entity.CategoriaId,
                Nombre = entity.Nombre
            };
        }
    }
}
