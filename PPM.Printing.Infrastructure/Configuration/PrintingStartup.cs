using Autofac;
using PPM.Application;
using PPM.Printing.Infrastructure.Configuration.Blob;
using PPM.Printing.Infrastructure.Configuration.Domain;
using PPM.Printing.Infrastructure.Configuration.EventBus;
using PPM.Printing.Infrastructure.Configuration.Hub;
using PPM.Printing.Infrastructure.Configuration.InternalClient;
using PPM.Printing.Infrastructure.Configuration.Medation;
using PPM.Printing.Infrastructure.Configuration.Processing;
using PPM.Printing.Infrastructure.Configuration.Qr;
using PPM.Printing.Infrastructure.Configuration.Quartz;

namespace PPM.Printing.Infrastructure.Configuration
{
    public static class PrintingStartup
    {
        public static void Initialize(string connectionString, string dbName,
            string connectionStringBlob, string blobContainerName, IHubClient client)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            containerBuilder.RegisterModule(new EventBusModule());
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new BlobModule(connectionStringBlob, blobContainerName));
            containerBuilder.RegisterModule(new QuartzModule());
            containerBuilder.RegisterModule(new QrModule());
            containerBuilder.RegisterModule(new HubModule(client));
            containerBuilder.RegisterModule(new InternalClientModule());
            var container = containerBuilder.Build();
            PrintingCompositionRoot.SetContainer(container);
            EventBusStartup.Initialize();
            QuartzModuleStartup.Initialize();
            InternalClientStartup.Initialize();
        }
    }
}
