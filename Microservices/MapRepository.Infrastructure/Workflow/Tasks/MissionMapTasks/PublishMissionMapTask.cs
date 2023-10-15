using MapRepository.Core.AppSettings;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;
using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;

internal class PublishMissionMapTask : IPublishMissionMapTask
{
    private readonly MessageBrokerSettings _messageBrokerSettings;
    private readonly IPublisher _publishService;
    private readonly ILogger<PublishMissionMapTask> _logger;

    public PublishMissionMapTask(IPublisher publisher, ILogger<PublishMissionMapTask> logger, MessageBrokerSettings messageBrokerSettings)
    {
        _messageBrokerSettings = messageBrokerSettings;
        _publishService = publisher;
        _logger = logger;
    }

    public Task PublishMap(string mapname)
    {
        return _publishService.Publish(mapname, _messageBrokerSettings.TopicName);
    }
}
