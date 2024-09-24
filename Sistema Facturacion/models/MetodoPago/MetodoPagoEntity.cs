namespace Sistema_Facturacion.models.MetodoPago
{
    public class MetodoPagoEntity
    {
        public string MetodoPagoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; }
    }
}
