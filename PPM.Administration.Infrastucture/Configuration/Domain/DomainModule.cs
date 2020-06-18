using Autofac;
using PPM.Administration.Application.Commands.Flows.AddStep;
using PPM.Administration.Domain.Flows;

namespace PPM.Administration.Infrastucture.Configuration.Domain
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LocationExistence>()
                .As<ILocationExistence>();
        }
    }
}
