using System;

namespace PPM.Domain
{
    public class DomainEventBase : IDomainEvent
    {
        public Guid Id { get; protected set; }
        public DateTime OccurredOn { get; private set; }
        public DomainEventBase()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.Now;
        }
    }
}
