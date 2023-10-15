using MapRepository.Core.Interfaces.Commands;
using MapRepository.Core.Interfaces.Queries;
using MapRepository.Core.Models;
//using Microsoft.Extensions.Logging;
using Minio;
using System.Reactive.Linq;

namespace MapRepository.Infrastructure.MinIo.Commands
{
    internal class DeleteMapsCommand : IDeleteMapsCommand
    {
        private readonly MinioClient _minio;
        private readonly MinIoConfiguration _settings;
        //private readonly ILogger<DeleteMapsCommand> _logger;
        private readonly IGetAllMapsQuery _getAllMapsQuery;
        private readonly IDeleteMapCommand _deleteMapCommand;   
        public DeleteMapsCommand(MinIoConfiguration settings,IGetAllMapsQuery getAllMapsQuery, IDeleteMapCommand deleteMapCommand)//, Logger<DeleteMapsCommand> logger)
        {
            _settings = settings;
            _minio = new MinioFactory(_settings).CreateMinioClient();
            _getAllMapsQuery = getAllMapsQuery; 
            _deleteMapCommand = deleteMapCommand;
            //_logger = logger;
        }
        public async Task<bool> DeleteMaps(string bucketName, List<string> maps = null)
        {
            List<Tuple<string, string>> objectsVersionsList = null;
            try
            { 
                var currentMaps = await _getAllMapsQuery.GetAllMaps(bucketName);
                foreach (var m in currentMaps)
                {
                    _deleteMapCommand.DeleteMap(m, bucketName);
                }

               
                //Console.WriteLine("Running example for API: RemoveObjectsAsync");
                //RemoveObjectsArgs objArgs;
                //if (maps is not null)
                //{
                //    objArgs = new RemoveObjectsArgs()
                //       .WithBucket(bucketName)
                //       .WithObjects(maps);
                //}
                //else
                //{
                //    objArgs = new RemoveObjectsArgs()
                //     .WithBucket(bucketName)
                //     .WithObjectsVersions(objectsVersionsList);
                //}

                //var observable = await _minio.RemoveObjectsAsync(objArgs).ConfigureAwait(false);

                //var items = await observable
                //    .Select(item => item.Key)
                //    //.Do(
                //    //    itemKey => _logger.LogInformation($"item {itemKey}"),
                //    //    ex => _logger.LogError($"OnError: {ex}"),
                //    //    () => _logger.LogInformation($"Removed objects in list from {bucketName}\n"))
                //    .ToList();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[Bucket-Object]  Exception: {e}");
                return false;
            }
        }
    }
}
