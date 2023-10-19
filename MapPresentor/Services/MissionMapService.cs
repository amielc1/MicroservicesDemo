using MapPresentor.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapPresentor.Services;

internal class MissionMapService : IMissionMapService
{
    private readonly IRESTCommand _restCommand;
  
    public MissionMapService(IRESTCommand restCommand)
    {
        _restCommand = restCommand;
    }

    public Task DeleteMap(string mapname)
    {
        return _restCommand.SendPostRequest(AppSettings.DeleteMapUrl, mapname);
    }

    public Task SetMissionMap(string mapname)
    {
        return _restCommand.SendPostRequest(AppSettings.SetMissionMapUrl, mapname);
    }

    public async Task<List<string>> LoadMaps()
    {
        var content = await _restCommand.SendGetRequest(AppSettings.GetAllMapsUrl);
        var maps = JsonConvert.DeserializeObject<List<string>>(content);
        return maps;
    }

    public async Task<byte[]> GetCurrentMissionMap()
    {
        var missionMapStr = await _restCommand.SendGetRequest(AppSettings.GetCurrentMissionMapUrl);  
        return Convert.FromBase64String(missionMapStr);
    }
}
