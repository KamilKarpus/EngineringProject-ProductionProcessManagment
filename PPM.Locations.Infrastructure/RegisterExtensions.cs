using Autofac;
using PPM.Locations.Application;
using PPM.Locations.Infrastructure.Configuration;

namespace PPM.Locations.Infrastructure
{
    public static class RegisterExtension
    {
        public static void RegisterLocationsModule(this ContainerBuilder builder)
        {
            builder.RegisterType<LocationsModule>().As<ILocationModule>();
        }
    }
}
