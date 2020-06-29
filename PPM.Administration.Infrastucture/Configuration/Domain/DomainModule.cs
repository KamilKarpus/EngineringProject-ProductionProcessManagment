using Autofac;
using PPM.Administration.Domain.Flows;
using PPM.Administration.Infrastucture.Domain;

namespace PPM.Administration.Infrastucture.Configuration.Domain
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocationExistence>()
                .As<ILocationExistence>();

            builder.RegisterType<FirstLocationSupportPrinting>()
                .As<IFirstLocationSupportPrinting>();
        }
    }
}
