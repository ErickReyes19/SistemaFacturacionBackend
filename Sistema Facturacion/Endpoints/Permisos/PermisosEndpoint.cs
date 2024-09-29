using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Permiso;
using Sistema_Facturacion.models.Rol;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Permisos
{
    public class PermisosEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/permisos", GetPermisos).RequireAuthorization();
            app.MapGet("api/permisosactivos", GetPermisosActivos).RequireAuthorization();
            app.MapPost("api/permisos", PostPermiso).RequireAuthorization();
            app.MapGet("api/permisos/{id}", GetPermisoById).RequireAuthorization();
            app.MapPut("api/permisos/{id}", UpdatePermiso).RequireAuthorization();
            app.MapDelete("api/permisos/{id}", DeletePermiso).RequireAuthorization();
        }


        private static async Task<IResult> GetPermisosActivos(AppDbContext context)
        {
            var permisosEntity = await context.Permisos
                                           .Where(r => r.Activo == 1)
                                           .ToListAsync();

            if (permisosEntity == null || permisosEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron permisos activos.");
            }

            var permisosDto = permisosEntity.Select(r => PermisoDto.FromEntity(r)).ToList();

            return Results.Ok(permisosDto);
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

        private static async Task<IResult> DeletePermiso(string id, AppDbContext context)
        {
            var permisoEntity = await context.Permisos.FindAsync(id);

            if (permisoEntity == null)
            {
                return Results.NotFound("Permiso no encontrado.");
            }

            context.Permisos.Remove(permisoEntity);
            await context.SaveChangesAsync();

            return Results.Ok($"Permiso con ID {id} eliminado correctamente.");
        }
    }
}
