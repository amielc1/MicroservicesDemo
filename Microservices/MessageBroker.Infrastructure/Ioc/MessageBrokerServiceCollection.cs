using MessageBroker.Core.Interfaces;
using MessageBroker.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Infrastructure.Ioc
{
    public static class MessageBrokerServiceCollection
    {
        public static void AddMessageBrokerLibrary(this IServiceCollection services)
        {         
            //services.AddScoped<ISubscriber, RabbitMQSubscriber>();
            services.AddScoped<IPublisher, RabbitMQPublisher>();
        }
    }
}
