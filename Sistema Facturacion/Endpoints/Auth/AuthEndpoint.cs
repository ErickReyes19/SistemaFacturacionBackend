using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Auth;

namespace Sistema_Facturacion.Endpoints.Auth
{
    public class AuthEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapPost("api/auth/login", Login);
        }

        private static async Task<IResult> Login(LoginDto loginDto, AppDbContext context, AuthService authService)
        {
            // Verificar las credenciales del usuario
            var usuario = await context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == loginDto.Correo && u.Contrasena == loginDto.Contrasena);

            if (usuario == null)
            {
                return Results.Unauthorized();
            }

            var permisos = await (from rp in context.RolesPermisos
                                  join p in context.Permisos on rp.PermisoId equals p.PermisoId
                                  where rp.RolId == usuario.RolId
                                  select p.Nombre 
                                 ).ToListAsync();

            var token = authService.GenerateToken(usuario.UsuarioId,usuario.Nombre, permisos);

            return Results.Ok(new { token });
        }


    }
}
