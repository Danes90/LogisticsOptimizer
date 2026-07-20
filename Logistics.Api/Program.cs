using FluentValidation;
using FluentValidation.AspNetCore;
using Logistics.Api.Middleware;
using Logistics.Api.Validators;
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

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<
    CreateTruckRequestValidator>();

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
builder.Services.AddScoped<ILoadPlanRepository,LoadPlanRepository>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

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


public partial class Program
{
}
