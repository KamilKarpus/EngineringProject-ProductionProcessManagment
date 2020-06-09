using Autofac;
using MediatR;
using PPM.Administration.Infrastucture.Configuration.DataAccess;
using PPM.Administration.Infrastucture.Configuration.Mediation;

namespace PPM.Administration.Infrastucture.Configuration
{
    public static class AdministrationStartup
    {
        public static void Intialize(string connectionString, string dbName)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, dbName));
            containerBuilder.RegisterModule(new MediationModule());
            var container = containerBuilder.Build();
            AdministrationCompositionRoot.SetContainer(container);
        }
    }
}
