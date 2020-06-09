using System;
using System.Collections.Generic;
using System.Text;

namespace PPM.MongoDBClient.Schema
{
    public class MapperInfo
    { 
        public Type Entity { get; set; }
        public IMapper Mapper { get; set; }
    }
}
