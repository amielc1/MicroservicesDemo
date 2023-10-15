using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Service;
using MapRepository.Core.Workflow;
using MapRepository.Infrastructure.Workflow;

namespace MapRepository.Infrastructure.Services;

internal class MapRepositoryService : IMapRepositoryService
{
    private readonly IDeleteMapWorkflow _deleteMapWorkflow;
    private readonly IUploadMapWorkflow _uploadMapWorkflow;
    private readonly IGetMapByNameWorkflow _getMapByNameWorkflow;
    private readonly IGetAllMapsWorkflow _getAllMapsWorkflow;

    public MapRepositoryService(
        IDeleteMapWorkflow deleteMapWorkflow,
        IUploadMapWorkflow uploadMapWorkflow,
        IGetMapByNameWorkflow getMapByNameWorkflow,
        IGetAllMapsWorkflow getAllMapsWorkflow)
    {
        _deleteMapWorkflow = deleteMapWorkflow;
        _uploadMapWorkflow = uploadMapWorkflow;
        _getMapByNameWorkflow = getMapByNameWorkflow;
        _getAllMapsWorkflow = getAllMapsWorkflow;
    }

    public async Task<ResultModel> DeleteMap(string mapname)
        => await _deleteMapWorkflow.DeleteMap(mapname);

    public async Task<List<string>> GetAllMapsAsync()
        => await _getAllMapsWorkflow.GetAllMaps();

    public async Task<ResultModel> UploadMap(string mapname, Stream mapstream)
         => await _uploadMapWorkflow.UploadMap(mapname, mapstream); 
}
