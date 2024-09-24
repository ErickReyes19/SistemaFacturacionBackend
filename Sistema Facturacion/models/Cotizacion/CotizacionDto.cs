namespace Sistema_Facturacion.models.Cotizacion
{
    public class CotizacionDto
    {
        public string CotizacionId { get; set; }  
        public string ClienteId { get; set; }     
        public string UsuarioId { get; set; }     
        public DateTime Validez { get; set; }     
        public string Observacion { get; set; }   
        public decimal Total { get; set; }        
        public bool Activo { get; set; }          

        public static CotizacionDto FromEntity(CotizacionEntity cotizacion)
        {
            return new CotizacionDto
            {
                CotizacionId = cotizacion.CotizacionId,  
                ClienteId = cotizacion.ClienteId,
                UsuarioId = cotizacion.UsuarioId,
                Validez = cotizacion.Validez,
                Observacion = cotizacion.Observacion,
                Total = cotizacion.Total,
                Activo = cotizacion.Activo == 1
            };
        }

        public static CotizacionEntity ToEntity(CotizacionDto cotizacionDto)
        {
            return new CotizacionEntity
            {
                CotizacionId = cotizacionDto.CotizacionId, 
                ClienteId = cotizacionDto.ClienteId,
                UsuarioId = cotizacionDto.UsuarioId,
                Validez = cotizacionDto.Validez,
                Observacion = cotizacionDto.Observacion,
                Total = cotizacionDto.Total,
                Activo = cotizacionDto.Activo ? 1 : 0
            };
        }
    }
}
