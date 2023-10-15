using MapRepository.Core.Models;

namespace MapRepository.Core.Interfaces.Commands;

public interface IDeleteMapCommand
{
    Task<ResultModel> DeleteMap(string mapname, string repository);
}
