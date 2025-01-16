using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Services;
using ProductManagement.Infrastructure.Repositories;
using ProductManagement.Infrastructure.Services;
using System;
using ProductManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Register Services
builder.Services.AddHttpClient<ExternalApiService>(); // Register HttpClient for external API service

// Register Application Services
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
