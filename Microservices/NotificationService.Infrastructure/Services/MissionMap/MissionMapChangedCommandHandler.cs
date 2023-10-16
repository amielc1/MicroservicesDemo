using NotificationService.Core.Interfaces;
using NotificationService.Core.Interfaces.MissionMap;

namespace NotificationService.Infrastructure.Services.MissionMap;

internal class MissionMapChangedCommandHandler : IMissionMapChangedCommandHandler
{
    private readonly INotifyer _notifyer;

    public MissionMapChangedCommandHandler(INotifyer notifyer)
    {
        _notifyer = notifyer;
    }

    public async void MissionMapChanged(string mapname)
    {
        await _notifyer.MissionMapChanged(mapname);
    }
}
