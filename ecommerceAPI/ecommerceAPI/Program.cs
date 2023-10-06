
using DAL;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Repos;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:7298/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<EcommeceDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("EcommeceDbContext"))
//);
var connectionString = builder.Configuration.GetConnectionString("EcommeceDbContext");
builder.Services.AddDbContext<EcommeceDbContext>(options => options.UseSqlServer(connectionString));



//builder.Services.AddScoped<IRepo<Category, int, Category>>(provider =>
//{
//    return DataAccessFactory.CategoryData();
//});
//builder.Services.AddScoped<IRepo<Product, int, Product>>(provider =>
//{
//    return DataAccessFactory.ProductData();
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

// Add CORS policy to allow requests from
app.UseCors(builder => builder.WithOrigins("http://localhost:7298").AllowAnyMethod().AllowAnyHeader());


app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
