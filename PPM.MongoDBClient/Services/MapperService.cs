using PPM.MongoDBClient.Schema;
using System.Collections.Concurrent;

namespace PPM.MongoDBClient.Services
{
    public class MapperService
    {
        private ConcurrentDictionary<string, IMapper> _mappers;
        public MapperService()
        {
            _mappers = new ConcurrentDictionary<string, IMapper>();
        }

        public void Subsribe<Entity>(IMapper mapper)
        {
            _mappers.TryAdd(nameof(Entity).ToLower(), mapper);
        }

        public IMapper GetMapper<Entity>()
        {
           return _mappers[nameof(Entity)];
        }
    }
}
