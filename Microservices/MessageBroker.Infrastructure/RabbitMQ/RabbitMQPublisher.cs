using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageBroker.Infrastructure.RabbitMQ
{
    internal class RabbitMQPublisher : IPublisher
    {
        private const string queueName = "entityQueue"; 
        private readonly ILogger<RabbitMQPublisher> _logger;
        IModel channel;

        public RabbitMQPublisher(ILogger<RabbitMQPublisher> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();
        }

        public Task Publish(string message, string topic)
        {

            channel.QueueDeclare(queue: queueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);


            _logger.LogInformation($"Send Message {message} to RabbitMQPublishService. topic {topic}");

            return Task.CompletedTask;
        }
    }
}
