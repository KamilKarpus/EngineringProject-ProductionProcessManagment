using Autofac;
using PPM.Application.Events;
using PPM.Domain;
using System.Threading.Tasks;

namespace PPM.Infrastructure.EventDispatcher
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly ILifetimeScope _scope;
        public EventDispatcher(ILifetimeScope scope)
        {
            _scope = scope;
        }
        public async Task DispatchAsync(params IDomainEvent[] events)
        {
            var handlersTypes = typeof(IDomainEventHandler<>);
            foreach (var @event in events)
            {
                var genericType = handlersTypes.MakeGenericType(@event.GetType());
                dynamic handler = _scope.Resolve(genericType);
                await handler.Handle((dynamic)@event);

            }


        }
    }
}
