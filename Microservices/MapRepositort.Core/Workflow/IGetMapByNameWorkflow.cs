using MapRepository.Core.Models;

namespace MapRepository.Core.Workflow;

public interface IGetMapByNameWorkflow
{
    Task<ResultModel> GetMap(string mapname, string pathToSave);
}
