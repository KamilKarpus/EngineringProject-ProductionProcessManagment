using PPM.Application.Events;
using PPM.Locations.Domain;
using PPM.Locations.Domain.DomainEvents;
using PPM.Locations.Domain.PackageProgresses.Events;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Domain.Transfer.Events;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.DomainEvents
{
    public class ProgressEventHandler : IDomainEventHandler<TransferFinishedDomainEvent>
    , IDomainEventHandler<PackageAddedDominEvent>, IDomainEventHandler<PackageProgressedDomainEvent>
    {
        private IPackageProgressRepository _repository;
        private IProductionFlowRepository _flowRepository;
        private ILocationsRepository _locationsRepository;
        public ProgressEventHandler(IPackageProgressRepository repository,
            IProductionFlowRepository flowRepository, ILocationsRepository locationsRepository)
        {
            _repository = repository;
            _flowRepository = flowRepository;
            _locationsRepository = locationsRepository;
        }

        public async Task Handle(TransferFinishedDomainEvent @event)
        {
            var progress = await _repository.GetByPackageId(@event.PackageId);
            if(progress != null)
            {
                var flow = await _flowRepository.GetById(progress.FlowId);

                progress.Progress(@event.ToLocationId, flow);

                await _repository.Update(progress);
            }
        }

        public async Task Handle(PackageAddedDominEvent @event)
        {
            var progress = await _repository.GetByPackageId(@event.PackageId);
            if(progress is null)
            {
                var newProgress = PackageProgress.Create(@event.PackageId,
                    @event.LocationId, @event.FlowId);

                await _repository.Add(newProgress);
            }
        }

        public async Task Handle(PackageProgressedDomainEvent @event)
        {
            var location = await _locationsRepository.GetLocationById(@event.LocationId);
            if(location != null)
            {
                location.PackageProgress(@event.PackageId, @event.Percentage);
                await _locationsRepository.Update(location);
            }
        }
    }
}
