using MapRepository.Core;
using MapRepository.Core.Interfaces;
using Minio;
using System.Diagnostics;
using System.Reactive.Linq;

namespace MapRepository.Infrastructure.MinIo.Queries
{
    internal class MapRepositoryQuery : IMapRepositoryQuery
    {
        string accessKey = Environment.GetEnvironmentVariable("MINIO_ACCESS_KEY");
        string secretKey = Environment.GetEnvironmentVariable("MINIO_SECRET_KEY");
        bool secure = false;
        MinioClient minio;
        private readonly MinIoConfiguration _settings;

        public MapRepositoryQuery(MinIoConfiguration settings)
        {
            _settings = settings;
            minio = new MinioClient()
                        .WithEndpoint(_settings.endpoint)
                         .WithCredentials(accessKey, secretKey)
                         .WithSSL(secure)
                         .Build();

        }
        public Task GetAllMaps()
        {
            try
            {
                Trace.WriteLine("Running example for API: ListObjectsAsync");
                var listArgs = new ListObjectsArgs()
                    .WithBucket(_settings.bucketName)
                    .WithPrefix(null)
                    .WithRecursive(true);
                var observable = minio.ListObjectsAsync(listArgs);
                var len = observable.Count();
                var subscription = observable.Subscribe(
                    item => Trace.WriteLine($"Object: {item.Key}"),
                    ex => Trace.WriteLine($"OnError: {ex}"),
                    () => Trace.WriteLine($"Listed all objects in bucket {_settings.bucketName}\n"));
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket]  Exception: {e}");
            }
            return Task.CompletedTask;
        }

        public Task GetMap(string mapname)
        {

            try
            {
                Trace.WriteLine("Running example for API: ListObjectsAsync");
                var listArgs = new ListObjectsArgs()
                .WithBucket(_settings.bucketName)
                    .WithPrefix(null)
                    .WithRecursive(true);
                var observable = minio.ListObjectsAsync(listArgs);
                var subscription = observable.Subscribe(
                    item => Trace.WriteLine($"Object: {item.Key}"),
                    ex => Trace.WriteLine($"OnError: {ex}"),
                    () => Trace.WriteLine($"Listed all objects in bucket {_settings.bucketName}\n"));
            }
            catch (Exception e)
            {
                Trace.WriteLine($"[Bucket]  Exception: {e}");
            }
            return Task.CompletedTask;
        }
    }
}
