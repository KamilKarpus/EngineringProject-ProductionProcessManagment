using Autofac;
using PPM.Printing.Domain;
using PPM.Printing.Infrastructure.Domain;

namespace PPM.Printing.Infrastructure.Configuration.Domain
{
    public class DomainModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PackageExistance>()
                .As<IPackageExistance>();
            builder.RegisterType<PrintingRequestExistance>()
                .As<IPrintingRequestExistance>();
        }
    }
}
