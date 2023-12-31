﻿using MessageBroker.Core.Interfaces;
using MessageBroker.Core.Models;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MessageBroker.Infrastructure.RabbitMQ;

internal class RabbitMQSubscriber : ISubscriber
{
    private readonly ILogger<RabbitMQPublisher> _logger;
    private readonly SubscriberSettings _settings;
    private IModel _channel;

    public RabbitMQSubscriber(ILogger<RabbitMQPublisher> logger, SubscriberSettings settings)
    {
        _logger = logger;
        _settings = settings;
    }

    public Task Subscribe(string topic, Action<string> OnMessageArrived)
    {
        _logger.LogInformation("Register {calss} to Topic {topic}, func : {function} (RabbitMQ)", nameof(RabbitMQSubscriber), topic, OnMessageArrived.Method);
        var factory = new ConnectionFactory { HostName = _settings.HostName };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare(queue: topic,
               durable: false,
               exclusive: false,
               autoDelete: false,
               arguments: null);

        _logger.LogInformation(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation($" [x] Received {message}");
            OnMessageArrived(message);
        };

        _channel.BasicConsume(queue: topic,
                             autoAck: true,
                             consumer: consumer);

        return Task.CompletedTask;
    }
}
