using Autofac;
using PPM.Orders.Application.Configuration;
using PPM.Orders.Infrastructure.Configuration;

namespace PPM.Orders.Infrastructure
{
    public static class RegisterExtension
    {
        public static void UseOrdersModule(this ContainerBuilder builder, string connectionString, string dbName)
        {
            builder.RegisterType<OrdersModule>().As<IOrdersModule>();
            OrdersStartup.Intialize(connectionString, dbName);
        }
    }
}
