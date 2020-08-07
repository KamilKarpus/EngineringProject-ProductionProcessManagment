using MediatR;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.IntegrationEventHandlers
{
    public class PackageCreatedIntergrationEventHandler : INotificationHandler<PackageCreatedIntergrationEvent>
    {
        private readonly ILocationsRepository _repository;
        private readonly IProductionFlowRepository _flowRepository;
        public PackageCreatedIntergrationEventHandler(ILocationsRepository repository,
            IProductionFlowRepository productionFlowRepository)
        {
            _repository = repository;
            _flowRepository = productionFlowRepository;
        }
        public async Task Handle(PackageCreatedIntergrationEvent notification, CancellationToken cancellationToken)
        {
            var flow = await _flowRepository.GetById(notification.FlowId);
            var initialLocationId = flow.GetFirstLocation();
            var location = await _repository.GetLocationById(initialLocationId);
            if (location != null)
            {
                location.AddPackage(notification.PackageId, notification.Height, notification.Weight, notification.Width, notification.Progress);
                await _repository.Update(location);
            }
           
            
        }
    }
}
