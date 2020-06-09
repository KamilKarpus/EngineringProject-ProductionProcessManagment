using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using PPM.MongoDBClient.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PPM.MongoDBClient
{
    public class MongoStore : IMongoStore
    {
        private readonly IConnectionService _connService;
        public MongoStore(MongoSettings settings)
        {
            _connService = new ConnectionService(settings.ConnectionString, settings.DbName);
        }
        public static MongoStore For(Action<MongoSettings> configure)
        {
            var settings = new MongoSettings();
            configure(settings);
            return new MongoStore(settings);
        }

        public IFindFluent<T,T> Query<T>(Expression<Func<T, bool>> predicate)
        { 
            var entityName = nameof(T).ToLower();
            var collection = _connService.GetCollection<T>(entityName);
            var result = collection.Find<T>(predicate);
            return result;
            
        }
    }
}
