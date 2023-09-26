using MapEntitiesService.Core.appsettings;
using MapEntitiesService.Infrastructure.Ioc;
using MessageBroker.Core.Models;
using MessageBroker.Infrastructure.Ioc;
using Serilog;

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
});

var logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext().CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

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
