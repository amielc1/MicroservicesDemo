using MapRepository.Core.Models;
using Minio;

namespace MapRepository.Infrastructure.MinIo
{
    internal class MinioFactory
    {
        private readonly MinIoConfiguration _settings;
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly bool _secure;
        private MinioClient _minio;

        public MinioFactory(MinIoConfiguration settings)
        {
            _settings = settings;
            _accessKey = Environment.GetEnvironmentVariable("MINIO_ACCESS_KEY");
            _secretKey = Environment.GetEnvironmentVariable("MINIO_SECRET_KEY");
            _secure = false;
        }

        public MinioClient CreateMinioClient()
        {
            _minio = new MinioClient()
                .WithEndpoint(_settings.endpoint)
                .WithCredentials(_accessKey, _secretKey)
                .WithSSL(_secure)
                .Build();

            return _minio;
        }

    }
}
