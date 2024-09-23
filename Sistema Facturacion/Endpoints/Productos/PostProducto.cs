using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Producto;

namespace Sistema_Facturacion.Endpoints.Productos
{
    public class PostProducto
    {

        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapPost ("api/productos", GetProductos);
        }
        private static async Task<IResult> GetProductos(AppDbContext context, ProductoEnitity nuevoProducto)
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

