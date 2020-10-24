using PPM.Application;
using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Domain.DomainEvents;
using System.Linq;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class OrderReadModelEventsHandler : IDomainEventHandler<OrderCreatedDomainEvent>,
        IDomainEventHandler<PackageAddedDomainEvent>, IDomainEventHandler<NumberAssignedDomainEvent>,
        IDomainEventHandler<MovePackageDomainEvent>
    {
        private readonly IMongoRepository<OrderReadModel> _repository;
        private readonly IHubClient _hubClient;
        public OrderReadModelEventsHandler(IMongoRepository<OrderReadModel>  repository,
            IHubClient hubClient)
        {
            _repository = repository;
            _hubClient = hubClient;
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
                    @event.Number, @event.Progress,@event.Length, @event.FlowId, @event.FlowName);
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
                await _hubClient.Notify<NumberAssignedDTO>("orderNumbers", new NumberAssignedDTO()
                {
                    OrderId = order.Id,
                    Number = order.OrderNumber,
                    Year = order.OrderYear
                });
            }
        }

        public async Task Handle(MovePackageDomainEvent @event)
        {
            var order = await _repository.Find(p => p.Id == @event.OrderId);
            if (order != null)
            {
                var package = order.Packages.FirstOrDefault(p => p.PackageId == @event.PackageId);
                package.Progress = @event.Progress;
                await _repository.Update(p => p.Id == @event.OrderId,order);
                await _hubClient.Notify<PackageProgresseDTO>(order.Id.ToString(), new PackageProgresseDTO() 
                {
                    PackageId = package.PackageId, 
                    Progress = package.Progress
                });
            }
        }
    }
}
