using MapEntitiesService.Core.Models;

namespace NotificationService.Core.Interfaces;

public interface INotifyer
{
    Task ReciveMapEntity(string entity);
    Task MissionMapChanged(string mapname);
}
