using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NotificationService.Core.Interfaces;

namespace NotificationService.Infrastructure.Services
{
    internal class NotificationBackgroundService : BackgroundService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly INotificationService _notificationService;


        public NotificationBackgroundService(ILogger<NotificationService> logger, INotificationService notificationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _notificationService.Subscribe("entityQueue", onMessageArrived);
        }

        private void onMessageArrived(string msg)
        {
            _logger.LogInformation($"message arrived ####  {msg}  ####");
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Subscribe Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}
