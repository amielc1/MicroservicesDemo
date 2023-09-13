using MapEntitiesService.Core.Models;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using NotificationService.Hubs;
using NotificationService.Core.Interfaces;

namespace NotificationService.Commands;

public class NewMapEntityCommandHandler : INewMapEntityCommandHandler
{
    private readonly IHubContext<NotificationHub, IMapEntityClientNames> _notificationHub;

    public NewMapEntityCommandHandler(IHubContext<NotificationHub, IMapEntityClientNames> notificationHub)
    {
        _notificationHub = notificationHub;
    }

    async void INewMapEntityCommandHandler.ReciveMapEntity(string mapEntity)
    {
        var entity = JsonSerializer.Deserialize<MapEntityDto>(mapEntity);
        if (entity is null) return;
        await _notificationHub.Clients.All.ReciveMapEntity(entity);
    }
}