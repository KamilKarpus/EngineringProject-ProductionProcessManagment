using PPM.Domain;
using System;

namespace PPM.Administration.Domain.Flows.Events.Steps
{
    public class StepAddedDomainEvent : DomainEventBase
    {
        public Guid FlowId { get; set; }
        public StepInfo[] Steps { get; set; }
        public int Days { get; set; }
        public StepAddedDomainEvent() : base()
        {

        }
    }
}
