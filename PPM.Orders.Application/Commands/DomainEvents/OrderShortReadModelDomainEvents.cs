using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Domain.DomainEvents;
using System;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class OrderShortReadModelDomainEvents : IDomainEventHandler<OrderCreatedDomainEvent>,
        IDomainEventHandler<NumberAssignedDomainEvent>
    {
        private readonly IMongoRepository<OrderShortViewModel> _repository;
        public OrderShortReadModelDomainEvents(IMongoRepository<OrderShortViewModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(OrderCreatedDomainEvent @event)
        {
            var model = await _repository.Find(p => p.Id == @event.OrderId);
            if(model == null)
            {
                await _repository.Add(new OrderShortViewModel() 
                { 
                    Id = @event.OrderId,
                    Description = @event.Description,
                    CompanyName = @event.CompanyName,
                    OrderNumber = 0,
                    OrderYear = 0
                });

            }
        }

        public async Task Handle(NumberAssignedDomainEvent @event)
        {
            var model = await _repository.Find(p => p.Id == @event.OrderId);
            if (model != null)
            {
                model.OrderNumber = @event.OrderNumber;
                model.OrderYear = @event.OrderYear;
                await _repository.Update(p => p.Id == @event.OrderId,
                    model);
            }
        }
    }
}
