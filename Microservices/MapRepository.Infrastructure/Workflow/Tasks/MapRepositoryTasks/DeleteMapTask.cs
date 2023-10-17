using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MapRepositoryTasks;

internal class DeleteMapTask : IDeleteMapTask
{
    private readonly IDeleteMapCommand _deleteMapCommand;
    private readonly MinIoConfiguration _settings;
    public DeleteMapTask(IDeleteMapCommand deleteMapCommand, MinIoConfiguration settings)
    {
        _deleteMapCommand = deleteMapCommand;
        _settings = settings;
    }
    public async Task<ResultModel> DeleteMap(string mapname)
    {
        return await _deleteMapCommand.DeleteMap(mapname, _settings.mapRepositoryBucketName);
    }
}
