using MediatR;
using PPM.Orders.Domain.Repositories;
using PPM.Orders.IntegrationEvents;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.IntegrationEventHandlers.Flows
{
    public class ProductionFlowCreatedIntegrationEventHandler : INotificationHandler<ProductionFlowCreatedIntegrationEvent>
    {
        private readonly IProductionFlowRepository _repository;
        public ProductionFlowCreatedIntegrationEventHandler(IProductionFlowRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ProductionFlowCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _repository.Add(new Domain.ProductionFlow(notification.FlowId, notification.Name,
                notification.Steps.Select(p=> new Domain.Step(p.StepId, p.LocationId, p.Percentage)).ToList()));
        }
    }
}
