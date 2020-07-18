using PPM.Domain;
using System;

namespace PPM.Administration.Domain.Flows.Events.Steps
{
    public class StepPositionChangedDomainEvent : DomainEventBase
    {
        public Guid FlowId { get; set; }
        public bool IsValid { get; set; }
        public StepInfo[] Steps {get; set;}
    }
}
