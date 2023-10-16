namespace NotificationService.Core.Interfaces.MapEntity
{
    public interface IMapEntitySubscribeService
    {
        Task Subscribe(string topic, Action<string> OnMessageArrived);
    }
}