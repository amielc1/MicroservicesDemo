namespace NotificationService.Core.Interfaces.MissionMap;

public interface IMissionMapChangedCommandHandler
{
    void MissionMapChanged(string mapname);
}
