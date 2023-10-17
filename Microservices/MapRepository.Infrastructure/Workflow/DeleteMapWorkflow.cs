using MapRepository.Core.Models;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;

namespace MapRepository.Infrastructure.Workflow;

internal class DeleteMapWorkflow : IDeleteMapWorkflow
{
    private readonly IDeleteMapTask _deleteMapTask;

    public DeleteMapWorkflow(IDeleteMapTask deleteMapTask)
    {
        _deleteMapTask = deleteMapTask;
    }

    public async Task<ResultModel> DeleteMap(string mapname)
        =>  await _deleteMapTask.DeleteMap(mapname);

}
