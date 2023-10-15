namespace MapRepository.Core.Workflow.Tasks.MissionMapTasks;

public interface IPublishMissionMapTask
{
    Task PublishMap(string mapname);
}
