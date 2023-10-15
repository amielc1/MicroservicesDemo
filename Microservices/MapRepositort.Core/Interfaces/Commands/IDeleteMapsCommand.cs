namespace MapRepository.Core.Interfaces.Commands;

public interface IDeleteMapsCommand
{
    Task<bool> DeleteMaps(string repository, List<string> maps = null);
}
