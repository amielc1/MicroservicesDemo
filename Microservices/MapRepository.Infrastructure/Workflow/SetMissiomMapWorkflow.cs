using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks;

namespace MapRepository.Infrastructure.Workflow;

internal class SetMissiomMapWorkflow : ISetMissiomMapWorkflow
{

    private readonly IValidateOneMapFileExistTask _validateOneMapFileExistTask;
    private readonly MinIoConfiguration _settings;
    private readonly IDeleteMapsCommand _deleteMapsCommand;
    private readonly IAddMapCommand _addMapCommand;


    public SetMissiomMapWorkflow(
        IValidateOneMapFileExistTask validateOneMapFileExistTask,
        IDeleteMapsCommand deleteMapsCommand,
        IAddMapCommand addMapCommand,   
        MinIoConfiguration settings)
    {
        _validateOneMapFileExistTask = validateOneMapFileExistTask;
        _deleteMapsCommand = deleteMapsCommand;
        _addMapCommand = addMapCommand; 
        _settings = settings;   
    }

    public async Task<ResultModel> SetMissiomMap(string missionMap)
    {
        //1.only one map file exist 
        //2.add current map 
        //3. delete privius map 

        var validateOneMapFileExistTask = await _validateOneMapFileExistTask.Validate(missionMap);
        if (!validateOneMapFileExistTask)
        {
            //clear all maps  
            var mapsDeleted = await _deleteMapsCommand.DeleteMaps(_settings.missionMapBucketName);
            if (!mapsDeleted)
            {
                return new ResultModel { Success = false, ErrorMessage = "Maps in buckets doesnt deleted" };
            }
            
            //add new map
            //var mapAded = await _addMapCommand.AddMap(missionMap)
        }

        //var insertNewMapTask = await _validateOneMapFileExistTask.Validate();
        //if (!validateOneMapFileExistTask)
        //{
        //    return new ResultModel { Success = false, ErrorMessage = "There are many maps, only one maps allowed" };
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

        //var addmapResult = await _addMapCommand.AddMap(mapname, pathToMap);
        //if (!addmapResult.Success)
        //{
        //    return new ResultModel { Success = false, ErrorMessage = "Failed to add map" };
        //}

        ////publish new map uploaded to notification service. 

        return new ResultModel { Success = true, ErrorMessage = "Workflow Passed " };
    }
}
