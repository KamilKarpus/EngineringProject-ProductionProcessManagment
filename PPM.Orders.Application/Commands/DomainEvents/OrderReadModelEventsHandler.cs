using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Domain.DomainEvents;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class OrderReadModelEventsHandler : IDomainEventHandler<OrderCreatedDomainEvent>
    {
        private readonly IMongoRepository<OrderReadModel> _repository;
        public OrderReadModelEventsHandler(IMongoRepository<OrderReadModel>  repository)
        {
            _repository = repository;
        }
        public async Task Handle(OrderCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.OrderId);
            if(result == null)
            {
                await _repository.Add(new OrderReadModel()
                {
                    Id = @event.Id,
                    DeliveryDate = @event.DeliveryDate,
                    OrderedDate = @event.OrderedDate,
                    CompanyName = @event.CompanyName,
                    FlowId = @event.FlowId,
                    FlowName = @event.FlowName,
                    StatusId = @event.StatusId,
                    StatusName = @event.StatusName
                });
            }
        }
    }
}
