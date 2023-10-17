namespace MapRepository.Core.Interfaces.Queries;

public interface IGetMapByNameQuery
{
    Task<string> GetMap(string mapname, string repository);
}
