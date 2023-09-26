using MapRepository.Core.Models;

namespace MapRepository.Core.Service;

public interface IMapRepositoryService
{
    Task<ResultModel> DeleteMap(string mapname);
    Task<ResultModel> UploadMap(string mapname, string pathToMap);
    Task<ResultModel> GetMap(string mapname, string pathToSave);
    Task<List<string>> GetAllMapsAsync();
}
