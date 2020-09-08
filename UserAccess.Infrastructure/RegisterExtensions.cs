using Autofac;
using PPM.UserAccess.Application;
using PPM.UserAccess.Infrastructure.Configuration;

namespace PPM.UserAccess.Infrastructure
{
    public static class RegisterExtension
    {
        public static void RegisterUserModule(this ContainerBuilder builder)
        {
            builder.RegisterType<UserModule>().As<IUserAccessModule>();
        }
    }
}
