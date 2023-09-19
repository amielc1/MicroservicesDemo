using MapRepository.Core.Interfaces;
using MapRepository.Infrastructure.MinIo.Commands;

namespace MapRepository.Core.Service
{
    public class MapRepositoryService : IMapRepositoryService
    {
        private readonly IMapRepositoryQuery _mapRepositoryQuery;
        private readonly IMapRepositoryCommand _mapRepositoryCommand;

        public MapRepositoryService(IMapRepositoryQuery mapRepositoryQuery, IMapRepositoryCommand mapRepositoryCommand)
        {
            _mapRepositoryCommand = mapRepositoryCommand;
            _mapRepositoryQuery = mapRepositoryQuery;

        }
        public Task AddMap(string mapname)
        {
            _mapRepositoryCommand.AddMap(mapname);
            return Task.CompletedTask;
        }

        public Task DeleteMap(string mapname)
        {
            _mapRepositoryCommand.DeleteMap(mapname);
            return Task.CompletedTask;
        }

        public Task GetAllMaps()
        {
            _mapRepositoryQuery.GetAllMaps();
            return Task.CompletedTask;
        }

        public Task GetMap(string mapname)
        {
            _mapRepositoryQuery.GetMap(mapname);
            return Task.CompletedTask;
        }
    }
}
