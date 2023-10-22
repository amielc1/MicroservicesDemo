using NotificationService.Core.Interfaces;
using NotificationService.Core.Interfaces.MapEntity;

namespace NotificationService.Infrastructure.Services.MapEntity;

internal class NewMapEntityCommandHandler : INewMapEntityCommandHandler
{
    private readonly INotifyer _notifyer;

    public NewMapEntityCommandHandler(INotifyer notifyer)
    {
        _notifyer = notifyer;
    }

    async void INewMapEntityCommandHandler.ReciveMapEntity(string mapEntity)
    {
        //var entity = JsonSerializer.Deserialize<MapEntityDto>(mapEntity);
        if (mapEntity is null) return;
        await _notifyer.ReciveMapEntity(mapEntity);
    }
}