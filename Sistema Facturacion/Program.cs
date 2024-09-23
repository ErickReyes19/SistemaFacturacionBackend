using Microsoft.EntityFrameworkCore;
using Sistema_Facturacion.Endpoints.Productos;
using Sistema_Facturacion.data;
using Sistema_Facturacion.Endpoints.Clientes;
using Sistema_Facturacion.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Crear una variable para la cadena de conexión
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Imprimir la cadena de conexión en la consola
Console.WriteLine($"Cadena de conexión: {connectionString}");

// Registrar el contexto de la base de datos usando la variable
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString));

var app = builder.Build();

// Configurar la tubería HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

// Mapea el endpoint de la fecha y hora actual
app.MapGet("/", () =>
{
    var currentDateTime = DateTime.Now;
    return $"API Sistemas activo. Fecha y hora actual: {currentDateTime}";
});

app.ConfigureAllEndpoints();
// Mapea otros controladores
app.MapControllers();

app.Run();
