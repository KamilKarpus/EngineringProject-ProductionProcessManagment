using PPM.Domain.ValueObject;
using PPM.Infrastructure.Eventbus;
using PPM.Orders.Domain.Repositories;
using PPM.Orders.IntegrationEvents;
using System.Threading.Tasks;

namespace PPM.Orders.Application.IntegrationEventHandlers.Orders
{
    public class PackageProgressedIntegrationEventHandler : IIntegrationEventHandler<PackageProgressIntegrationEvent>
    {
        private readonly IOrderRepository _repository;
        public PackageProgressedIntegrationEventHandler(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(PackageProgressIntegrationEvent @event)
        {
            var order = await _repository.GetbyId(@event.OrderId);
            if(order != null)
            {
                order.ProgressPackage(@event.PackageId, Percentage.Of(@event.Progress));
                await _repository.Update(order);
            }
        }
    }
}
