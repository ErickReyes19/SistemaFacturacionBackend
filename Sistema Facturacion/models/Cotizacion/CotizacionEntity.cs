namespace Sistema_Facturacion.models.Cotizacion
{
    public class CotizacionEntity
    {
        public string CotizacionId { get; set; }      
        public string ClienteId { get; set; }         
        public string UsuarioId { get; set; }         
        public DateTime FechaCreacion { get; set; }   
        public DateTime Validez { get; set; }              
        public string Observacion { get; set; }       
        public decimal Total { get; set; }            
        public int Activo { get; set; }              
    }
}
