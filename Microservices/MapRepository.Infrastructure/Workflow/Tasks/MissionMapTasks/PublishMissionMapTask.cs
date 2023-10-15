using MapRepository.Core.Workflow.Tasks.MissionMapTasks;
using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;

internal class PublishMissionMapTask : IPublishMissionMapTask
{
    //Todo extract to config 
    private const string MISSION_MAP_TOPIC = "MissonMapTopic";
    private readonly IPublisher _publishService;
    private readonly ILogger<PublishMissionMapTask> _logger;

    public PublishMissionMapTask(IPublisher publisher, ILogger<PublishMissionMapTask> logger)
    {
        _publishService = publisher;
        _logger = logger;
    }
     

    public Task PublishMap(string mapname)
    {
        return _publishService.Publish(mapname, MISSION_MAP_TOPIC);
    }
}
