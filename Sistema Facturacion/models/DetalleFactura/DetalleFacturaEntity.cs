namespace Sistema_Facturacion.models.DetalleFactura
{
    public class DetalleFacturaEntity
    {
        public string DetalleFacturaId { get; set; } 
        public decimal Subtotal { get; set; }        
        public decimal PrecioUnitario { get; set; }  
        public int Cantidad { get; set; }            
        public string ProductoId { get; set; }       
        public string FacturaId { get; set; }        
    }
}
