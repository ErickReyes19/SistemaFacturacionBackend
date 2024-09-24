
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Categoria;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Categoria
{
    public class CategoriasEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/categorias", GetCategorias).RequireAuthorization();
            app.MapPost("api/categorias", PostCategoria).RequireAuthorization();
            app.MapGet("api/categorias/{id}", GetCategoriaById).RequireAuthorization();
            app.MapPut("api/categorias/{id}", UpdateCategoria).RequireAuthorization();
        }

        private static async Task<IResult> GetCategorias(AppDbContext context)
        {
            var categoriasEntity = await context.Categorias.ToListAsync();

            if (categoriasEntity == null || categoriasEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron categorías.");
            }

            var categoriasDto = categoriasEntity.Select(c => CategoriaDto.FromEntity(c)).ToList();

            return Results.Ok(categoriasDto);
        }

        private static async Task<IResult> GetCategoriaById(string id, AppDbContext context)
        {
            var categoriaEntity = await context.Categorias.FindAsync(id);

            if (categoriaEntity == null)
            {
                return Results.NotFound("Categoría no encontrada.");
            }

            var categoriaDto = CategoriaDto.FromEntity(categoriaEntity);
            return Results.Ok(categoriaDto);
        }

        private static async Task<IResult> PostCategoria(CategoriaDto categoriaDto, AppDbContext context)
        {
            if (categoriaDto == null)
            {
                return Results.BadRequest("La categoría no puede ser nula.");
            }

            var categoriaEntity = CategoriaDto.ToEntity(categoriaDto);
            categoriaEntity.CategoriaId = Guid.NewGuid().ToString();
            categoriaEntity.FechaCreacion = DateTime.Now;
            categoriaEntity.Activo = 1;

            await context.Categorias.AddAsync(categoriaEntity);
            await context.SaveChangesAsync();

            return Results.Created("Creado con exito", categoriaEntity);
        }

        private static async Task<IResult> UpdateCategoria(string id, CategoriaDto categoriaDto, AppDbContext context)
        {
            if (categoriaDto == null)
            {
                return Results.BadRequest("La categoría no puede ser nula.");
            }

            var categoriaEntity = await context.Categorias.FindAsync(id);

            if (categoriaEntity == null)
            {
                return Results.NotFound("Categoría no encontrada.");
            }

            // Actualizar los valores
            categoriaEntity.Nombre = categoriaDto.Nombre;
            categoriaEntity.Descripcion = categoriaDto.Descripcion;
            categoriaEntity.Activo = categoriaDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok(categoriaEntity);
        }
    }
}
