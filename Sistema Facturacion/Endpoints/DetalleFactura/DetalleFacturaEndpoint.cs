using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.DetalleFactura;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.DetalleFactura
{
    [Authorize]
    public class DetalleFacturaEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/detallefactura", GetDetallesFactura);
            app.MapPost("api/detallefactura", PostDetalleFactura);
            app.MapGet("api/detallefactura/{id}", GetDetalleFacturaById);
        }

        private static async Task<IResult> GetDetallesFactura(AppDbContext context)
        {
            var detallesFactura = await context.DetalleFactura.ToListAsync();

            if (detallesFactura == null || detallesFactura.Count == 0)
            {
                return Results.NotFound("No se encontraron detalles de factura.");
            }

            var detallesDto = detallesFactura.Select(df => DetalleFacturaDto.FromEntity(df)).ToList();

            return Results.Ok(detallesDto);
        }

        private static async Task<IResult> GetDetalleFacturaById(string id, AppDbContext context)
        {
            var detalleFactura = await context.DetalleFactura.FindAsync(id);

            if (detalleFactura == null)
            {
                return Results.NotFound("Detalle de factura no encontrado.");
            }

            var detalleDto = DetalleFacturaDto.FromEntity(detalleFactura);
            return Results.Ok(detalleDto);
        }

        private static async Task<IResult> PostDetalleFactura(DetalleFacturaDto detalleFacturaDto, AppDbContext context)
        {
            if (detalleFacturaDto == null)
            {
                return Results.BadRequest("El detalle de factura no puede ser nulo.");
            }

            var detalleFacturaEntity = DetalleFacturaDto.ToEntity(detalleFacturaDto);
            detalleFacturaEntity.DetalleFacturaId = Guid.NewGuid().ToString(); 

            await context.DetalleFactura.AddAsync(detalleFacturaEntity);
            await context.SaveChangesAsync();

            return Results.Ok(detalleFacturaEntity);
        }
    }
}
