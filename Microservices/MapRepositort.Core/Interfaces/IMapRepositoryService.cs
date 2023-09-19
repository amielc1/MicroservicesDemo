namespace MapRepository.Core.Interfaces;

public interface IMapRepositoryService
{
    Task AddMap(string mapname);
    Task DeleteMap(string mapname);
    Task GetMap(string mapname);
    Task GetAllMaps();
}
