using PPM.Application.Events;
using PPM.Infrastructure.Eventbus;
using PPM.Locations.Domain.DomainEvents;
using PPM.Locations.IntegrationEvents;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Locations.DomainEvents
{
    public class LocationEventBusHandler : IDomainEventHandler<PackageAddedDominEvent>
    {
        private readonly IEventsBus _eventsBus;
        public LocationEventBusHandler(IEventsBus bus)
        {
            _eventsBus = bus;
        }
        public Task Handle(PackageAddedDominEvent @event)
        {
            _eventsBus.Publish(new PackageLocationChangeIntegrationEvent(@event.Id, @event.OccurredOn,
                @event.PackagedId, @event.OrderId, @event.LocationId));
            return Task.CompletedTask;
        }
    }
}
