using Autofac;
using PPM.Administration.Application;
using PPM.Administration.Infrastucture.Configuration;

namespace PPM.Administration.Infrastucture
{
    public static class RegisterExtension
    {
        public static void UseAdministationModule(this ContainerBuilder builder, string connectionString, string dbName)
        {
            builder.RegisterType<AdministrationModule>().As<IAdministrationModule>();
            AdministrationStartup.Intialize(connectionString, dbName);
        }
    }
}
