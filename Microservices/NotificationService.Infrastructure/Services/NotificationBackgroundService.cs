using MessageBroker.Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationService.Core.Interfaces;

namespace NotificationService.Infrastructure.Services;

internal class NotificationBackgroundService : BackgroundService
{
    private readonly ILogger<NotificationService> _logger;
    private readonly INotificationService _notificationService;
    private readonly INewMapEntityCommandHandler _newMapEntityCommandHandler;
    private readonly Settings _settings;

    public NotificationBackgroundService(
        ILogger<NotificationService> logger,
        INotificationService notificationService,
        INewMapEntityCommandHandler newMapEntityCommandHandler,
        Settings settings)
    {
        _logger = logger;
        _settings = settings;
        _notificationService = notificationService;
        _newMapEntityCommandHandler = newMapEntityCommandHandler;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _notificationService.Subscribe(_settings.TopicName, _newMapEntityCommandHandler.ReciveMapEntity);
        return Task.CompletedTask;
    }

}
