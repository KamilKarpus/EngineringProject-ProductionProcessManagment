using Autofac;
using MediatR;
using PPM.Administration.Infrastucture.Configuration.DataAccess;
using PPM.Administration.Infrastucture.Configuration.Domain;
using PPM.Administration.Infrastucture.Configuration.EventBus;
using PPM.Administration.Infrastucture.Configuration.Mediation;
using PPM.Administration.Infrastucture.Configuration.Notify;
using PPM.Administration.Infrastucture.Configuration.Processing;
using PPM.Application;

namespace PPM.Administration.Infrastucture.Configuration
{
    public static class AdministrationStartup
    {
        public static void Initialize(string connectionString, string dbName, 
            IHubClient client)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            containerBuilder.RegisterModule(new EventBusModule());
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new NotifyModule(client));
            var container = containerBuilder.Build();
            AdministrationCompositionRoot.SetContainer(container);
            EventBusStartup.Initialize();
        }
    }
}
