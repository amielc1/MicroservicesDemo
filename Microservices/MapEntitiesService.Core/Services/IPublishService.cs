﻿using MapEntitiesService.Core.Models;

namespace MapEntitiesService.Core.Services
{
    public interface IPublishService
    {
        Task Publish(MapEntityDto entity, string topic);
    }
}
