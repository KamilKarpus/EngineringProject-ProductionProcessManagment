using System;

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
        public Guid FlowId { get; set; }
        public string FlowName { get; set; }
    }
}
