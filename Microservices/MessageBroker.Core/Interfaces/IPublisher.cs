namespace MessageBroker.Core.Interfaces
{
    public interface IPublisher
    {
        Task Publish(string message, string topic);
    }
}
