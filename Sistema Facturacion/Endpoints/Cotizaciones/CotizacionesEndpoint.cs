using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Cotizacion;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Cotizaciones
{
    [Authorize]
    public class CotizacionesEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/cotizaciones", GetCotizaciones);
            app.MapPost("api/cotizaciones", PostCotizacion);
            app.MapGet("api/cotizaciones/{id}", GetCotizacionById);
            app.MapPut("api/cotizaciones/{id}", UpdateCotizacion);
        }

        private static async Task<IResult> GetCotizaciones(AppDbContext context)
        {
            var cotizacionesEntity = await context.Cotizaciones.ToListAsync();

            if (cotizacionesEntity == null || cotizacionesEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron cotizaciones.");
            }

            var cotizacionesDto = cotizacionesEntity.Select(c => CotizacionDto.FromEntity(c)).ToList();

            return Results.Ok(cotizacionesDto);
        }

        private static async Task<IResult> GetCotizacionById(string id, AppDbContext context)
        {
            var cotizacionEntity = await context.Cotizaciones.FindAsync(id);

            if (cotizacionEntity == null)
            {
                return Results.NotFound("Cotización no encontrada.");
            }

            var cotizacionDto = CotizacionDto.FromEntity(cotizacionEntity);
            return Results.Ok(cotizacionDto);
        }

        private static async Task<IResult> PostCotizacion(CotizacionDto cotizacionDto, AppDbContext context)
        {
            if (cotizacionDto == null)
            {
                return Results.BadRequest("La cotización no puede ser nula.");
            }

            var cotizacionEntity = CotizacionDto.ToEntity(cotizacionDto);
            cotizacionEntity.CotizacionId = Guid.NewGuid().ToString();
            cotizacionEntity.FechaCreacion = DateTime.Now; 
            cotizacionEntity.Activo = 1;

            await context.Cotizaciones.AddAsync(cotizacionEntity);
            await context.SaveChangesAsync();

            return Results.Ok(cotizacionEntity);
        }

        private static async Task<IResult> UpdateCotizacion(string id, CotizacionDto cotizacionDto, AppDbContext context)
        {
            if (cotizacionDto == null)
            {
                return Results.BadRequest("La cotización no puede ser nula.");
            }

            var cotizacionEntity = await context.Cotizaciones.FindAsync(id);

            if (cotizacionEntity == null)
            {
                return Results.NotFound("Cotización no encontrada.");
            }

            cotizacionEntity.ClienteId = cotizacionDto.ClienteId;
            cotizacionEntity.UsuarioId = cotizacionDto.UsuarioId;
            cotizacionEntity.Validez = cotizacionDto.Validez;
            cotizacionEntity.Observacion = cotizacionDto.Observacion;
            cotizacionEntity.Total = cotizacionDto.Total;
            cotizacionEntity.Activo = cotizacionDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok(cotizacionEntity);
        }
    }
}
