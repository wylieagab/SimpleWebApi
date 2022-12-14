using Microsoft.EntityFrameworkCore;
using SimpleRobotsWebApi.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<RobotAPIDbContext>(options => options.UseInMemoryDatabase("RobotsDb"));
builder.Services.AddScoped<IRobotAPIContextSeed, RobotAPIContextSeed>();
builder.Services.AddSwaggerGen();

var dataBaseSeed = builder.Services.BuildServiceProvider().GetRequiredService<IRobotAPIContextSeed>();

dataBaseSeed.SeedAsync();

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
