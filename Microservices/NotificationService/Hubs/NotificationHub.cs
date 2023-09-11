using MapEntitiesService.Core.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.SignalR;

namespace NotificationService.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task NotifyNewEntity(MapEntityDto mapEntity)
        {
            await Clients.All.SendAsync("ReciveMapEntity", mapEntity);
        }
    }
}
