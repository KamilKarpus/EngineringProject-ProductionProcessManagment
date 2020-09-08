using Autofac;
using PPM.Administration.Application;
using PPM.Administration.Infrastucture.Configuration;

namespace PPM.Administration.Infrastucture
{
    public static class RegisterExtension
    {
        public static void RegisterAdministationModule(this ContainerBuilder builder)
        {
            builder.RegisterType<AdministrationModule>().As<IAdministrationModule>();
         
        }
    }
}
