using Newtonsoft.Json;
using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.InternalCommands;
using PPM.Printing.Application.Commands.Internal;
using PPM.Printing.Domain.Event;
using System.Threading.Tasks;

namespace PPM.Printing.Application.Commands.DomainEvents
{
    public class InternalCommnadsEventHandler : IDomainEventHandler<PrintingRequestCreatedDomainEvent>
    {
        private readonly IMongoRepository<InternalCommand> _repository;
        public InternalCommnadsEventHandler(IMongoRepository<InternalCommand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(PrintingRequestCreatedDomainEvent @event)
        {
            var command = new CreateQrCodeCommand()
            {
                RequestId = @event.RequestId
            };
            await _repository.Add(new InternalCommand(JsonConvert.SerializeObject(command),
            command.GetType().FullName));
        }
    }
}
