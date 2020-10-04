using System;

namespace PPM.Orders.Application.ReadModels
{
    public class PackageLocationInfoDTO
    {
        public Guid Id { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }
    }
}
