using MapRepository.Core.Models;

namespace MapRepository.Core.Interfaces.Queries;

public interface IGetMapByNameQuery
{
    Task<ResultModel> GetMap(string mapname, string pathToSave);
}
