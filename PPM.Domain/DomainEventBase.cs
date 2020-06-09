using System;

namespace PPM.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public DateTime OccurredOn { get; private set; }
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }
    }
}
