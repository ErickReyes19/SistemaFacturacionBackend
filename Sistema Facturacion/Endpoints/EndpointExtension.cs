using Sistema_Facturacion.Endpoints.Categorias;
using Sistema_Facturacion.Endpoints.Clientes;
using Sistema_Facturacion.Endpoints.Productos;
using Sistema_Facturacion.Endpoints.Roles;
using Sistema_Facturacion.Endpoints.Stock;

namespace Sistema_Facturacion.Endpoints
{
    public static class EndpointExtensions
    {
        public static void ConfigureAllEndpoints(this WebApplication app)
        {
            ProductosEndpointBuilder.ConfigureEndpoints(app);
            ClientesEndpointBuilder.ConfigureEndpoints(app);
            StockEndpointBuilder.ConfigureEndpoints(app);
            CategoriasEndpointBuilder.ConfigureEndpoints(app);
            RolesEndpointBuilder.ConfigureEndpoints(app);
        }
    }
}
