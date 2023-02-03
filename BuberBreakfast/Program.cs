using BuberBreakfast.DataBase;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IBreakfastService, BreakfastService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// LocalDb
// builder.Services.AddDbContext<BreakfastContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddDbContext<BreakfastContext>(options =>
//     options.EnableSensitiveDataLogging());

// MySql
builder.Services.AddDbContext<BreakfastContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();