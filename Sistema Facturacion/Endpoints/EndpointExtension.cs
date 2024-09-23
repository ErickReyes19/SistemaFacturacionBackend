using Sistema_Facturacion.Endpoints.Clientes;
using Sistema_Facturacion.Endpoints.Productos;

namespace Sistema_Facturacion.Endpoints
{
    public static class EndpointExtensions
    {
        public static void ConfigureAllEndpoints(this WebApplication app)
        {
            ProductosEndpointBuilder.ConfigureEndpoints(app);
            ClientesEndpointBuilder.ConfigureEndpoints(app);
        }
    }
}
