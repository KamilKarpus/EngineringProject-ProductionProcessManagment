using PPM.Application.Events;
using PPM.Infrastructure.Eventbus;
using PPM.Orders.Domain.DomainEvents;
using PPM.Orders.IntegrationEvents;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class EventBusDomainEvents : IDomainEventHandler<PackageAddedDomainEvent>
    {
        private readonly IEventsBus _eventBus;
        public EventBusDomainEvents(IEventsBus bus)
        {
            _eventBus = bus;
        }
        public Task Handle(PackageAddedDomainEvent @event)
        {
            _eventBus.Publish(new PackageCreatedIntergrationEvent(
                @event.OrderId, @event.PackageId, @event.Weight, @event.Height,
                @event.Width, @event.Number, @event.Progress, @event.FlowId,
                @event.Id, @event.OccurredOn));
            return Task.CompletedTask;
        }
    }
}
