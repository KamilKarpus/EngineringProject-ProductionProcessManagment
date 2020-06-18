using Autofac;
using PPM.Administration.IntegrationEvents;
using PPM.Infrastructure.Eventbus;

namespace PPM.Administration.Infrastucture.Configuration.EventBus
{
    public class EventBusStartup
    {
        public static void Initialize()
        {
            var eventBus = AdministrationCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
            SubscribeToEventBus<LocationCreatedIntegrationEvent>(eventBus);
    
        }

        private static void SubscribeToEventBus<T>(IEventsBus eventBus) where T : IntegrationEvent
        {
            eventBus.Subscribe<T>(new IntegrationEventGenericHandler<T>());
        }

    }
}
