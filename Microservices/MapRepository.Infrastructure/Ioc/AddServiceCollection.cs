using MapRepository.Core.Interfaces;
using MapRepository.Infrastructure.MinIo.Commands;
using MapRepository.Infrastructure.MinIo.Queries;
using Microsoft.Extensions.DependencyInjection;
using MapRepository.Core.Service;
namespace MapRepository.Infrastructure.Ioc;

public static class AddServiceColleAddServiceCollectionction
{
    public static void AddServiceLibrary(this IServiceCollection services)
    {
        services.AddTransient<IMapRepositoryService, MapRepositoryService>();
        services.AddTransient<IMapRepositoryCommand, MapRepositoryCommand>();
        services.AddTransient<IMapRepositoryQuery, MapRepositoryQuery>();
    }
}
