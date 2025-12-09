using IoT_ParkingApp.Data;
using IoT_ParkingApp.Repositories;
using IoT_ParkingApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MySQL DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();
builder.Services.AddScoped<ISensorDataService, SensorDataService>();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
