using Sistema_Facturacion.Endpoints.Auth;
using Sistema_Facturacion.Endpoints.Categorias;
using Sistema_Facturacion.Endpoints.Clientes;
using Sistema_Facturacion.Endpoints.Permisos;
using Sistema_Facturacion.Endpoints.Productos;
using Sistema_Facturacion.Endpoints.Roles;
using Sistema_Facturacion.Endpoints.RolesPermisos;
using Sistema_Facturacion.Endpoints.Stock;
using Sistema_Facturacion.Endpoints.Usuarios;

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
            PermisosEndpointBuilder.ConfigureEndpoints(app);
            RolesPermisosEndpointBuilder.ConfigureEndpoints(app);
            UsuarioEndpointBuilder.ConfigureEndpoints(app);
            AuthEndpointBuilder.ConfigureEndpoints(app);
        }
    }
}
