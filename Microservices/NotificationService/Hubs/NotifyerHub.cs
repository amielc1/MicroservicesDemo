using MapEntitiesService.Core.Models;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Core.Interfaces;

namespace NotificationService.Hubs;

public class NotifyerHub : INotifyer
{
    private readonly IHubContext<NotificationHub, IMapEntityClientNames> _notificationHub;

    public NotifyerHub(IHubContext<NotificationHub, IMapEntityClientNames> notificationHub)
    {
        _notificationHub = notificationHub;
    }

    public async Task ReciveMapEntity(MapEntityDto entity)
    {
        await _notificationHub.Clients.All.ReciveMapEntity(entity);
    }
}
