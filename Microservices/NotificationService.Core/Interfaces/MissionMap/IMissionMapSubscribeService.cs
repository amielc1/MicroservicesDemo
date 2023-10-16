namespace NotificationService.Core.Interfaces.MissionMap;

public interface IMissionMapSubscribeService
{
    Task Subscribe(string topic, Action<string> OnMessageArrived);
}
