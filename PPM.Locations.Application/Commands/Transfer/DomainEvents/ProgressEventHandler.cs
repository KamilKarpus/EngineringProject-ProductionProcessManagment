using PPM.Application.Events;
using PPM.Locations.Domain;
using PPM.Locations.Domain.DomainEvents;
using PPM.Locations.Domain.PackageProgresses.Events;
using PPM.Locations.Domain.Repositories;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.DomainEvents
{
    public class ProgressEventHandler : IDomainEventHandler<PackageAddedDominEvent>, IDomainEventHandler<PackageProgressedDomainEvent>
    {
        private IPackageProgressRepository _repository;
        private ILocationsRepository _locationsRepository;
        private IProductionFlowRepository _flowRepository;
        public ProgressEventHandler(IPackageProgressRepository repository,
          ILocationsRepository locationsRepository, IProductionFlowRepository flowRepository)
        {
            _repository = repository;
            _locationsRepository = locationsRepository;
            _flowRepository = flowRepository;
        }

        public async Task Handle(PackageAddedDominEvent @event)
        {
            var progress = await _repository.GetByPackageId(@event.PackageId);
            if(progress is null)
            {
                var newProgress = PackageProgress.Create(@event.PackageId,
                    @event.LocationId, @event.FlowId);

                var flow = await _flowRepository.GetById(@event.FlowId);

                newProgress.Progress(@event.LocationId, flow);

                var location = await _locationsRepository.GetLocationById(@event.LocationId);
                location.PackageProgress(@event.PackageId, newProgress.Percentage.Value);
                await _locationsRepository.Update(location);

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
