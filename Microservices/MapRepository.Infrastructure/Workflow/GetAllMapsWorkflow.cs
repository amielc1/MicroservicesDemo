using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;

namespace MapRepository.Infrastructure.Workflow;

internal class GetAllMapsWorkflow : IGetAllMapsWorkflow
{
    private readonly IGetAllMapsTask _getAllMapsTask;
    public GetAllMapsWorkflow(IGetAllMapsTask getAllMapsTask)
    {
        _getAllMapsTask = getAllMapsTask;
    }
    public async Task<List<string>> GetAllMaps()
      => await _getAllMapsTask.GetAllMaps();

}
