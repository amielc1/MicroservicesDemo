using MapEntitiesService.Core.Models;
using MapEntitiesService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MapEntitiesService.Controllers
{
    [Route("api/MapEntities")]
    [ApiController]
    public class MapEntitiesController : ControllerBase
    {
        private readonly IPublishService  _publishService;

        public MapEntitiesController(IPublishService  publishService)
        {
            _publishService = publishService;
        }

        [HttpPost]
        public IActionResult CreateMapEntity(
            [FromBody] MapEntityDto mapEntity)
        {
            _publishService.Publish(mapEntity, "topic");
            return Ok(mapEntity);
        }
    }
}
