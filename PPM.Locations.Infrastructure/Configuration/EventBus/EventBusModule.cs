using Autofac;
using MediatR;
using PPM.EventBus;
using PPM.Infrastructure.Eventbus;
using System.Threading.Tasks;

namespace PPM.Locations.Infrastructure.Configuration.EventBus
{
    public class EventBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>();
        }
    }
    internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T> where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {
            using (var scope = LocationCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Publish(@event);
            }
        }
    }
}
