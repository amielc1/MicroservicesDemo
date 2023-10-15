using MapRepository.Core.Models;

namespace MapRepository.Core.Interfaces.Commands;

public interface ICopyMapCommand
{
    Task<ResultModel> CopyMap(string mapname, string fromBucket, string toBucket);
}
