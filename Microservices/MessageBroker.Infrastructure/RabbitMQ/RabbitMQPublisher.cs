using MessageBroker.Core.Interfaces;
using MessageBroker.Core.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace MessageBroker.Infrastructure.RabbitMQ
{
    internal class RabbitMQPublisher : IPublisher
    {

        private readonly ILogger<RabbitMQPublisher> _logger;
        private readonly PublisherSettings _settings;
        IModel channel;

        public RabbitMQPublisher(ILogger<RabbitMQPublisher> logger, PublisherSettings settings)
        {
            _logger = logger;
            _settings = settings;
            var factory = new ConnectionFactory { HostName = _settings.HostName };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public Task Publish(string message, string topic)
        {

            channel.QueueDeclare(queue: topic,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                             routingKey: topic,
                                             basicProperties: null,
                                             body: body);

            _logger.LogInformation($"Send Message {message} to RabbitMQPublishService. topic {topic}");

            return Task.CompletedTask;
        }
    }
}
