using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.MetodoPago;
using Microsoft.AspNetCore.Authorization; // Importante para la autorización
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.MetodoPago
{
    public class MetodoPagoEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            // Proteger cada endpoint con autorización
            app.MapGet("api/metodospago", GetMetodosPago).RequireAuthorization();
            app.MapPost("api/metodospago", PostMetodoPago).RequireAuthorization();
            app.MapGet("api/metodospago/{id}", GetMetodoPagoById).RequireAuthorization();
            app.MapPut("api/metodospago/{id}", UpdateMetodoPago).RequireAuthorization();
        }

        private static async Task<IResult> GetMetodosPago(AppDbContext context)
        {
            var metodosPagoEntity = await context.MetodoPagos.ToListAsync();

            if (metodosPagoEntity == null || metodosPagoEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron métodos de pago.");
            }

            var metodosPagoDto = metodosPagoEntity.Select(mp => MetodoPagoDto.FromEntity(mp)).ToList();

            return Results.Ok(metodosPagoDto);
        }

        private static async Task<IResult> GetMetodoPagoById(string id, AppDbContext context)
        {
            var metodoPagoEntity = await context.MetodoPagos.FindAsync(id);

            if (metodoPagoEntity == null)
            {
                return Results.NotFound("Método de pago no encontrado.");
            }

            var metodoPagoDto = MetodoPagoDto.FromEntity(metodoPagoEntity);
            return Results.Ok(metodoPagoDto);
        }

        private static async Task<IResult> PostMetodoPago(MetodoPagoDto metodoPagoDto, AppDbContext context)
        {
            if (metodoPagoDto == null)
            {
                return Results.BadRequest("El método de pago no puede ser nulo.");
            }

            var metodoPagoEntity = MetodoPagoDto.ToEntity(metodoPagoDto);
            metodoPagoEntity.MetodoPagoId = Guid.NewGuid().ToString();
            metodoPagoEntity.FechaCreacion = DateTime.Now;
            metodoPagoEntity.Activo = 1;

            await context.MetodoPagos.AddAsync(metodoPagoEntity);
            await context.SaveChangesAsync();

            return Results.Ok(metodoPagoEntity);
        }

        private static async Task<IResult> UpdateMetodoPago(string id, MetodoPagoDto metodoPagoDto, AppDbContext context)
        {
            if (metodoPagoDto == null)
            {
                return Results.BadRequest("El método de pago no puede ser nulo.");
            }

            var metodoPagoEntity = await context.MetodoPagos.FindAsync(id);

            if (metodoPagoEntity == null)
            {
                return Results.NotFound("Método de pago no encontrado.");
            }

            metodoPagoEntity.Nombre = metodoPagoDto.Nombre;
            metodoPagoEntity.Activo = metodoPagoDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok("Actualizado con exito");
        }
    }
}
