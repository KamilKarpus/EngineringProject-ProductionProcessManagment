using System;
using System.Collections.Generic;

namespace PPM.Orders.Application.ReadModels
{
    public class OrderReadModel
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public int OrderNumber { get; set;}
        public int OrderYear { get; set; }
        public List<PackageReadModel> Packages { get; set; } = new List<PackageReadModel>();

        public void AddPackage(Guid packageId,
         decimal weight,
         decimal height,
         decimal width, 
         int number,
         int progress,
         Guid flowId, string flowName)
        {
            Packages.Add(new PackageReadModel()
            {
                Height = height,
                Width = width,
                Number = number,
                Progress = progress,
                PackageId = packageId,
                Weight = weight,
                FlowId = flowId,
                FlowName = flowName
            });
        }
    }
}
