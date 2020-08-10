using Autofac;
using PPM.Locations.Domain;
using PPM.Locations.Domain.Transfer;
using PPM.Locations.Infrastructure.Domain;

namespace PPM.Locations.Infrastructure.Configuration.Domain
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UniqueName>().As<IUniqueName>();
            builder.RegisterType<UniqueShortName>().As<IUniqueShortName>();
            builder.RegisterType<GetLocationState>().As<IGetLocationState>();
            builder.RegisterType<LocationExistance>().As<ILocationExistance>();
        }
    }
}
