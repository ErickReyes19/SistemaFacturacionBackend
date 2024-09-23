namespace Sistema_Facturacion.models.Stock
{
    public class StockEntity
    {
        public string StockId { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
