using PPM.Infrastructure.Eventbus;
using System;

namespace PPM.Administration.IntegrationEvents
{
    public class ProductionFlowCreatedIntegrationEvent : IntegrationEvent
    {
        public ProductionFlowCreatedIntegrationEvent(Guid id, DateTime occuredOn, 
            Guid flowId, string name) : base(id, occuredOn)
        {
            FlowId = flowId;
            Name = name;
        }

        public Guid FlowId { get; private set; }
        public string Name { get; private set; }
    }
}
