using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using PPM.Administration.Domain.Flows.Events;
using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.Flows.DomainEvents
{
    public class ProductionFlowDomainEventCreatedHandler : IDomainEventHandler<ProductionFlowCreatedDomainEvent>
    {
        private readonly IMongoRepository<ProductionFlowShortInfo> _repository;
        public ProductionFlowDomainEventCreatedHandler(IMongoRepository<ProductionFlowShortInfo> repository)
        {
            _repository = repository;
        }
        public async Task Handle(ProductionFlowCreatedDomainEvent @event)
        {
            await _repository.Add(new ProductionFlowShortInfo()
            {
                Id = @event.ProductionId,
                Name = @event.Name
            });
        }
    }
}
