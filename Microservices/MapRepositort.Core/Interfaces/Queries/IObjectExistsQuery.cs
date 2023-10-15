namespace MapRepository.Core.Interfaces.Queries;

public interface IObjectExistsQuery
{
    Task<bool> ObjectExist(string name,string bucket);
}
