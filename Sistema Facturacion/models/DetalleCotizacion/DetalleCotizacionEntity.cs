namespace Sistema_Facturacion.models.DetalleCotizacion
{
    public class DetalleCotizacionEntity
    {
        public string DetalleCotizacionId { get; set; }  
        public string CotizacionId { get; set; }        
        public string ProductoId { get; set; }          
        public int Cantidad { get; set; }               
        public decimal Precio { get; set; }             
        public decimal Subtotal { get; set; }           
    }
}
