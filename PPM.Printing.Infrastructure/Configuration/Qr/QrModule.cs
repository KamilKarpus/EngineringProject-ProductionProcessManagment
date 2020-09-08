using Autofac;
using IronBarCode;
using PPM.Printing.Application.Configuration.Services;
using PPM.Printing.Infrastructure.Services;

namespace PPM.Printing.Infrastructure.Configuration.Qr
{
    public class QrModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QrCodeService>()
                .As<IQrCodeService>();

            builder.RegisterType<PrintingService>()
                .As<IPrintingService>();
        }
    }
}
