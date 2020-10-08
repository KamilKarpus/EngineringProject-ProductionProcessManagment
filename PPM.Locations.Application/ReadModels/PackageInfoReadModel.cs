using System;
namespace PPM.Locations.Application.ReadModels
{
    public class  PackageInfoReadModel
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
        public Guid FlowId { get; set; }
    }
}
