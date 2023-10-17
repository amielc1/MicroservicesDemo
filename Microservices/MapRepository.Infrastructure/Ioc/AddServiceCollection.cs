using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Service;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks;
using MapRepository.Core.Workflow.Tasks.MapRepositoryTasks;
using MapRepository.Core.Workflow.Tasks.MissionMapTasks;
using MapRepository.Infrastructure.MinIo.Commands;
using MapRepository.Infrastructure.MinIo.Queries;
using MapRepository.Infrastructure.Services;
using MapRepository.Infrastructure.Workflow;
using MapRepository.Infrastructure.Workflow.Tasks;
using MapRepository.Infrastructure.Workflow.Tasks.MapRepositoryTasks;
using MapRepository.Infrastructure.Workflow.Tasks.MissionMapTasks;
using Microsoft.Extensions.DependencyInjection;

namespace MapRepository.Infrastructure.Ioc;

public static class AddServiceColleAddServiceCollectionction
{
    public static void AddServiceLibrary(this IServiceCollection services)
    {
        services.AddTransient<IAddMapCommand, AddMapCommand>();
        services.AddTransient<IDeleteMapCommand, DeleteMapCommand>();
        services.AddTransient<IDeleteMapsCommand, DeleteMapsCommand>();
        services.AddTransient<ICopyMapCommand, CopyMapCommand>();

        services.AddTransient<IGetAllMapsQuery, GetAllMapsQuery>();
        services.AddTransient<IGetMapByNameQuery, GetMapByNameQuery>();
        services.AddTransient<IObjectExistsQuery, ObjectExistsQuery>();

        services.AddTransient<IUploadMapWorkflow, UploadMapWorkflow>();
        services.AddTransient<IGetMapByNameWorkflow, GetMapByNameWorkflow>();
        services.AddTransient<IDeleteMapWorkflow, DeleteMapWorkflow>();
        services.AddTransient<IGetAllMapsWorkflow, GetAllMapsWorkflow>();
        services.AddTransient<ISetMissiomMapWorkflow, SetMissiomMapWorkflow>();

        services.AddTransient<IValidateMapNameTask, ValidateMapNameTask>();
        services.AddTransient<IUploadMapFileTask, UploadMapFileTask>();
        services.AddTransient<IValidateMapFileExistTask, ValidateMapFileExistTask>();
        services.AddTransient<IValidateOneMapFileExistTask, ValidateOneMapFileExistTask>();
        services.AddTransient<IGetAllMapsTask, GetAllMapsTask>();
        services.AddTransient<IDeleteMapTask, DeleteMapTask>();

        services.AddTransient<ICopySelectedMapTask, CopySelectedMapTask>();
        services.AddTransient<IDeletePrevMissionMapTask, DeletePrevMissionMapTask>();
        services.AddTransient<IFindMapInMapsRepositoryTask, FindMapInMapsRepositoryTask>();
        services.AddTransient<IPublishMissionMapTask, PublishMissionMapTask>();
        services.AddTransient<IGetCurrentMissionMapTask, GetCurrentMissionMapTask>();


        services.AddTransient<IMapRepositoryService, MapRepositoryService>();
        services.AddTransient<IMissionMapService, MissionMapService>();

    }
}
