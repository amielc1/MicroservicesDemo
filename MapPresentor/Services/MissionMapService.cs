using MapPresentor.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapPresentor.Services;

internal class MissionMapService : IMissionMapService
{
    private readonly IRESTCommand _restCommand;
    private readonly AppSettings _settings;

    public MissionMapService(IRESTCommand restCommand,IOptions<AppSettings> options)
    {
        _restCommand = restCommand;
        _settings = options.Value;
    }

    public Task DeleteMap(string mapname)
    {
        return _restCommand.SendPostRequest(_settings.DeleteMapUrl, mapname);
    }

    public Task SetMissionMap(string mapname)
    {
        return _restCommand.SendPostRequest(_settings.SetMissionMapUrl, mapname);
    }

    public async Task<List<string>> LoadMaps()
    {
        var content = await _restCommand.SendGetRequest(_settings.GetAllMapsUrl);
        var maps = JsonConvert.DeserializeObject<List<string>>(content);
        return maps;
    }

    public async Task<byte[]> GetCurrentMissionMap()
    {
        var missionMapStr = await _restCommand.SendGetRequest(_settings.GetCurrentMissionMapUrl);  
        return Convert.FromBase64String(missionMapStr);
    }
}
