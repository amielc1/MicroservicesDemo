using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using Microsoft.Extensions.Logging;
using Minio;

namespace MapRepository.Infrastructure.MinIo.Commands;

internal class CopyMapCommand : ICopyMapCommand
{
    private readonly MinioClient _minio;
    private readonly MinIoConfiguration _settings;
    private readonly ILogger<CopyMapCommand> _logger;

    public CopyMapCommand(MinIoConfiguration settings, ILogger<CopyMapCommand> logger)
    {
        _settings = settings;
        _minio = new MinioFactory(_settings).CreateMinioClient();
        _logger = logger;
    }

    public async Task<ResultModel> CopyMap(string mapname, string fromBucket ,string toBucket)
    {
        var mapres = new ResultModel();
        try
        {
            Console.WriteLine("Running example for API: CopyObjectAsync");
            var metaData = new Dictionary<string, string>
                (StringComparer.Ordinal) { { "Test-Metadata", "Test  Test" } };
            // Optionally pass copy conditions
            var cpSrcArgs = new CopySourceObjectArgs()
                .WithBucket(fromBucket)
                .WithObject(mapname)
                .WithServerSideEncryption(null) ;
            var args = new CopyObjectArgs()
                .WithBucket(toBucket)
                .WithObject(mapname)
                .WithCopyObjectSource(cpSrcArgs)
                .WithServerSideEncryption(null);
            await _minio.CopyObjectAsync(args).ConfigureAwait(false);
            _logger.LogInformation("Copied object {mapname} from bucket {fromBucket} to bucket {toBucket}", mapname, fromBucket, toBucket);
            mapres.Success = true;
            mapres.ErrorMessage = $"Copy object {mapname} to bucket {toBucket}";
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
