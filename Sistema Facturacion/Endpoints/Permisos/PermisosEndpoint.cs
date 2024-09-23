using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Permiso;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Permisos
{
    public class PermisosEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/permisos", GetPermisos);
            app.MapPost("api/permisos", PostPermiso);
            app.MapGet("api/permisos/{id}", GetPermisoById);
            app.MapPut("api/permisos/{id}", UpdatePermiso);
        }

        private static async Task<IResult> GetPermisos(AppDbContext context)
        {
            var permisosEntity = await context.Permisos.ToListAsync();

            if (permisosEntity == null || permisosEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron permisos.");
            }

            var permisosDto = permisosEntity.Select(p => PermisoDto.FromEntity(p)).ToList();

            return Results.Ok(permisosDto);
        }

        private static async Task<IResult> GetPermisoById(string id, AppDbContext context)
        {
            var permisoEntity = await context.Permisos.FindAsync(id);

            if (permisoEntity == null)
            {
                return Results.NotFound("Permiso no encontrado.");
            }

            var permisoDto = PermisoDto.FromEntity(permisoEntity);
            return Results.Ok(permisoDto);
        }

        private static async Task<IResult> PostPermiso(PermisoDto permisoDto, AppDbContext context)
        {
            if (permisoDto == null)
            {
                return Results.BadRequest("El permiso no puede ser nulo.");
            }

            var permisoEntity = PermisoDto.ToEntity(permisoDto);
            permisoEntity.PermisoId = Guid.NewGuid().ToString();
            permisoEntity.FechaCreacion = DateTime.Now; 
            permisoEntity.Activo = 1; 

            await context.Permisos.AddAsync(permisoEntity);
            await context.SaveChangesAsync();

            return Results.Ok(permisoEntity);
        }

        private static async Task<IResult> UpdatePermiso(string id, PermisoDto permisoDto, AppDbContext context)
        {
            if (permisoDto == null)
            {
                return Results.BadRequest("El permiso no puede ser nulo.");
            }

            var permisoEntity = await context.Permisos.FindAsync(id);

            if (permisoEntity == null)
            {
                return Results.NotFound("Permiso no encontrado.");
            }

            
            permisoEntity.Nombre = permisoDto.Nombre;
            permisoEntity.Activo = permisoDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok(permisoEntity);
        }
    }
}
