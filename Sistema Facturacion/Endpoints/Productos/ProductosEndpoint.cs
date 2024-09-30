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
            app.MapGet("api/productos", GetProductos).RequireAuthorization();
            app.MapGet("api/productosactivos", GetProductosActivos).RequireAuthorization();
            app.MapPost("api/productos", PostProductos).RequireAuthorization();
            app.MapGet("api/productos/{id}", GetProductoById).RequireAuthorization();
            app.MapPut("api/productos/{id}", UpdateProducto).RequireAuthorization();
        }

        private static async Task<IResult> GetProductos(AppDbContext context)
        {
            var productosEntity = await context.Productos
                .Include(p => p.Categoria) // Incluir la categoría
                .ToListAsync();

            if (productosEntity == null || productosEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron productos.");
            }

            // Mapear productos a DTOs, utilizando el método FromEntity
            var productosDto = productosEntity.Select(p => ProductoDto.FromEntity(p)).ToList();

            return Results.Ok(productosDto);
        }

        private static async Task<IResult> GetProductosActivos(AppDbContext context)
        {
            var productosEntity = await context.Productos
                .Include(p => p.Categoria) // Incluir la categoría
                .Where(p => p.Activo == 1)
                .ToListAsync();

            if (productosEntity == null || productosEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron productos.");
            }

            // Mapear productos a DTOs
            var productosDto = productosEntity.Select(p => ProductoDto.FromEntity(p)).ToList();

            return Results.Ok(productosDto);
        }

        private static async Task<IResult> GetProductoById(string id, AppDbContext context)
        {
            var productoEntity = await context.Productos
                .Include(p => p.Categoria) // Incluir la categoría
                .FirstOrDefaultAsync(p => p.ProductoId == id);

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
            try
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
            productoEntity.Stock = productoDto.Stock;


            await context.SaveChangesAsync();

            return Results.Ok(productoEntity);
            }
            catch(Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
