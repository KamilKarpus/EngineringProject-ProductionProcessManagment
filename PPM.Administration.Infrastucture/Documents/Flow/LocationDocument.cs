using System;

namespace PPM.Administration.Infrastucture.Documents.Flow
{
    public class LocationDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool SupportPrinting { get; set; }
    }
}