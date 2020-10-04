using Autofac;
using PPM.Application.ModuleClient;
using PPM.Infrastructure.ModuleClient;

namespace PPM.Locations.Infrastructure.Configuration.InternalClient
{
    public class InternalClientModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ModuleClient>()
                .As<IModuleClient>();
        }
    }
}
