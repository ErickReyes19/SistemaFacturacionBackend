namespace Sistema_Facturacion.models.DetalleFactura
{
    public class DetalleFacturaDto
    {
        public string DetalleFacturaId { get; set; } 
        public decimal Subtotal { get; set; }        
        public decimal PrecioUnitario { get; set; }  
        public int Cantidad { get; set; }            
        public string ProductoId { get; set; }       
        public string FacturaId { get; set; }       

        public static DetalleFacturaDto FromEntity(DetalleFacturaEntity detalleFactura)
        {
            return new DetalleFacturaDto
            {
                DetalleFacturaId = detalleFactura.DetalleFacturaId,
                Subtotal = detalleFactura.Subtotal,
                PrecioUnitario = detalleFactura.PrecioUnitario,
                Cantidad = detalleFactura.Cantidad,
                ProductoId = detalleFactura.ProductoId,
                FacturaId = detalleFactura.FacturaId
            };
        }

        public static DetalleFacturaEntity ToEntity(DetalleFacturaDto detalleFacturaDto)
        {
            return new DetalleFacturaEntity
            {
                DetalleFacturaId = detalleFacturaDto.DetalleFacturaId,
                Subtotal = detalleFacturaDto.Subtotal,
                PrecioUnitario = detalleFacturaDto.PrecioUnitario,
                Cantidad = detalleFacturaDto.Cantidad,
                ProductoId = detalleFacturaDto.ProductoId,
                FacturaId = detalleFacturaDto.FacturaId
            };
        }
    }
}
