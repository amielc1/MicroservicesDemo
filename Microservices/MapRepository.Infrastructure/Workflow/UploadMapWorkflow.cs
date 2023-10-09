using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow;

internal class UploadMapWorkflow : IUploadMapWorkflow
{
    private readonly IValidateMapFileTask _validateMapFileTask;
    private readonly IValidateMapNameTask _validateMapNameTask;
    private readonly IValidateMapFileExistTask _validateMapFileExistTask;
    private readonly IAddMapCommand _addMapCommand;

    public UploadMapWorkflow(
        IValidateMapFileTask validateMapFileTask,
        IValidateMapNameTask validateMapNameTask,
        IValidateMapFileExistTask validateMapFileExistTask,
        IAddMapCommand addMapCommand)
    {
        _validateMapFileTask = validateMapFileTask;
        _validateMapNameTask = validateMapNameTask;
        _validateMapFileExistTask = validateMapFileExistTask;
        _addMapCommand = addMapCommand;
    }

    public async Task<ResultModel> UploadMap(string mapname, string pathToMap)
    {
       
        //var validateMapFileExistTask = await _validateMapFileExistTask.Validate(mapname);
        //if (!validateMapFileExistTask)
        //{
        //    return new ResultModel { Success = false, ErrorMessage = "Map already exist" };
        //}

        //var validateMapFileTask = _validateMapFileTask.Validate(mapname);
        //if (!validateMapFileTask)
        //{
        //    return new ResultModel { Success = false, ErrorMessage = "Failed to validate map file" };
        //}

        //var validateMapNameTask = _validateMapNameTask.Validate(mapname);
        //if (!validateMapNameTask)
        //{
        //    return new ResultModel { Success = false, ErrorMessage = "Failed to validate map name" };
        //}

        var addmapResult = await _addMapCommand.AddMap(mapname, pathToMap);
        if (!addmapResult.Success)
        {
            return new ResultModel { Success = false, ErrorMessage = "Failed to add map" };
        }

        //publish new map uploaded to notification service. 

        return new ResultModel { Success = true, ErrorMessage = "Workflow Passed " };
    }
}
