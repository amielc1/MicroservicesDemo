﻿using MapEntitiesService.Core.Models;
using Microsoft.AspNetCore.SignalR;
using NotificationService.Core.Interfaces;

namespace NotificationService.Hubs;

public class NotificationHub : Hub<IClientNames>
{

    //todo check if this needed
    public async Task NotifyNewEntity(MapEntityDto mapEntity)
    {
        await Clients.All.ReciveMapEntity(mapEntity);
    }

    public override Task OnConnectedAsync()
    {
        return base.OnConnectedAsync();
    }
}
