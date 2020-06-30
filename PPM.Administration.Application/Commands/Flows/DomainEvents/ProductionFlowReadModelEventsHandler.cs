using PPM.Administration.Application.ReadModels;
using PPM.Administration.Domain.Flows.Events;
using PPM.Administration.Domain.Flows.Events.Steps;
using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Administration.Application.Commands.Flows.DomainEvents
{
    public class ProductionFlowReadModelEventsHandler : IDomainEventHandler<ProductionFlowCreatedDomainEvent>,
        IDomainEventHandler<StepAddedDomainEvent>, IDomainEventHandler<StepDeletedDomainEvent>,
        IDomainEventHandler<ProductionFlowStatusChangedDomainEvent>
    {
        private readonly IMongoRepository<ProductionFlowReadModel> _repository;
        public ProductionFlowReadModelEventsHandler(IMongoRepository<ProductionFlowReadModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(ProductionFlowCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.ProductionId);
            if(result == null)
            {
               await _repository.Add(new ProductionFlowReadModel()
                {
                    Id = @event.ProductionId,
                    RequiredDaysToFinish = @event.RequiredDaysToFinish,
                    Name = @event.Name,
                    StatusId = @event.StatusId,
                    StatusName = @event.StatusName,
                });
            }
        }
        public async Task Handle(StepAddedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            result.RequiredDaysToFinish = @event.Days;
            result.Steps = @event.Steps.Select(p => new StepsReadModel()
            {
                LocationId = p.LocationId,
                MaxDaysRequiredToFinish = p.MaxDaysRequiredToFinish,
                Number = p.Number,
                Percentage = p.Percentage,
                StepId = p.StepId,
                StepName = p.StepName
            }).ToList();
            await _repository.Update(p=>p.Id == @event.FlowId, result);
        }
        public async Task Handle(StepDeletedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            result.Steps = @event.Steps.Select(p => new StepsReadModel()
            {
                LocationId = p.LocationId,
                MaxDaysRequiredToFinish = p.MaxDaysRequiredToFinish,
                Number = p.Number,
                Percentage = p.Percentage,
                StepId = p.StepId,
                StepName = p.StepName
            }).ToList();
            await _repository.Update(p => p.Id == @event.FlowId, result);
        }

        public async Task Handle(ProductionFlowStatusChangedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.FlowId);
            if(result != null)
            {
                result.StatusId = @event.StatusId;
                result.StatusName = @event.StatusName;
                await _repository.Update(p => p.Id == @event.FlowId, result);
            }
        }
    }
}
