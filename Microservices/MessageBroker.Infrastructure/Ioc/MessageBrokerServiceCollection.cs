using MessageBroker.Core.Interfaces;
using MessageBroker.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Infrastructure.Ioc
{
    public static class MessageBrokerServiceCollection
    {
        public static void AddMessageBrokerPublishLibrary(this IServiceCollection services)
        {
            services.AddScoped<IPublisher, RabbitMQPublisher>();
        }
        public static void AddMessageBrokerSubscribeLibrary(this IServiceCollection services)
        {
            services.AddTransient<ISubscriber, RabbitMQSubscriber>();
        }
    }
}
