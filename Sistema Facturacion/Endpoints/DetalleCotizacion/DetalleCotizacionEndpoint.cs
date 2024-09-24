using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.DetalleCotizacion;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.DetalleCotizacion
{
    [Authorize]
    public class DetalleCotizacionEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/detallecotizacion", GetDetallesCotizacion);
            app.MapPost("api/detallecotizacion", PostDetalleCotizacion);
            app.MapGet("api/detallecotizacion/{id}", GetDetalleCotizacionById);
        }

        private static async Task<IResult> GetDetallesCotizacion(AppDbContext context)
        {
            var detallesCotizacion = await context.DetalleCotizacion.ToListAsync();

            if (detallesCotizacion == null || detallesCotizacion.Count == 0)
            {
                return Results.NotFound("No se encontraron detalles de cotización.");
            }

            var detallesDto = detallesCotizacion.Select(dc => DetalleCotizacionDto.FromEntity(dc)).ToList();

            return Results.Ok(detallesDto);
        }

        private static async Task<IResult> GetDetalleCotizacionById(string id, AppDbContext context)
        {
            var detalleCotizacion = await context.DetalleCotizacion.FindAsync(id);

            if (detalleCotizacion == null)
            {
                return Results.NotFound("Detalle de cotización no encontrado.");
            }

            var detalleDto = DetalleCotizacionDto.FromEntity(detalleCotizacion);
            return Results.Ok(detalleDto);
        }

        private static async Task<IResult> PostDetalleCotizacion(DetalleCotizacionDto detalleCotizacionDto, AppDbContext context)
        {
            if (detalleCotizacionDto == null)
            {
                return Results.BadRequest("El detalle de cotización no puede ser nulo.");
            }

            var detalleCotizacionEntity = DetalleCotizacionDto.ToEntity(detalleCotizacionDto);
            detalleCotizacionEntity.DetalleCotizacionId = Guid.NewGuid().ToString(); // Generar nuevo ID

            await context.DetalleCotizacion.AddAsync(detalleCotizacionEntity);
            await context.SaveChangesAsync();

            return Results.Ok(detalleCotizacionEntity);
        }
    }
}
