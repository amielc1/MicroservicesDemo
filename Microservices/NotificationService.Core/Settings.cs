namespace MessageBroker.Core.Models;

public class Settings
{
    public string NotifictionWsEndpoint { get; set; } = string.Empty;
    public string HostName { get; set; } = string.Empty;
    public string MapEntitiesTopic { get; set; } = string.Empty;
    public string MissonMapTopic { get; set; } = string.Empty;
}
