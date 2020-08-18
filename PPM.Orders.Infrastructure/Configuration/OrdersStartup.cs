using Autofac;
using PPM.Orders.Infrastructure.Configuration.DataAccess;
using PPM.Orders.Infrastructure.Configuration.Domain;
using PPM.Orders.Infrastructure.Configuration.EventBus;
using PPM.Orders.Infrastructure.Configuration.Quartz;
using PPM.Orders.Infrastucture.Configuration.Mediation;
using PPM.Orders.Infrastucture.Configuration.Processing;

namespace PPM.Orders.Infrastructure.Configuration
{
    public static class OrdersStartup
    {
        public static void Intialize(string connectionString, string dbName)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventBusModule());
            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new DomainModule());
            var container = containerBuilder.Build();
            OrderCompositionRoot.SetContainer(container);
            QuartzModuleStartup.Initialize();
            EventBusStartup.Initialize();
        }
    }
}
