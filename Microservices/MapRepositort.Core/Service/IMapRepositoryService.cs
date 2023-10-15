using MapRepository.Core.Models;

namespace MapRepository.Core.Service;

public interface IMapRepositoryService
{
    Task<ResultModel> DeleteMap(string mapname);
    Task<ResultModel> UploadMap(string mapname, Stream mapstream);
    Task<List<string>> GetAllMapsAsync();
}
