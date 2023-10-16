using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
using NotificationService.Core.Interfaces.MissionMap;

namespace NotificationService.Infrastructure.Services.MissionMap;

internal class MissionMapSubscribeService : IMissionMapSubscribeService
{

    private readonly ISubscriber _subscribeService;
    private readonly ILogger<MissionMapSubscribeService> _logger;

    public MissionMapSubscribeService(ILogger<MissionMapSubscribeService> logger, ISubscriber subscriber)
    {
        _logger = logger;
        _subscribeService = subscriber;
    }

    public Task Subscribe(string topic, Action<string> OnMessageArrived)
    {
        _logger.LogInformation($"Subscribe {nameof(MissionMapSubscribeService)}, topic {topic}");
        _subscribeService.Subscribe(topic, OnMessageArrived);
        return Task.CompletedTask;
    }
     
}
