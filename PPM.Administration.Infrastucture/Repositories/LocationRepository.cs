using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using PPM.Administration.Infrastucture.Documents.Flow;
using PPM.Infrastructure.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace PPM.Administration.Infrastucture.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        public LocationRepository(IMongoRepository<LocationDocument> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(Location location)
        {
            await _repository.Add(location?.ToDocument());
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _repository.ExistsAsync(p => p.Id == id);
        }

        public async Task<Location> GetById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }
    }
}
