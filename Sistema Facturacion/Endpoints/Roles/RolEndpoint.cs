using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Rol;
using Sistema_Facturacion.models.RolesPermiso;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Roles
{
    public class RolesEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/roles", GetRoles).RequireAuthorization();
            app.MapGet("api/rolesActivo", GetRolesActivos).RequireAuthorization();
            app.MapPost("api/roles", PostRol).RequireAuthorization();
            app.MapGet("api/roles/{id}", GetRolById).RequireAuthorization();
            app.MapPut("api/roles/{id}", UpdateRol).RequireAuthorization();
        }

        private static async Task<IResult> GetRoles(AppDbContext context)
        {
            var rolesEntity = await context.Roles
                                           .Include(r => r.RolesPermisos) // Incluye los permisos
                                           .ThenInclude(rp => rp.Permiso) // Asegúrate de incluir la relación con Permiso
                                           .ToListAsync();

            if (rolesEntity == null || rolesEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron roles.");
            }

            // Mapea a DTO incluyendo solo los permisos activos
            var rolesDto = rolesEntity.Select(r =>
            {
                // Filtra solo los permisos activos
                var permisosIds = r.RolesPermisos
                                   .Where(rp => rp.Permiso.Activo == 1) // Filtra los permisos activos
                                   .Select(rp => rp.PermisoId)
                                   .ToList();

                return RolDto.FromEntity(r, permisosIds); // Asegúrate de que RolDto acepte permisos filtrados
            }).ToList();

            return Results.Ok(rolesDto);
        }

        private static async Task<IResult> GetRolesActivos(AppDbContext context)
        {
            var rolesEntity = await context.Roles
                                           .Where(r => r.Activo == 1)
                                           .ToListAsync();

            if (rolesEntity == null || rolesEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron roles activos.");
            }

            var rolesDto = rolesEntity.Select(r => RolDto.FromEntity(r)).ToList();

            return Results.Ok(rolesDto);
        }

        private static async Task<IResult> GetRolById(string id, AppDbContext context)
        {
            var rolEntity = await context.Roles
                                          .Include(r => r.RolesPermisos) // Incluye los permisos
                                          .FirstOrDefaultAsync(r => r.RolId == id);

            if (rolEntity == null)
            {
                return Results.NotFound("Rol no encontrado.");
            }

            var permisosIds = rolEntity.RolesPermisos.Select(rp => rp.PermisoId).ToList(); // Obtiene los permisos
            var rolDto = RolDto.FromEntity(rolEntity, permisosIds);
            return Results.Ok(rolDto);
        }

        private static async Task<IResult> PostRol(RolDto rolDto, AppDbContext context)
        {
            if (rolDto == null)
            {
                return Results.BadRequest("El rol no puede ser nulo.");
            }
            try
            {


            var rolEntity = RolDto.ToEntity(rolDto);
            rolEntity.RolId = Guid.NewGuid().ToString();
            rolEntity.FechaCreacion = DateTime.Now;
            rolEntity.Activo = 1;

            await context.Roles.AddAsync(rolEntity);
            await context.SaveChangesAsync();

            // Agregar los permisos asociados
            if (rolDto.PermisosIds != null && rolDto.PermisosIds.Any())
            {
                var permisos = rolDto.PermisosIds.Select(permisoId => new RolesPermisosEntity
                {
                    RolId = rolEntity.RolId,
                    PermisoId = permisoId,
                    FechaCreacion = DateTime.Now 
                });

                await context.RolesPermisos.AddRangeAsync(permisos);
                await context.SaveChangesAsync();
            }

            return Results.Ok("Rol Creado con exito");
            }catch(Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }

        private static async Task<IResult> UpdateRol(string id, RolDto rolDto, AppDbContext context)
        {
            try
            {
                if (rolDto == null)
                {
                    return Results.BadRequest("El rol no puede ser nulo.");
                }

                var rolEntity = await context.Roles.FindAsync(id);

                if (rolEntity == null)
                {
                    return Results.NotFound("Rol no encontrado.");
                }

                rolEntity.Nombre = rolDto.Nombre;
                rolEntity.Descripcion = rolDto.Descripcion;
                rolEntity.Activo = rolDto.Activo ? 1 : 0;

                await context.SaveChangesAsync();

                // Actualizar permisos (si se requiere)
                var existingPermisos = await context.RolesPermisos
                                                     .Where(rp => rp.RolId == rolEntity.RolId)
                                                     .ToListAsync();

                // Eliminar permisos existentes
                context.RolesPermisos.RemoveRange(existingPermisos);
                await context.SaveChangesAsync();

                // Agregar nuevos permisos
                if (rolDto.PermisosIds != null && rolDto.PermisosIds.Any())
                {
                    var permisos = rolDto.PermisosIds.Select(permisoId => new RolesPermisosEntity
                    {
                        RolId = rolEntity.RolId,
                        PermisoId = permisoId,
                        FechaCreacion = DateTime.Now
                    });

                    await context.RolesPermisos.AddRangeAsync(permisos);
                    await context.SaveChangesAsync();
                }

                return Results.Ok(rolEntity);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        }
    }
}
