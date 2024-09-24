namespace Sistema_Facturacion.models.DetalleCotizacion
{
    public class DetalleCotizacionDto
    {
        public string CotizacionId { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        public static DetalleCotizacionDto FromEntity(DetalleCotizacionEntity detalleCotizacion)
        {
            return new DetalleCotizacionDto
            {
                CotizacionId = detalleCotizacion.CotizacionId,
                ProductoId = detalleCotizacion.ProductoId,
                Cantidad = detalleCotizacion.Cantidad,
                Precio = detalleCotizacion.Precio,
                Subtotal = detalleCotizacion.Subtotal
            };
        }

        public static DetalleCotizacionEntity ToEntity(DetalleCotizacionDto detalleCotizacionDto)
        {
            return new DetalleCotizacionEntity
            {
                DetalleCotizacionId = Guid.NewGuid().ToString(),
                CotizacionId = detalleCotizacionDto.CotizacionId,
                ProductoId = detalleCotizacionDto.ProductoId,
                Cantidad = detalleCotizacionDto.Cantidad,
                Precio = detalleCotizacionDto.Precio,
                Subtotal = detalleCotizacionDto.Subtotal
            };
        }
    }
}
