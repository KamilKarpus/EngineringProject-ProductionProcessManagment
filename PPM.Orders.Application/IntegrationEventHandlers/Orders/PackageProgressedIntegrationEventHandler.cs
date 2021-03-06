using MediatR;
using PPM.Domain.ValueObject;
using PPM.Infrastructure.Eventbus;
using PPM.Orders.Domain.Repositories;
using PPM.Orders.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.IntegrationEventHandlers.Orders
{
    public class PackageProgressedIntegrationEventHandler : INotificationHandler<PackageProgressIntegrationEvent>
    {
        private readonly IOrderRepository _repository;
        public PackageProgressedIntegrationEventHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(PackageProgressIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var order = await _repository.GetbyId(notification.OrderId);
            if (order != null)
            {
                order.ProgressPackage(notification.PackageId, Percentage.Of(notification.Progress));
                await _repository.Update(order);
            }
        }
    }
}
