using Autofac;
using PPM.Application.Events;
using PPM.Domain;
using System.Collections;
using System.Collections.Generic;
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
            foreach (var @event in events)
            {
                foreach (dynamic handler in GetHandlers(@event))
                {
                   await handler.Handle((dynamic)@event);
                }

            }


        }
        private IEnumerable GetHandlers(IDomainEvent eventToDispatch)
        {
            return (IEnumerable)_scope.Resolve(
                typeof(IEnumerable<>).MakeGenericType(
                    typeof(IDomainEventHandler<>).MakeGenericType(eventToDispatch.GetType())));
        }
    }
}
