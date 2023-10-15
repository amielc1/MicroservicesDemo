using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Queries;
using Microsoft.Extensions.Logging;
using Minio;
using Minio.Exceptions;

namespace MapRepository.Infrastructure.MinIo.Queries;

internal class ObjectExistsQuery : IObjectExistsQuery
{
    private readonly MinioClient _minio;
    private readonly MinIoConfiguration _settings;
    private readonly ILogger<ObjectExistsQuery> _logger;

    public ObjectExistsQuery(MinIoConfiguration settings, ILogger<ObjectExistsQuery> logger)
    {
        _settings = settings;
        _logger = logger;
        _minio = new MinioFactory(_settings).CreateMinioClient();
    }

    public async Task<bool> ObjectExist(string name, string bucket)
    {
        try
        {
            var getObjectArgs = new GetObjectArgs()
                .WithBucket(bucket)
                .WithObject(name)
                .WithCallbackStream(stream => { });
            _ = await _minio.GetObjectAsync(getObjectArgs).ConfigureAwait(false);
            return true;
        }
        catch (ObjectNotFoundException)
        {
            return false;
        }
    }
}
