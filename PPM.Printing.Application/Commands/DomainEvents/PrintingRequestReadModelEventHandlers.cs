using Microsoft.AspNetCore.SignalR;
using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Printing.Application.ReadModels;
using PPM.Printing.Domain.Event;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Commands.DomainEvents
{
    public class PrintingRequestReadModelEventHandlers : IDomainEventHandler<PrintingRequestCreatedDomainEvent>,
        IDomainEventHandler<SuccessfulStatusDomainEvent>, IDomainEventHandler<FailStatusDomainEvent>
    {
        private readonly IMongoRepository<PrintingRequestReadModel> _repository;

        public PrintingRequestReadModelEventHandlers(IMongoRepository<PrintingRequestReadModel> repository)
        {
            _repository = repository;
        }
        public async Task Handle(SuccessfulStatusDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.RequestId);
            if(result != null)
            {
                result.ProcessedDate = @event.ProcessedDate;
                result.Status = @event.StatusId;
                result.StatusName = @event.StatusName;
                result.StorageUrl = @event.FileUrl;
                result.OrderId = @event.OrderId;
                await _repository.Update(p => p.Id == @event.RequestId, result);
            }
        }

        public async Task Handle(PrintingRequestCreatedDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.RequestId);
            if(result == null)
            {
                await _repository.Add(new PrintingRequestReadModel()
                {
                    Id = @event.RequestId,
                    RequestedDate = @event.RequestDate,
                    PackageId = @event.PackageId,
                    Status = @event.Status,
                    StatusName = @event.StatusName
                });
            }
        }

        public async Task Handle(FailStatusDomainEvent @event)
        {
            var result = await _repository.Find(p => p.Id == @event.RequestId);
            if (result != null)
            {
                result.Status = @event.StatusId;
                result.StatusName = @event.StatusName;
                await _repository.Update(p => p.Id == @event.RequestId, result);
            }
        }
    }
}
