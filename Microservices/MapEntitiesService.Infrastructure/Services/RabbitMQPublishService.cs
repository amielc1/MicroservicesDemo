using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services;
using Microsoft.Extensions.Logging;

namespace MapEntitiesService.Infrastructure.Services
{
    internal class RabbitMQPublishService : IPublishService
    {
        private readonly ILogger<RabbitMQPublishService> _logger;
        public RabbitMQPublishService(ILogger<RabbitMQPublishService> logger)
        {
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Task Publish(MapEntityDto entity, string topic)
        {
            _logger.LogInformation($"Send Point {entity.Tile} to RabbitMQPublishService. topic {topic}");

            return Task.CompletedTask;
        }
    }

}
