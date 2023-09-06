using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services;

namespace MapEntitiesService.Infrastructure.Services
{
    public class RabbitMQPublishService : IPublishService
    {
        public void Publish(MapEntityDto entity, string topic)
        {
            Console.WriteLine($"Send Point {entity.Tile} to topic {topic}");
        }
    }

}
