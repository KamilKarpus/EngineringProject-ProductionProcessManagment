using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.ReadModels;
using PPM.Locations.Domain.DomainEvents;
using PPM.Locations.Domain.Transfer.Events;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.DomainEvents
{
    public class PackageReadModelDomainEvent : IDomainEventHandler<TransferFinishedDomainEvent>,
        IDomainEventHandler<PackageAddedDominEvent>
    {
        private IMongoRepository<PackageInfoReadModel> _repository;
        private IMongoRepository<LocationReadModel> _locationRepository;
        public PackageReadModelDomainEvent(IMongoRepository<PackageInfoReadModel> repository,
            IMongoRepository<LocationReadModel> locationRepository)
        {
            _repository = repository;
            _locationRepository = locationRepository;
        }
        public async Task Handle(TransferFinishedDomainEvent @event)
        {

            var location = await _locationRepository.Find(p => p.Id == @event.ToLocationId);
            var package = await _repository.Find(p => p.Id == @event.PackageId);
            if(package != null)
            {
                package.LocationId = location.Id;
                package.LocationName = location.Name;
                await _repository.Update(p => p.Id == @event.PackageId, package);
            }
        }

        public async Task Handle(PackageAddedDominEvent @event)
        {
            var location = await _locationRepository.Find(p => p.Id == @event.LocationId);
            var package = await _repository.Find(p => p.Id == @event.PackageId);
            if(package == null)
            {
                await _repository.Add(new PackageInfoReadModel()
                {
                    Id = @event.PackageId,
                    LocationId = location.Id,
                    LocationName = location.Name
                });
            }
        }
    }
}
