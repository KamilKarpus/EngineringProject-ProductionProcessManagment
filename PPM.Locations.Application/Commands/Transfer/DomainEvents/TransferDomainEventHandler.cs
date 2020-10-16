using PPM.Application.Events;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Domain.Transfer.Events;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.DomainEvents
{
    public class TransferDomainEventHandler : IDomainEventHandler<TransferFinishedDomainEvent>
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IPackageProgressRepository _packageProgressRepository;
        private readonly IProductionFlowRepository _flowRepository;
        public TransferDomainEventHandler(ILocationsRepository locationsRepository,
            IPackageProgressRepository packageRepository, IProductionFlowRepository flowRepository)
        {
            _locationsRepository = locationsRepository;
            _packageProgressRepository = packageRepository;
            _flowRepository = flowRepository;
        }

        public async Task Handle(TransferFinishedDomainEvent @event)
        {
            var locationFrom = await _locationsRepository.GetLocationById(@event.FromLocationId);
            var locationTo = await _locationsRepository.GetLocationById(@event.ToLocationId);

            var packageToMove = locationFrom.Packages.FirstOrDefault(p => p.Id == @event.PackageId);
            locationFrom.DeletePackage(@event.PackageId);
            locationTo.AddPackage(packageToMove.Id, packageToMove.Weight.Value,
                packageToMove.Height.Value, packageToMove.Width.Value, packageToMove.Progress.Value, packageToMove.OrderId,
                packageToMove.Length, packageToMove.FlowId);

            await _locationsRepository.Update(locationFrom);

            await _locationsRepository.Update(locationTo);


            var progress = await _packageProgressRepository.GetByPackageId(@event.PackageId);
            if (progress != null)
            {
                var flow = await _flowRepository.GetById(progress.FlowId);

                progress.Progress(@event.ToLocationId, flow);

                await _packageProgressRepository.Update(progress);
            }
        }

    }
}
