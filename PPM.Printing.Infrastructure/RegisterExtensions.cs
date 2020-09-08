using Autofac;
using PPM.Printing.Application;
using PPM.Printing.Infrastructure.Configuration;

namespace PPM.Printing.Infrastructure
{
    public static class RegisterExtensions
    {
        public static void RegisterPrintingModule(this ContainerBuilder builder)
        {
            builder.RegisterType<PrintingModule>().As<IPrintingModule>();
        }
    }
}
