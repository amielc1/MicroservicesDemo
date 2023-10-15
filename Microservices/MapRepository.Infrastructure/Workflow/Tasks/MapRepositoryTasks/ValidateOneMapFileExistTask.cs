using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow.Tasks;

internal class ValidateOneMapFileExistTask : IValidateOneMapFileExistTask
{
    private readonly IObjectExistsQuery _objectExistsQuery;
    public ValidateOneMapFileExistTask(IObjectExistsQuery objectExistsQuery)
    {
        _objectExistsQuery = objectExistsQuery;
    }
    public Task<bool> Validate(string mapname, string bucket)
        => _objectExistsQuery.ObjectExist(mapname, bucket);
}
