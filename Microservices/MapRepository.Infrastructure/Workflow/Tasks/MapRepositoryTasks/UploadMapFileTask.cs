using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MapRepositoryTasks;

internal class UploadMapFileTask : IUploadMapFileTask
{
    private readonly IAddMapCommand _addMapCommand;
    private readonly MinIoConfiguration _settings;
    public UploadMapFileTask(IAddMapCommand addMapCommand, MinIoConfiguration settings)
    {
        _addMapCommand = addMapCommand;
        _settings = settings;
    }
    public async Task<bool> UploadMap(string mapname, Stream mapstream)
    {
        //todo adjest return - bool or result model .
        return (await _addMapCommand
             .AddMap(mapname, mapstream, _settings.mapRepositoryBucketName))
             .Success;
    }

}
