using System;

namespace PPM.Locations.Infrastructure.Documents.Progress
{
    public class PackageProgressDocument
    {
        public Guid Id { get;  set; }
        public Guid PackageId { get;  set; }
        public Guid LocationId { get;  set; }
        public Guid FlowId { get;  set; }
        public int CurrentStepNumber { get;  set; }
        public bool IsValid { get;  set; }
        public int Percentage { get; set; }
    }
}
