using PPM.Application.Events;
using PPM.Infrastructure.Eventbus;
using PPM.Locations.Domain.DomainEvents;
using PPM.Locations.IntegrationEvents;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Locations.DomainEvents
{
    public class EventBusEvents : IDomainEventHandler<LocationCreatedDomainEvent>
    {
        private readonly IEventsBus _bus;
        public EventBusEvents(IEventsBus bus)
        {
            _bus = bus;
        }
        public Task Handle(LocationCreatedDomainEvent @event)
        {
            _bus.Publish(new LocationCreatedIntegrationEvent(@event.Id, @event.OccurredOn,
                @event.LocationId, @event.Name, @event.SupportQR));

            return Task.CompletedTask;
        }
    }
}
