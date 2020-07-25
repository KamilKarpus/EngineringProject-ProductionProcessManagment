using Autofac;
using PPM.Infrastructure.DataAccess;
using PPM.Infrastructure.DataAccess.Repositories;
using PPM.UserAccess.Infrastructure.Documents;
using PPM.UserAccess.Infrastucture.Configuration;

namespace PPM.UserAccess.Infrastructure.Configuration.DataAccess
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

            builder.RegisterType<MongoRepository<UserDocument>>()
                .As<IMongoRepository<UserDocument>>()
                .WithParameter("collectionName", "ppm_users");

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }
    }
}
