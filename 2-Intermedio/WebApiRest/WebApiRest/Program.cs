using Microsoft.EntityFrameworkCore;
using WebApiRest.Repositorios;
using WebApiRest.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// 1. Registrar el DbContext configurando SQLite
builder.Services.AddDbContext<TiendaContext>(options =>
    options.UseSqlite("Data Source=tienda.db"));

// 2. Registrar tu servicio personalizado
builder.Services.AddScoped<TiendaService, TiendaService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer(); // Permite explorar los endpoints
builder.Services.AddSwaggerGen(); // Registra el generador de Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();   // Genera el archivo JSON (swagger.json)
    // Levanta la interfaz gráfica interactiva
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");

        // ESTA LÍNEA HACE QUE SWAGGER SEA LA PÁGINA DE INICIO (RAÍZ)
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
