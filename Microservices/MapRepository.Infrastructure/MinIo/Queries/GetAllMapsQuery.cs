using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Models;
using Microsoft.Extensions.Logging;
using Minio;
using System.Reactive.Linq;

namespace MapRepository.Infrastructure.MinIo.Queries;

internal class GetAllMapsQuery : IGetAllMapsQuery
{
    private readonly MinioClient _minio;
    private readonly MinIoConfiguration _settings;
    private readonly ILogger<GetAllMapsQuery> _logger;

    public GetAllMapsQuery(MinIoConfiguration settings, ILogger<GetAllMapsQuery> logger)
    {
        _settings = settings;
        _logger = logger;
        _minio = new MinioFactory(_settings).CreateMinioClient();

    }
    public async Task<List<string>> GetAllMaps(string bucket)
    {
        try
        {
            _logger.LogInformation("Running example for API: ListObjectsAsync");
            var listArgs = new ListObjectsArgs()
                .WithBucket(bucket)
                .WithPrefix(null)
                .WithRecursive(true);

            var observable = _minio.ListObjectsAsync(listArgs);

            var items = await observable
                .Select(item => item.Key)
                .Do(itemKey => _logger.LogInformation($"item {itemKey}"),
                    ex => _logger.LogError($"OnError: {ex}"),
                    () => _logger.LogInformation($"Listed all objects in bucket {_settings.mapRepositoryBucketName}"))
                .ToList();
             
            return (List<string>)items;

        }
        catch (Exception e)
        {
            Console.WriteLine($"[Bucket]  Exception: {e}");
            return new List<string>();
        }

    }

}
