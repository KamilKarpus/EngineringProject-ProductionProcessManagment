using System;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    public class PackageProgresseDTO
    {
        public Guid PackageId { get; set; }
        public int Progress { get; set; }
    }
}