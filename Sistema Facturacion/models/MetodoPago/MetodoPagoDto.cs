namespace Sistema_Facturacion.models.MetodoPago
{
    public class MetodoPagoDto
    {
        public string MetodoPagoId { get; set; }  // Agregado el ID
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }  // Agregada la FechaCreacion
        public bool Activo { get; set; }

        // Método para convertir desde la entidad hacia el DTO
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
