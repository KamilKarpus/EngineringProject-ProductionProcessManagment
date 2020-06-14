using Autofac;
using PPM.Locations.Application;
using PPM.Locations.Infrastructure.Configuration;

namespace PPM.Locations.Infrastructure
{
    public static class RegisterExtension
    {
        public static void UseAdministationModule(this ContainerBuilder builder, string connectionString, string dbName)
        {
            builder.RegisterType<LocationsModule>().As<ILocationModule>();
            LocationsStartup.Intialize(connectionString, dbName);
        }
    }
}
