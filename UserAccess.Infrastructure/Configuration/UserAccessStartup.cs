using Autofac;
using PPM.UserAccess.Infrastructure.Configuration.DataAccess;
using PPM.UserAccess.Infrastructure.Configuration.Domain;
using PPM.UserAccess.Infrastructure.Configuration.Mediation;
using PPM.UserAccess.Infrastructure.Configuration.Processing;

namespace PPM.UserAccess.Infrastructure.Configuration
{
    public static class UserAccessStartup
    {
        public static void Initialize(string connectionString, string dbName)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            containerBuilder.RegisterModule(new DomainModule());
            containerBuilder.RegisterModule(new ProcessingModule());
            var container = containerBuilder.Build();
            UserCompositionRoot.SetContainer(container);
        }
    }
}
