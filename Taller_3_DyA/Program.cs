using Microsoft.EntityFrameworkCore;
using Server.Models;
using Taller_3_DyA.Data;
using Taller_3_DyA.Repository;
using Taller_3_DyA.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// App Db Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DbConnection");
    if (string.IsNullOrEmpty(connectionString))
    {
        throw new InvalidOperationException("Connection string not found");
    }
    options.UseSqlServer(connectionString);
});

// Repositories
builder.Services.AddScoped<IProductRepository<ProductV1>, ProductRepositoryV1>();
builder.Services.AddScoped<IProductRepository<ProductV2>, ProductRepositoryV2>();
builder.Services.AddScoped<IProductRepository<ProductV3>, ProductRepositoryV3>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();