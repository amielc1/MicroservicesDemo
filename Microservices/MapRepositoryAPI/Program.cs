using MapRepository.Core.Models;
using MapRepository.Infrastructure.Ioc;
using MessageBroker.Core.Models;
using MessageBroker.Infrastructure.Ioc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection(nameof(MinIoConfiguration)).Get<MinIoConfiguration>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(settings);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceLibrary();
//todo inject settings : (like MapEntitiesService
//"MapEntitiesServiceSettings": {
//    "HostName": "rabbithost",
//    "TopicName": "entityQueue"
//  },
builder.Services.AddMessageBrokerPublishLibrary(new PublisherSettings
{
    HostName = "rabbithost"
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
