using PPM.Administration.Domain.Flows.Events;
using PPM.Administration.IntegrationEvents;
using PPM.Application.Events;
using PPM.Infrastructure.Eventbus;
using System;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.Flows.DomainEvents
{
    public class ProductionFlowServiceBusHandler : IDomainEventHandler<ProductionFlowStatusChangedDomainEvent>
    {
        private IEventsBus _eventBus;
        public ProductionFlowServiceBusHandler(IEventsBus bus)
        {
            _eventBus = bus;
        }

        public Task Handle(ProductionFlowStatusChangedDomainEvent @event)
        {
            var eventToPublish = new ProductionFlowCreatedIntegrationEvent(@event.Id,
                @event.OccurredOn, @event.FlowId, @event.FlowName);
            _eventBus.Publish(eventToPublish);
            return Task.CompletedTask;
        }
    }
}
