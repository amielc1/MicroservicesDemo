using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Models;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;

namespace MapRepository.Infrastructure.Workflow;

internal class SetMissiomMapWorkflow : ISetMissiomMapWorkflow
{
    private readonly IFindMapInMapsRepositoryTask _findMapInMapsRepositoryTask;
    private readonly IDeletePrevMissionMapTask _deletePrevMissionMapTask;
    private readonly ICopySelectedMapTask _copySelectedMapTask;
    private readonly IPublishMissionMapTask _publishMissionMapTask;
    private readonly IGetCurrentMissionMapTask _getCurrentMissionMapTask;
    private readonly MinIoConfiguration _settings;


    public SetMissiomMapWorkflow(
        IFindMapInMapsRepositoryTask findMapInMapsRepositoryTask,
        IDeletePrevMissionMapTask deletePrevMissionMapTask,
        ICopySelectedMapTask copySelectedMapTask,
        IPublishMissionMapTask publishMissionMapTask,
        IGetCurrentMissionMapTask getCurrentMissionMapTask,
        MinIoConfiguration settings)
    {
        _findMapInMapsRepositoryTask = findMapInMapsRepositoryTask;
        _deletePrevMissionMapTask = deletePrevMissionMapTask;
        _copySelectedMapTask = copySelectedMapTask;
        _publishMissionMapTask = publishMissionMapTask;
        _getCurrentMissionMapTask = getCurrentMissionMapTask;
        _settings = settings;
    }

    public Task<string> GetCurrentMissionMap()
    {
        return _getCurrentMissionMapTask.GetCurrentMissionMap();
    }

    public async Task<ResultModel> SetMissiomMap(string mapname)
    {
        //1.only one map file exist 
        //2.add current map 
        //3. delete privius map 

        var validateOneMapFileExistTask = await _findMapInMapsRepositoryTask.Validate(mapname);
        if (validateOneMapFileExistTask)
        {
            //clear all maps  
            var mapsDeleted = await _deletePrevMissionMapTask.DeletePrevMapTask();
            if (!mapsDeleted)
            {
                return new ResultModel { Success = false, ErrorMessage = "Maps in buckets doesnt deleted" };
            }

            //add new map
            var mapCopyed = await _copySelectedMapTask.CopySelectedMap(mapname);
            if (!mapCopyed)
            {
                return new ResultModel { Success = false, ErrorMessage = "Maps not copyed" };
            }

            await _publishMissionMapTask.PublishMap(mapname);
        }
        else
        {
            return new ResultModel { Success = false, ErrorMessage = $"Map {mapname} didn't find in map repository" };
        }

        return new ResultModel { Success = true, ErrorMessage = "Workflow Passed " };
    }
}
