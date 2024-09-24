using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Factura;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema_Facturacion.Endpoints.Factura
{
    public class FacturasEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/facturas", GetFacturas).RequireAuthorization();
            app.MapPost("api/facturas", PostFactura).RequireAuthorization();
            app.MapGet("api/facturas/{id}", GetFacturaById).RequireAuthorization();
            app.MapPut("api/facturas/{id}", UpdateFactura).RequireAuthorization();
        }

        private static async Task<IResult> GetFacturas(AppDbContext context)
        {
            var facturasEntity = await context.Facturas.ToListAsync();

            if (facturasEntity == null || facturasEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron facturas.");
            }

            var facturasDto = facturasEntity.Select(f => FacturaDto.FromEntity(f)).ToList();

            return Results.Ok(facturasDto);
        }

        private static async Task<IResult> GetFacturaById(string id, AppDbContext context)
        {
            var facturaEntity = await context.Facturas.FindAsync(id);

            if (facturaEntity == null)
            {
                return Results.NotFound("Factura no encontrada.");
            }

            var facturaDto = FacturaDto.FromEntity(facturaEntity);
            return Results.Ok(facturaDto);
        }

        private static async Task<IResult> PostFactura(FacturaDto facturaDto, AppDbContext context)
        {
            if (facturaDto == null)
            {
                return Results.BadRequest("La factura no puede ser nula.");
            }

            var facturaEntity = FacturaDto.ToEntity(facturaDto);
            facturaEntity.FacturaId = Guid.NewGuid().ToString();
            facturaEntity.FechaCreacion = DateTime.Now;
            facturaEntity.Activo = 1;

            await context.Facturas.AddAsync(facturaEntity);
            await context.SaveChangesAsync();

            return Results.Ok(facturaEntity);
        }

        private static async Task<IResult> UpdateFactura(string id, FacturaDto facturaDto, AppDbContext context)
        {
            if (facturaDto == null)
            {
                return Results.BadRequest("La factura no puede ser nula.");
            }

            var facturaEntity = await context.Facturas.FindAsync(id);

            if (facturaEntity == null)
            {
                return Results.NotFound("Factura no encontrada.");
            }

            facturaEntity.ClienteId = facturaDto.ClienteId;
            facturaEntity.Total = facturaDto.Total;
            facturaEntity.Estado = facturaDto.Estado;
            facturaEntity.Notas = facturaDto.Notas;
            facturaEntity.MontoPagado = facturaDto.MontoPagado;
            facturaEntity.Cambio = facturaDto.Cambio;
            facturaEntity.IdMetodoPago = facturaDto.IdMetodoPago;
            facturaEntity.UsuarioId = facturaDto.UsuarioId;
            facturaEntity.Activo = facturaDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok(facturaEntity);
        }
    }
}
