namespace MapRepository.Core.Interfaces;

public interface IMapRepositoryQuery
{
    Task GetMap(string mapname);
    Task GetAllMaps();


}