using MapRepository.Core.Models;
using MapRepository.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace MapRepositoryAPI.Controllers;

[Route("api/MapRepository")]
[ApiController]
public class MapRepositoryController : ControllerBase
{

    private readonly IMapRepositoryService _mapRepositoryService;

    public MapRepositoryController(IMapRepositoryService mapRepositoryService)
    {
        _mapRepositoryService = mapRepositoryService;
    }

    [HttpGet(nameof(GetAllMaps))]
    public async Task<List<string>> GetAllMaps()
        => await _mapRepositoryService.GetAllMapsAsync();

    [HttpGet(nameof(GetMap))]
    public async Task<ResultModel> GetMap(string mapname, string pathToSave)
        => await _mapRepositoryService.GetMap(mapname, pathToSave);

    [HttpDelete(nameof(DeleteMap))]
    public async Task<ResultModel> DeleteMap(string mapName)
        => await _mapRepositoryService.DeleteMap(mapName);

    [HttpPost(nameof(UploadFile))]
    public async Task<ResultModel> UploadFile([FromBody] IFormFile file)
        => await _mapRepositoryService.UploadMap(file.FileName, file.FileName);

    [HttpPost(nameof(UploadFileName))]
    public async Task<ResultModel> UploadFileName(string mapname, string pathToMap)
        => await _mapRepositoryService.UploadMap(mapname, pathToMap);
}
