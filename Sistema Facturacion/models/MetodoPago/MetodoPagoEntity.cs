namespace Sistema_Facturacion.models.MetodoPago
{
    public class MetodoPagoEntity
    {
        public required string MetodoPagoId { get; set; }
        public required string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; }
    }
}
