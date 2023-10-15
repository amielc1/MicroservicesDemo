using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow;

internal class UploadMapWorkflow : IUploadMapWorkflow
{
    private readonly IUploadMapFileTask _uploadMapFileTask;
    private readonly IValidateMapNameTask _validateMapNameTask;
    private readonly IValidateMapFileExistTask _validateMapFileExistTask;
    private readonly IAddMapCommand _addMapCommand;

    public UploadMapWorkflow(
        IUploadMapFileTask uploadMapFileTask,
        IValidateMapNameTask validateMapNameTask,
        IValidateMapFileExistTask validateMapFileExistTask,
        IAddMapCommand addMapCommand)
    {
        _uploadMapFileTask = uploadMapFileTask;
        _validateMapNameTask = validateMapNameTask;
        _validateMapFileExistTask = validateMapFileExistTask;
        _addMapCommand = addMapCommand;
    }

    public async Task<ResultModel> UploadMap(string mapname, Stream mapstream)
    {
        var mapUploaded = await _uploadMapFileTask.UploadMap(mapname, mapstream);

        if (!mapUploaded)
        {
            return new ResultModel { Success = false, ErrorMessage = "Failed to add map" };
        }

        return new ResultModel { Success = true, ErrorMessage = "Workflow Passed " };
    } 
}
