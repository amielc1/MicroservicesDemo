namespace MapRepository.Core.Workflow.Tasks.MissionMapTasks;

public interface ICopySelectedMapTask
{
    Task<bool> CopySelectedMap(string mapname); 
}
