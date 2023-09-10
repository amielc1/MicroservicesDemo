using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageBroker.Infrastructure.RabbitMQ
{
    internal class RabbitMQSubscriber : ISubscriber
    {
        private const string queueName = "entityQueue";
        private readonly ILogger<RabbitMQPublisher> _logger;
        IModel channel;

        public RabbitMQSubscriber(ILogger<RabbitMQPublisher> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        private void onMessage(string message)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                _logger.LogInformation($" [x] Received {message}");
            };
            channel.BasicConsume(queue: queueName,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public Task Subscribe(string topic, Action<string> OnMessageArrived)
        {

            var factory = new ConnectionFactory { HostName = "rabbithost" };
            var connection = factory.CreateConnection();
            channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName,
                   durable: false,
                   exclusive: false,
                   autoDelete: false,
                   arguments: null);

            _logger.LogInformation(" [*] Waiting for messages.");

            return Task.CompletedTask;
        }
    }
}
