using Autofac;
using PPM.Orders.Application.Configuration;
using PPM.Orders.Infrastructure.Configuration;

namespace PPM.Orders.Infrastructure
{
    public static class RegisterExtension
    {
        public static void RegisterOrdersModule(this ContainerBuilder builder)
        {
            builder.RegisterType<OrdersModule>().As<IOrdersModule>();
        }
    }
}
