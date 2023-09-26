using MapEntitiesService.Core.Models;

namespace MapEntitiesService.Core.Services;

public interface IMapEntityService
{
    Task Publish(MapEntityDto entity, string topic);
}
