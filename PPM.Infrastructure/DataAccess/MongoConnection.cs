using MongoDB.Driver;

namespace PPM.Infrastructure.DataAccess
{
    public class MongoConnection : IMongoConnection
    {
        private readonly IMongoClient _client;
        private readonly string _connectionString;
        private readonly string _dbName;
        private readonly IMongoDatabase _database;
        public MongoConnection(string connectionString, string dbName)
        {
            _connectionString = connectionString;
            _dbName = dbName;
            _client = new MongoClient(_connectionString);
            _database = _client.GetDatabase(_dbName);
        }
        public IMongoCollection<T> GetCollection<T>()
        {
            var collectionName = typeof(T).Name;
            return  _database.GetCollection<T>(collectionName);
        }

    }
}
