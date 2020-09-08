using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Printing.Domain;
using PPM.Printing.Domain.Repository;
using PPM.Printing.Infrastructure.Documents;
using System;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Repository
{
    public class PackageRepository : IPackageRepository
    {
        private readonly IMongoRepository<PackageDocument> _repository;
        public PackageRepository(IMongoRepository<PackageDocument> repository)
        {
            _repository = repository;
        }
        public async Task Add(Package package)
        {
             await _repository.Add(package.ToDocument());
        }

        public async Task<Package> GetById(Guid id)
        {
            var result = await _repository.Find(p => p.Id == id);
            return result?.AsEntity();
        }
    }
}
