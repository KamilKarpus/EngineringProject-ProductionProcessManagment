using Autofac;
using PPM.Infrastructure.Eventbus;
using PPM.Locations.IntegrationEvents;

namespace PPM.Locations.Infrastructure.Configuration.EventBus
{
    public class EventBusStartup
    {
        public static void Initialize()
        {
            var eventBus = LocationCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
            SubscribeToEventBus<PackageCreatedIntergrationEvent>(eventBus);
            SubscribeToEventBus<ProductionFlowCreatedIntegrationEvent>(eventBus);



        }

        private static void SubscribeToEventBus<T>(IEventsBus eventBus) where T : IntegrationEvent
        {
            eventBus.Subscribe<T>(new IntegrationEventGenericHandler<T>());
        }

    }
}
