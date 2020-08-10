using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.ReadModels;
using PPM.Locations.Domain.Transfer.Events;
using System.Threading.Tasks;

namespace PPM.Locations.Application.Commands.Transfer.DomainEvents
{
    public class ReadModelDomainEventHandler : IDomainEventHandler<TransferCreatedDomainEvent>,
        IDomainEventHandler<TransferFinishedDomainEvent>
    {
        private readonly IMongoRepository<TransferReadModel> _repository;
        public ReadModelDomainEventHandler(IMongoRepository<TransferReadModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(TransferCreatedDomainEvent @event)
        {
            var readModel = await _repository.Find(p => p.Id == @event.TransferId);
            if(readModel == null)
            {
                await _repository.Add(new TransferReadModel()
                {
                    Id = @event.TransferId,
                    StartDate = @event.StartDate,
                    ToLocationId = @event.ToLocationId,
                    FromLocationId = @event.FromLocationId,
                    Status = @event.Status,
                    PackageId = @event.PackageId,
                    RequestedByUser = @event.RequestedByUser
                });
            }
        }

        public async Task Handle(TransferFinishedDomainEvent @event)
        {
            var readModel = await _repository.Find(p => p.Id == @event.TransferId);
            if(readModel != null)
            {
                readModel.Status = @event.Status;
                readModel.FinishDate = @event.FinishDate;
                await _repository.Update(p => p.Id == @event.TransferId, readModel);
            }
        }
    }
}
