using System;

namespace PPM.Locations.Domain.Flow
{
    public class ProductionFlow
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public ProductionFlow(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
