namespace MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;

public interface IGetAllMapsTask
{
    Task<List<string>> GetAllMaps();
}
