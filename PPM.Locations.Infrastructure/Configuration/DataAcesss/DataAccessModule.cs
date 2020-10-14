using Autofac;
using PPM.Infrastructure.DataAccess;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Application.Queries;
using PPM.Locations.Application.ReadModels;
using PPM.Locations.Infrastructure.Documents.Flow;
using PPM.Locations.Infrastructure.Documents.Locations;
using PPM.Locations.Infrastructure.Documents.Progress;
using PPM.Locations.Infrastructure.Documents.Transfer;

namespace PPM.Locations.Infrastructure.Configuration.DataAcesss
{
    public class DataAccessModule : Autofac.Module
    {
        public string _connectionString;
        public string _dbName;
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

            builder.RegisterType<MongoRepository<LocationDocument>>()
                .As<IMongoRepository<LocationDocument>>()
                .WithParameter("collectionName", "ppm_locations");

            builder.RegisterType<MongoRepository<LocationShortInfo>>()
             .As<IMongoRepository<LocationShortInfo>>()
             .WithParameter("collectionName", "ppm_locations_shortInfo");


            builder.RegisterType<MongoRepository<ProductionFlowDocument>>()
             .As<IMongoRepository<ProductionFlowDocument>>()
             .WithParameter("collectionName", "ppm_locations_flows");


            builder.RegisterType<MongoRepository<TransferRequestDocument>>()
             .As<IMongoRepository<TransferRequestDocument>>()
             .WithParameter("collectionName", "ppm_locations_transfers");

            builder.RegisterType<MongoRepository<LocationReadModel>>()
            .As<IMongoRepository<LocationReadModel>>()
            .WithParameter("collectionName", "ppm_locations_locationReadModel");

            builder.RegisterType<MongoRepository<TransferReadModel>>()
            .As<IMongoRepository<TransferReadModel>>()
            .WithParameter("collectionName", "ppm_locations_transferReadModel");

            builder.RegisterType<MongoRepository<PackageInfoReadModel>>()
                .As<IMongoRepository<PackageInfoReadModel>>()
                .WithParameter("collectionName", "ppm_locations_packageInfo");

            builder.RegisterType<MongoRepository<PackageProgressDocument>>()
                .As<IMongoRepository<PackageProgressDocument>>()
                .WithParameter("collectionName", "ppm_locations_packageProgress");

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());

            base.Load(builder);
        }
    }
}
