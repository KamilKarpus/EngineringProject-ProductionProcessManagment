using PPM.Infrastructure.Eventbus;
using System;
using System.Collections.Generic;

namespace PPM.Locations.IntegrationEvents
{
    public class ProductionFlowCreatedIntegrationEvent : IntegrationEvent
    {
        public ProductionFlowCreatedIntegrationEvent(Guid id, DateTime occuredOn,
            Guid flowId, string name, List<Step> steps) : base(id, occuredOn)
        {
            FlowId = flowId;
            Name = name;
            Steps = steps;
        }

        public Guid FlowId { get; private set; }
        public string Name { get; private set; }
        public List<Step> Steps { get; private set; }
    }

    public class Step
    {
        public Guid StepId { get; set; }
        public Guid LocationId { get; set; }
        public int Percentage { get; set; }
        public string StepName { get; set; }
        public int MaxDaysRequiredToFinish { get; set; }
        public int Number { get; set; }
    }
}
