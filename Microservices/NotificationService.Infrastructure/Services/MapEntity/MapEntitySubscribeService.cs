using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
using NotificationService.Core.Interfaces.MapEntity;

namespace NotificationService.Infrastructure.Services.MapEntity
{
    internal class MapEntitySubscribeService : IMapEntitySubscribeService
    {
        private readonly ISubscriber _subscribeService;
        private readonly ILogger<MapEntitySubscribeService> _logger;

        public MapEntitySubscribeService(ILogger<MapEntitySubscribeService> logger, ISubscriber subscriber)
        {
            _logger = logger;
            _subscribeService = subscriber;
        }

        public Task Subscribe(string topic, Action<string> OnMessageArrived)
        {
            _logger.LogInformation($"Subscribe {nameof(MapEntitySubscribeService)}, topic {topic}");
            _subscribeService.Subscribe(topic, OnMessageArrived);
            return Task.CompletedTask;
        }

    }
}
