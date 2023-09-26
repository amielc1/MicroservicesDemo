using MapRepository.Core.Models;

namespace MapRepository.Core.Interfaces.Commands;

public interface IAddMapCommand
{
    Task<ResultModel> AddMap(string mapname, string pathToMap);
}
