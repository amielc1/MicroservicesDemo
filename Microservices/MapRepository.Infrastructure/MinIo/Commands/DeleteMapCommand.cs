using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using Microsoft.Extensions.Logging;
using Minio;

namespace MapRepository.Infrastructure.MinIo.Commands;

internal class DeleteMapCommand : IDeleteMapCommand
{
    private readonly MinioClient _minio;
    private readonly MinIoConfiguration _settings;
    private readonly ILogger<DeleteMapCommand> _logger;

    public DeleteMapCommand(MinIoConfiguration settings, ILogger<DeleteMapCommand> logger)
    {
        _settings = settings;
        _minio = new MinioFactory(_settings).CreateMinioClient();
        _logger = logger;
    }

    public async Task<ResultModel> DeleteMap(string mapname)
    {
        var mapres = new ResultModel();
        try
        {
            var args = new RemoveObjectArgs()
                .WithBucket(_settings.bucketName)
                .WithObject(mapname);

            _logger.LogInformation("Running example for API: RemoveObjectAsync");
            await _minio.RemoveObjectAsync(args).ConfigureAwait(false);
            _logger.LogInformation($"Removed object {mapname} from bucket {_settings.bucketName}  successfully");
            mapres.Success = true;
            mapres.ErrorMessage = $"Removed object {mapname} from bucket {_settings.bucketName}  successfully";
        }
        catch (Exception e)
        {
            var msg = $"[Bucket-Object]  Exception: {e}";
            _logger.LogError(msg);
            mapres.Success = false;
            mapres.ErrorMessage = msg;
        }
        return mapres;
    }
}
