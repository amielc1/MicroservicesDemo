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

    public async Task<string> GetCurrentMissionMap()
    => await _setMissiomMapWorkflow.GetCurrentMissionMap();

    public async Task<ResultModel> SetMissiionMap(string mapname)
      => await _setMissiomMapWorkflow.SetMissiomMap(mapname);
}
