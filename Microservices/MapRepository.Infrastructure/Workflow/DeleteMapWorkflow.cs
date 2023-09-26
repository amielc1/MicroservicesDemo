using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow;

namespace MapRepository.Infrastructure.Workflow;

internal class DeleteMapWorkflow : IDeleteMapWorkflow
{
    private readonly IDeleteMapCommand _deleteMapCommand;

    public DeleteMapWorkflow(IDeleteMapCommand deleteMapCommand)
    {
        _deleteMapCommand = deleteMapCommand;
    }
    public async Task<ResultModel> DeleteMap(string mapname)
        => await _deleteMapCommand.DeleteMap(mapname);

}
