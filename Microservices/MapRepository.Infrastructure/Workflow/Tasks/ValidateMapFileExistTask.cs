using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow.Tasks;

internal class ValidateMapFileExistTask : IValidateMapFileExistTask
{
    private readonly IObjectExistsQuery _objectExistsQuery;

    public ValidateMapFileExistTask(IObjectExistsQuery objectExistsQuery)
    {
        _objectExistsQuery = objectExistsQuery;
    }
    public async Task<bool> Validate(string mapname)
        => await _objectExistsQuery.ObjectExist(mapname);

}
