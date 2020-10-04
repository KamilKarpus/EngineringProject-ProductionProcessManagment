using PPM.Application.Events;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.Domain.Transfer.Events;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.DomainEvents
{
    public class TransferDomainEventHandler : IDomainEventHandler<TransferFinishedDomainEvent>
    {
        private readonly ILocationsRepository _locationsRepository;
        public TransferDomainEventHandler(ILocationsRepository locationsRepository)
        {
            _locationsRepository = locationsRepository;
        }

        public async Task Handle(TransferFinishedDomainEvent @event)
        {
            var locationFrom = await _locationsRepository.GetLocationById(@event.FromLocationId);
            var locationTo = await _locationsRepository.GetLocationById(@event.ToLocationId);

            var packageToMove = locationFrom.Packages.FirstOrDefault(p => p.Id == @event.PackageId);
            locationFrom.DeletePackage(@event.PackageId);
            locationTo.AddPackage(packageToMove.Id, packageToMove.Weight.Value,
                packageToMove.Height.Value, packageToMove.Width.Value, packageToMove.Progress.Value, packageToMove.OrderId,
                packageToMove.Length);

            await _locationsRepository.Update(locationFrom);
            await _locationsRepository.Update(locationTo);
        }
    }
}
