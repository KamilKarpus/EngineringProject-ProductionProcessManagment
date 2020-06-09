using System;

namespace PPM.Locations.Domain.Flow
{
    public class ProjectFlow
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public ProjectFlow(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
