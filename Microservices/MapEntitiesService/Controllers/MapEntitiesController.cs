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

        public MapEntitiesController(IMapEntityService mapEntityService, ILogger<MapEntitiesController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));    
            _mapEntityService = mapEntityService ?? throw new ArgumentNullException(nameof(mapEntityService));
        }

        [HttpPost]
        public async  Task<IActionResult> CreateMapEntity(
            [FromBody] MapEntityDto mapEntity)
        {
            _logger.LogInformation("from MapEntitiesController, send entity");
            await _mapEntityService.Publish(mapEntity, "topic");
            return Ok(mapEntity);
        }
    }
}
