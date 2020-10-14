using PPM.Application.Events;
using PPM.Infrastructure.Eventbus;
using PPM.Locations.Domain.DomainEvents;
using PPM.Locations.IntegrationEvents;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Locations.DomainEvents
{
    public class LocationEventBusHandler : IDomainEventHandler<PackageAddedDominEvent>,
        IDomainEventHandler<LocationPackageProgressedDomainEvent>
    {
        private readonly IEventsBus _eventsBus;
        public LocationEventBusHandler(IEventsBus bus)
        {
            _eventsBus = bus;
        }
        public Task Handle(PackageAddedDominEvent @event)
        {
            _eventsBus.Publish(new PackageLocationChangeIntegrationEvent(@event.Id, @event.OccurredOn,
                @event.PackageId, @event.OrderId, @event.LocationId));
            return Task.CompletedTask;
        }

        public Task Handle(LocationPackageProgressedDomainEvent @event)
        {
            _eventsBus.Publish(new PackageProgressIntegrationEvent(@event.Id, @event.OccurredOn,
                @event.OrderId, @event.PackageId, @event.Progress));
            return Task.CompletedTask;
        }
    }
}
