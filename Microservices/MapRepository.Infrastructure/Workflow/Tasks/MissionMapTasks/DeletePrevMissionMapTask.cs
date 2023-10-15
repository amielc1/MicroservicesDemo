using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;

internal class DeletePrevMissionMapTask : IDeletePrevMissionMapTask
{

    private readonly IDeleteMapsCommand _deleteMapsCommand;
    private readonly MinIoConfiguration _settings;
    public DeletePrevMissionMapTask(IDeleteMapsCommand deleteMapsCommand, MinIoConfiguration settings)
    {
        _deleteMapsCommand = deleteMapsCommand;
        _settings = settings;

    }
    public Task<bool> DeletePrevMapTask()
    {
        return _deleteMapsCommand.DeleteMaps(_settings.missionMapBucketName);
    }


}
