using MapRepository.Core.Service;
using MapRepositoryAPI.DTOs;
using MapRepositoryAPI.Helpers;
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
    public async Task<ResultDto> GetMap(string mapname, string pathToSave)
        => (await _mapRepositoryService.GetMap(mapname, pathToSave)).ToDto();

    [HttpDelete(nameof(DeleteMap))]
    public async Task<ResultDto> DeleteMap(string mapName)
        => (await _mapRepositoryService.DeleteMap(mapName)).ToDto();

    [HttpPost(nameof(UploadFile))]
    public async Task<ResultDto> UploadFile([FromBody] IFormFile file)
        => (await _mapRepositoryService.UploadMap(file.FileName, file.FileName)).ToDto();

    [HttpPost(nameof(UploadFileName))]
    public async Task<ResultDto> UploadFileName(string mapname, string pathToMap)
        => (await _mapRepositoryService.UploadMap(mapname, pathToMap)).ToDto();
}