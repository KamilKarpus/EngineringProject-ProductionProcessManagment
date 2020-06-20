using PPM.Domain;
using System;

namespace PPM.Administration.Domain.Flows.Events
{
    public class ProductionFlowCreatedDomainEvent : DomainEventBase
    {
        public Guid ProductionId { get; set; }
        public string Name { get; set; }
        public ProductionFlowCreatedDomainEvent() : base()
        {

        }
    }
}
