using Sistema_Facturacion.models.Clientes;

namespace Sistema_Facturacion.models.Stock
{
    public class StockDto
    {
        public string StockId { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }


        public static StockDto FromEntity(StockEntity stockEntity)
        {
            return new StockDto
            {
                StockId = stockEntity.StockId,
                ProductoId = stockEntity.ProductoId,
                Cantidad = stockEntity.Cantidad,
                FechaRegistro = stockEntity.FechaRegistro,
                
            };
        }

        public static StockEntity ToEntity(StockDto stockDto)
        {
            return new StockEntity
            {
                StockId = stockDto.StockId,
                ProductoId = stockDto.ProductoId,
                Cantidad = stockDto.Cantidad,
                FechaRegistro = stockDto.FechaRegistro,
            };
        }
    }


}
