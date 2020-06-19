using Autofac;
using PPM.Infrastructure.DataAccess;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.Locations.Infrastructure.Documents.Locations;

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

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());

            base.Load(builder);
        }
    }
}
