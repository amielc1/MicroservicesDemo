namespace MessageBroker.Core.Interfaces;

public interface ISubscriber
{
    Task Subscribe(string topic, Action<string> OnMessageArrived);
}
