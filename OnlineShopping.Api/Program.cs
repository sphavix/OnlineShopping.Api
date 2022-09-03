using Microsoft.EntityFrameworkCore;
using OnlineShopping.Api.Database;
using OnlineShopping.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injection
builder.Services.AddDbContext<OnlineShoppingDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("onlineshopping")));

builder.Services.AddScoped<IProductService, ProductService>();

//Enable CORS
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowOrigin", options =>
    {
        options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger(x => x.SerializeAsV2 = true);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Use CORS
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
