using Microsoft.Extensions.DependencyInjection;
using NotificationService.Core.Interfaces;
using NotificationService.Infrastructure.Services;

namespace NotificationService.Infrastructure.Ioc;

public static class ServiceCollectionExtention
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddSingleton<INewMapEntityCommandHandler, NewMapEntityCommandHandler>();
        services.AddHostedService<NotificationBackgroundService>();
        services.AddTransient<INotificationService, Services.NotificationService>();
    }
}
