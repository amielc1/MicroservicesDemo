using MapEntitiesService.Infrastructure.Ioc;
using MessageBroker.Infrastructure.Ioc;
using MapEntitiesService.Core.appsettings;
using MessageBroker.Core.Models;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var settings = builder.Configuration.GetSection(nameof(MapEntitiesServiceSettings)).Get<MapEntitiesServiceSettings>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureLibrary(settings);
builder.Services.AddMessageBrokerPublishLibrary(new PublisherSettings
{
    HostName = settings.HostName
}) ;

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
