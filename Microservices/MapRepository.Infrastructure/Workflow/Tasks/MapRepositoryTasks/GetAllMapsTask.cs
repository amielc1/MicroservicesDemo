using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MapRepositoryTasks;

internal class GetAllMapsTask : IGetAllMapsTask
{
    private readonly IGetAllMapsQuery _getAllMapsQuery;
    private readonly MinIoConfiguration _settings;

    public GetAllMapsTask(IGetAllMapsQuery getAllMapsQuery, MinIoConfiguration settings)
    {
        _getAllMapsQuery = getAllMapsQuery;
        _settings = settings;
    }

    public async Task<List<string>> GetAllMaps()
    {
        return await _getAllMapsQuery.GetAllMaps(_settings.mapRepositoryBucketName);
    }
}
