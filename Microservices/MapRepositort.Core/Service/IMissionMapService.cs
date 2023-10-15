using MapRepository.Core.Models;

namespace MapRepository.Core.Service;

public interface IMissionMapService
{
    Task<ResultModel> SetMissiionMap(string mapname);

}
