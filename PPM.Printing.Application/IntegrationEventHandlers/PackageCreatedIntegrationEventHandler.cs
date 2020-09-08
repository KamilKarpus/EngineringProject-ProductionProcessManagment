using MediatR;
using PPM.Printing.Domain.Repository;
using PPM.Printing.IntegrationEvents;
using System.Threading;
using System.Threading.Tasks;

namespace PPM.Printing.Application.IntegrationEventHandlers
{
    public class PackageCreatedIntegrationEventHandler : INotificationHandler<PackageCreatedIntergrationEvent>
    {
        private readonly IPackageRepository _repository;
        public PackageCreatedIntegrationEventHandler(IPackageRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(PackageCreatedIntergrationEvent notification, CancellationToken cancellationToken)
        {
            var result = await _repository.GetById(notification.PackageId);
            if(result == null)
            {
                await _repository.Add(new Domain.Package(notification.PackageId, notification.OrderId));
            }
        }
    }
}
