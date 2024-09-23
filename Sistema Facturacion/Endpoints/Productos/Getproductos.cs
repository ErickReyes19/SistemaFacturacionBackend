using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Producto;

namespace Sistema_Facturacion.Endpoints.Productos
{
    public class ProductosEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/productos", GetProductos);
            app.MapPost("api/productos", PostProductos);
        }

        private static async Task<IResult> GetProductos(AppDbContext context)
        {
            var productos = await context.Productos.ToListAsync();

            if (productos == null || productos.Count.Equals(0))
            {
                return Results.NotFound("No se encontraron productos.");
            }

            return Results.Ok(productos);
        }

        private static async Task<IResult> PostProductos(AppDbContext context, ProductoEnitity nuevoProducto)
        {
            if (nuevoProducto == null)
            {
                return Results.BadRequest("El producto no puede ser nulo.");
            }

            await context.Productos.AddAsync(nuevoProducto);
            await context.SaveChangesAsync();

            return Results.Ok("");
        }
    }
}
