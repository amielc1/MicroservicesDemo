using MapEntitiesService.Core.appsettings;
using MapEntitiesService.Core.Services;
using MapEntitiesService.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MapEntitiesService.Infrastructure.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLibrary(this IServiceCollection services, MapEntitiesServiceSettings settings)
        {
            services.AddSingleton(settings);
            services.AddScoped<IMapEntityService, MapEntityService>();
        }
    }
}
