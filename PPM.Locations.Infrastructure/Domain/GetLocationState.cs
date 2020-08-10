using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Domain.Transfer;
using PPM.Locations.Infrastructure.Documents.Locations;
using System;

namespace PPM.Locations.Infrastructure.Domain
{
    public class GetLocationState : IGetLocationState
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        public GetLocationState(IMongoRepository<LocationDocument> repository)
        {
            _repository = repository;
        }
        public LocationState GetState(Guid locationId)
        {
            var result = _repository.Find(p => p.Id == locationId);
            result.Wait();
            var location = result.Result;
            return new LocationState(location.Type, location.Packages.Count);

        }
    }
}
