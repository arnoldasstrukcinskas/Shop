using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using shop.DATA;
using shop.DATA.Repositories.Interfaces;
using shop.DATA.Repositories.Repositories;
using Shop.BLL.Interfaces;
using Shop.BLL.Services;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Services
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
//Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySql(connectionString, serverVersion));

// Configure of swagger documentation
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Order Manager",
        Version = "v1"
    });

    // Include XML comments
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});



var app = builder.Build();

// Try connect to database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        await context.Database.CanConnectAsync();
        Console.WriteLine("✅ Database connection successful!");

        // Apply migrations automatically
        await context.Database.MigrateAsync();
        Console.WriteLine("✅ Database migrations applied!");

    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Database setup failed: {ex.Message}");
    }
}

app.MapHealthChecks("/health");


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
