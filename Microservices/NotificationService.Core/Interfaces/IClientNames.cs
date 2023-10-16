using MapEntitiesService.Core.Models;

namespace NotificationService.Core.Interfaces
{
    public interface IClientNames
    {
        Task ReciveMapEntity(MapEntityDto mapEntity);
        Task MissionMapChanged(string mapname);
    }
}
