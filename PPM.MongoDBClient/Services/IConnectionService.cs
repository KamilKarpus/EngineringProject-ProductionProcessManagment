using MongoDB.Driver;

namespace PPM.MongoDBClient.Services
{
    public interface IConnectionService
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}