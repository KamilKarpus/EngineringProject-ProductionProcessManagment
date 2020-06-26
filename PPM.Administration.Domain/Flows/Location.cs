using System;

namespace PPM.Administration.Domain.Flows
{
    public class Location
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public bool SupportPrinting { get; private set; }
        public Location(Guid id, string name, bool supportPriting)
        {
            Id = id;
            Name = name;
            SupportPrinting = supportPriting;
        }
    }
}
