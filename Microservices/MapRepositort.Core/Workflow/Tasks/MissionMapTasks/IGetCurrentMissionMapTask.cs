namespace MapRepository.Core.Workflow.Tasks.MissionMapTasks;

public interface IGetCurrentMissionMapTask
{
    Task<string> GetCurrentMissionMap();
}
