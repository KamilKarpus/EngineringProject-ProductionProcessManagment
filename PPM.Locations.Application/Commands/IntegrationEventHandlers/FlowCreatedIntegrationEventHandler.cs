using MediatR;
using PPM.Locations.Domain.Flow;
using PPM.Locations.Domain.Repositories;
using PPM.Locations.IntegrationEvents;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.IntegrationEventHandlers
{
    public class FlowCreatedIntegrationEventHandler : INotificationHandler<ProductionFlowCreatedIntegrationEvent>
    {
        private readonly IProductionFlowRepository _repository;
        public FlowCreatedIntegrationEventHandler(IProductionFlowRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ProductionFlowCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _repository.Add(new ProductionFlow(notification.FlowId, notification.Name,
                notification.Steps.Select(p => new Domain.Flow.Step(p.StepId, p.LocationId, p.Percentage, p.StepName, p.MaxDaysRequiredToFinish, p.Number)).ToList()));
        }
    }
}
