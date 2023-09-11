using Microsoft.AspNetCore.Mvc;
using NotificationService.Infrastructure.Services;
using NotificationService.Core.Interfaces;

namespace NotificationService.Controllers
{
    [Route("api/Subscribe")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ILogger<CommandsController> _logger;

        public CommandsController(INotificationService notificationService, ILogger<CommandsController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe()
        {
            _logger.LogInformation("from CommandsController - Subscribe");
            await _notificationService.Subscribe("entityQueue", foo);
            return Ok();
        }

        private void foo(string msg)
        {
            _logger.LogInformation($"Message recived ~~~ {msg} ~~~");

        }
    }
}
