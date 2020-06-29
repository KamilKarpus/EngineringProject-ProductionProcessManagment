using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using System;

namespace PPM.Administration.Infrastucture.Domain
{
    public class LocationExistence : ILocationExistence
    {
        private readonly ILocationRepository _repository;
        public LocationExistence(ILocationRepository repository)
        {
            _repository = repository;
        }
        public bool IsExists(Guid locationId)
        {
            var result = _repository.ExistsAsync(locationId).GetAwaiter().GetResult();
            return result;
        }
    }
}
