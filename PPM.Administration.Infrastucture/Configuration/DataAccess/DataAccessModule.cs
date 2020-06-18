using Autofac;
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
                .AsImplementedInterfaces();
            builder.RegisterType<MongoRepository<LocationDocument>>()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());

            base.Load(builder);
        }
    }
}
