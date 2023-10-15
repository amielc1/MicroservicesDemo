using MapRepository.Core.Models;

namespace MapRepository.Core.Interfaces.Queries;

public interface IGetAllMapsQuery
{
    Task<List<string>> GetAllMaps(string repository);
}
