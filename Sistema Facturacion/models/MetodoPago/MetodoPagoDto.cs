namespace Sistema_Facturacion.models.MetodoPago
{
    public class MetodoPagoDto
    {
        public required string MetodoPagoId { get; set; }  
        public required string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }  
        public bool Activo { get; set; }

        public static MetodoPagoDto FromEntity(MetodoPagoEntity metodoPago)
        {
            return new MetodoPagoDto
            {
                MetodoPagoId = metodoPago.MetodoPagoId, 
                Nombre = metodoPago.Nombre,
                FechaCreacion = metodoPago.FechaCreacion, 
                Activo = metodoPago.Activo == 1
            };
        }

      
        public static MetodoPagoEntity ToEntity(MetodoPagoDto metodoPagoDto)
        {
            return new MetodoPagoEntity
            {
                MetodoPagoId = metodoPagoDto.MetodoPagoId,  
                Nombre = metodoPagoDto.Nombre,
                FechaCreacion = metodoPagoDto.FechaCreacion,  
                Activo = metodoPagoDto.Activo ? 1 : 0
            };
        }
    }
}
