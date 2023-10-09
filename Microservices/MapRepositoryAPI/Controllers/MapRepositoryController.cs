using MapRepository.Core.Service;
using MapRepositoryAPI.DTOs;
using MapRepositoryAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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
    public async Task<ResultDto> UploadFile(IFormFile file)
    {
        //convert file to binary as string 
        var arr = new byte[file.Length];
        var stream = file.OpenReadStream();
        await stream.ReadAsync(arr);
        var fileasstring = Convert.ToBase64String(arr);
        //send string file to service (docker)
        return (await _mapRepositoryService.UploadMap(file.FileName, fileasstring)).ToDto();
    }


    [HttpPost(nameof(UploadFileName))]
    public async Task<ResultDto> UploadFileName(string mapname, string pathToMap)
        => (await _mapRepositoryService.UploadMap(mapname, pathToMap)).ToDto();
}