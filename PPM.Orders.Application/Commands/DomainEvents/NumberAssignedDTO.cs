using System;

namespace PPM.Orders.Application.Commands.DomainEvents
{
    internal class NumberAssignedDTO
    {
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
    }
}