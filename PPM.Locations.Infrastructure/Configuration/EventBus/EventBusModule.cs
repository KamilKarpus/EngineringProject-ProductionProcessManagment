using Autofac;
using PPM.EventBus;
using PPM.Infrastructure.Eventbus;

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
}
