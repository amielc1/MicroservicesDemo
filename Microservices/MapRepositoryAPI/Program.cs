using MapRepository.Core.AppSettings;
using MapRepository.Infrastructure.Ioc;
using MessageBroker.Core.Models;
using MessageBroker.Infrastructure.Ioc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var minIoSettings = builder.Configuration.GetSection(nameof(MinIoConfiguration)).Get<MinIoConfiguration>();
var messageBrokerSettings = builder.Configuration.GetSection(nameof(MessageBrokerSettings)).Get<MessageBrokerSettings>();
// Add services to the container. 
builder.Services.AddControllers();
builder.Services.AddSingleton(minIoSettings);
builder.Services.AddSingleton(messageBrokerSettings);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServiceLibrary();

builder.Services.AddMessageBrokerPublishLibrary(new PublisherSettings
{
    HostName = messageBrokerSettings.HostName
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
