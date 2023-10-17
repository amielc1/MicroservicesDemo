using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow;
using System.Reflection;

namespace MapRepository.Infrastructure.Workflow;

internal class GetMapByNameWorkflow : IGetMapByNameWorkflow
{
    private readonly IGetMapByNameQuery _getMapByNameQuery;

    public GetMapByNameWorkflow(IGetMapByNameQuery getMapByNameQuery)
    {
        _getMapByNameQuery = getMapByNameQuery;
    }
    public async Task<ResultModel> GetMap(string mapname, string pathToSave)
        => new ResultModel() { Success = true }; //await _getMapByNameQuery.GetMap(mapname, pathToSave);


}
