using Autofac;
using PPM.UserAccess.Application;
using PPM.UserAccess.Infrastructure.Configuration;

namespace PPM.UserAccess.Infrastructure
{
    public static class RegisterExtension
    {
        public static void UseAUserModule(this ContainerBuilder builder, string connectionString, string dbName)
        {
            builder.RegisterType<UserModule>().As<IUserAccessModule>();
            UserAccessStartup.Intialize(connectionString, dbName);
        }
    }
}
