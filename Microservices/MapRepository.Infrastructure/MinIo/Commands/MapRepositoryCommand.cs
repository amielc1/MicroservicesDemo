using MapRepository.Core;
using Minio;
using CommunityToolkit.HighPerformance;
using Minio.DataModel;



namespace MapRepository.Infrastructure.MinIo.Commands
{
    internal class MapRepositoryCommand : IMapRepositoryCommand
    {
        string accessKey = Environment.GetEnvironmentVariable("MINIO_ACCESS_KEY");
        string secretKey = Environment.GetEnvironmentVariable("MINIO_SECRET_KEY");
        bool secure = false;
        MinioClient minio;

        private readonly MinIoConfiguration _settings;

        public MapRepositoryCommand(MinIoConfiguration settings)
        {
            _settings = settings;
            minio = new MinioClient()
                        .WithEndpoint(_settings.endpoint)
                         .WithCredentials(accessKey, secretKey)
                         .WithSSL(secure)
                         .Build();

        }

        public async Task AddMap(string mapname)
        {
            try
            { 
               ReadOnlyMemory<byte> bs = await File.ReadAllBytesAsync(mapname).ConfigureAwait(false);
                Console.WriteLine("Running example for API: PutObjectAsync");
                using var filestream = bs.AsStream();

                var fileInfo = new FileInfo(mapname);
                var metaData = new Dictionary<string, string>
                    (StringComparer.Ordinal) { { "Test-Metadata", "Test  Test" } };
                var args = new PutObjectArgs()
                    .WithBucket(_settings.bucketName)
                    .WithObject(mapname)
                    .WithStreamData(filestream)  
                    .WithObjectSize(filestream.Length)
                    .WithContentType("application/octet-stream")
                    .WithHeaders(metaData);
                _ = await minio.PutObjectAsync(args).ConfigureAwait(false);

                Console.WriteLine($"Uploaded object {mapname} to bucket {_settings.bucketName}");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
        }

        public async Task DeleteMap(string mapname)
        {
            try
            {
                var args = new RemoveObjectArgs()
                    .WithBucket(_settings.bucketName)
                    .WithObject(mapname);

                Console.WriteLine("Running example for API: RemoveObjectAsync");
                await minio.RemoveObjectAsync(args).ConfigureAwait(false);
                Console.WriteLine($"Removed object {mapname} from bucket {_settings.bucketName}  successfully");
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket-Object]  Exception: {e}");
            }
        }
    }
}
