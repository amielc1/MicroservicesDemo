using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services;
using Microsoft.Extensions.Logging;

namespace MapEntitiesService.Infrastructure.Services
{
    internal class MapEntityService : IMapEntityService
    {
        private readonly IPublishService _publishService;
        private readonly ILogger<MapEntityService> _logger;

        public MapEntityService(ILogger<MapEntityService> logger, IPublishService publishService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publishService = publishService ?? throw new ArgumentNullException(nameof(publishService));
        }
        public async Task Publish(MapEntityDto entity, string topic)
        {
            _logger.LogInformation("Send entity from MapEntityService"); 
           await _publishService.Publish(entity, topic);
        }
    }
}
