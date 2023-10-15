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

    [HttpDelete(nameof(DeleteMap))]
    public async Task<ResultDto> DeleteMap(string mapName)
        => (await _mapRepositoryService.DeleteMap(mapName)).ToDto();

    [HttpPost(nameof(UploadFile))]
    public async Task<ResultDto> UploadFile(IFormFile file)
     => (await _mapRepositoryService.UploadMap(file.FileName, file.OpenReadStream())).ToDto();
}