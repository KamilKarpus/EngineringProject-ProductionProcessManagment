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
                public Guid FlowId { get; set; }
            }
        }
    }
}
