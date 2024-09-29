using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.RolesPermiso;

namespace Sistema_Facturacion.Endpoints.RolesPermisos
{
    public class RolesPermisosEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapPost("api/roles-permisos/upsert", UpsertRolesPermisos).RequireAuthorization();
            app.MapGet("api/roles-permisos/{rolId}", GetPermisosPorRol).RequireAuthorization();
        }

        private static async Task<IResult> UpsertRolesPermisos(RolesPermisosUpsertDto rolesPermisosDto, AppDbContext context)
        {
            if (rolesPermisosDto == null)
            {
                return Results.BadRequest("Los datos de rol-permiso no pueden ser nulos.");
            }

            var existingRolesPermisos = await context.RolesPermisos
                .Where(rp => rp.RolId == rolesPermisosDto.RolId)
                .ToListAsync();

            // Eliminar permisos que no están en la lista nueva
            var permisosToRemove = existingRolesPermisos
                .Where(rp => !rolesPermisosDto.PermisosIds.Contains(rp.PermisoId))
                .ToList();

            context.RolesPermisos.RemoveRange(permisosToRemove);

            // Agregar o actualizar permisos
            foreach (var permisoId in rolesPermisosDto.PermisosIds)
            {
                if (!existingRolesPermisos.Any(rp => rp.PermisoId == permisoId))
                {
                    var rolesPermisosEntity = new RolesPermisosEntity
                    {
                        RolId = rolesPermisosDto.RolId,
                        PermisoId = permisoId,
                        FechaCreacion = DateTime.Now
                    };

                    await context.RolesPermisos.AddAsync(rolesPermisosEntity);
                }
            }

            await context.SaveChangesAsync();

            return Results.Ok("Permisos actualizados correctamente.");
        }

        private static async Task<IResult> GetPermisosPorRol(string rolId, AppDbContext context)
        {
            if (string.IsNullOrEmpty(rolId))
            {
                return Results.BadRequest("El ID del rol no puede ser nulo.");
            }

            var permisos = await context.RolesPermisos
                .Where(rp => rp.RolId == rolId)
                .Join(context.Permisos,
                      rp => rp.PermisoId,
                      p => p.PermisoId,
                      (rp, p) => new
                      {
                          rp.PermisoId,
                          p.Nombre,  
                      })
                .ToListAsync();

            if (permisos == null || permisos.Count == 0)
            {
                return Results.NotFound("No se encontraron permisos para este rol.");
            }

            return Results.Ok(permisos);
        }

    }


}
