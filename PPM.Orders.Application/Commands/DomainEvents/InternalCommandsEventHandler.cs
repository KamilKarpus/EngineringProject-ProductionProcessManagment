using PPM.Application.Events;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.InternalCommands;
using PPM.Orders.Application.Commands.Internal.AssignOrderNumber;
using PPM.Orders.Domain.DomainEvents;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class InternalCommandsEventHandler : IDomainEventHandler<OrderCreatedDomainEvent>
    {
        private readonly IMongoRepository<InternalCommand> _repository;
        public InternalCommandsEventHandler(IMongoRepository<InternalCommand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(OrderCreatedDomainEvent @event)
        {
            var command = new AssignOrderNumberCommand()
            {
                OrderId = @event.OrderId
            };
            await _repository.Add(new InternalCommand(JsonConvert.SerializeObject(command),
                command.GetType().FullName));
        }
    }
}
