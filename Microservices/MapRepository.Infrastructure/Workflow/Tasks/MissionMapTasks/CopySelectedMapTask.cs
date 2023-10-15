using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;

internal class CopySelectedMapTask : ICopySelectedMapTask
{


    private readonly ICopyMapCommand _copyMapCommand;
    private readonly MinIoConfiguration _settings;
    public CopySelectedMapTask(ICopyMapCommand copyMapCommand, MinIoConfiguration settings)
    {
        _copyMapCommand = copyMapCommand;
        _settings = settings;

    }

    public async Task<bool> CopySelectedMap(string mapname)
    {
        return (await _copyMapCommand.CopyMap(mapname,
                                _settings.mapRepositoryBucketName,
                                _settings.missionMapBucketName)).Success;
    }
}
