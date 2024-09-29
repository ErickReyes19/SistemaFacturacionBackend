using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.data;
using Sistema_Facturacion.models.Clientes;
using Sistema_Facturacion.models.Producto;

namespace Sistema_Facturacion.Endpoints.Clientes
{
    public class ClientesEndpointBuilder
    {
        public static void ConfigureEndpoints(WebApplication app)
        {
            app.MapGet("api/clientes", GetClientes).RequireAuthorization();
            app.MapPost("api/clientes", PostClientes).RequireAuthorization();
            app.MapGet("api/clientes/{id}", GetClienteById).RequireAuthorization(); 
            app.MapPut("api/clientes/{id}", UpdateCliente).RequireAuthorization();
        }

        private static async Task<IResult> GetClientes(AppDbContext context)
        {
            var clientesEntity = await context.Clientes.ToListAsync();

            if (clientesEntity == null || clientesEntity.Count == 0)
            {
                return Results.NotFound("No se encontraron clientes.");
            }

            var clientesDto = clientesEntity.Select(clienteEntity => ClienteDto.FromEntity(clienteEntity)).ToList();

            return Results.Ok(clientesDto);
        }

        private static async Task<IResult> PostClientes(ClienteDto clienteDto, AppDbContext context)
        {
            if (clienteDto == null)
            {
                return Results.BadRequest("El cliente no puede ser nulo.");
            }

            var clienteEntity = ClienteDto.ToEntity(clienteDto);
            clienteEntity.ClienteId = Guid.NewGuid().ToString();
            clienteEntity.Activo = 1;
            clienteEntity.FechaRegistro = DateTime.Now;

            await context.Clientes.AddAsync(clienteEntity);
            await context.SaveChangesAsync();

            return Results.Ok(clienteEntity);        }

        private static async Task<IResult> GetClienteById(string id, AppDbContext context)
        {
            var clienteEntity = await context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);

            if (clienteEntity == null)
            {
                return Results.NotFound("Cliente no encontrado.");
            }

            var clienteDto = ClienteDto.FromEntity(clienteEntity);
            return Results.Ok(clienteDto);
        }

        private static async Task<IResult> UpdateCliente(string id, ClienteDto clienteDto, AppDbContext context)
        {
            if (clienteDto == null)
            {
                return Results.BadRequest("El cliente no puede ser nulo.");
            }

            var clienteEntity = await context.Clientes.FirstOrDefaultAsync(c => c.ClienteId == id);
            if (clienteEntity == null)
            {
                return Results.NotFound("Cliente no encontrado.");
            }

            clienteEntity.Nombre = clienteDto.Nombre;
            clienteEntity.Identidad = clienteDto.Identidad;
            clienteEntity.Apellido = clienteDto.Apellido;
            clienteEntity.Correo = clienteDto.Correo;
            clienteEntity.Telefono = clienteDto.Telefono;
            clienteEntity.Direccion = clienteDto.Direccion;
            clienteEntity.Activo = clienteDto.Activo ? 1 : 0;

            await context.SaveChangesAsync();

            return Results.Ok("Cliente actualizado"); 
        }
    }
}
