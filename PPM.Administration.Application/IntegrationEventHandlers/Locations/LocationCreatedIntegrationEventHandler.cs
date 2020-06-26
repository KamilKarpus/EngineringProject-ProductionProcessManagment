using MediatR;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Domain.Repositories;
using PPM.Administration.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.IntegrationEventHandlers.Locations
{
    public class LocationCreatedIntegrationEventHandler : INotificationHandler<LocationCreatedIntegrationEvent>
    {
        private readonly ILocationRepository _repository;
        public LocationCreatedIntegrationEventHandler(ILocationRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(LocationCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(notification.LocationId);
            if(result == null)
            {
                await _repository.AddAsync(new Location(notification.LocationId, notification.Name, notification.SupportQR));
            }
        }
    }
}
