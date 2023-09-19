//using MapRepository.Core.Interfaces;
//using Minio;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MapRepository.Infrastructure.Services
//{
//    internal class MinioMapRepository : IMapRepository
//    {

//        string endpoint = "minio:9000";//todo extract into appsettings  
//        string accessKey = Environment.GetEnvironmentVariable("MINIO_ACCESS_KEY");
//        string secretKey = Environment.GetEnvironmentVariable("MINIO_SECRET_KEY");
//        bool secure = false;


//        public async Task InsertMap()
//        {
//            MinioClient minio = new MinioClient()
//                         .WithEndpoint(endpoint)
//                         .WithCredentials(accessKey, secretKey)
//                         .WithSSL(secure)
//                         .Build();

//            // Create an async task for listing buckets.
//            var getListBucketsTask = await minio.ListBucketsAsync().ConfigureAwait(false);

//            // Iterate over the list of buckets.
//            foreach (var bucket in getListBucketsTask.Buckets)
//            {
//                Console.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
//            }

//        }
//    }
//}
