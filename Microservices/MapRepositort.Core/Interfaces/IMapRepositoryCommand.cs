namespace MapRepository.Infrastructure.MinIo.Commands;

public interface IMapRepositoryCommand
{
    Task AddMap(string mapname);
    Task DeleteMap(string mapname);
}
