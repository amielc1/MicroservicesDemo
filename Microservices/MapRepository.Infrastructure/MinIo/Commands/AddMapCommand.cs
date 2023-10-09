using CommunityToolkit.HighPerformance;
using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Models;
using Microsoft.Extensions.Logging;
using Minio;
using System.Text;

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

    public async Task<ResultModel> AddMap(string mapname, string pathToMap)
    {
        var mapres = new ResultModel();
        try
        {
            var bytes = Encoding.ASCII.GetBytes(mapname);
            MemoryStream stream = new MemoryStream(bytes);
            //ReadOnlyMemory<byte> bs = await File.ReadAllBytesAsync(pathToMap).ConfigureAwait(false);
            //_logger.LogInformation("Running example for API: PutObjectAsync");
            //using var filestream = bs.AsStream();


            using var filestream = stream;

            var fileInfo = new FileInfo(pathToMap);
            var metaData = new Dictionary<string, string>
                (StringComparer.Ordinal) { { "Test-Metadata", "Test  Test" } };
            var args = new PutObjectArgs()
                .WithBucket(_settings.bucketName)
                .WithObject(mapname)
                .WithStreamData(filestream)
                .WithObjectSize(filestream.Length)
                .WithContentType("application/octet-stream")
                .WithHeaders(metaData);
            _ = await _minio.PutObjectAsync(args).ConfigureAwait(false);

            _logger.LogInformation($"Uploaded object {mapname} to bucket {_settings.bucketName}");
            mapres.Success = true;
            mapres.ErrorMessage = $"Uploaded object {mapname} to bucket {_settings.bucketName}";
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

