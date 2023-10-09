using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using Microsoft.Extensions.Logging;
using Minio;
using System.Reactive.Linq;

namespace MapRepository.Infrastructure.MinIo.Commands
{
    internal class DeleteMapsCommand : IDeleteMapsCommand
    {
        private readonly MinioClient _minio;
        private readonly MinIoConfiguration _settings;
        private readonly ILogger<DeleteMapsCommand> _logger;

        public DeleteMapsCommand(MinIoConfiguration settings, Logger<DeleteMapsCommand> logger)
        {
            _settings = settings;
            _minio = new MinioFactory(_settings).CreateMinioClient();
            _logger = logger;
        }
        public async Task<bool> DeleteMaps(string bucketName, List<string> maps = null)
        {
            try
            {
                Console.WriteLine("Running example for API: RemoveObjectsAsync");
                if (maps is not null)
                {
                    var objArgs = new RemoveObjectsArgs()
                        .WithBucket(bucketName)
                        .WithObjects(maps);
                    var observable = await _minio.RemoveObjectsAsync(objArgs).ConfigureAwait(false);

                    var items = await observable
                        .Select(item => item.Key)
                        .Do(
                            itemKey => _logger.LogInformation($"item {itemKey}"),
                            ex => _logger.LogError($"OnError: {ex}"),
                            () => _logger.LogInformation($"Removed objects in list from {bucketName}\n"))
                        .ToList();
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket-Object]  Exception: {e}");
                return false;
            }
        }
    }
}
