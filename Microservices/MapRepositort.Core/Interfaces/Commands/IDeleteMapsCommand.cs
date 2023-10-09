namespace MapRepository.Core.Interfaces.Commands;

public interface IDeleteMapsCommand
{
    Task<bool> DeleteMaps(string bucketName, List<string> maps = null);
}
