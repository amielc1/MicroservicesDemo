using MessageBroker.Core.Models;
using MessageBroker.Infrastructure.Ioc;
using NotificationService.Commands;
using NotificationService.Core.Interfaces;
using NotificationService.Hubs;
using NotificationService.Infrastructure.Ioc;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = builder.Configuration.GetSection(nameof(NotificationServiceSettings)).Get<NotificationServiceSettings>();

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSingleton<INewMapEntityCommandHandler, NewMapEntityCommandHandler>();

builder.Services.AddSingleton(settings);
builder.Services.AddMessageBrokerSubscribeLibrary(new SubscriberSettings
{
    HostName = settings.HostName,
});

builder.Services.AddNotificationServiceLibrary();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
