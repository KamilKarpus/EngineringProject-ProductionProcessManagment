using MongoDB.Driver;

namespace PPM.MongoDBClient.Services
{
    public class ConnectionService : IConnectionService
    {
        private IMongoDatabase _db;
        private MongoClient _mongoClient;
        public ConnectionService(string connection, string dbName)
        {
            _mongoClient = new MongoClient(connection);
            _db = _mongoClient.GetDatabase(dbName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
    }
}
