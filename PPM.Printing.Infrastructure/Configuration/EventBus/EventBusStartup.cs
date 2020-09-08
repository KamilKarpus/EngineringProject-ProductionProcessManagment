using Autofac;
using PPM.Infrastructure.Eventbus;
using PPM.Printing.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.Printing.Infrastructure.Configuration.EventBus
{
    public class EventBusStartup
    {
        public static void Initialize()
        {
            var eventBus = PrintingCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();
            SubscribeToEventBus<PackageCreatedIntergrationEvent>(eventBus);
        }

        private static void SubscribeToEventBus<T>(IEventsBus eventBus) where T : IntegrationEvent
        {
            eventBus.Subscribe<T>(new IntegrationEventGenericHandler<T>());
        }
    }
}
