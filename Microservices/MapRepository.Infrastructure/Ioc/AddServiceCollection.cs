using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Service;
using MapRepository.Core.Workflow;
using MapRepository.Core.Workflow.Tasks;
using MapRepository.Infrastructure.MinIo.Commands;
using MapRepository.Infrastructure.MinIo.Queries;
using MapRepository.Infrastructure.Services;
using MapRepository.Infrastructure.Workflow;
using MapRepository.Infrastructure.Workflow.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MapRepository.Infrastructure.Ioc;

public static class AddServiceColleAddServiceCollectionction
{
    public static void AddServiceLibrary(this IServiceCollection services)
    {
        services.AddTransient<IAddMapCommand, AddMapCommand>();
        services.AddTransient<IDeleteMapCommand, DeleteMapCommand>();
        services.AddTransient<IGetAllMapsQuery, GetAllMapsQuery>();
        services.AddTransient<IGetMapByNameQuery, GetMapByNameQuery>();
        services.AddTransient<IObjectExistsQuery, ObjectExistsQuery>();

        services.AddTransient<IUploadMapWorkflow, UploadMapWorkflow>();
        services.AddTransient<IGetMapByNameWorkflow, GetMapByNameWorkflow>();
        services.AddTransient<IDeleteMapWorkflow, DeleteMapWorkflow>();
        services.AddTransient<IGetAllMapsWorkflow, GetAllMapsWorkflow>();

        services.AddTransient<IValidateMapNameTask, ValidateMapNameTask>();
        services.AddTransient<IValidateMapFileTask, ValidateMapFileTask>();
        services.AddTransient<IValidateMapFileExistTask, ValidateMapFileExistTask>();

        services.AddTransient<IMapRepositoryService, MapRepositoryService>();
    }
}
