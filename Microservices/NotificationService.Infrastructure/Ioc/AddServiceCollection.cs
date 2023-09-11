using Microsoft.Extensions.DependencyInjection;
using NotificationService.Core.Interfaces;

namespace NotificationService.Infrastructure.Ioc
{
    public static class AddServiceCollection
    {
        public static void AddNotificationServiceLibrary(this IServiceCollection services)
        { 
            services.AddHostedService<Services.NotificationBackgroundService>();
            services.AddTransient<INotificationService, Services.NotificationService>();
        }
    }
}
