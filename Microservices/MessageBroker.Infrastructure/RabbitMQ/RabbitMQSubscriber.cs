using MessageBroker.Core.Interfaces;
using MessageBroker.Core.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageBroker.Infrastructure.RabbitMQ
{
    internal class RabbitMQSubscriber : ISubscriber
    {
        private readonly ILogger<RabbitMQPublisher> _logger;
        private readonly SubscriberSettings _settings;
        IModel channel;

        public RabbitMQSubscriber(ILogger<RabbitMQPublisher> logger, SubscriberSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }
         
        public Task Subscribe(string topic, Action<string> OnMessageArrived)
        {
            var factory = new ConnectionFactory { HostName = _settings.HostName };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(queue: topic,
                   durable: false,
                   exclusive: false,
                   autoDelete: false,
                   arguments: null);

            _logger.LogInformation(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
                OnMessageArrived(message);
            };

            channel.BasicConsume(queue: topic,
                                 autoAck: true,
                                 consumer: consumer);

            return Task.CompletedTask;
        }
    }
}
