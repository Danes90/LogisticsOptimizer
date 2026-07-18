using Logistics.Application.Commands.CreateTruck;
using Logistics.Application.Interfaces;
using Logistics.Infrastructure.Persistence;
using Logistics.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<LogisticsDbContext>(
    options =>
    {
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("PostgreSql"));
    });

// Dependency Injection
builder.Services.AddScoped<ITruckRepository, TruckRepository>();
builder.Services.AddScoped<CreateTruckHandler>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Fejlesztés alatt ezt kikommentelheted,
// ha a HTTPS warning zavar

// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();