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
                CategoriaNombre = entity.CategoriaId,
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
                CategoriaId = dto.CategoriaNombre,
                Stock = dto.Stock
            };
        }
    }
}
