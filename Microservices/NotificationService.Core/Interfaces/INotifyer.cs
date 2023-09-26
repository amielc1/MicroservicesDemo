using MapEntitiesService.Core.Models;

namespace NotificationService.Core.Interfaces;

public interface INotifyer
{
    Task ReciveMapEntity(MapEntityDto entity);
}
