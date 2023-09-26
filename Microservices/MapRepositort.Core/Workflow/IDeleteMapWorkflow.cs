using MapRepository.Core.Models;

namespace MapRepository.Core.Workflow;

public interface IDeleteMapWorkflow
{
    Task<ResultModel> DeleteMap(string mapname);
}
