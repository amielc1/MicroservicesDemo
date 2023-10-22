using MapEntitiesService.Core.Models;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Core.Interfaces;

namespace NotificationService.Hubs;

public class NotifyerHub : INotifyer
{
    private readonly IHubContext<NotificationHub, IClientNames> _notificationHub;

    public NotifyerHub(IHubContext<NotificationHub, IClientNames> notificationHub)
    {
        _notificationHub = notificationHub;
    }

    public async Task MissionMapChanged(string mapname)
    {
        await _notificationHub.Clients.All.MissionMapChanged(mapname);
    }

    public async Task ReciveMapEntity(string entity)
    {
        await _notificationHub.Clients.All.ReciveMapEntity(entity);
    }
}
