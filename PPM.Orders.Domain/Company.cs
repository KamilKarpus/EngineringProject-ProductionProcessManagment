using System;

namespace PPM.Orders.Domain
{
    public class Company
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Company(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
