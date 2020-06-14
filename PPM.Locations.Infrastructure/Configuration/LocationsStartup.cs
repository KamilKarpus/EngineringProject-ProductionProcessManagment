using Autofac;
using PPM.Locations.Infrastructure.Configuration.DataAcesss;
using PPM.Locations.Infrastructure.Configuration.Mediation;

namespace PPM.Locations.Infrastructure.Configuration
{
    class LocationsStartup
    {
        public static void Intialize(string connectionString, string dbName)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            var container = containerBuilder.Build();
            LocationCompositionRoot.SetContainer(container);
        }
    }
}
