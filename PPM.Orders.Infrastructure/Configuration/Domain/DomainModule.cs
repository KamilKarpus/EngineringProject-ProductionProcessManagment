using Autofac;
using PPM.Orders.Domain;
using PPM.Orders.Infrastructure.Domains;

namespace PPM.Orders.Infrastructure.Configuration.Domain
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GetFlowProgress>()
                .As<IGetFlowProgress>();
            base.Load(builder);
        }
    }
}
