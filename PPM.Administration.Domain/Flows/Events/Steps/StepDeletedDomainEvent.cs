using PPM.Domain;
using System;

namespace PPM.Administration.Domain.Flows.Events.Steps
{
    public class StepDeletedDomainEvent : DomainEventBase
    {
        public Guid FlowId { get; set; }
        public StepInfo[] Steps { get; set; }
        public StepDeletedDomainEvent()
        {

        }
    }
}
