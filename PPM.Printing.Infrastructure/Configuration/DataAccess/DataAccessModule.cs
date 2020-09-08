using Autofac;
using PPM.Infrastructure.DataAccess;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Infrastructure.InternalCommands;
using PPM.Printing.Application.ReadModels;
using PPM.Printing.Infrastructure.Documents;

namespace PPM.Printing.Infrastructure.Configuration
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

            builder.RegisterType<MongoRepository<PrintingRequestDocument>>()
              .AsImplementedInterfaces()
              .WithParameter("collectionName", "ppm_printingRequest");

            builder.RegisterType<MongoRepository<PrintingRequestReadModel>>()
              .AsImplementedInterfaces()
              .WithParameter("collectionName", "ppm_printingRequest_readModel");

            builder.RegisterType<MongoRepository<PackageDocument>>()
               .AsImplementedInterfaces()
               .WithParameter("collectionName", "ppm_packages");

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
