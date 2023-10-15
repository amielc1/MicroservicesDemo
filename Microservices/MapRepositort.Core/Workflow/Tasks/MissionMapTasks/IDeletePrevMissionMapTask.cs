namespace MapRepository.Core.Workflow.Tasks.MissionMapTasks;

public interface IDeletePrevMissionMapTask
{
    Task<bool> DeletePrevMapTask();
}
