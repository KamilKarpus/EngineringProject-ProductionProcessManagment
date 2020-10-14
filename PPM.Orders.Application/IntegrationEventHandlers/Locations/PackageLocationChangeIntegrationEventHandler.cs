using MediatR;
using PPM.Orders.Domain;
using PPM.Orders.Domain.Repositories;
using PPM.Orders.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Orders.Application.IntegrationEventHandlers.Locations
{
    public class PackageLocationChangeIntegrationEventHandler : INotificationHandler<PackageLocationChangeIntegrationEvent>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IGetFlowProgress _getFlowProgress;
        public PackageLocationChangeIntegrationEventHandler(IOrderRepository orderRepository,
            IGetFlowProgress getFlowProgress)
        {
            _orderRepository = orderRepository;
            _getFlowProgress = getFlowProgress;
        }
        public async Task Handle(PackageLocationChangeIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetbyId(notification.OrderId);
            if (order != null)
            {
                order.MovePackage(notification.LocationId, notification.PackagedId, _getFlowProgress);
                await _orderRepository.Update(order);
            }
        }
    }
}
