using MapRepository.Core.Models;
using MapRepository.Core.Service;
using MapRepository.Core.Workflow;

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

    public async Task<ResultModel> GetMap(string mapname, string pathToSave)
      => await _getMapByNameWorkflow.GetMap(mapname, pathToSave);

    public async Task<ResultModel> UploadMap(string mapname, string pathToMap)
        => await _uploadMapWorkflow.UploadMap(mapname, pathToMap);

    public async Task<ResultModel> UploadMapStr(string mapname, string mapfile)
        => await _uploadMapWorkflow.UploadMap(mapname, mapfile);
}
