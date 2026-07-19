using Logistics.Application.Commands.CreatePallet;
using Logistics.Application.Commands.CreateTruck;
using Logistics.Application.Commands.OptimizeLoadPlan;
using Logistics.Application.Interfaces;
using Logistics.Application.Queries.GetPallets;
using Logistics.Application.Queries.GetTrucks;
using Logistics.Domain.Interfaces;
using Logistics.Domain.Services;
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

// Repositories
builder.Services.AddScoped<ITruckRepository, TruckRepository>();
builder.Services.AddScoped<IPalletRepository, PalletRepository>();
builder.Services.AddScoped<
    ILoadOptimizer,
    SimpleLoadOptimizer>();
builder.Services.AddScoped<
    OptimizeLoadPlanHandler>();



// Handlers
builder.Services.AddScoped<CreateTruckHandler>();
builder.Services.AddScoped<GetTrucksHandler>();
builder.Services.AddScoped<CreatePalletHandler>();
builder.Services.AddScoped<GetPalletsHandler>();

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

// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();