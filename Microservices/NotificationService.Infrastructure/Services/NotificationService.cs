using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
using NotificationService.Core.Interfaces;

namespace NotificationService.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ISubscriber _subscribeService;
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILogger<NotificationService> logger, ISubscriber subscriber)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _subscribeService = subscriber ?? throw new ArgumentNullException(nameof(subscriber));
        }

        public Task Subscribe(string topic, Action<string> OnMessageArrived)
        {
            _logger.LogInformation($"Subscribe for message from topic {topic}");

            _subscribeService.Subscribe(topic, OnMessageArrived);
            return Task.CompletedTask;
        }

      
    }
}
