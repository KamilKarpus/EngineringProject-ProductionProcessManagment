using MongoDB.Driver;

namespace PPM.Infrastructure.DataAccess
{
    public interface IMongoConnection
    {
        IMongoCollection<T> GetCollection<T>(string collectionName);
  
    }
}
