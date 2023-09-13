using MapEntitiesService.Core.Models;

namespace NotificationService.Core.Interfaces
{
    public interface IMapEntityClientNames
    {
        Task ReciveMapEntity(MapEntityDto mapEntity);
    }
}
