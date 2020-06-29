using Autofac;
using PPM.Administration.Application.Queries.ProductionFlows.GetFlowsList;
using PPM.Administration.Application.ReadModels;
using PPM.Administration.Infrastucture.Documents.Flow;
using PPM.Infrastructure.DataAccess;
using PPM.Infrastructure.DataAccess.Repositories;

namespace PPM.Administration.Infrastucture.Configuration.DataAccess
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

            builder.RegisterType<MongoRepository<ProductionFlowDocument>>()
                .AsImplementedInterfaces()
                .WithParameter("collectionName", "ppm_productionFlow");

            builder.RegisterType<MongoRepository<LocationDocument>>()
                .AsImplementedInterfaces()
                .WithParameter("collectionName", "ppm_locations");


            builder.RegisterType<MongoRepository<ProductionFlowShortInfo>>()
                .AsImplementedInterfaces()
                .WithParameter("collectionName", "ppm_productionFlow_list");

            builder.RegisterType<MongoRepository<ProductionFlowReadModel>>()
              .AsImplementedInterfaces()
              .WithParameter("collectionName", "ppm_productionFlow_readModel");

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());

            base.Load(builder);
        }
    }
}
