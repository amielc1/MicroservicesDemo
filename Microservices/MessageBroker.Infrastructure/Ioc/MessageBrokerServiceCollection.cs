using MessageBroker.Core.Interfaces;
using MessageBroker.Core.Models;
using MessageBroker.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Infrastructure.Ioc
{
    public static class MessageBrokerServiceCollection
    {
        public static void AddMessageBrokerPublishLibrary(this IServiceCollection services, PublisherSettings settings)
        {
            services.AddSingleton(settings);
            services.AddTransient<IPublisher, RabbitMQPublisher>();
        }
        public static void AddMessageBrokerSubscribeLibrary(this IServiceCollection services, SubscriberSettings settings)
        {
            services.AddSingleton(settings);
            services.AddTransient<ISubscriber, RabbitMQSubscriber>();
        }
    }
}
