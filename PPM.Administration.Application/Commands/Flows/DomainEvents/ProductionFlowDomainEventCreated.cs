using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using PPM.Administration.Domain.Flows.Events;
using PPM.Administration.Domain.Flows.Events.Steps;
using PPM.Application;
using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.Flows.DomainEvents
{
    public class ProductionFlowDomainEventCreatedHandler : IDomainEventHandler<ProductionFlowCreatedDomainEvent>,
        IDomainEventHandler<StepPositionChangedDomainEvent>, IDomainEventHandler<ProductionFlowStatusChangedDomainEvent>,
         IDomainEventHandler<StepAddedDomainEvent>, IDomainEventHandler<StepDeletedDomainEvent>
    {
        private readonly IMongoRepository<ProductionFlowShortInfo> _repository;
        private readonly IHubClient _hubClient;
        public ProductionFlowDomainEventCreatedHandler(IMongoRepository<ProductionFlowShortInfo> repository,
            IHubClient client)
        {
            _repository = repository;
            _hubClient = client;
        }
        public async Task Handle(ProductionFlowCreatedDomainEvent @event)
        {
            var readModel = new ProductionFlowShortInfo()
            {
                Id = @event.ProductionId,
                Name = @event.Name,
                IsValid = @event.IsValid
            };
            await _repository.Add(readModel);
            await _hubClient.Notify(readModel);
        }

        public async Task Handle(StepPositionChangedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            if(result != null)
            {
                result.IsValid = @event.IsValid;
                await _repository.Update(p => p.Id == @event.FlowId, result);
            }
        }

        public async Task Handle(ProductionFlowStatusChangedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            if (result != null)
            {
                result.Status = @event.StatusId;
                result.StatusName = @event.StatusName;
                await _repository.Update(p => p.Id == @event.FlowId, result);
                await _hubClient.Notify(result);
            }
        }

        public async Task Handle(StepDeletedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            if (result != null)
            {
                result.IsValid = @event.IsValid;
                await _repository.Update(p => p.Id == @event.FlowId, result);
                await _hubClient.Notify(result);
            }
        }

        public async Task Handle(StepAddedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            if (result != null)
            {
                result.IsValid = @event.IsValid;
                await _repository.Update(p => p.Id == @event.FlowId, result);
                await _hubClient.Notify(result);
            }
        }
    }
}
