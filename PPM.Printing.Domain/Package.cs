using System;

namespace PPM.Printing.Domain
{
    public class Package
    {
        public Guid Id { get; private set; }
        public Guid OrderId { get; private set; }

        public Package(Guid packageId, Guid orderId)
        {
            Id = packageId;
            OrderId = orderId;
        }

    }
}
