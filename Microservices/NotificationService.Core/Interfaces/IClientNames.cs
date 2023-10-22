using MapEntitiesService.Core.Models;

namespace NotificationService.Core.Interfaces
{
    public interface IClientNames
    {
        Task ReciveMapEntity(string mapEntity);
        Task MissionMapChanged(string mapname);
    }
}
