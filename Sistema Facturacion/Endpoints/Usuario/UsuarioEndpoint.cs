using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Usuarios;

namespace Sistema_Facturacion.Endpoints.Usuario
{
    public class UsuarioEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/usuarios", GetUsuarios).RequireAuthorization();
            app.MapPost("api/usuarios", PostUsuario).RequireAuthorization();
            app.MapGet("api/usuarios/{id}", GetUsuarioById).RequireAuthorization();
            app.MapPut("api/usuarios/{id}", UpdateUsuario).RequireAuthorization();
        }

        private static async Task<IResult> GetUsuarios(AppDbContext context)
        {
            var usuarios = await context.Usuarios.ToListAsync();

            if (usuarios == null || usuarios.Count == 0)
            {
                return Results.NotFound("No se encontraron usuarios.");
            }

            var usuariosDto = usuarios.Select(u => new
            {
                u.UsuarioId,
                u.Nombre,
                u.Correo,
                u.RolId,
                u.FechaCreacion,
                Activo = u.Activo == 1 // Convierte int a bool
            }).ToList();

            return Results.Ok(usuariosDto);
        }

        private static async Task<IResult> PostUsuario(UsuarioDto usuarioDto, AppDbContext context)
        {
            if (usuarioDto == null)
            {
                return Results.BadRequest("El usuario no puede ser nulo.");
            }

            var usuarioEntity = UsuarioDto.ToEntity(usuarioDto);
            usuarioEntity.UsuarioId = Guid.NewGuid().ToString();
            usuarioEntity.Activo = 1;
            usuarioEntity.FechaCreacion = DateTime.Now;

            await context.Usuarios.AddAsync(usuarioEntity);
            await context.SaveChangesAsync();

            return Results.Ok(usuarioEntity);
        }


        private static async Task<IResult> GetUsuarioById(string id, AppDbContext context)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return Results.NotFound("Usuario no encontrado.");
            }

            var usuarioDto = new
            {
                usuario.UsuarioId,
                usuario.Nombre,
                usuario.Correo,
                usuario.RolId,
                usuario.FechaCreacion,
                Activo = usuario.Activo == 1
            };

            return Results.Ok(usuarioDto);
        }

        private static async Task<IResult> UpdateUsuario(string id, UsuarioDto usuarioDto, AppDbContext context)
        {
            if (usuarioDto == null)
            {
                return Results.BadRequest("El usuario no puede ser nulo.");
            }

            var usuarioEntity = await context.Usuarios.FindAsync(id);
            if (usuarioEntity == null)
            {
                return Results.NotFound("Usuario no encontrado.");
            }

            usuarioEntity.Nombre = usuarioDto.Nombre;
            usuarioEntity.Correo = usuarioDto.Correo;
            usuarioEntity.Contrasena = usuarioDto.Contrasena;
            usuarioEntity.RolId = usuarioDto.RolId;
            usuarioEntity.Activo = usuarioDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok(usuarioEntity);
        }
    }
}
