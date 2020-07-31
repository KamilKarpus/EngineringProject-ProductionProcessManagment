using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Domain;
using PPM.Locations.Infrastructure.Documents.Locations;

namespace PPM.Locations.Infrastructure.Domain
{
    public class UniqueName : IUniqueName
    {
        private readonly IMongoRepository<LocationDocument> _repository;
        public UniqueName(IMongoRepository<LocationDocument> repository)
        {
            _repository = repository;
        }
        public bool IsUnique(string name)
        {
            var result = _repository.ExistsAsync(p => p.Name == name);
            result.Wait();
            return !result.Result;
        }
    }
}
