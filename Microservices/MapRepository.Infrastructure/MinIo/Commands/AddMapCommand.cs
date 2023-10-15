using MapRepository.Core.AppSettings;
using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using Microsoft.Extensions.Logging;
using Minio;

namespace MapRepository.Infrastructure.MinIo.Commands;
internal class AddMapCommand : IAddMapCommand
{
    private readonly MinioClient _minio;
    private readonly MinIoConfiguration _settings;
    private readonly ILogger<AddMapCommand> _logger;

    public AddMapCommand(
        MinIoConfiguration settings, ILogger<AddMapCommand> logger)
    {
        _settings = settings;
        _minio = new MinioFactory(_settings).CreateMinioClient();
        _logger = logger;
    }

    public async Task<ResultModel> AddMap(string mapname, Stream mapstream, string bucket)
    {
        var mapres = new ResultModel();
        try
        {
            var args = new PutObjectArgs()
            .WithBucket(bucket)
            .WithObject(mapname)
            .WithStreamData(mapstream)
            .WithObjectSize(mapstream.Length)
            .WithContentType("application/octet-stream");
            _ = await _minio.PutObjectAsync(args).ConfigureAwait(false);
            _logger.LogInformation($"Uploaded object {mapname} to bucket {bucket}");
            mapres.Success = true;
            mapres.ErrorMessage = $"Uploaded object {mapname} to bucket {bucket}";
        }
        catch (Exception e)
        {
            var msg = $"[Bucket]  Exception: {e}";
            _logger.LogError(msg);
            mapres.ErrorMessage = msg;
            mapres.Success = false;
        }
        return mapres;
    }
}