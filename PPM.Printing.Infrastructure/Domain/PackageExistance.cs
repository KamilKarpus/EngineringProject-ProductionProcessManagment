using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Printing.Domain;
using PPM.Printing.Infrastructure.Documents;
using System;

namespace PPM.Printing.Infrastructure.Domain
{
    public class PackageExistance : IPackageExistance
    {
        private readonly IMongoRepository<PackageDocument> _repository;
        public PackageExistance(IMongoRepository<PackageDocument> repository)
        {
            _repository = repository;
        }
        public bool PackageExists(Guid packageId)
        {
            var existance = _repository.ExistsAsync(p => p.Id == packageId);
            existance.Wait();
            return existance.Result;
        }
    }
}
