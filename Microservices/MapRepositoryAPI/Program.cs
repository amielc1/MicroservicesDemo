using MapRepository.Core.Models;
using MapRepository.Infrastructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection(nameof(MinIoConfiguration)).Get<MinIoConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(settings);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceLibrary();
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
