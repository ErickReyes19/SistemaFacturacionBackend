﻿using Sistema_Facturacion.Endpoints.Auth;
using Sistema_Facturacion.Endpoints.Categoria;
using Sistema_Facturacion.Endpoints.Clientes;
using Sistema_Facturacion.Endpoints.Cotizaciones;
using Sistema_Facturacion.Endpoints.DetalleCotizacion;
using Sistema_Facturacion.Endpoints.DetalleFactura;
using Sistema_Facturacion.Endpoints.Factura;
using Sistema_Facturacion.Endpoints.MetodoPago;
using Sistema_Facturacion.Endpoints.Permisos;
using Sistema_Facturacion.Endpoints.Productos;
using Sistema_Facturacion.Endpoints.Roles;
using Sistema_Facturacion.Endpoints.RolesPermisos;
using Sistema_Facturacion.Endpoints.Stock;
using Sistema_Facturacion.Endpoints.Usuario;

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
            MetodoPagoEndpointBuilder.ConfigureEndpoints(app);
            CotizacionesEndpointBuilder.ConfigureEndpoints(app);
            DetalleCotizacionEndpointBuilder.ConfigureEndpoints(app);
            FacturasEndpointBuilder.ConfigureEndpoints(app);
            DetalleFacturaEndpointBuilder.ConfigureEndpoints(app);
        }
    }
}
