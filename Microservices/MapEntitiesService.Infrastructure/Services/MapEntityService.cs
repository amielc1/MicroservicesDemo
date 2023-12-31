﻿using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services;
using MessageBroker.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MapEntitiesService.Infrastructure.Services;

internal class MapEntityService : IMapEntityService
{
    private readonly IPublisher _publishService;
    private readonly ILogger<MapEntityService> _logger;

    public MapEntityService(ILogger<MapEntityService> logger, IPublisher publishService)
    {
        _logger = logger;
        _publishService = publishService;
    }
    public async Task Publish(MapEntityDto entity, string topic)
    {
        _logger.LogInformation("Send entity from MapEntityService");
        var msg = JsonSerializer.Serialize(entity);
        await _publishService.Publish(msg, topic);
    }
}
