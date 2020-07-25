using Autofac;
using PPM.UserAccess.Domain.Users;
using PPM.UserAccess.Infrastructure.Domain;

namespace PPM.UserAccess.Infrastructure.Configuration.Domain
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserLoginAvailability>()
                .As<IUserLoginAvailability>();
        }
    }
}
