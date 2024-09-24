using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Stock;

namespace Sistema_Facturacion.Endpoints.Stock
{
    public class StockEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/stock", GetStock).RequireAuthorization();
            app.MapPost("api/stock", PostStock).RequireAuthorization();
            app.MapGet("api/stock/{id}", GetStockById).RequireAuthorization();
            app.MapPut("api/stock/{id}", UpdateStock).RequireAuthorization();
        }

        private static async Task<IResult> GetStock(AppDbContext context)
        {
            var stockItems = await context.Stock.ToListAsync();

            if (stockItems == null || stockItems.Count == 0)
            {
                return Results.NotFound("No se encontraron artículos en stock.");
            }

            var stockDtoList = stockItems.Select(item => new StockDto
            {
                StockId = item.StockId,
                ProductoId = item.ProductoId,
                Cantidad = item.Cantidad,
                FechaRegistro = item.FechaRegistro
            }).ToList();

            return Results.Ok(stockDtoList);
        }

        private static async Task<IResult> PostStock(StockDto stockDto, AppDbContext context)
        {
            if (stockDto == null)
            {
                return Results.BadRequest("El stock no puede ser nulo.");
            }

            var stockEntity = new StockEntity
            {
                StockId = Guid.NewGuid().ToString(),
                ProductoId = stockDto.ProductoId,
                Cantidad = stockDto.Cantidad,
                FechaRegistro = DateTime.Now
            };

            await context.Stock.AddAsync(stockEntity);
            await context.SaveChangesAsync();

            return Results.Ok( stockEntity);
        }

        private static async Task<IResult> GetStockById(string id, AppDbContext context)
        {
            var stockItem = await context.Stock.FindAsync(id);

            if (stockItem == null)
            {
                return Results.NotFound("Artículo de stock no encontrado.");
            }

            var stockDto = new StockDto
            {
                StockId = stockItem.StockId,
                ProductoId = stockItem.ProductoId,
                Cantidad = stockItem.Cantidad,
                FechaRegistro = stockItem.FechaRegistro
            };

            return Results.Ok(stockDto);
        }

        private static async Task<IResult> UpdateStock(string id, StockDto stockDto, AppDbContext context)
        {
            if (stockDto == null)
            {
                return Results.BadRequest("El stock no puede ser nulo.");
            }

            var stockItem = await context.Stock.FindAsync(id);
            if (stockItem == null)
            {
                return Results.NotFound("Artículo de stock no encontrado.");
            }

            stockItem.ProductoId = stockDto.ProductoId;
            stockItem.Cantidad = stockDto.Cantidad;
            stockItem.FechaRegistro = DateTime.Now;

            await context.SaveChangesAsync();

            return Results.NoContent();
        }
    }
}
