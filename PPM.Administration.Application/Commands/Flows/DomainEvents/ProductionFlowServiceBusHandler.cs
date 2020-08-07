using PPM.Administration.Domain.Flows.Events;
using PPM.Administration.IntegrationEvents;
using PPM.Application.Events;
using PPM.Infrastructure.Eventbus;
using System.Linq;
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
            var steps = @event.Steps.Select(p => new Step()
            {
                LocationId = p.LocationId,
                MaxDaysRequiredToFinish = p.MaxDaysRequiredToFinish,
                Number = p.Number,
                Percentage = p.Percentage,
                StepId = p.StepId,
                StepName = p.StepName
            }).ToList();

            var eventToPublish = new ProductionFlowCreatedIntegrationEvent(@event.Id,
                @event.OccurredOn, @event.FlowId, @event.FlowName, steps);

            _eventBus.Publish(eventToPublish);
            return Task.CompletedTask;
        }
    }
}
