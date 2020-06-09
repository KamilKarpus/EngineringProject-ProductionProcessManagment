using System;

namespace PPM.Administration.Domain.Flows
{
    public class Location
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Location(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
