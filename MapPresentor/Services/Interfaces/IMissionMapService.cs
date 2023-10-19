using System.Collections.Generic;
using System.Threading.Tasks;

namespace MapPresentor.Services.Interfaces;

public interface IMissionMapService
{
    Task SetMissionMap(string mapname);
    Task DeleteMap(string mapname);
    Task<List<string>> LoadMaps();
    Task<byte[]> GetCurrentMissionMap();
}