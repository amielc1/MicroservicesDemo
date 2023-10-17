using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;
using Microsoft.Extensions.Logging;

namespace MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;

internal class GetCurrentMissionMapTask : IGetCurrentMissionMapTask
{
    private readonly MinIoConfiguration _settings;
    private readonly IGetMapByNameQuery _getMapByNameQuery;
    private readonly IGetAllMapsQuery _getAllMapsQuery;
    private readonly ILogger<GetCurrentMissionMapTask> _logger; 

    public GetCurrentMissionMapTask(
        IGetMapByNameQuery getMapByNameQuery,
        IGetAllMapsQuery getAllMapsQuery,
        MinIoConfiguration settings,
        ILogger<GetCurrentMissionMapTask> logger)
    {
        _settings = settings;
        _logger = logger;
        _getMapByNameQuery = getMapByNameQuery;
        _getAllMapsQuery = getAllMapsQuery;
    }
    public async Task<string> GetCurrentMissionMap()
    {
        try
        {
            _logger.LogDebug("try to GetCurrentMissionMap ");
            var missionMapContent = await _getAllMapsQuery.GetAllMaps(_settings.missionMapBucketName);
            var currentMissionMap = missionMapContent.FirstOrDefault();
            if (currentMissionMap != null && currentMissionMap != string.Empty)
            {
                return await _getMapByNameQuery.GetMap(currentMissionMap, _settings.missionMapBucketName);
            }
            else
            {
                return string.Empty;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
