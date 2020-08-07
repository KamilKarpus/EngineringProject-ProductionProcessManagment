using System;

namespace PPM.Orders.Application.Commands
{
    public static class Commands
    {
        public static class V1
        {
            public class AddNewOrder
            {
                public string CompanyName { get; set; }
                public DateTime DeliveryDate { get; set; }
                public string Description { get; set; }
            }

            public class AddPackage
            {
                public Guid FlowId { get; set; }
                public decimal Weight { get; set; }
                public decimal Height { get; set; }
                public decimal Width { get; set; }
            }
        }
    }
}
