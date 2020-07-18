using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using PPM.Administration.Infrastucture.Documents.Flow;
using PPM.Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Location>> FindMany(Guid[] ids)
        {
            var filter = Builders<LocationDocument>.Filter.In("_id", ids);
            var result = await _repository.Collection.FindAsync(filter);
            return (await result.ToListAsync()).Select(p=>p.AsEntity()).ToList();
        }
    }
}
