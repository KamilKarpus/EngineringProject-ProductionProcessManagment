using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.EventDispatcher;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Infrastructure.Documents.Progress;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Repositories
{
    public class PackageProgressRepository : IPackageProgressRepository
    {
        private readonly IMongoRepository<PackageProgressDocument> _repository;
        private readonly IEventDispatcher _dispatcher;
        public PackageProgressRepository(IMongoRepository<PackageProgressDocument> repository,
            IEventDispatcher dispatcher)
        {
            _repository = repository;
            _dispatcher = dispatcher;
        }
        public async Task Add(PackageProgress packageProgress)
        {
            await _repository.Add(packageProgress.ToDocument());
            await _dispatcher.DispatchAsync(packageProgress?.DomainEvents?.ToArray());
        }

        public async Task<PackageProgress> GetByPackageId(Guid packageId)
        {
            return (await _repository.Find(p => p.PackageId == packageId))?.AsEntity();
        }

        public async Task Update(PackageProgress packageProgress)
        {
            await _repository.Update(p=>p.Id == packageProgress.Id, packageProgress.ToDocument());
            await _dispatcher.DispatchAsync(packageProgress?.DomainEvents?.ToArray());
        }
    }
}
