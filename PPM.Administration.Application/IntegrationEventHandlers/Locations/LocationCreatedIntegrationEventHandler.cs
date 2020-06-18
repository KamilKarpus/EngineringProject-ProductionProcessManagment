using MediatR;
using PPM.Administration.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Administration.Application.IntegrationEventHandlers.Locations
{
    public class LocationCreatedIntegrationEventHandler : INotificationHandler<LocationCreatedIntegrationEvent>
    {
        public Task Handle(LocationCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
