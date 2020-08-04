using System;
using System.Collections.Generic;

namespace PPM.Orders.Infrastructure.Documents.Orders
{
    public class OrderDocument
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int OrderNumber { get;  set; }
        public int NumberYear { get; set; }
        public int Status { get; set; }
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
        public List<PackageDocument> Packages { get; set; } 
    }
}
