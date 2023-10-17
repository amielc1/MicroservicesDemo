using MapRepository.Core.Models;

namespace MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;

public interface IDeleteMapTask
{
    Task<ResultModel> DeleteMap(string mapname);
}
