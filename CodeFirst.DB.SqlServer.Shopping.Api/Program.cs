using CodeFirst.DB.SqlServer.Shopping.Application.Interfaces;
using CodeFirst.DB.SqlServer.Shopping.Application.Mapper;
using CodeFirst.DB.SqlServer.Shopping.Application.Services;
using CodeFirst.DB.SqlServer.Shopping.Infraestructure.Context;
using CodeFirst.DB.SqlServer.Shopping.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using CodeFirst.DB.SqlServer.Shopping.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//builder.AddConfigServer();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Entidad_Dto), typeof(Dto_Entidad));

builder.Services.AddDbContext<ShoppingContext>(config =>
{
    config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IShoppingService, ShoppingService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<ICompraRepository, CompraRepository>();
builder.Services.AddTransient<IProductoRepository, ProductoRepository>();

builder.Services.AddTransient<ShoppingContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
