using MapEntitiesService.Core.Services;
using MapEntitiesService.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MapEntitiesService.Infrastructure.Ioc
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructureLibrary(this IServiceCollection services)
        {
            services.AddScoped<IPublishService, RabbitMQPublishService>();
            services.AddScoped<IMapEntityService, MapEntityService>();
        }
    }
}
