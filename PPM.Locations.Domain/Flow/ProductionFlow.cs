using System;
using System.Collections.Generic;
using System.Linq;

namespace PPM.Locations.Domain.Flow
{
    public class ProductionFlow
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Step> Steps { get; private set; }

        public ProductionFlow(Guid id, string name, List<Step> steps)
        {
            Id = id;
            Name = name;
            Steps = steps;
        }

        public void AddSteps(Step step)
        {
            Steps.Add(step);
        }
        public Guid GetFirstLocation() 
        {
            return Steps.FirstOrDefault(p => p.Number == 1).LocationId;
        }

    }
}
