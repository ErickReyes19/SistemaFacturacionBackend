using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
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
            app.MapGet("api/productos/{id}", GetProductoById);
            app.MapPut("api/productos/{id}", UpdateProducto);
        }

        private static async Task<IResult> GetProductos(AppDbContext context)
        {
            var productosEntity = await context.Productos.ToListAsync();

            if (productosEntity == null || productosEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron productos.");
            }

            var productosDto = productosEntity.Select(p => ProductoDto.FromEntity(p)).ToList();

            return Results.Ok(productosDto);
        }

        private static async Task<IResult> GetProductoById(string id, AppDbContext context)
        {
            var productoEntity = await context.Productos.FindAsync(id);

            if (productoEntity == null)
            {
                return Results.NotFound("Producto no encontrado.");
            }

            var productoDto = ProductoDto.FromEntity(productoEntity);
            return Results.Ok(productoDto);
        }

        private static async Task<IResult> PostProductos(ProductoDto productoDto, AppDbContext context)
        {
            if (productoDto == null)
            {
                return Results.BadRequest("El producto no puede ser nulo.");
            }

            var productoEntity = ProductoDto.ToEntity(productoDto);
            productoEntity.ProductoId = Guid.NewGuid().ToString();
            productoEntity.FechaRegistro = DateTime.Now; 
            productoEntity.Activo = 1;

            await context.Productos.AddAsync(productoEntity);
            await context.SaveChangesAsync();

            return Results.Created("Creado con exito", productoEntity);
        }

        private static async Task<IResult> UpdateProducto(string id, ProductoDto productoDto, AppDbContext context)
        {
            if (productoDto == null)
            {
                return Results.BadRequest("El producto no puede ser nulo.");
            }

            var productoEntity = await context.Productos.FindAsync(id);

            if (productoEntity == null)
            {
                return Results.NotFound("Producto no encontrado.");
            }

            // Actualizar los valores
            productoEntity.NombreProducto = productoDto.NombreProducto;
            productoEntity.PrecioProducto = productoDto.PrecioProducto;
            productoEntity.Descripcion = productoDto.Descripcion;
            productoEntity.CategoriaId = productoDto.CategoriaId;
            productoEntity.Activo = productoDto.Activo ? 1 : 0;


            await context.SaveChangesAsync();

            return Results.Ok(productoEntity);
        }
    }
}
