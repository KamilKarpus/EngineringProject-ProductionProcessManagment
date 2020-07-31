using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Domain;
using PPM.Locations.Infrastructure.Documents.Locations;

namespace PPM.Locations.Infrastructure.Domain
{
    public class UniqueShortName : IUniqueShortName
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        public UniqueShortName(IMongoRepository<LocationDocument> repository)
        {
            _repository = repository;
        }
        public bool IsUnique(string shortName)
        {
            var result = _repository.ExistsAsync(p => p.ShortName == shortName);
            result.Wait();
            return !result.Result;
        }
    }
}
