using MapEntitiesService.Core.appsettings;
using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MapEntitiesService.Controllers
{
    [Route("api/MapEntities")]
    [ApiController]
    public class MapEntitiesController : ControllerBase
    {
        private readonly IMapEntityService _mapEntityService;
        private readonly ILogger<MapEntitiesController> _logger;
        private readonly MapEntitiesServiceSettings _settings;

        public MapEntitiesController(IMapEntityService mapEntityService,
            ILogger<MapEntitiesController> logger,
            MapEntitiesServiceSettings settings)
        {
            _logger = logger;
            _settings = settings;
            _mapEntityService = mapEntityService;
        }

        [HttpPost]
        public async  Task<IActionResult> CreateMapEntity(
            [FromBody] MapEntityDto mapEntity)
        {
            _logger.LogInformation("from MapEntitiesController, send entity");
            await _mapEntityService.Publish(mapEntity, _settings.TopicName);
            return Ok(mapEntity);
        }
    }
}
