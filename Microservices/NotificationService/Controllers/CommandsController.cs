﻿using Microsoft.AspNetCore.Mvc;

namespace NotificationService.Controllers;
[Route("api/Subscribe")]
[ApiController]
public class CommandsController : ControllerBase
{
    private readonly ILogger<CommandsController> _logger;

    public CommandsController(ILogger<CommandsController> logger)
    {
        _logger = logger;
    }
}

