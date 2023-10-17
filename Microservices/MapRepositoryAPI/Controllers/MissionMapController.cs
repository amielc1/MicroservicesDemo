using MapRepository.Core.Models;
using MapRepository.Core.Service;
using MapRepositoryAPI.DTOs;
using MapRepositoryAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MapRepositoryAPI.Controllers;

[Route("api/MissionMap")]
[ApiController]
public class MissionMapController : Controller
{
    private readonly IMissionMapService _missionMapService;
    public MissionMapController(IMissionMapService missionMapService)
    {
        _missionMapService = missionMapService;
    }

    [HttpPost(nameof(SetMissionMap))]
    public async Task<ResultDto> SetMissionMap(string mapname)
        => (await _missionMapService.SetMissiionMap(mapname)).ToDto();

    [HttpGet(nameof(GetCurrentMissionMap))]
    public async Task<string> GetCurrentMissionMap()
        => await _missionMapService.GetCurrentMissionMap();
}
