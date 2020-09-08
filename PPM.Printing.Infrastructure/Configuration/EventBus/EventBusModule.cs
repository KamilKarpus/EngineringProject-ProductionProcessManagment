using Autofac;
using MediatR;
using PPM.EventBus;
using PPM.Infrastructure.Eventbus;
using System.Threading.Tasks;

namespace PPM.Printing.Infrastructure.Configuration.EventBus
{
    public class EventBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
    internal class IntegrationEventGenericHandler<T> : IIntegrationEventHandler<T> where T : IntegrationEvent
    {
        public async Task Handle(T @event)
        {
            using (var scope = PrintingCompositionRoot.BeginLifetimeScope())
            {
                var mediator = scope.Resolve<IMediator>();
                await mediator.Publish(@event);
            }
        }
    }
}
