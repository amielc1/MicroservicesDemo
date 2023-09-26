using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Models;
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

    public async Task<ResultModel> GetMap(string mapname, string pathToSave)
    {
        var mapres = new ResultModel();
        try
        {
            _logger.LogInformation("Running example for API: GetObjectAsync");
            var args = new GetObjectArgs()
            .WithBucket(_settings.bucketName)
                .WithObject(mapname)
                .WithFile(pathToSave);
            var stat = await _minio.GetObjectAsync(args).ConfigureAwait(false);

            _logger.LogInformation($"Downloaded the file {mapname} in bucket {_settings.bucketName}");
            _logger.LogInformation($"Stat details of object {mapname} in bucket {_settings.bucketName}\n" + stat);
            mapres.Success = true;
        }
        catch (Exception e)
        {
            var msg = $"[Bucket]  Exception: {e}";
            mapres.Success = false;
            mapres.ErrorMessage = msg;
            _logger.LogError(msg);
            return mapres;
        }
        return mapres;
    }
}
