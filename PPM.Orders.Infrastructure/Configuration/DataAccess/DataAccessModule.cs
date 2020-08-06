using Autofac;
using PPM.Infrastructure.DataAccess;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.InternalCommands;
using PPM.Orders.Application.ReadModels;
using PPM.Orders.Infrastructure.Documents.Flows;
using PPM.Orders.Infrastructure.Documents.Orders;
using PPM.Orders.Infrastucture.Configuration;
using System.IO;

namespace PPM.Orders.Infrastructure.Configuration.DataAccess
{
    public class DataAccessModule : Autofac.Module
    {
        private string _connectionString;
        private string _dbName;
        public DataAccessModule(string connectionString, string dbName)
        {
            _connectionString = connectionString;
            _dbName = dbName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoConnection>()
                   .AsImplementedInterfaces()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("dbName", _dbName);

            builder.RegisterType<MongoRepository<OrderDocument>>()
              .AsImplementedInterfaces()
              .WithParameter("collectionName", "ppm_orders");

            builder.RegisterType<MongoRepository<ProductionFlowDocument>>()
              .AsImplementedInterfaces()
              .WithParameter("collectionName", "ppm_orders_flows");

            builder.RegisterType<MongoRepository<OrderReadModel>>()
              .AsImplementedInterfaces()
              .WithParameter("collectionName", "ppm_orders_readmodels");

            builder.RegisterType<MongoRepository<InternalCommand>>()
                .AsImplementedInterfaces()
                .WithParameter("collectionName", "ppm_orders_internalCommands");

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
            base.Load(builder);
        }
    }
}
