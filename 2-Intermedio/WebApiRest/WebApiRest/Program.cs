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
    app.UseSwaggerUI(); // Levanta la interfaz gráfica interactiva
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
