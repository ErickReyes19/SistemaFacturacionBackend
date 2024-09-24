namespace Sistema_Facturacion.models.Factura
{
    public class FacturaDto
    {
        public string UsuarioId { get; set; }       
        public string FacturaId { get; set; }       
        public string ClienteId { get; set; }          
        public decimal Total { get; set; }          
        public string Estado { get; set; }          
        public string Notas { get; set; }           
        public decimal MontoPagado { get; set; }    
        public decimal Cambio { get; set; }         
        public DateTime FechaCreacion { get; set; } 
        public bool Activo { get; set; }            
        public string IdMetodoPago { get; set; }    

        public static FacturaDto FromEntity(FacturaEntity factura)
        {
            return new FacturaDto
            {
                FacturaId = factura.FacturaId,
                ClienteId = factura.ClienteId,
                Total = factura.Total,
                Estado = factura.Estado,
                Notas = factura.Notas,
                MontoPagado = factura.MontoPagado,
                Cambio = factura.Cambio,
                FechaCreacion = factura.FechaCreacion,
                Activo = factura.Activo == 1, 
                IdMetodoPago = factura.IdMetodoPago,
                UsuarioId = factura.UsuarioId
            };
        }

        public static FacturaEntity ToEntity(FacturaDto facturaDto)
        {
            return new FacturaEntity
            {
                FacturaId = facturaDto.FacturaId,
                ClienteId = facturaDto.ClienteId,
                Total = facturaDto.Total,
                Estado = facturaDto.Estado,
                Notas = facturaDto.Notas,
                MontoPagado = facturaDto.MontoPagado,
                Cambio = facturaDto.Cambio,
                FechaCreacion = facturaDto.FechaCreacion,
                Activo = facturaDto.Activo ? 1 : 0, 
                IdMetodoPago = facturaDto.IdMetodoPago,
                UsuarioId = facturaDto.UsuarioId
            };
        }
    }
}
