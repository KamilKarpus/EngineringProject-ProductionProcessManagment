using Autofac;
using PPM.Infrastructure.Eventbus;
using PPM.Orders.IntegrationEvents;

namespace PPM.Orders.Infrastructure.Configuration.EventBus
{
    public class EventBusStartup
    {
        public static void Initialize()
        {
            var eventBus = OrderCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
            SubscribeToEventBus<ProductionFlowCreatedIntegrationEvent>(eventBus);
            SubscribeToEventBus<PackageLocationChangeIntegrationEvent>(eventBus);


        }

        private static void SubscribeToEventBus<T>(IEventsBus eventBus) where T : IntegrationEvent
        {
            eventBus.Subscribe<T>(new IntegrationEventGenericHandler<T>());
        }

    }
}
