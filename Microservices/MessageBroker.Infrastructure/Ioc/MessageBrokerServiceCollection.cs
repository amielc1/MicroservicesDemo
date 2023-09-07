using MessageBroker.Core.Interfaces;
using MessageBroker.Infrastructure.RabbitMQ;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBroker.Infrastructure.Ioc
{
    public static class MessageBrokerServiceCollection
    {
        public static void AddMessageBrokerLibrary(this IServiceCollection services)
        {
            services.AddScoped<IPublisher, RabbitMQPublisher>();
            services.AddScoped<ISubscriber, RabbitMQSubscriber>();
        }
    }
}
