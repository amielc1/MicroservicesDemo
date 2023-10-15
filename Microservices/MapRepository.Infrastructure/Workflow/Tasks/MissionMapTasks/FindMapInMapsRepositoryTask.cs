using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;

namespace MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;

internal class FindMapInMapsRepositoryTask : IFindMapInMapsRepositoryTask
{
    private readonly IObjectExistsQuery _objectExistsQuery;
    private readonly MinIoConfiguration _settings;

    public FindMapInMapsRepositoryTask(IObjectExistsQuery objectExistsQuery, MinIoConfiguration settings)
    {
        _objectExistsQuery = objectExistsQuery;
        _settings = settings;
    }

    public Task<bool> Validate(string mapname)
        => _objectExistsQuery.ObjectExist(mapname, _settings.mapRepositoryBucketName);

}
