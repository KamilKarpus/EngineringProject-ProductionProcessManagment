using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Infrastructure.Documents.Locations;
using System;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Repositories
{
    public class LocationRepository : ILocationsRepository
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        public LocationRepository(IMongoRepository<LocationDocument> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Location location)
        {
            await _repository.Add(location.ToDocument());
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
