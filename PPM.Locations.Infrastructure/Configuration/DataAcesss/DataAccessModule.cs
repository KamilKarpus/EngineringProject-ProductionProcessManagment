using Autofac;

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
        }
    }
}
