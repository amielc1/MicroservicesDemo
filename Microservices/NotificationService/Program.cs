using MessageBroker.Core.Models;
using MessageBroker.Infrastructure.Ioc;
using NotificationService.Core.Interfaces;
using NotificationService.Hubs;
using NotificationService.Infrastructure.Ioc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = builder.Configuration.GetSection(nameof(Settings)).Get<Settings>()!;

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddSingleton(settings);
builder.Services.AddMessageBrokerSubscribeLibrary(new SubscriberSettings
{
    HostName = settings.HostName,
});

builder.Services.AddSingleton<INotifyer, NotifyerHub>();
builder.Services.AddInfrastructureLayer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
app.MapHub<NotificationHub>(settings.NotifictionWsEndpoint);
app.Run();
