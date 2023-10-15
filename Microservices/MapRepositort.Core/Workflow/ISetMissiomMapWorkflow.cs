using MapRepository.Core.Models;

namespace MapRepository.Core.Workflow;

public interface ISetMissiomMapWorkflow
{
    Task<ResultModel> SetMissiomMap(string mapname);
}
