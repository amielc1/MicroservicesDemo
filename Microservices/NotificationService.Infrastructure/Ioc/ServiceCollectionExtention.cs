using Microsoft.Extensions.DependencyInjection;
using NotificationService.Core.Interfaces.MapEntity;
using NotificationService.Core.Interfaces.MissionMap;
using NotificationService.Infrastructure.Services;
using NotificationService.Infrastructure.Services.MapEntity;
using NotificationService.Infrastructure.Services.MissionMap;

namespace NotificationService.Infrastructure.Ioc;

public static class ServiceCollectionExtention
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    { 
        services.AddHostedService<NotificationBackgroundService>();
        services.AddSingleton<INewMapEntityCommandHandler, NewMapEntityCommandHandler>();
        services.AddTransient<IMapEntitySubscribeService, MapEntitySubscribeService>();
        services.AddTransient<IMissionMapSubscribeService, MissionMapSubscribeService>();
        services.AddSingleton<IMissionMapChangedCommandHandler, MissionMapChangedCommandHandler>();
    }
}
