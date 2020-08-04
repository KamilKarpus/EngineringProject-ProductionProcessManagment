using Autofac;
using PPM.Application.Events;
using PPM.Infrastructure.EventDispatcher;
using PPM.Orders.Infrastructure.Configuration;

namespace PPM.Orders.Infrastucture.Configuration.Processing
{
    public class ProcessingModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EventDispatcher>()
                .As<IEventDispatcher>();

            builder.RegisterAssemblyTypes(Assemblies.Application)
                .AsClosedTypesOf(typeof(IDomainEventHandler<>))
                .InstancePerDependency()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
