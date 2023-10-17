using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Queries;
using Microsoft.Extensions.Logging;
using Minio;

namespace MapRepository.Infrastructure.MinIo.Queries;

internal class GetMapByNameQuery : IGetMapByNameQuery
{
    private readonly MinioClient _minio;
    private readonly MinIoConfiguration _settings;
    private readonly ILogger<GetMapByNameQuery> _logger;

    public GetMapByNameQuery(MinIoConfiguration settings, ILogger<GetMapByNameQuery> logger)
    {
        _settings = settings;
        _logger = logger;
        _minio = new MinioFactory(_settings).CreateMinioClient();
    }

    public async Task<string> GetMap(string mapname, string repository)
    {
        try
        {
            _logger.LogInformation("Try to GetMap {mapname} from Repository {repository}", mapname, repository);
            using (var ms = new MemoryStream())
            {
                var args = new GetObjectArgs()
                 .WithBucket(repository)
                 .WithObject(mapname)
                 .WithCallbackStream((s) => s.CopyToAsync(ms));
                var result = await _minio.GetObjectAsync(args);
                // Convert the memory stream's buffer to a byte array
                byte[] byteArray = ms.ToArray();
                // Convert the byte array to a Base64 string
                string base64String = Convert.ToBase64String(byteArray);
                return base64String;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when Try to GetMap {mapname} from Repository {repository}", mapname, repository);
            throw;
        }
    }
}
