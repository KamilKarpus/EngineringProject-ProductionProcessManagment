using Autofac;
using Autofac.Core;
using PPM.Locations.Application.Services;
using PPM.Locations.Infrastructure.Configuration.DataAcesss;
using PPM.Locations.Infrastructure.Configuration.Domain;
using PPM.Locations.Infrastructure.Configuration.EventBus;
using PPM.Locations.Infrastructure.Configuration.InternalClient;
using PPM.Locations.Infrastructure.Configuration.Mediation;
using PPM.Locations.Infrastructure.Configuration.Processing;
using PPM.Locations.Infrastructure.Services;

namespace PPM.Locations.Infrastructure.Configuration
{
    public class LocationsStartup
    {
        public static void Initialize(string connectionString, string dbName)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventBusModule());
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new InternalClientModule());

            containerBuilder.RegisterType<RecommendationService>()
                .As<IRecommendationService>();

            var container = containerBuilder.Build();
            LocationCompositionRoot.SetContainer(container);
            EventBusStartup.Initialize();
            InternalClientStartup.Initialize();
        }
    }
}
