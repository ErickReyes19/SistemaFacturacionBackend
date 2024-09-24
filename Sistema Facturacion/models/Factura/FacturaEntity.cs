namespace Sistema_Facturacion.models.Factura
{
    public class FacturaEntity
    {
        public string FacturaId { get; set; }      
        public string ClienteId { get; set; }          
        public decimal Total { get; set; }         
        public string Estado { get; set; }         
        public string Notas { get; set; }          
        public decimal MontoPagado { get; set; }   
        public decimal Cambio { get; set; }        
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; }            
        public string IdMetodoPago { get; set; }   
        public string UsuarioId { get; set; }      
    }
}
