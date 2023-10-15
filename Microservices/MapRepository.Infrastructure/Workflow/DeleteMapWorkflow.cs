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

    //TODO pass bucketname 
    public async Task<ResultModel> DeleteMap(string mapname)
        =>  new ResultModel() { Success = true };//_deleteMapCommand.DeleteMap(mapname,"BUCKET");

}
