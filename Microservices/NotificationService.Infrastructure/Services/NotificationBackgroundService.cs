using MessageBroker.Core.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationService.Core.Interfaces.MapEntity;
using NotificationService.Core.Interfaces.MissionMap;

namespace NotificationService.Infrastructure.Services;

internal class NotificationBackgroundService : BackgroundService
{
    private readonly ILogger<NotificationBackgroundService> _logger;
    private readonly IMapEntitySubscribeService _mapEntitySubscribeService;
    private readonly INewMapEntityCommandHandler _newMapEntityCommandHandler;
    private readonly IMissionMapChangedCommandHandler _newMissionMapCommandHandler;
    private readonly IMissionMapSubscribeService _missionMapSubscribeService;
    private readonly Settings _settings;

    public NotificationBackgroundService(
        ILogger<NotificationBackgroundService> logger,
        IMapEntitySubscribeService mapEntitySubscribeService,
        INewMapEntityCommandHandler newMapEntityCommandHandler,
        IMissionMapSubscribeService missionMapSubscribeService,
        IMissionMapChangedCommandHandler newMissionMapCommandHandler,   
        Settings settings)
    {
        _logger = logger;
        _settings = settings;
        _mapEntitySubscribeService = mapEntitySubscribeService;
        _newMapEntityCommandHandler = newMapEntityCommandHandler;
        _missionMapSubscribeService = missionMapSubscribeService;
        _newMissionMapCommandHandler = newMissionMapCommandHandler;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _missionMapSubscribeService.Subscribe(_settings.MissonMapTopic, _newMissionMapCommandHandler.MissionMapChanged);
        _mapEntitySubscribeService.Subscribe(_settings.MapEntitiesTopic, _newMapEntityCommandHandler.ReciveMapEntity);

        return Task.CompletedTask;
    }

}
