namespace Sistema_Facturacion.models.Producto
{
    public class ProductoEntity
    {
        public string ProductoId { get; set; }      
        public string NombreProducto { get; set; }   
        public decimal PrecioProducto { get; set; }  
        public string Descripcion { get; set; }      
        public DateTime FechaRegistro { get; set; }  
        public int Activo { get; set; }              
        public string CategoriaId { get; set; }             
        public int Stock { get; set; }      
    }
}
