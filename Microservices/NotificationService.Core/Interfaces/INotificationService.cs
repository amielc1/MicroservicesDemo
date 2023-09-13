namespace NotificationService.Core.Interfaces
{
    public interface INotificationService 
    {
        Task Subscribe(string topic, Action<string> OnMessageArrived);
    }
}
