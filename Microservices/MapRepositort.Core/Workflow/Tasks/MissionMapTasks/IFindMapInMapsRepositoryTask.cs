namespace MapRepository.Core.Workflow.Tasks.MissionMapTasks;

public interface IFindMapInMapsRepositoryTask
{
    Task<bool> Validate(string mapname);
}
