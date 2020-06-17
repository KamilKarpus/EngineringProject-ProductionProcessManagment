using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Infrastructure.Documents.Locations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Repositories
{
    public class LocationRepository : ILocationsRepository
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        private readonly IEventDispatcher _dispatcher;
        public LocationRepository(IMongoRepository<LocationDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }
        public async Task AddAsync(Location location)
        {
            await _repository.Add(location.ToDocument());
            await _dispatcher.DispatchAsync(location.DomainEvents.ToArray());
        }

        public async Task<Location> GetLocationById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);

            return result?.AsEntity();
        }

        public async Task<Location> GetLocationByName(string name)
        {
            var result = await _repository.Find(p => p.Name == name);
            return result?.AsEntity();
        }
    }
}
