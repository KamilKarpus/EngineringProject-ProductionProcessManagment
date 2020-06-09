using MongoDB.Driver;
using System;
using System.Linq.Expressions;

namespace PPM.MongoDBClient
{
    public interface IMongoStore
    {
        IFindFluent<T, T> Query<T>(Expression<Func<T, bool>> predicate);
    }
}