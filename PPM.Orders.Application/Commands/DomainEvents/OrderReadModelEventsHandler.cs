﻿using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Domain.DomainEvents;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class OrderReadModelEventsHandler : IDomainEventHandler<OrderCreatedDomainEvent>,
        IDomainEventHandler<PackageAddedDomainEvent>, IDomainEventHandler<NumberAssignedDomainEvent>
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
                    Id = @event.OrderId,
                    DeliveryDate = @event.DeliveryDate,
                    OrderedDate = @event.OrderedDate,
                    CompanyName = @event.CompanyName,
                    StatusId = @event.StatusId,
                    StatusName = @event.StatusName,
                    Description = @event.Description
                });
            }
        }

        public async Task Handle(PackageAddedDomainEvent @event)
        {
            var order = await _repository.Find(p => p.Id == @event.OrderId);
            if(order != null)
            {
                order.StatusId = @event.StatusId;
                order.StatusName = @event.StatusName;
                order.AddPackage(@event.PackageId, @event.Weight, @event.Height, @event.Width,
                    @event.Number, @event.Progress, @event.FlowId, @event.FlowName);
                await _repository.Update(p => p.Id == @event.OrderId, order);
            }
        }

        public async Task Handle(NumberAssignedDomainEvent @event)
        {
            var order = await _repository.Find(p => p.Id == @event.OrderId);
            if (order != null)
            {
                order.OrderNumber = @event.OrderNumber;
                order.OrderYear = @event.OrderYear;
                await _repository.Update(p => p.Id == @event.OrderId, order);
            }
        }
    }
}