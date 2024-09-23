using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Rol;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Roles
{
    public class RolesEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/roles", GetRoles);
            app.MapPost("api/roles", PostRol);
            app.MapGet("api/roles/{id}", GetRolById);
            app.MapPut("api/roles/{id}", UpdateRol);
        }

        private static async Task<IResult> GetRoles(AppDbContext context)
        {
            var rolesEntity = await context.Roles.ToListAsync();

            if (rolesEntity == null || rolesEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron roles.");
            }

            var rolesDto = rolesEntity.Select(r => RolDto.FromEntity(r)).ToList();

            return Results.Ok(rolesDto);
        }

        private static async Task<IResult> GetRolById(string id, AppDbContext context)
        {
            var rolEntity = await context.Roles.FindAsync(id);

            if (rolEntity == null)
            {
                return Results.NotFound("Rol no encontrado.");
            }

            var rolDto = RolDto.FromEntity(rolEntity);
            return Results.Ok(rolDto);
        }

        private static async Task<IResult> PostRol(RolDto rolDto, AppDbContext context)
        {
            if (rolDto == null)
            {
                return Results.BadRequest("El rol no puede ser nulo.");
            }

            var rolEntity = RolDto.ToEntity(rolDto);
            rolEntity.RolId = Guid.NewGuid().ToString();
            rolEntity.FechaCreacion = DateTime.Now; 
            rolEntity.Activo = 1;

            await context.Roles.AddAsync(rolEntity);
            await context.SaveChangesAsync();

            return Results.Ok(rolEntity);
        }

        private static async Task<IResult> UpdateRol(string id, RolDto rolDto, AppDbContext context)
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
            rolEntity.Activo = rolDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok(rolEntity);
        }
    }
}
