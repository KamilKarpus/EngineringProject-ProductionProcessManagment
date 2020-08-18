using System;
using System.Collections.Generic;

namespace PPM.Orders.Domain
{
    public class ProductionFlow
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Step> Steps { get; private set; }

        public ProductionFlow(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public ProductionFlow(Guid id, string name, List<Step> steps) : this(id, name)
        {
            Steps = steps;
        }

        public void AddStep(Guid id, Guid locationId, int percentage)
        {
            Steps.Add(new Step(id, locationId, percentage));
        }
    }
}