using MapRepository.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MapRepositoryAPI.Controllers
{
    [Route("api/MapRepository")]
    [ApiController]
    public class MapRepositoryController : ControllerBase
    {
        public record MapDto(string Name, IFormFile file);

        private readonly IMapRepositoryService _mapRepository;
        private readonly ILogger<MapRepositoryController> _logger;



        public MapRepositoryController(IMapRepositoryService mapRepository, ILogger<MapRepositoryController> logger)
        {
            _logger = logger;
            _mapRepository = mapRepository;
        }

        [HttpPost]
        [Route("DeleteMap")]
        public async Task<IActionResult> DeleteMap(string mapName)
        {
            await _mapRepository.DeleteMap(mapName);
            return Ok();
        }

        [HttpPost]
        [Route("UploadFile")]
      
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var a = file;
            //var result = await WriteFile(file);
            await _mapRepository.AddMap(file.FileName);
            return Ok();
        }

        [HttpPost]
        [Route("UploadFileName")]

        public async Task<IActionResult> UploadFileName(string file)
        {
            await _mapRepository.AddMap(file);
            return Ok();
        }


        private async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
            }
            return filename;
        }

    }
}
