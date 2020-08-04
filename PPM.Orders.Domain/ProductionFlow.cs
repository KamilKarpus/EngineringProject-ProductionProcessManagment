using System;

namespace PPM.Orders.Domain
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