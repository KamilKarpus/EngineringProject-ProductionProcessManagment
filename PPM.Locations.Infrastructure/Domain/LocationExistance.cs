using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Domain.Transfer;
using PPM.Locations.Infrastructure.Documents.Locations;
using System;

namespace PPM.Locations.Infrastructure.Domain
{
    public class LocationExistance : ILocationExistance
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        public LocationExistance(IMongoRepository<LocationDocument> repository)
        {
            _repository = repository;
        }
        public bool Exists(Guid locationId)
        {
            var result = _repository.ExistsAsync(p => p.Id == locationId);
            result.Wait();
            return result.Result;
        }
    }
}
