using Autofac;
using PPM.Infrastructure.ModuleClient;
using PPM.Orders.Infrastructure.Services;

namespace PPM.Orders.Infrastructure.Configuration.InternalModule
{
    public class InternalClientModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ModuleClient>()
                .AsImplementedInterfaces();

            builder.RegisterType<PrintingService>()
                .AsImplementedInterfaces();
        }
    }
}
