using MapRepository.Core.Models;
using MapRepository.Core.Service;
using MapRepository.Core.Workflow;

namespace MapRepository.Infrastructure.Services;

internal class MissionMapService : IMissionMapService
{
    private readonly ISetMissiomMapWorkflow _setMissiomMapWorkflow;

    public MissionMapService(ISetMissiomMapWorkflow setMissiomMapWorkflow)
    {
        _setMissiomMapWorkflow = setMissiomMapWorkflow;
    }
     
    public Task<ResultModel> SetMissiionMap(string mapname)
      => _setMissiomMapWorkflow.SetMissiomMap(mapname);

    public Task<ResultModel> SubscribeMissionMap()
    {
        throw new NotImplementedException();
    }
}
