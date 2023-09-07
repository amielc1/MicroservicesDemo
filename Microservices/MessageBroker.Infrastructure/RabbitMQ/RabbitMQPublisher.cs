using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
namespace MessageBroker.Infrastructure.RabbitMQ
{
    internal class RabbitMQPublisher : IPublisher
    {
        private readonly ILogger<RabbitMQPublisher> _logger;

        public RabbitMQPublisher(ILogger<RabbitMQPublisher> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task Publish(string message, string topic)
        {
            _logger.LogInformation($"Send Message {message} to RabbitMQPublishService. topic {topic}");

            return Task.CompletedTask;
        }
    }
}
