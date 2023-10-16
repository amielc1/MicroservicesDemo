using MapEntitiesService.Core.Models;
using NotificationService.Core.Interfaces;
using NotificationService.Core.Interfaces.MapEntity;
using System.Text.Json;

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
        var entity = JsonSerializer.Deserialize<MapEntityDto>(mapEntity);
        if (entity is null) return;
        await _notifyer.ReciveMapEntity(entity);
    }
}