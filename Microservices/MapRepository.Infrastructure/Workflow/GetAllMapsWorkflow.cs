using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Workflow;

namespace MapRepository.Infrastructure.Workflow;

internal class GetAllMapsWorkflow : IGetAllMapsWorkflow
{
    private readonly IGetAllMapsQuery _getAllMapsQuery;
    public GetAllMapsWorkflow(IGetAllMapsQuery getAllMapsQuery)
    {
        _getAllMapsQuery = getAllMapsQuery;
    }
    public async Task<List<string>> GetAllMaps()
      => new List<string>();//_getAllMapsQuery.GetAllMaps("maprepositorybucket");

}
